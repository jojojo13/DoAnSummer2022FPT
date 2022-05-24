using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CapstoneModels.RequestModel
{
    [Table("Rc_Candidate_EDU")]
    public class Rc_Candidate_EDU
    {
        [Key]
        public int ID { get; set; }

        public int? Candidate_ID { get; set; }
        public int? Learning_Level { get; set; }
        public int? InforMatics_Level1 { get; set; }
        public string School1 { get; set; }
        public int? DeeGree1 { get; set; }
        public string Major1 { get; set; }
        public int? Language1 { get; set; }

        // level2 
        public int? InforMatics_Level2 { get; set; }
        public string School2 { get; set; }
        public int? DeeGree2 { get; set; }
        public string Major2 { get; set; }
        public int? Language2 { get; set; }

        //level3
        public int? InforMatics_Level3 { get; set; }
        public string School3 { get; set; }
        public int? DeeGree3 { get; set; }
        public string Major3 { get; set; }
        public int? Language3 { get; set; }
    }
}
