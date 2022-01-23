using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesData.Model
{
    public class UserType
    {
        [Key]
        public int UsertypeID { get; set; }
        [Required]
        public string UserLevel { get; set; }
    }
}
