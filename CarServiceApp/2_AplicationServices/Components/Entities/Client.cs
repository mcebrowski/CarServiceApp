using System.Text;

namespace CarServiceApp.Entities
{
    public class Client : EntityBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"   First name: {FirstName}    Last name: {LastName}");
            sb.AppendLine($"   Department: {Department}");

            return sb.ToString();
        }
    }
}
