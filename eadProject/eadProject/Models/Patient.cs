using eadProject.Models;

namespace eadProject.Models;


    public partial class Patient : FullAudinModel
{
    public int Id { get; set; }
    public string CNIC { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public ICollection<Reports>? reports { get; set; }

}