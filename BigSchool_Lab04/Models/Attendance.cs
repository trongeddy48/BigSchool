﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BigSchool_Lab04.Models
{
    [Table("Attendance")]
    public partial class Attendance
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Attendee { get; set; }

        public virtual Course Course { get; set; }
    }
}