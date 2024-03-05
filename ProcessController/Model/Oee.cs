namespace ProcessController.Model
{
    public class Oee
    {
        public required int Id { get; set; }
        public required Process ProcessId {  get; set; }
        public required DateTime DateTime { get; set; }
        public required int Value {  get; set; }

    }
}
