using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Don_PlcDashboard_and_Reports.Models
{
    public class TagModel
    {
        [Key]
        public int TagID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The TagName value cannot exceed 50 characters. ")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The TagAdress value cannot exceed 50 characters. ")]
        public string Adress { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The TagDataType value cannot exceed 50 characters. ")]
        public string DataType { get; set; }

        [Required]
        public int PlcModelID { get; set; }
        public virtual PlcModel PlcModel { get; set; }
    }
}
