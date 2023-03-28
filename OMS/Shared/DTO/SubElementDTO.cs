using System.ComponentModel.DataAnnotations;

namespace OMS.Shared.DTO
{
    public class SubElementDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Element is required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters Allowed")]
        public string Element { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters allowed")]
        public string Type { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Width Must be Greater than 0")]
        public int Width { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Height Must be Greater than 0")]
        public int Height { get; set; }
    }
}
