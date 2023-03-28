using OrderManagement.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Window:BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
       
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public List<SubElement> subElements { get; set; } = new List<SubElement>();
    }

}
