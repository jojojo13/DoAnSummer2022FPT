using API.Controllers;
using API.ResponseModel.Orgnization;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestCP
{
    public class OrgnizationUnitTest
    {
        [Fact]
        public void GetAllTitleTest()
        {
            var controller = new OrgnizationAPIController();
            var result = controller.GetAllTitle(0, 100);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetAllOfTitleTest()
        {
            var controller = new OrgnizationAPIController();
            var result = controller.GetAllOfTitle(0, 100);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ActiveTitleTest()
        {
            var controller = new OrgnizationAPIController();
            List<int> list = new List<int>();
            list.Add(1);
            var result = controller.ActiveTitle(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DeActiveTitleTest()
        {
            var controller = new OrgnizationAPIController();
            List<int> list = new List<int>();
            list.Add(1);
            var result = controller.DeActiveTitle(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DeleteTitleTest()
        {
            var controller = new OrgnizationAPIController();
            List<int> list = new List<int>();
            list.Add(1);
            var result = controller.DeleteTitle(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void InsertTitleTest()
        {
            var controller = new OrgnizationAPIController();
            TitleResponse obj = new TitleResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            var result = controller.InsertTitle(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ModifyTitleTest()
        {
            var controller = new OrgnizationAPIController();
            TitleResponse obj = new TitleResponse();
            obj.Id = 17;
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            var result = controller.ModifyTitle(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void GetAllPositionTest()
        {
            var controller = new OrgnizationAPIController();
            var result = controller.GetAllPosition(0, 100);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetAllOfPositionTest()
        {
            var controller = new OrgnizationAPIController();
            var result = controller.GetAllOfPosition(0, 100);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void DeActivePositionTest()
        {
            var controller = new OrgnizationAPIController();
            List<int> list = new List<int>();
            list.Add(1);
            var result = controller.DeActivePosition(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ActivePositionTest()
        {
            var controller = new OrgnizationAPIController();
            List<int> list = new List<int>();
            list.Add(1);
            var result = controller.ActivePosition(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void DeletePositionTest()
        {
            var controller = new OrgnizationAPIController();
            List<int> list = new List<int>();
            list.Add(1);
            var result = controller.DeletePosition(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void InsertPositionTest()
        {
            var controller = new OrgnizationAPIController();
            PositionResponse tobj = new PositionResponse();
            tobj.Name ="Test";
            tobj.Note ="Test";
            tobj.TitleID =17;
            tobj.OtherSkill = "Test";
            tobj.BasicSalary = 10000000;
            tobj.year_exp = "2 year";
            var result = controller.InsertPosition(tobj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void ModifyPositionTest()
        {
            var controller = new OrgnizationAPIController();
            PositionResponse tobj = new PositionResponse();
            tobj.Id = 17;
            tobj.Name = "Test";
            tobj.Note = "Test";
            tobj.TitleID = 17;
            tobj.OtherSkill = "Test";
            tobj.BasicSalary = 10000000;
            tobj.year_exp = "2 year";
            var result = controller.ModifyPosition(tobj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetAllOrgTest()
        {
            var controller = new OrgnizationAPIController();
            var result = controller.GetAllOrg();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void CheckPositionExist()
        {
            var controller = new OrgnizationAPIController();
            var result = controller.CheckPositionExist(1,2);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }







    }
}
