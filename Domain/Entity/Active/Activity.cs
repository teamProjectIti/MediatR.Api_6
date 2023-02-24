namespace Domain.Entity.Active
{
    public class Activity
    {

        public Guid Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public DateTime Date { get; set; }
        public string Describation { get; set; } = string.Empty;
        public string Caregory { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Venu { get; set; } = string.Empty;

    }
}
