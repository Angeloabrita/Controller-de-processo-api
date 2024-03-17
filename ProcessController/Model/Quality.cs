namespace ProcessController.Model
{
    public class Quality
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ValQuality { get; set; }

        public required int ProcessId { get; set; }
        public required Process Process { get; set; }

    }
}
