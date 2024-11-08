using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage.Data.Models
{
    public class GioiTinh
    {
        [Key]
        public int GioiTinhID { get; set; }

        [Required]
        [StringLength(10)] // Adjust the length as necessary
        public required string TenGioiTinh { get; set; }
    }
}
