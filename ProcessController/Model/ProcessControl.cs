namespace ProcessController.Model
{
    public class ProcessControl
    {
        public required int Id { get; set; }
        public required int GoodPart { get; set; }
        public required int BadPart {  get; set; }
        public required int EstimativePart { get; set; }
        public int TimeWork { get; set; }
        public int TimeStop { get; set; }
        public int TimeAvaibe { get; set;}

        public required int ProcessId { get; set; }
        public required Process Process { get; set; }

    }
}
