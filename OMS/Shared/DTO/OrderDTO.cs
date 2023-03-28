using System.ComponentModel.DataAnnotations;

namespace OMS.Shared.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Max 50 Characters Allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "Max 50 characters Allowed")]
        public string State { get; set; }
        public List<WindowDTO> Windows { get; set; } = new List<WindowDTO>();
    }

}
