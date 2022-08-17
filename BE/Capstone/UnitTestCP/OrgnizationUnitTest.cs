using API.Controllers;
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
            var result = controller.GetAllTitle(0,100);
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






    }
}
