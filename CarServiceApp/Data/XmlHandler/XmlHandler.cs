using CarServiceApp.Data.CsvReader;
using System.Xml.Linq;

namespace CarServiceApp.Data.XmlHandler
{
    public class XmlHandler : IXmlHandler
    {
        private readonly ICsvReader _csvReader;

        public XmlHandler(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        public void Run()
        {
            CreateXml();
            QueryXml();
            JoinXml();
        }

        public void CreateXml()
        {
            var carsRecords = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars", carsRecords.Select(x =>
                new XElement("Car",
                new XAttribute("Name", x.Name),
                new XAttribute("Manufacturer", x.Manufacturer),
                new XAttribute("Combined", x.Combined)
                )
            ));

            document.Add(cars);
            document.Save("fuel.xml");

        }

        public void QueryXml()
        {
            var document = XDocument.Load("fuel.xml");
            var names = document.Element("Cars")?.Elements("Car").Where(x => x.Attribute("Manufacturer")?.Value == "BMW").Select(x => x.Attribute("Name")?.Value);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }


        public void JoinXml()
        {
            var carsRecords = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");
            var manufacurersRecords = _csvReader.ProcessManufacturers(@"Resources\Files\manufacturers.csv");

            var groups = manufacurersRecords.GroupJoin(
                carsRecords,
                manufacturer => manufacturer.Name,
                car => car.Manufacturer,
                (m, g) =>
                new
                {
                    Manufacturer = m,
                    Cars = g,
                }
                ).OrderBy(x => x.Manufacturer.Name);

            var document = new XDocument();
            var manufacturers = new XElement("Manufacturers", groups.Select(x =>
                new XElement("Manufacturer",
                    new XAttribute("ManufacturerName", x.Manufacturer.Name),
                    new XAttribute("Country", x.Manufacturer.Country),
                        new XElement("Cars",
                            new XAttribute("CarsCountry", x.Manufacturer.Country),
                            new XAttribute("CombinedSum", x.Cars.Sum(c => c.Combined)),
                                 x.Cars.Select(c =>
                                    new XElement("Car",
                                        new XAttribute("CarModel", c.Name),
                                        new XAttribute("Combined", c.Combined)
                                    )
                                )
                        )
                    )
                ));
            document.Add(manufacturers);
            document.Save("joinxml.xml");
        }
    }
}
