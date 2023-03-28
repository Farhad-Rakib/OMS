using OrderManagement.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class SubElement:BaseEntity
    {
       
        public string Element { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        [ForeignKey("Window")]
        public int WindowId { get; set; }
        public Window? Window { get; set; }
    }

}
