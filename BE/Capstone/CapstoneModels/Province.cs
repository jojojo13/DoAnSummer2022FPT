using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Province")]
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }

        public int NationID { get; set; }
        [ForeignKey("NationID")]
        public Nation Nation { get; set; }


        public virtual ICollection<District> Districts { get; set; }    
        public virtual ICollection<ORgnization> ORgnizations { get; set; }
    }
}
