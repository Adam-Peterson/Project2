using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table("Missions")]
    public class Missions
    {
        [Key]
        public int missionID { get; set; }
        public string missionName { get; set; }
        public String missionPresidentName { get; set; }
        public string missionAddress { get; set; }
        public String missionLanguage { get; set; }
        public String climate { get; set; }
        public string dominantReligion { get; set; }
        public byte[] MissionSymbol { get; set; }
    }
}

