using API.Controllers;
using API.ResponseModel.Candidate;
using API.ResponseModel.Orgnization;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseModel.CandidateModel;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestCP
{
    public class CandidateUnitTest
    {
        [Fact]
        public void GetSkillSheet()
        {
            var controller=  new CandidateAPIController();
            var result = controller.GetSkillSheet("LANGUAGE");
            result
                .Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetTypeSkill()
        {
            var controller= new CandidateAPIController();
            var result = controller.GetTypeSkill();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));

        }
        [Fact]
        public void SetStep1()
        {
            var controller= new CandidateAPIController();
            var result = controller.SetStep1CandidatePV(new SetStep1 { CandidateId = 167, RequestId = 99, Step1 = 1 });
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void SetStep5()
        {
            var controller = new CandidateAPIController();
            var result = controller.SetStep5CandidatePV(new SetStep5 { CandidateId = 167, RequestId = 99, Step5Result = 1 });
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetAllCandidate()
        {
            var controller = new CandidateAPIController();
            var result = controller.GetAllCandidate(0, 5);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetAllCandidateDraff()
        {
            var controller = new CandidateAPIController();
            var result = controller.GetAllCandidateDraff(0, 5);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetAllCandidateByFillter()
        {
            var controller = new CandidateAPIController();
            var result = controller.GetAllCandidateByFillter(new CandidateFillter { email="son",name="ng"});
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void CheckDuplicateCandidate()
        {
            var controller= new CandidateAPIController();
            var result = controller.CheckDuplicateCandidate(new CheckDuplicateCandidateModel { email = "lili@gmail.com" });
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void DeleteCandidate()
        {
            var controller = new CandidateAPIController();
            var result = controller.DeleteCandidate(new List<int>( 7))  ;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void ActiveCandidate()
        {
            var controller = new CandidateAPIController();
            var result= controller.ActiveCandidate(new List<int>( 2)) ;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void DeActiveCandidate()
        {
            var controller = new CandidateAPIController();
            var result = controller.DeActiveCandidate(new deactiveResponse { comment = "Khong thien chi", lstCandidateID = new List<int>(2) }) ;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void MatchingCandidate()
        {
            var controller= new CandidateAPIController();
            var result = controller.MatchingCandidate(new MatchingResponse { RequestID = 1, lstCandidateID = new List<int>(1) });
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void CheckQuantity()
        {
            var controller = new CandidateAPIController();
            var result = controller.CheckQuantity(new MatchingResponse { RequestID = 1, lstCandidateID = new List<int>(1) });
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetAllRequestByCandidateID()
        {
            var controller = new CandidateAPIController();
            var result = controller.GetAllRequestByCandidateID(1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetCandidateRequestInf()
        {
            var controller = new CandidateAPIController();
            var result = controller.GetCandidateRequestInf(1,1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void Onboard()
        {
            var controller = new CandidateAPIController();
            var result = controller.Onboard(1, 1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void CheckInforCandidateEdit()
        {
            var controller = new CandidateAPIController();
            var result = controller.CheckInforCandidateEdit(new CandidateEdit { Email="lili@gmail.com",Phone="0998874444"});
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }

        [Fact]
        public void EditInforCandidate()
        {
            var controller = new CandidateAPIController();
            var result = controller.EditInforCandidate(new InforCandidateEdit { FullName="Duong Kim Hoang Long",ID=5,Email="lolo@gmail.com",Phone="0987666557"});
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetOneInforCandidateToEdit()
        {
            var controller = new CandidateAPIController();
            var result = controller.GetOneInforCandidateToEdit(1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetAllResultStep3()
        {
            var controller = new CandidateAPIController();
            var result = controller.GetAllResultStep3(1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void PassStep3to4()
        {
            var controller = new CandidateAPIController();
            var result = controller.PassStep3to4(new PassStep3
            {
                CandidateID = 1,RequestID=1,Result=1
            });
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void ViewStep3RcEvent()
        {
            var controller = new CandidateAPIController();
            var result = controller.ViewStep3RcEvent(1, 1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void ReportByYear()
        {
            var controller = new CandidateAPIController();
            var result = controller.ReportByYear(2021);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void ReportStep1()
        {
            var controller = new CandidateAPIController();
            var result = controller.ReportStep1();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void ReportStep3()
        {
            var controller = new CandidateAPIController();
            var result = controller.ReportStep3();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void ReportStep5()
        {
            var controller = new CandidateAPIController();
            var result = controller.ReportPassStep5();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void GetĐPositionStep4()
        {
            var controller = new CandidateAPIController();
            var result = controller.GetDDPositionStep4(2);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }



    }
}
