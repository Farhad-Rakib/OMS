using System.ComponentModel.DataAnnotations;

namespace OMS.Shared.DTO
{

    public class WindowDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Maximum 50 Characters Allowed")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Must be Greater Than 0")]
        public int Quantity{ get; set; }
    
        public List<SubElementDTO> SubElements { get; set; } = new List<SubElementDTO>();
    }
}
