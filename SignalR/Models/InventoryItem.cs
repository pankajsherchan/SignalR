using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Models
{
    public class InventoryItem
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        //foreign Key
        //  [ForeignKey("UserID")]
        public int UserID { get; set; }
        public virtual User user { get; set; }
    }
}
