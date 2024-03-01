namespace ProcessController.Services
{
    public class ManagerIndicators 
        { 
       public string ProcessID { get; set; }
       public DateOnly Date {  get; set; }
       public float Quality { get; set; }
       public float Perfomance { get; set; }
       public float Avaibility { get; set; }
       public float Oee => (float)(Avaibility * Perfomance * Quality);
        
    }
}
