using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RcCandidateServices
{
    internal interface IRcCandidate
    {
        /// <summary>
        /// add thong tin vao bang rccandidate
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        bool AddRcCandidate(RcCandidate r);
        /// <summary>
        /// add thong tin vao bang rccandidate cv
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        bool AddRcCandidateCV(RcCandidateCv r);
        /// <summary>
        /// add thong tin vao bang rccandidateedu
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        bool AddRcCandidateEdu(RcCandidateEdu r);
        bool UpdateStepCandidate(RcCandidate r);
        /// <summary>
        /// tra ve CandidateID khi create new candi
        /// </summary>
        /// <returns></returns>
   

        
    }
}
