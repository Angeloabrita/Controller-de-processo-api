namespace ProcessController.Model
{
    public class Perfomance
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public required float PerfomanceVal { get; set; }

        public required int ProcessId { get; set; }
        public required Process Process { get; set; }
    }
}
