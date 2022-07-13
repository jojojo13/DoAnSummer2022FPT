using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService
{
   public interface ICandidate
    {
        List<OtherList> GetOtherListByAttribute(int? ID);

        #region add candidate
        /// <summary>
        /// add thong tin vao bang rccandidate
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        string AddRcCandidate(RcCandidate r);
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

        bool AddRcCandidateExp(RcCandidateExp r);
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

        List<RcCandidate> GetAllCandidate(int page, int total,int status);


        List<RcCandidate> GetAllCandidateByFillter( int index,  int size,  string name, DateTime dob,  string phone,  string email,  string location,  string position,  string yearExp,  string language, int status );

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

        RcCandidate GetCandidateByCode(string code);
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
        List<RcCandidateExp> GetCandidateExpbyID(int id);

        List<OtherListType> GetSkillType(int type);

        Province GetLocation(int id);
        #endregion
        string GetSkill(int candidateID);
        string Position(int candidateID);
        string Exp(int candidateID);

        #region "matching request"
        bool MatchingCandidate(int requestID, List<int> lstCandidateID);
        List<RcCandidate> GetCandidateByRequest(int requestID);
        bool  CheckQuantity(int requestID, List<int> lstCandidateID);
        bool DeleteCandidateRequest(List<int> listID);

        #endregion
    }
}
