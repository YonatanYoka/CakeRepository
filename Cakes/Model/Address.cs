using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakesData.Model
{
    public class Address
    {
        [Key]
        public int Addressid { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street_name { get; set; }
        [Required]
        [MaxLength(10)]
        public string House_number { get; set; }
        [Required]
        [MaxLength(20)]
        public string Zipcode { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public override string ToString()
        {
            return $"{Street_name} ,{House_number},{Zipcode},{City}";

        }
    }
}