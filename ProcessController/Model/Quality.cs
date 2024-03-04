namespace ProcessController.Model
{
    public class Quality
    {
        public int Id { get; set; }
        public Process ProcessID { get; set; }
        public DateTime DateTime { get; set; }
        public int ValQuality { get; set; }

    }
}
