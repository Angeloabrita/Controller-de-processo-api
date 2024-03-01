namespace ProcessController.Model
{
    public class Process
    {
        public required int Id { get; set; }
        public DateTime DateTime { get; set; }
        public required string ProcessName { get; set; }
        public string? Story { get; set; }
    }
}
