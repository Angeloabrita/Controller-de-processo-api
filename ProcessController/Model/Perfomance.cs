namespace ProcessController.Model
{
    public class Perfomance
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Process ProcessID { get; set; }
        public required float PerfomanceVal { get; set; }
    }
}
