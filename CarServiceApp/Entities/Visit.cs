namespace CarServiceApp.Entities
{
    public class Visit : EntityBase
    {
        public string? Date { get; set; }
        
        public override string ToString() => $"{Id}. {Date}";
    }
}
