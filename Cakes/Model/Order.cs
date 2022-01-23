using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakesData.Model
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        [DataType("smalldatetime")]
        public DateTime OrderDate { get; set; } 
        [Required]
        [DataType("smalldatetime")]
        public DateTime DelivryDate { get; set; }
        [DataType("smalldatetime")]
        public DateTime? OrderPreparedDate { get; set; }
        
        [Required]
        public string Address { get; set; }

        public Cake Cake { get; set; }

        [ForeignKey("User")]
        public int OrderUserID { get; set; }
        public User User { get; set; }
        [Required]
        public double OrderPrice { get; set; }

        public override string ToString()
        {
            return $"Order ID-{OrderID}, User ID-{OrderUserID}, Order Date-{OrderDate}, Requested Delivery-{DelivryDate}\n" +
                $"Order Price-{OrderPrice}";
        }
    }
}
