namespace eadProject.Models
{
    public abstract class FullAudinModel : IAuditedModel
     {

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
