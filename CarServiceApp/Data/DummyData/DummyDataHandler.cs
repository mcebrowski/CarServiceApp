using CarServiceApp.Entities;

namespace CarServiceApp.Data.DummyData
{
    public abstract class DummyDataHandler : IDummyDataHandler
    {
        public abstract void AddEmployees();

        protected IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Anna",
                    LastName = "Nowakowska",
                    Department = Department.CustomerService,
                    Salary = 7500m,
                    DateOfBirth = new DateTime(1991, 05, 25),
                    StartOfEmployment = new DateTime(2012, 08, 01),
                    IsManager = false
                },
                new Employee()
                {
                    FirstName = "Monika",
                    LastName = "Dziuba",
                    Department = Department.CustomerService,
                    Salary = 8900m,
                    DateOfBirth = new DateTime(1985, 07, 30),
                    StartOfEmployment = new DateTime(2008, 03, 20),
                    IsManager = true
                },
                new Employee()
                {
                    FirstName = "Damian",
                    LastName = "Bednarz",
                    Department = Department.SpareParts,
                    Salary = 9300m,
                    DateOfBirth = new DateTime(1982, 11, 12),
                    StartOfEmployment = new DateTime(2007, 09, 01),
                    IsManager = true
                },
                new Employee()
                {
                    FirstName = "Kamil",
                    LastName = "Pawlak",
                    Department = Department.SpareParts,
                    Salary = 7150m,
                    DateOfBirth = new DateTime(1989, 04, 30),
                    StartOfEmployment = new DateTime(2017, 03, 15),
                    IsManager = false
                },
                new Employee()
                {
                    FirstName = "Zbigniew",
                    LastName = "Wolny",
                    Department = Department.BodyAndPaintWorkshop,
                    Salary = 11700m,
                    DateOfBirth = new DateTime(1975, 09, 30),
                    StartOfEmployment = new DateTime(2004, 07, 10),
                    IsManager = true
                },
                new Employee()
                {
                    FirstName = "Tomasz",
                    LastName = "Nowak",
                    Department = Department.BodyAndPaintWorkshop,
                    Salary = 9800m,
                    DateOfBirth = new DateTime(1981, 12, 07),
                    StartOfEmployment = new DateTime(2013, 02, 20),
                    IsManager = false
                },
                new Employee()
                {
                    FirstName = "Adam",
                    LastName = "Teodorczyk",
                    Department = Department.MechanicalWorkshop,
                    Salary = 10600m,
                    DateOfBirth = new DateTime(1980, 09, 01),
                    StartOfEmployment = new DateTime(2009, 05, 20),
                    IsManager = true
                },
                new Employee()
                {
                    FirstName = "Michał",
                    LastName = "Zielonka",
                    Department = Department.MechanicalWorkshop,
                    Salary = 8600m,
                    DateOfBirth = new DateTime(1992, 04, 30),
                    StartOfEmployment = new DateTime(2018, 04, 15),
                    IsManager = false
                }
            };
            return employees;
        }
        public abstract void AddClients();

        protected IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>()
            {
                new Client()
                {
                    FirstName = "Anna",
                    LastName = "Bułka",
                    Department = Department.MechanicalWorkshop,
                },
                new Client()
                {
                    FirstName = "Piotr",
                    LastName = "Skoczek",
                    Department = Department.MechanicalWorkshop,
                },
                new Client()
                {
                    FirstName = "Wojciech",
                    LastName = "Nowacki",
                    Department = Department.SpareParts,
                },
                new Client()
                {
                    FirstName = "Mirosław",
                    LastName = "Jędrak",
                    Department = Department.SpareParts,
                },
                new Client()
                {
                    FirstName = "Iwona",
                    LastName = "Bochen",
                    Department = Department.SpareParts,
                },
                new Client()
                {
                    FirstName = "Maria",
                    LastName = "Kowalska",
                    Department = Department.BodyAndPaintWorkshop,
                },
                new Client()
                {
                    FirstName = "Paweł",
                    LastName = "Nowak",
                    Department = Department.BodyAndPaintWorkshop,
                },
                new Client()
                {
                    FirstName = "Adam",
                    LastName = "Kowalski",
                    Department = Department.BodyAndPaintWorkshop,
                },

            };
            return clients;
        }
    }
}
