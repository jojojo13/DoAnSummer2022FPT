﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Rc_Resource_Candidate")]
    public class Rc_Resource_Candidate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public int? NumberCandidate { get; set; }

        public virtual ICollection<Rc_Candidate> Rc_Candidates { get; set; }
    }
}
