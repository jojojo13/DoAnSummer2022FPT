using API.Controllers;
using API.ResponseModel.Orgnization;
using API.ResponseModel.Profile;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestCP
{
    public class ProfileUnitTest
    {
        [Fact]
        public void GetContractType()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetContractType(0, 100);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetAllContractType()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetAllContractType(0, 100);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void InsertContractType()
        {
            var controller = new ProfileAPIController();
            ContractTypeResponse obj = new ContractTypeResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            var result = controller.InsertContractType(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void DeleteContractType()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeleteContractType(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ActiveContractType()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.ActiveContractType(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void deActiveContractType()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeActiveContractType(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ModifyContractType()
        {
            var controller = new ProfileAPIController();
            ContractTypeResponse obj = new ContractTypeResponse();
            obj.Id = 1000;
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            var result = controller.ModifyContractType(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetNation()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetNation();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetProvinceByNationId()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetProvinceByNationId(13);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void GetDistrictByProvinceId()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetDistrictByProvinceId(13);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]  
        public void GetWardByDistrictId()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetWardByDistrictId(13);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void InsertNation()
        {
            var controller = new ProfileAPIController();
            NationResponse obj = new NationResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            var result = controller.InsertNation(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ModifyNation()
        {
            var controller = new ProfileAPIController();
            NationResponse obj = new NationResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            var result = controller.ModifyNation(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void InsertProvince()
        {
            var controller = new ProfileAPIController();
            ProvinceResponse obj = new ProvinceResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            obj.NationId = 13;
            var result = controller.InsertProvince(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void InsertDistrict()
        {
            var controller = new ProfileAPIController();
            DistrictResponse obj = new DistrictResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            obj.ProvinceId = 13;
            var result = controller.InsertDistrict(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]


        public void InsertWard()
        {
            var controller = new ProfileAPIController();
            WardResponse obj = new WardResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            obj.DistrictId = 13;
            var result = controller.InsertWard(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void ModifyProvince()
        {
            var controller = new ProfileAPIController();
            ProvinceResponse obj = new ProvinceResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            obj.NationId = 13;
            var result = controller.ModifyProvince(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ModifyDistrict()
        {
            var controller = new ProfileAPIController();
            DistrictResponse obj = new DistrictResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            obj.ProvinceId = 13;
            var result = controller.ModifyDistrict(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]


        public void ModifyWard()
        {
            var controller = new ProfileAPIController();
            WardResponse obj = new WardResponse();
            obj.Name = "TEST";
            obj.Note = "TEST";
            obj.Status = -1;
            obj.Code = "TEST";
            obj.DistrictId = 13;
            var result = controller.ModifyWard(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void DeleteNation()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeleteNation(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DeleteProvince()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeleteProvince(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DeleteDistrict()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeleteDistrict(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DeleteWard()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeleteWard(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }






        [Fact]
        public void ActiveNation()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.ActiveNation(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ActiveProvince()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.ActiveProvince(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ActiveWard()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.ActiveWard(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ActiveDistrict()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.ActiveDistrict(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void DeActiveNation()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeActiveNation(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DeActiveProvince()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeActiveProvince(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DeActiveWard()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeActiveWard(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DeActiveDistrict()
        {
            var controller = new ProfileAPIController();
            List<int> list = new List<int>();
            list.Add(1000);
            var result = controller.DeActiveDistrict(list);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public void GetListPositionByOrgID()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetListPositionByOrgID(1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetListEmployeeByOrgID()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetListEmployeeByOrgID(1,0,100);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetAllInforOfEmployee()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetAllInforOfEmployee(1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetProfileOfEmployee()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetProfileOfEmployee(1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void GetContractEmployee()
        {
            var controller = new ProfileAPIController();
            var result = controller.GetContractEmployee(0, 100);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void getContractEmployeeById()
        {
            var controller = new ProfileAPIController();
            var result = controller.getContractEmployeeById(1);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }



        [Fact]
        public void InsertContractEmployee()
        {
            var controller = new ProfileAPIController();

            ContractEmpResponse obj = new ContractEmpResponse();
            obj.ContractNo = T.ContractNo;
            obj.ContractTypeId = T.ContractTypeId;
            obj.Effect = T.EffectDate;
            obj.Expire = T.ExpireDate;
            obj.OrgnizationId = T.OrgnizationId;
            obj.PositionId = T.PositionId;
            obj.EmployeeId = T.EmployeeId;
            obj.Note = T.Note;

            var result = controller.InsertContractEmployee(obj);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }




    }
    }
