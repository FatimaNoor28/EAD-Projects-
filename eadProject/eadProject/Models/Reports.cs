namespace eadProject.Models
{
    public class Reports
    {
        public int Id { get; set; }
        public string link { get; set; }
        public int PatientId { get; set; }

        public Patient patient { get; set; }

    }
}
