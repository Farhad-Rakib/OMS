using OrderManagement.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Order:BaseEntity
    {

        
        [Required(ErrorMessage = "Please enter a name for the order")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a state for the order")]
        public string State { get; set; }
        public List<Window> Windows { get; set; } = new List<Window>();

    }

}
