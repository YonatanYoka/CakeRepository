using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CakesData.Utilities;

namespace CakesData.Model
{
    public class Cake 
    {
        [Key]
        public int CakeID { get; set; }
        [Required]
        public string CakeName { get; set; }
        public string Description { get; set; }
        [Required]
        public double CakePrice { get; set; }
        [Required]
        public CakesInfo CakeType { get; set; }
        [Required]
        public SizeInfo CakeSize { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public int orderID { get; set; }
        public override string ToString()
        {
            return $"{CakeName}";
        }
    }
}
