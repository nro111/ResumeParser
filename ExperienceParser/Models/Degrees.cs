using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperienceParser.Models
{
    public partial class Degrees
    {
        [Key]
        public int DegreeID { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
    }
}
