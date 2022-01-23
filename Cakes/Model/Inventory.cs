using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesData.Model
{
    public class Inventory
    {
        [Key]
        public int InventoryUnitID { get; set; }
        public int InventoryUnitsInStock { get; set; }



        [ForeignKey("Proudct")]
        public int InventoryProductID { get; set; }
        public Product Product{ get; set; }



    }
}
