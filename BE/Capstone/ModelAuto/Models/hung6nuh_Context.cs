using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ModelAuto.Models
{
    public partial class hung6nuh_Context : DbContext
    {
        public hung6nuh_Context()
        {
        }

        public hung6nuh_Context(DbContextOptions<hung6nuh_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeContract> EmployeeContracts { get; set; }
        public virtual DbSet<EmployeeCv> EmployeeCvs { get; set; }
        public virtual DbSet<Nation> Nations { get; set; }
        public virtual DbSet<Orgnization> Orgnizations { get; set; }
        public virtual DbSet<OtherList> OtherLists { get; set; }
        public virtual DbSet<OtherListType> OtherListTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PositionOrg> PositionOrgs { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<RcCandidate> RcCandidates { get; set; }
        public virtual DbSet<RcCandidateCv> RcCandidateCvs { get; set; }
        public virtual DbSet<RcCandidateEdu> RcCandidateEdus { get; set; }
        public virtual DbSet<RcCandidateFamily> RcCandidateFamilies { get; set; }
        public virtual DbSet<RcCandidateHeal> RcCandidateHeals { get; set; }
        public virtual DbSet<RcCandidateWorrkingBefore> RcCandidateWorrkingBefores { get; set; }
        public virtual DbSet<RcPhaseRequest> RcPhaseRequests { get; set; }
        public virtual DbSet<RcRequest> RcRequests { get; set; }
        public virtual DbSet<RcRequestExam> RcRequestExams { get; set; }
        public virtual DbSet<RcRequestExamResult> RcRequestExamResults { get; set; }
        public virtual DbSet<RcRequestHistory> RcRequestHistories { get; set; }
        public virtual DbSet<RcRequestInterView> RcRequestInterViews { get; set; }
        public virtual DbSet<RcRequestInterViewResult> RcRequestInterViewResults { get; set; }
        public virtual DbSet<RcRequestResult> RcRequestResults { get; set; }
        public virtual DbSet<RcRequestSchedu> RcRequestSchedus { get; set; }
        public virtual DbSet<RcResourceCandidate> RcResourceCandidates { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("contextJson.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("MyDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.EmployeeId, "IX_Account_EmployeeID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.ToTable("Contract_Type");

                entity.Property(e => e.Bhtn).HasColumnName("BHTN");

                entity.Property(e => e.Bhxh).HasColumnName("BHXH");

                entity.Property(e => e.Bhyt).HasColumnName("BHYT");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.HasIndex(e => e.ProvinceId, "IX_District_ProvinceID");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.OrgId, "IX_Employee_OrgID");

                entity.HasIndex(e => e.PositionId, "IX_Employee_PositionID");

                entity.HasIndex(e => e.Status, "IX_Employee_Status");

                entity.Property(e => e.OrgId).HasColumnName("OrgID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.OrgId);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Status);
            });

            modelBuilder.Entity<EmployeeContract>(entity =>
            {
                entity.ToTable("EmployeeContract");

                entity.HasIndex(e => e.ContractType, "IX_EmployeeContract_Contract_type");

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeContract_EmployeeID");

                entity.HasIndex(e => e.OrgId, "IX_EmployeeContract_OrgId");

                entity.HasIndex(e => e.PositionId, "IX_EmployeeContract_PositionId");

                entity.HasIndex(e => e.SignId, "IX_EmployeeContract_SignId");

                entity.Property(e => e.ContractNo).HasColumnName("Contract_NO");

                entity.Property(e => e.ContractType).HasColumnName("Contract_type");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.IsCamKet).HasColumnName("Is_CamKet");

                entity.Property(e => e.IsThue).HasColumnName("Is_thue");

                entity.HasOne(d => d.ContractTypeNavigation)
                    .WithMany(p => p.EmployeeContracts)
                    .HasForeignKey(d => d.ContractType);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeContractEmployees)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.EmployeeContracts)
                    .HasForeignKey(d => d.OrgId);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.EmployeeContracts)
                    .HasForeignKey(d => d.PositionId);

                entity.HasOne(d => d.Sign)
                    .WithMany(p => p.EmployeeContractSigns)
                    .HasForeignKey(d => d.SignId);
            });

            modelBuilder.Entity<EmployeeCv>(entity =>
            {
                entity.ToTable("EmployeeCV");

                entity.HasIndex(e => e.DistrictHk, "IX_EmployeeCV_DistrictHK");

                entity.HasIndex(e => e.DistrictLive, "IX_EmployeeCV_DistrictLive");

                entity.HasIndex(e => e.DistrictOb, "IX_EmployeeCV_DistrictOB");

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeCV_EmployeeID");

                entity.HasIndex(e => e.Gender, "IX_EmployeeCV_Gender");

                entity.HasIndex(e => e.NationHk, "IX_EmployeeCV_NationHK");

                entity.HasIndex(e => e.NationLive, "IX_EmployeeCV_NationLive");

                entity.HasIndex(e => e.NationOb, "IX_EmployeeCV_NationOB");

                entity.HasIndex(e => e.ProvinceHk, "IX_EmployeeCV_ProvinceHK");

                entity.HasIndex(e => e.ProvinceLive, "IX_EmployeeCV_ProvinceLive");

                entity.HasIndex(e => e.ProvinceOb, "IX_EmployeeCV_ProvinceOB");

                entity.HasIndex(e => e.WardHk, "IX_EmployeeCV_WardHK");

                entity.HasIndex(e => e.WardLive, "IX_EmployeeCV_WardLive");

                entity.HasIndex(e => e.WardOb, "IX_EmployeeCV_WardOB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cmnd).HasColumnName("CMND");

                entity.Property(e => e.Cmndplace).HasColumnName("CMNDPlace");

                entity.Property(e => e.DistrictHk).HasColumnName("DistrictHK");

                entity.Property(e => e.DistrictOb).HasColumnName("DistrictOB");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.NationHk).HasColumnName("NationHK");

                entity.Property(e => e.NationOb).HasColumnName("NationOB");

                entity.Property(e => e.PorvinceHk).HasColumnName("PorvinceHK");

                entity.Property(e => e.PorvinceOb).HasColumnName("PorvinceOB");

                entity.Property(e => e.ProvinceHk).HasColumnName("ProvinceHK");

                entity.Property(e => e.ProvinceOb).HasColumnName("ProvinceOB");

                entity.Property(e => e.WardHk).HasColumnName("WardHK");

                entity.Property(e => e.WardOb).HasColumnName("WardOB");

                entity.HasOne(d => d.DistrictHkNavigation)
                    .WithMany(p => p.EmployeeCvDistrictHkNavigations)
                    .HasForeignKey(d => d.DistrictHk);

                entity.HasOne(d => d.DistrictLiveNavigation)
                    .WithMany(p => p.EmployeeCvDistrictLiveNavigations)
                    .HasForeignKey(d => d.DistrictLive);

                entity.HasOne(d => d.DistrictObNavigation)
                    .WithMany(p => p.EmployeeCvDistrictObNavigations)
                    .HasForeignKey(d => d.DistrictOb);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeCvs)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.EmployeeCvs)
                    .HasForeignKey(d => d.Gender);

                entity.HasOne(d => d.NationHkNavigation)
                    .WithMany(p => p.EmployeeCvNationHkNavigations)
                    .HasForeignKey(d => d.NationHk);

                entity.HasOne(d => d.NationLiveNavigation)
                    .WithMany(p => p.EmployeeCvNationLiveNavigations)
                    .HasForeignKey(d => d.NationLive);

                entity.HasOne(d => d.NationObNavigation)
                    .WithMany(p => p.EmployeeCvNationObNavigations)
                    .HasForeignKey(d => d.NationOb);

                entity.HasOne(d => d.ProvinceHkNavigation)
                    .WithMany(p => p.EmployeeCvProvinceHkNavigations)
                    .HasForeignKey(d => d.ProvinceHk);

                entity.HasOne(d => d.ProvinceLiveNavigation)
                    .WithMany(p => p.EmployeeCvProvinceLiveNavigations)
                    .HasForeignKey(d => d.ProvinceLive);

                entity.HasOne(d => d.ProvinceObNavigation)
                    .WithMany(p => p.EmployeeCvProvinceObNavigations)
                    .HasForeignKey(d => d.ProvinceOb);

                entity.HasOne(d => d.WardHkNavigation)
                    .WithMany(p => p.EmployeeCvWardHkNavigations)
                    .HasForeignKey(d => d.WardHk);

                entity.HasOne(d => d.WardLiveNavigation)
                    .WithMany(p => p.EmployeeCvWardLiveNavigations)
                    .HasForeignKey(d => d.WardLive);

                entity.HasOne(d => d.WardObNavigation)
                    .WithMany(p => p.EmployeeCvWardObNavigations)
                    .HasForeignKey(d => d.WardOb);
            });

            modelBuilder.Entity<Nation>(entity =>
            {
                entity.ToTable("Nation");
            });

            modelBuilder.Entity<Orgnization>(entity =>
            {
                entity.ToTable("ORgnization");

                entity.HasIndex(e => e.DistrictId, "IX_ORgnization_DistrictID");

                entity.HasIndex(e => e.ManagerId, "IX_ORgnization_ManagerID");

                entity.HasIndex(e => e.NationId, "IX_ORgnization_NationID");

                entity.HasIndex(e => e.ProvinceId, "IX_ORgnization_ProvinceID");

                entity.HasIndex(e => e.WardId, "IX_ORgnization_WardID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.NationId).HasColumnName("NationID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.WardId).HasColumnName("WardID");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Orgnizations)
                    .HasForeignKey(d => d.DistrictId);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Orgnizations)
                    .HasForeignKey(d => d.ManagerId);

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Orgnizations)
                    .HasForeignKey(d => d.NationId);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Orgnizations)
                    .HasForeignKey(d => d.ProvinceId);

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Orgnizations)
                    .HasForeignKey(d => d.WardId);
            });

            modelBuilder.Entity<OtherList>(entity =>
            {
                entity.ToTable("Other_List");

                entity.HasIndex(e => e.TypeId, "IX_Other_List_TypeID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.OtherLists)
                    .HasForeignKey(d => d.TypeId);
            });

            modelBuilder.Entity<OtherListType>(entity =>
            {
                entity.ToTable("Other_List_Type");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.HasIndex(e => e.FormWorking, "IX_Position_FormWorking");

                entity.HasIndex(e => e.InformationLevel, "IX_Position_Information_level");

                entity.HasIndex(e => e.LearningLevel, "IX_Position_Learning_level");

                entity.HasIndex(e => e.TitleId, "IX_Position_TitleID");

                entity.HasIndex(e => e.Language, "IX_Position_language");

                entity.HasIndex(e => e.LanguageLevel, "IX_Position_language_level");

                entity.HasIndex(e => e.MajorGroup, "IX_Position_majorGroup");

                entity.Property(e => e.InformationLevel).HasColumnName("Information_level");

                entity.Property(e => e.Language).HasColumnName("language");

                entity.Property(e => e.LanguageLevel).HasColumnName("language_level");

                entity.Property(e => e.LearningLevel).HasColumnName("Learning_level");

                entity.Property(e => e.Major).HasColumnName("major");

                entity.Property(e => e.MajorGroup).HasColumnName("majorGroup");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.Property(e => e.YearExp).HasColumnName("year_exp");

                entity.HasOne(d => d.FormWorkingNavigation)
                    .WithMany(p => p.PositionFormWorkingNavigations)
                    .HasForeignKey(d => d.FormWorking);

                entity.HasOne(d => d.InformationLevelNavigation)
                    .WithMany(p => p.PositionInformationLevelNavigations)
                    .HasForeignKey(d => d.InformationLevel);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.PositionLanguageNavigations)
                    .HasForeignKey(d => d.Language);

                entity.HasOne(d => d.LanguageLevelNavigation)
                    .WithMany(p => p.PositionLanguageLevelNavigations)
                    .HasForeignKey(d => d.LanguageLevel);

                entity.HasOne(d => d.LearningLevelNavigation)
                    .WithMany(p => p.PositionLearningLevelNavigations)
                    .HasForeignKey(d => d.LearningLevel);

                entity.HasOne(d => d.MajorGroupNavigation)
                    .WithMany(p => p.PositionMajorGroupNavigations)
                    .HasForeignKey(d => d.MajorGroup);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.TitleId);
            });

            modelBuilder.Entity<PositionOrg>(entity =>
            {
                entity.ToTable("PositionOrg");

                entity.HasIndex(e => e.OrgId, "IX_PositionOrg_OrgID");

                entity.HasIndex(e => e.PositionId, "IX_PositionOrg_positionID");

                entity.Property(e => e.OrgId).HasColumnName("OrgID");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.PositionOrgs)
                    .HasForeignKey(d => d.OrgId);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PositionOrgs)
                    .HasForeignKey(d => d.PositionId);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.HasIndex(e => e.NationId, "IX_Province_NationID");

                entity.Property(e => e.NationId).HasColumnName("NationID");

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.NationId);
            });

            modelBuilder.Entity<RcCandidate>(entity =>
            {
                entity.ToTable("Rc_Candidate");

                entity.HasIndex(e => e.PhaseId, "IX_Rc_Candidate_PhaseID");

                entity.HasIndex(e => e.ResourceId, "IX_Rc_Candidate_ResourceID");

                entity.Property(e => e.PhaseId).HasColumnName("PhaseID");

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.StepCv).HasColumnName("StepCV");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.RcCandidates)
                    .HasForeignKey(d => d.PhaseId);

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.RcCandidates)
                    .HasForeignKey(d => d.ResourceId);
            });

            modelBuilder.Entity<RcCandidateCv>(entity =>
            {
                entity.ToTable("Rc_Candidate_CV");

                entity.HasIndex(e => e.CandidateId, "IX_Rc_Candidate_CV_CandidateID");

                entity.HasIndex(e => e.DistrictHk, "IX_Rc_Candidate_CV_DistrictHK");

                entity.HasIndex(e => e.DistrictLive, "IX_Rc_Candidate_CV_DistrictLive");

                entity.HasIndex(e => e.DistrictOb, "IX_Rc_Candidate_CV_DistrictOB");

                entity.HasIndex(e => e.Gender, "IX_Rc_Candidate_CV_Gender");

                entity.HasIndex(e => e.NationHk, "IX_Rc_Candidate_CV_NationHK");

                entity.HasIndex(e => e.NationLive, "IX_Rc_Candidate_CV_NationLive");

                entity.HasIndex(e => e.NationOb, "IX_Rc_Candidate_CV_NationOB");

                entity.HasIndex(e => e.PorvinceHk, "IX_Rc_Candidate_CV_PorvinceHK");

                entity.HasIndex(e => e.PorvinceLive, "IX_Rc_Candidate_CV_PorvinceLive");

                entity.HasIndex(e => e.PorvinceOb, "IX_Rc_Candidate_CV_PorvinceOB");

                entity.HasIndex(e => e.WardHk, "IX_Rc_Candidate_CV_WardHK");

                entity.HasIndex(e => e.WardLive, "IX_Rc_Candidate_CV_WardLive");

                entity.HasIndex(e => e.WardOb, "IX_Rc_Candidate_CV_WardOB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(50)
                    .HasColumnName("CMND");

                entity.Property(e => e.Cmndplace)
                    .HasMaxLength(100)
                    .HasColumnName("CMNDPlace");

                entity.Property(e => e.DistrictHk).HasColumnName("DistrictHK");

                entity.Property(e => e.DistrictOb).HasColumnName("DistrictOB");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Facebook).HasMaxLength(50);

                entity.Property(e => e.Linkedin).HasMaxLength(50);

                entity.Property(e => e.NationHk).HasColumnName("NationHK");

                entity.Property(e => e.NationOb).HasColumnName("NationOB");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PorvinceHk).HasColumnName("PorvinceHK");

                entity.Property(e => e.PorvinceOb).HasColumnName("PorvinceOB");

                entity.Property(e => e.Twitter).HasMaxLength(50);

                entity.Property(e => e.VisaNumber).HasMaxLength(50);

                entity.Property(e => e.WardHk).HasColumnName("WardHK");

                entity.Property(e => e.WardOb).HasColumnName("WardOB");

                entity.Property(e => e.Zalo).HasMaxLength(50);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.RcCandidateCvs)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.DistrictHkNavigation)
                    .WithMany(p => p.RcCandidateCvDistrictHkNavigations)
                    .HasForeignKey(d => d.DistrictHk);

                entity.HasOne(d => d.DistrictLiveNavigation)
                    .WithMany(p => p.RcCandidateCvDistrictLiveNavigations)
                    .HasForeignKey(d => d.DistrictLive);

                entity.HasOne(d => d.DistrictObNavigation)
                    .WithMany(p => p.RcCandidateCvDistrictObNavigations)
                    .HasForeignKey(d => d.DistrictOb);

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.RcCandidateCvs)
                    .HasForeignKey(d => d.Gender);

                entity.HasOne(d => d.NationHkNavigation)
                    .WithMany(p => p.RcCandidateCvNationHkNavigations)
                    .HasForeignKey(d => d.NationHk);

                entity.HasOne(d => d.NationLiveNavigation)
                    .WithMany(p => p.RcCandidateCvNationLiveNavigations)
                    .HasForeignKey(d => d.NationLive);

                entity.HasOne(d => d.NationObNavigation)
                    .WithMany(p => p.RcCandidateCvNationObNavigations)
                    .HasForeignKey(d => d.NationOb);

                entity.HasOne(d => d.PorvinceHkNavigation)
                    .WithMany(p => p.RcCandidateCvPorvinceHkNavigations)
                    .HasForeignKey(d => d.PorvinceHk);

                entity.HasOne(d => d.PorvinceLiveNavigation)
                    .WithMany(p => p.RcCandidateCvPorvinceLiveNavigations)
                    .HasForeignKey(d => d.PorvinceLive);

                entity.HasOne(d => d.PorvinceObNavigation)
                    .WithMany(p => p.RcCandidateCvPorvinceObNavigations)
                    .HasForeignKey(d => d.PorvinceOb);

                entity.HasOne(d => d.WardHkNavigation)
                    .WithMany(p => p.RcCandidateCvWardHkNavigations)
                    .HasForeignKey(d => d.WardHk);

                entity.HasOne(d => d.WardLiveNavigation)
                    .WithMany(p => p.RcCandidateCvWardLiveNavigations)
                    .HasForeignKey(d => d.WardLive);

                entity.HasOne(d => d.WardObNavigation)
                    .WithMany(p => p.RcCandidateCvWardObNavigations)
                    .HasForeignKey(d => d.WardOb);
            });

            modelBuilder.Entity<RcCandidateEdu>(entity =>
            {
                entity.ToTable("Rc_Candidate_EDU");

                entity.HasIndex(e => e.CandidateId, "IX_Rc_Candidate_EDU_Candidate_ID");

                entity.HasIndex(e => e.DeeGree1, "IX_Rc_Candidate_EDU_DeeGree1");

                entity.HasIndex(e => e.DeeGree2, "IX_Rc_Candidate_EDU_DeeGree2");

                entity.HasIndex(e => e.DeeGree3, "IX_Rc_Candidate_EDU_DeeGree3");

                entity.HasIndex(e => e.InforMaticsLevel1, "IX_Rc_Candidate_EDU_InforMatics_Level1");

                entity.HasIndex(e => e.InforMaticsLevel2, "IX_Rc_Candidate_EDU_InforMatics_Level2");

                entity.HasIndex(e => e.InforMaticsLevel3, "IX_Rc_Candidate_EDU_InforMatics_Level3");

                entity.HasIndex(e => e.Language1, "IX_Rc_Candidate_EDU_Language1");

                entity.HasIndex(e => e.Language2, "IX_Rc_Candidate_EDU_Language2");

                entity.HasIndex(e => e.Language3, "IX_Rc_Candidate_EDU_Language3");

                entity.HasIndex(e => e.LearningLevel, "IX_Rc_Candidate_EDU_Learning_Level");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Awards1).HasMaxLength(100);

                entity.Property(e => e.Awards2).HasMaxLength(100);

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_ID");

                entity.Property(e => e.Gpa1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("GPA1");

                entity.Property(e => e.Gpa2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("GPA2");

                entity.Property(e => e.Graduate1).HasColumnType("date");

                entity.Property(e => e.Graduate2).HasColumnType("date");

                entity.Property(e => e.InforMaticsLevel1).HasColumnName("InforMatics_Level1");

                entity.Property(e => e.InforMaticsLevel2).HasColumnName("InforMatics_Level2");

                entity.Property(e => e.InforMaticsLevel3).HasColumnName("InforMatics_Level3");

                entity.Property(e => e.LearningLevel).HasColumnName("Learning_Level");

                entity.Property(e => e.LevelLanguage1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LevelLanguage2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LevelLanguage3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeLanguage1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeLanguage2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeLanguage3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.RcCandidateEdus)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.DeeGree1Navigation)
                    .WithMany(p => p.RcCandidateEduDeeGree1Navigations)
                    .HasForeignKey(d => d.DeeGree1);

                entity.HasOne(d => d.DeeGree2Navigation)
                    .WithMany(p => p.RcCandidateEduDeeGree2Navigations)
                    .HasForeignKey(d => d.DeeGree2);

                entity.HasOne(d => d.DeeGree3Navigation)
                    .WithMany(p => p.RcCandidateEduDeeGree3Navigations)
                    .HasForeignKey(d => d.DeeGree3);

                entity.HasOne(d => d.InforMaticsLevel1Navigation)
                    .WithMany(p => p.RcCandidateEduInforMaticsLevel1Navigations)
                    .HasForeignKey(d => d.InforMaticsLevel1);

                entity.HasOne(d => d.InforMaticsLevel2Navigation)
                    .WithMany(p => p.RcCandidateEduInforMaticsLevel2Navigations)
                    .HasForeignKey(d => d.InforMaticsLevel2);

                entity.HasOne(d => d.InforMaticsLevel3Navigation)
                    .WithMany(p => p.RcCandidateEduInforMaticsLevel3Navigations)
                    .HasForeignKey(d => d.InforMaticsLevel3);

                entity.HasOne(d => d.Language1Navigation)
                    .WithMany(p => p.RcCandidateEduLanguage1Navigations)
                    .HasForeignKey(d => d.Language1);

                entity.HasOne(d => d.Language2Navigation)
                    .WithMany(p => p.RcCandidateEduLanguage2Navigations)
                    .HasForeignKey(d => d.Language2);

                entity.HasOne(d => d.Language3Navigation)
                    .WithMany(p => p.RcCandidateEduLanguage3Navigations)
                    .HasForeignKey(d => d.Language3);

                entity.HasOne(d => d.LearningLevelNavigation)
                    .WithMany(p => p.RcCandidateEduLearningLevelNavigations)
                    .HasForeignKey(d => d.LearningLevel);
            });

            modelBuilder.Entity<RcCandidateFamily>(entity =>
            {
                entity.ToTable("Rc_Candidate_Family");

                entity.HasIndex(e => e.CandidateId, "IX_Rc_Candidate_Family_CandidateID");

                entity.HasIndex(e => e.District, "IX_Rc_Candidate_Family_District");

                entity.HasIndex(e => e.Nation, "IX_Rc_Candidate_Family_Nation");

                entity.HasIndex(e => e.Porvince, "IX_Rc_Candidate_Family_Porvince");

                entity.HasIndex(e => e.RelationId, "IX_Rc_Candidate_Family_RelationId");

                entity.HasIndex(e => e.Ward, "IX_Rc_Candidate_Family_Ward");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.DeductFrom).HasColumnName("Deduct_From");

                entity.Property(e => e.DeductTo).HasColumnName("Deduct_To");

                entity.Property(e => e.IsDeduct).HasColumnName("Is_Deduct");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.RcCandidateFamilies)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.DistrictNavigation)
                    .WithMany(p => p.RcCandidateFamilies)
                    .HasForeignKey(d => d.District);

                entity.HasOne(d => d.NationNavigation)
                    .WithMany(p => p.RcCandidateFamilies)
                    .HasForeignKey(d => d.Nation);

                entity.HasOne(d => d.PorvinceNavigation)
                    .WithMany(p => p.RcCandidateFamilies)
                    .HasForeignKey(d => d.Porvince);

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.RcCandidateFamilies)
                    .HasForeignKey(d => d.RelationId);

                entity.HasOne(d => d.WardNavigation)
                    .WithMany(p => p.RcCandidateFamilies)
                    .HasForeignKey(d => d.Ward);
            });

            modelBuilder.Entity<RcCandidateHeal>(entity =>
            {
                entity.ToTable("Rc_Candidate_Heal");

                entity.HasIndex(e => e.CadidateId, "IX_Rc_Candidate_Heal_Cadidate_ID");

                entity.HasIndex(e => e.LoaiSk, "IX_Rc_Candidate_Heal_LoaiSK");

                entity.Property(e => e.BenhKhac).HasColumnName("Benh_Khac");

                entity.Property(e => e.CadidateId).HasColumnName("Cadidate_ID");

                entity.Property(e => e.CanNang).HasColumnName("Can_Nang");

                entity.Property(e => e.ChieuCao).HasColumnName("Chieu_Cao");

                entity.Property(e => e.HuyetAp).HasColumnName("Huyet_Ap");

                entity.Property(e => e.LoaiSk).HasColumnName("LoaiSK");

                entity.Property(e => e.MatPhai).HasColumnName("Mat_Phai");

                entity.Property(e => e.MatTrai).HasColumnName("Mat_Trai");

                entity.Property(e => e.NhomMau).HasColumnName("Nhom_mau");

                entity.Property(e => e.TaiMuiHong).HasColumnName("Tai_Mui_Hong");

                entity.HasOne(d => d.Cadidate)
                    .WithMany(p => p.RcCandidateHeals)
                    .HasForeignKey(d => d.CadidateId);

                entity.HasOne(d => d.LoaiSkNavigation)
                    .WithMany(p => p.RcCandidateHeals)
                    .HasForeignKey(d => d.LoaiSk);
            });

            modelBuilder.Entity<RcCandidateWorrkingBefore>(entity =>
            {
                entity.ToTable("Rc_Candidate_Worrking_Before");

                entity.HasIndex(e => e.CandidateId, "IX_Rc_Candidate_Worrking_Before_CandidateID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.RcCandidateWorrkingBefores)
                    .HasForeignKey(d => d.CandidateId);
            });

            modelBuilder.Entity<RcPhaseRequest>(entity =>
            {
                entity.ToTable("Rc_Phase_Request");

                entity.HasIndex(e => e.PositionId, "IX_Rc_Phase_Request_PositionId");

                entity.HasIndex(e => e.RequestId, "IX_Rc_Phase_Request_RequestId");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.RcPhaseRequests)
                    .HasForeignKey(d => d.PositionId);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RcPhaseRequests)
                    .HasForeignKey(d => d.RequestId);
            });

            modelBuilder.Entity<RcRequest>(entity =>
            {
                entity.ToTable("Rc_Request");

                entity.HasIndex(e => e.OrgId, "IX_Rc_Request_OrgId");

                entity.HasIndex(e => e.PositionId, "IX_Rc_Request_PositionID");

                entity.HasIndex(e => e.Project, "IX_Rc_Request_Project");

                entity.HasIndex(e => e.SignId, "IX_Rc_Request_SignId");

                entity.HasIndex(e => e.StatusHr, "IX_Rc_Request_StatusHr");

                entity.HasIndex(e => e.StatusMg, "IX_Rc_Request_StatusMg");

                entity.HasIndex(e => e.Type, "IX_Rc_Request_Type");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.RcRequests)
                    .HasForeignKey(d => d.OrgId);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.RcRequests)
                    .HasForeignKey(d => d.PositionId);

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.RcRequestProjectNavigations)
                    .HasForeignKey(d => d.Project);

                entity.HasOne(d => d.Sign)
                    .WithMany(p => p.RcRequests)
                    .HasForeignKey(d => d.SignId);

                entity.HasOne(d => d.StatusHrNavigation)
                    .WithMany(p => p.RcRequestStatusHrNavigations)
                    .HasForeignKey(d => d.StatusHr);

                entity.HasOne(d => d.StatusMgNavigation)
                    .WithMany(p => p.RcRequestStatusMgNavigations)
                    .HasForeignKey(d => d.StatusMg);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.RcRequestTypeNavigations)
                    .HasForeignKey(d => d.Type);
            });

            modelBuilder.Entity<RcRequestExam>(entity =>
            {
                entity.ToTable("Rc_Request_Exam");

                entity.HasIndex(e => e.PhaseId, "IX_Rc_Request_Exam_Phase_ID");

                entity.Property(e => e.PhaseId).HasColumnName("Phase_ID");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.RcRequestExams)
                    .HasForeignKey(d => d.PhaseId);
            });

            modelBuilder.Entity<RcRequestExamResult>(entity =>
            {
                entity.ToTable("Rc_Request_Exam_Result");

                entity.HasIndex(e => e.CandidateId, "IX_Rc_Request_Exam_Result_CandidateID");

                entity.HasIndex(e => e.ExamId, "IX_Rc_Request_Exam_Result_ExamID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.RcRequestExamResults)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.RcRequestExamResults)
                    .HasForeignKey(d => d.ExamId);
            });

            modelBuilder.Entity<RcRequestHistory>(entity =>
            {
                entity.ToTable("Rc_Request_History");

                entity.HasIndex(e => e.PhaseRequestId, "IX_Rc_Request_History_Phase_Request_ID");

                entity.Property(e => e.PhaseRequestId).HasColumnName("Phase_Request_ID");

                entity.Property(e => e.UserLog).HasColumnName("User_log");

                entity.HasOne(d => d.PhaseRequest)
                    .WithMany(p => p.RcRequestHistories)
                    .HasForeignKey(d => d.PhaseRequestId);
            });

            modelBuilder.Entity<RcRequestInterView>(entity =>
            {
                entity.ToTable("Rc_Request_InterView");

                entity.HasIndex(e => e.PhaseId, "IX_Rc_Request_InterView_Phase_ID");

                entity.Property(e => e.PhaseId).HasColumnName("Phase_ID");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.RcRequestInterViews)
                    .HasForeignKey(d => d.PhaseId);
            });

            modelBuilder.Entity<RcRequestInterViewResult>(entity =>
            {
                entity.ToTable("Rc_Request_InterView_Result");

                entity.HasIndex(e => e.CandidateId, "IX_Rc_Request_InterView_Result_CandidateID");

                entity.HasIndex(e => e.InterviewId, "IX_Rc_Request_InterView_Result_InterviewID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.InterviewId).HasColumnName("InterviewID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.RcRequestInterViewResults)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.RcRequestInterViewResults)
                    .HasForeignKey(d => d.InterviewId);
            });

            modelBuilder.Entity<RcRequestResult>(entity =>
            {
                entity.ToTable("Rc_Request_Result");

                entity.HasIndex(e => e.CandidateId, "IX_Rc_Request_Result_CandidateID");

                entity.HasIndex(e => e.StatusContact, "IX_Rc_Request_Result_StatusContact");

                entity.HasIndex(e => e.StatusRequest, "IX_Rc_Request_Result_Status_Request");

                entity.Property(e => e.AvgScore).HasColumnName("Avg_Score");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.IsMoveHsnv).HasColumnName("Is_Move_HSNV");

                entity.Property(e => e.ResultInterview).HasColumnName("Result_Interview");

                entity.Property(e => e.StatusRequest).HasColumnName("Status_Request");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.RcRequestResults)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.StatusContactNavigation)
                    .WithMany(p => p.RcRequestResultStatusContactNavigations)
                    .HasForeignKey(d => d.StatusContact);

                entity.HasOne(d => d.StatusRequestNavigation)
                    .WithMany(p => p.RcRequestResultStatusRequestNavigations)
                    .HasForeignKey(d => d.StatusRequest);
            });

            modelBuilder.Entity<RcRequestSchedu>(entity =>
            {
                entity.ToTable("Rc_Request_Schedu");

                entity.HasIndex(e => e.CandidateId, "IX_Rc_Request_Schedu_Candidate_ID");

                entity.HasIndex(e => e.ExamId, "IX_Rc_Request_Schedu_ExamID");

                entity.HasIndex(e => e.HinhThuc, "IX_Rc_Request_Schedu_HinhThuc");

                entity.HasIndex(e => e.IdNguoiPv, "IX_Rc_Request_Schedu_ID_NguoiPV");

                entity.HasIndex(e => e.InterViewId, "IX_Rc_Request_Schedu_InterView_ID");

                entity.HasIndex(e => e.StatusContact, "IX_Rc_Request_Schedu_Status_Contact");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_ID");

                entity.Property(e => e.DateNotify).HasColumnName("Date_Notify");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.ExpectedCost).HasColumnName("Expected_Cost");

                entity.Property(e => e.GioPv).HasColumnName("Gio_PV");

                entity.Property(e => e.IdNguoiPv).HasColumnName("ID_NguoiPV");

                entity.Property(e => e.InterViewId).HasColumnName("InterView_ID");

                entity.Property(e => e.IsExam).HasColumnName("Is_Exam");

                entity.Property(e => e.IsInteview).HasColumnName("Is_Inteview");

                entity.Property(e => e.StatusContact).HasColumnName("Status_Contact");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.RcRequestSchedus)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.RcRequestSchedus)
                    .HasForeignKey(d => d.ExamId);

                entity.HasOne(d => d.HinhThucNavigation)
                    .WithMany(p => p.RcRequestScheduHinhThucNavigations)
                    .HasForeignKey(d => d.HinhThuc);

                entity.HasOne(d => d.IdNguoiPvNavigation)
                    .WithMany(p => p.RcRequestSchedus)
                    .HasForeignKey(d => d.IdNguoiPv);

                entity.HasOne(d => d.InterView)
                    .WithMany(p => p.RcRequestSchedus)
                    .HasForeignKey(d => d.InterViewId);

                entity.HasOne(d => d.StatusContactNavigation)
                    .WithMany(p => p.RcRequestScheduStatusContactNavigations)
                    .HasForeignKey(d => d.StatusContact);
            });

            modelBuilder.Entity<RcResourceCandidate>(entity =>
            {
                entity.ToTable("Rc_Resource_Candidate");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("Title");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("Ward");

                entity.HasIndex(e => e.DistrictId, "IX_Ward_DistrictID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
