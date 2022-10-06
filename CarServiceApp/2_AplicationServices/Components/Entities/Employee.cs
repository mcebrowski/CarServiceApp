using System.Text;

namespace CarServiceApp.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
        public bool IsManager { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartOfEmployment { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"   First name: {FirstName}    Last name: {LastName}");
            sb.AppendLine($"   Department: {Department}");
            if (IsManager)
            {
                sb.AppendLine($"   Manager of this department");
            };
            sb.AppendLine($"   Salary: {Salary}   Age: {DateTime.Now.Year - DateOfBirth.Year}");
            sb.AppendLine($"   Employeed from: {StartOfEmployment.ToString("dd-MM-yyyy")}");

            return sb.ToString();
        }
    }
}
