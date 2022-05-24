using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    public class Context:DbContext
    {
        // Ho so + To chuc
        public DbSet<Nation> Nations { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Contract_Type> ContractTypes { get; set; }
        public DbSet<Other_List> Other_Lists { get; set; } 
        public DbSet<Other_List_Type > Other_Lists_Types { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<ORgnization> ORgnizations { get; set; }
        public DbSet<Position> Positions { get; set; }  
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCV> EmployeeCVs { get; set; }
        public DbSet<EmployeeContract> EmployeeContracts { get; set; }

        // Tuyen dung
        public DbSet<Rc_Request> Rc_Requests { get; set; }
        public DbSet<Rc_Phase_Request> rc_Phase_Requests { get; set; }
        public DbSet<Rc_Request_History> rc_Request_Histories { get; set; }
        public DbSet<Rc_Resource_Candidate> rc_Resource_Candidates { get; set; }
        public DbSet<Rc_Candidate> rc_Candidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("jsconfig1.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("MyDB"));
            }
        }
    }
}
