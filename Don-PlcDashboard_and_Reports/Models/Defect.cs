﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Don_PlcDashboard_and_Reports.Models
{
    public class Defect
    {
        [Display(Name = "ID")]
        public int DefectID { get; set; }

        [Required]
        public int PlcModelID { get; set; }

        [Display(Name = "Plc Name")]
        public virtual PlcModel PlcModel { get; set; }
        
        [Display(Name = "Timp Start Defect")]
        public DateTime TimpStartDefect { get; set; }

        [Display(Name = "Timp Stop Defect")]
        public DateTime TimpStopDefect { get; set; }

        [Display(Name = "Interval Stationare")]
        public TimeSpan IntervalStationare { get; set; }

        [StringLength(50, ErrorMessage = "The MotivStationare value cannot exceed 50 characters. ")]
        [Display(Name = "Motiv Stationare")]
        public string MotivStationare { get; set; }

        [Display(Name = "Is Defect Finalizat")]
        public bool? DefectFinalizat { get; set; }
    }
}
