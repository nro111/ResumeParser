using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperienceParser.Models
{
    public partial class ApplicantCertifications
    {
        [Key]
        public int ACID { get; set; }

        [ForeignKey("ApplicantID")]
        public int ApplicantID { get; set; }

        [ForeignKey("CertificationID")]
        public int CertificationID { get; set; }

    }
}
