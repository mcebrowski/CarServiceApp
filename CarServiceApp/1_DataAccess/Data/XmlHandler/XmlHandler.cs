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

        public void CreateXml(string description)
        {
            if (description == "employees")
            {
                var records = _csvReader.ProcessEmployees(@"1_DataAccess\Resources\Files\employees.csv");
                var document = new XDocument();
                var employees = new XElement("Employees", records.Select(x =>
                    new XElement("Employee",
                    new XAttribute("FirstName", x.FirstName),
                    new XAttribute("LastName", x.LastName),
                    new XAttribute("Department", x.Department),
                    new XAttribute("Salary", x.Salary),
                    new XAttribute("DateOfBirth", x.DateOfBirth),
                    new XAttribute("StartOfEmployment", x.StartOfEmployment)
                    )
                ));

                document.Add(employees);
                document.Save("employees.xml");
                Console.WriteLine("\n Dummy employee data has been saved in xml file\n");
            }
            else
            {
                var records = _csvReader.ProcessClients(@"1_DataAccess\Resources\Files\clients.csv");
                var document = new XDocument();
                var clients = new XElement("Clients", records.Select(x =>
                    new XElement("Client",
                    new XAttribute("FirstName", x.FirstName),
                    new XAttribute("LastName", x.LastName),
                    new XAttribute("Department", x.Department)
                    )
                ));

                document.Add(clients);
                document.Save("clients.xml");
                Console.WriteLine("\n Dummy client data has been saved in xml file\n");
            }
        }

        public void QueryXml()
        {
            var document = XDocument.Load("employees.xml");
            var names = document.Element("Employees")?.Elements("Employee").Where(x => x.Attribute("LastName")?.Value == "Nowak").Select(x => x.Attribute("FirstName")?.Value);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public void JoinXml()
        {
            var employeeRecords = _csvReader.ProcessEmployees(@"1_DataAccess\Resources\Files\employees.csv");
            var clientRecords = _csvReader.ProcessClients(@"1_DataAccess\Resources\Files\clients.csv");

            var groups = employeeRecords.GroupJoin(
                clientRecords,
                employee => employee.Department,
                client => client.Department,
                (employee, client) => new
                {
                    employee,
                    client
                }
                ).OrderBy(x => x.employee.Department).DistinctBy(x => x.employee.Department).Where(x => x.employee.IsManager = true);

            var document = new XDocument();
            var departments = new XElement("Departments", groups.Select(x =>
                new XElement("Department",
                    new XAttribute("DepartmentName", x.employee.Department),
                    new XAttribute("DepartmentHead", x.employee.FirstName + " " + x.employee.LastName),
                    new XElement("Clients", x.client.Select(c =>
                        new XElement("Client",
                            new XAttribute("FirstName", c.FirstName),
                            new XAttribute("LastName", c.LastName)
                        )
                    ))
                )
            ));

            document.Add(departments);
            document.Save("joinxml.xml");
            Console.WriteLine("\n Query has been saved in xml file\n");
        }
    }
}
