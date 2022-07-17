using ModelAuto.Models;
using Services.ResponseModel.CandidateModel;
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

        bool AddRcCandidateSkill(List<RcCandidateSkill> r);

        bool AddRcCandidateExp(List<RcCandidateExp> r);
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

        List<CandidateResponeServices> GetAllCandidate(int page, int total,int status);


        List<CandidateResponeServices> GetAllCandidateByFillter( int index,  int size,  string name, int yob,  string phone,  string email,  string location,  string position,  string yearExp,  string language, int status, ref int totalItems);

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
        RcCandidateCv GetCandidateCVbyID(int? id);
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
      

        List<OtherListType> GetSkillType(int type);


        List<RcCandidateSkill> GetCandidateSkillbyID(int id);
        List<RcCandidateSkill> GetCandidateLanguagebyID(int id);
        List<RcCandidateExp> GetCandidateExpbyID(int id);


        Province GetLocation(int? id);
        Nation GetNation(int? id);
        District GetDistrict(int? id);
        Ward GetWard(int? id);
        #endregion
        string GetSkill(int? candidateID);
        string Position(int? candidateID);
        string Exp(int? candidateID);
        OtherListType GetOtherListTypesCandidate(int id);
        OtherList GetOtherListCandidate(int id);
        List<RcCandidateExp> GetDomainOneCandidate(int id);

        checkResponse checkDuplicateCandidate(CheckDuplicateCandidateModel obj);
        #region "matching request"
        bool MatchingCandidate(int requestID, List<int> lstCandidateID);
        List<CandidateResponeServices> GetCandidateByRequest(int requestID, int totalItem);
        bool  CheckQuantity(int requestID, List<int> lstCandidateID);
        bool DeleteCandidateRequest(List<int> listID);

        #endregion
    }
}
