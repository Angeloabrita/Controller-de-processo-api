namespace ProcessController.Model
{
    public class Oee
    {
        public required int Id { get; set; }
        public required DateTime DateTime { get; set; }
        public required int Value {  get; set; }


        public int ProcessId { get; set; } // This is the foreign key
        public Process Process { get; set; } // Navigation property

    }
}
