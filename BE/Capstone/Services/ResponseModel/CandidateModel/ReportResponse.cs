using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.CandidateModel
{
    public class ReportResponse
    {


        public string month { get; set; }
        public int quantity { get; set; }

        public ReportResponse(string month, int quantity)
        {
            this.month = month;
            this.quantity = quantity;
        }
    }
    public class ReportResult
    {
        public int ResultPass { get; set; }
        public int Total { get;set; }

    }
}
