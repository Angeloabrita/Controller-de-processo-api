namespace ProcessController.Model
{
    public class Availability
    {
        public required int ID { get; set; }
        public DateTime DateTime { get; set; }
        public Process ProcessID { get; set; }
        public required int ValAvailibity { get; set; }

    }
}
