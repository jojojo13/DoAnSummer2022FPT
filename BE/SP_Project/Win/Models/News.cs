using System;
using System.Collections.Generic;

#nullable disable

namespace Win.Models
{
    public partial class News
    {
        public int Idnew { get; set; }
        public string Tieude { get; set; }
        public string NoiDung { get; set; }
        public DateTime? Date { get; set; }
    }
}
