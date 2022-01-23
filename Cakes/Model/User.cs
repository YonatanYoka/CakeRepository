using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CakesData.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType("nvarchar")]
        public Address Address { get; set; }

        public List<Order> Orders { get; set; }









    }
}
