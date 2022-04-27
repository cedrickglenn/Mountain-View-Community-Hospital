using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Datalayer.EFCode.Configurations.AssociativeClassConfigurations;
using Datalayer.EFCode.Configurations.BaseClassConfigurations;
using Datalayer.EFCode.Configurations.BaseClassConfigurations.PersonClassConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Datalayer.EFClasses
{
    public class MVCHContext : DbContext
    {
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Inpatient> Inpatients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<JobClass> JobClasses { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Outpatient> Outpatients { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientOrder> PatientOrders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Vital> Vitals { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<WorkUnit> WorkUnits { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<EmployeeSpecialty> EmployeeSpecialties { get; set; }
        public DbSet<FacilityPhysician> FacilityPhysicians { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
        public DbSet<PhysicianSpecialty> PhysicianSpecialties { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<UnitEmployee> UnitEmployees { get; set; }
        public DbSet<VendorSupply> VendorSupplies { get; set; }
        public DbSet<VitalRecord> VitalRecords { get; set; }
        public DbSet<VolunteerSpecialty> VolunteerSpecialties { get; set; }
        public DbSet<WardEmployee> WardEmployees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(
                   // @"Server=.\SDESIGN;Database=MVCHospital;Trusted_Connection=True;MultipleActiveResultSets=True");
                optionsBuilder.UseSqlServer(
                        "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MVCHospital; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BedConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new FacilityConfig());
            modelBuilder.ApplyConfiguration(new InpatientConfig());
            modelBuilder.ApplyConfiguration(new ItemConfig());
            modelBuilder.ApplyConfiguration(new JobClassConfig());
            modelBuilder.ApplyConfiguration(new NurseConfig());
            modelBuilder.ApplyConfiguration(new OutpatientConfig());
            modelBuilder.ApplyConfiguration(new PatientConfig());
            modelBuilder.ApplyConfiguration(new PatientOrderConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PhysicianConfig());
            modelBuilder.ApplyConfiguration(new ServiceConfig());
            modelBuilder.ApplyConfiguration(new SpecialtyConfig());
            modelBuilder.ApplyConfiguration(new StaffConfig());
            modelBuilder.ApplyConfiguration(new TechnicianConfig());
            modelBuilder.ApplyConfiguration(new VendorConfig());
            modelBuilder.ApplyConfiguration(new ProcedureConfig());
            modelBuilder.ApplyConfiguration(new ConditionConfig());
            modelBuilder.ApplyConfiguration(new VisitConfig());
            modelBuilder.ApplyConfiguration(new VitalConfig());
            modelBuilder.ApplyConfiguration(new VolunteerConfig());
            modelBuilder.ApplyConfiguration(new WardConfig());
            modelBuilder.ApplyConfiguration(new WorkUnitConfig());
            modelBuilder.ApplyConfiguration(new DiagnosisConfig());
            modelBuilder.ApplyConfiguration(new EmployeeSpecialtyConfig());
            modelBuilder.ApplyConfiguration(new FacilityPhysicianConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderItemConfig());
            modelBuilder.ApplyConfiguration(new OrderServiceConfig());
            modelBuilder.ApplyConfiguration(new PhysicianSpecialtyConfig());
            modelBuilder.ApplyConfiguration(new TreatmentConfig());
            modelBuilder.ApplyConfiguration(new UnitEmployeeConfig());
            modelBuilder.ApplyConfiguration(new VendorSupplyConfig());
            modelBuilder.ApplyConfiguration(new VitalRecordConfig());
            modelBuilder.ApplyConfiguration(new VolunteerSpecialtyConfig());
            modelBuilder.ApplyConfiguration(new WardEmployeeConfig());
        }

    }

}
