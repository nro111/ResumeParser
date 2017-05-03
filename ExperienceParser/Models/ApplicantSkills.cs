using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperienceParser.Models
{
    public partial class ApplicantSkills
    {
        [Key]
        public int ASID { get; set; }

        [ForeignKey("ApplicantID")]
        public int ApplicantID { get; set; }

        [ForeignKey("SkillID")]
        public int SkillID { get; set; }

    }
}
