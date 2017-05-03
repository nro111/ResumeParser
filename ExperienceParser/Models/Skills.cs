using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperienceParser
{
    public partial class Skills
    {
        [Key]
        public int SkillID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
