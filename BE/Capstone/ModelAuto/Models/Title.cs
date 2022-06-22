using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Title
    {
        public Title()
        {
            Positions = new HashSet<Position>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
