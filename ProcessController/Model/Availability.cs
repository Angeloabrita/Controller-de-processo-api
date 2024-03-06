namespace ProcessController.Model
{
    public class Availability
    {
        public required int Id { get; set; }
        public DateTime DateTime { get; set; }
        public required Process ProcessID { get; set; }
        public required int ValAvailibity { get; set; }

    }
}
