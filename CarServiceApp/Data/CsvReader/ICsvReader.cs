using CarServiceApp.Data.CsvReader.Models;

namespace CarServiceApp.Data.CsvReader
{
        public interface ICsvReader
    {
        List<Car> ProcessCars(string filePath);

        List<Manufacturer> ProcessManufacturers(string filepath);
    }
}
