namespace ProcessController.Model
{
    public class ProcessControl
    {
        public required int Id { get; set; }
        public required Process ProcessId { get; set; }

        public required int PartsPrecess { get; set; }

        public required int LosPart {  get; set; }

        public int timeStopMin { get; set; }

        public int timeWorkingMax { get; set;}






    }
}
