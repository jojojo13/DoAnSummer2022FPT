using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RcCandidateServices
{
    public interface IRcCandidate
    {
        #region add candidate
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

        bool AddRcCandidateSkill(RcCandidateSkill r);
        #endregion

        #region  de thuc hien 5 man phong van
        /// <summary>
        /// PV thanh cong thi chuyen step cua Candidate len
        /// </summary>
        /// <param name="CandidateID"></param>
        /// <returns></returns>
        bool PromoteCandidate(int CandidateID);
        /// <summary>
        /// set status false cua candidate khi phong van that bai
        /// </summary>
        /// <param name="CandidateID"></param>
        /// <returns></returns>
        bool ViewFailedCandidate(int CandidateID);

        #endregion

        #region GetInforofCandiddate
        /// <summary>
        /// Lay ra tat ca candidate theo kieu phan trang
        /// </summary>
        /// <returns></returns>

        List<RcCandidate> GetAllCandidate(int page, int total);
        /// <summary>
        /// Lay ra tat ca cac candidate co step khac nhau
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        List<RcCandidate> GetAllCandidateByStep(int step);

        /// <summary>
        /// lay ra thong tin cua candidate theo Id cua no
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RcCandidate GetCandidateByID(int id);
        /// <summary>
        /// lay ra thong tin 1 cv trong ban rccandidatecv theo candidateID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RcCandidateCv GetCandidateCVbyID(int id);
        /// <summary>
        /// lay ra thong tin 1 edu trong ban rccandidateedu theo candidateID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RcCandidateEdu GetCandidateEdubyID(int id);
        /// <summary>
        /// lay ra danh sach cac skill cua candidate theo RcCandidateID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<RcCandidateSkill> GetCandidateSkillbyID(int id);

     

        #endregion


    }
}
