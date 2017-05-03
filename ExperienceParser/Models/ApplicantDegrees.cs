using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperienceParser.Models
{
    public partial class ApplicantDegrees
    {
        [Key]
        public int ADID { get; set; }

        [ForeignKey("ApplicantID")]
        public int ApplicantID { get; set; }

        [ForeignKey("DegreeID")]
        public int DegreeID { get; set; }

    }
}
