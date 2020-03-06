using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalayer.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.FacilityId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "JobClass",
                columns: table => new
                {
                    JobClassId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobClass", x => x.JobClassId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    SpecialtyId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.SpecialtyId);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Vitals",
                columns: table => new
                {
                    VitalId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitals", x => x.VitalId);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    WardId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FacilityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.WardId);
                    table.ForeignKey(
                        name: "FK_Ward_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkUnit",
                columns: table => new
                {
                    WorkUnitId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    FacilityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkUnit", x => x.WorkUnitId);
                    table.ForeignKey(
                        name: "FK_WorkUnit_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorSupply",
                columns: table => new
                {
                    VendorSupplyId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    VendorId = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorSupply", x => x.VendorSupplyId);
                    table.ForeignKey(
                        name: "FK_VendorSupply_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorSupply_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    BedId = table.Column<string>(nullable: false),
                    RoomNumber = table.Column<string>(nullable: true),
                    WorkUnitId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_Bed_WorkUnit_WorkUnitId",
                        column: x => x.WorkUnitId,
                        principalTable: "WorkUnit",
                        principalColumn: "WorkUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PersonType = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    DateHired = table.Column<DateTime>(nullable: true),
                    EmployeeType = table.Column<string>(nullable: true),
                    NurseId = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    License = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true),
                    JobClassId = table.Column<string>(nullable: true),
                    TechnicianId = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true),
                    ContactRelationship = table.Column<string>(nullable: true),
                    DateOfContact = table.Column<string>(nullable: true),
                    MedicalRecordNumber = table.Column<string>(nullable: true),
                    InsuranceCompanyName = table.Column<string>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    GroupNumber = table.Column<string>(nullable: true),
                    InsurancePhoneNumber = table.Column<string>(nullable: true),
                    PatientType = table.Column<string>(nullable: true),
                    ContactPersonId = table.Column<string>(nullable: true),
                    InpatientId = table.Column<string>(nullable: true),
                    DateAdmitted = table.Column<DateTime>(nullable: true),
                    DischargeDate = table.Column<DateTime>(nullable: true),
                    BedId = table.Column<string>(nullable: true),
                    WardId = table.Column<string>(nullable: true),
                    OutpatientId = table.Column<string>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    PhysicianId = table.Column<string>(nullable: true),
                    PagerNumber = table.Column<string>(nullable: true),
                    DEANumber = table.Column<string>(nullable: true),
                    VolunteerId = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    HoursWorked = table.Column<int>(nullable: true),
                    SupervisorId = table.Column<string>(nullable: true),
                    WorkUnitId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Bed_BedId",
                        column: x => x.BedId,
                        principalTable: "Bed",
                        principalColumn: "BedId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_JobClass_JobClassId",
                        column: x => x.JobClassId,
                        principalTable: "JobClass",
                        principalColumn: "JobClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_WorkUnit_WorkUnitId",
                        column: x => x.WorkUnitId,
                        principalTable: "WorkUnit",
                        principalColumn: "WorkUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    DiagnosisId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    PhysicianId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.DiagnosisId);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Persons_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSpecialty",
                columns: table => new
                {
                    EmployeeSpecialtyId = table.Column<string>(nullable: false),
                    DateAcquired = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    SpecialtyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSpecialty", x => x.EmployeeSpecialtyId);
                    table.ForeignKey(
                        name: "FK_EmployeeSpecialty_Persons_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeSpecialty_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacilityPhysician",
                columns: table => new
                {
                    FacilityPhysicianId = table.Column<string>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<string>(nullable: true),
                    PhysicianId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityPhysician", x => x.FacilityPhysicianId);
                    table.ForeignKey(
                        name: "FK_FacilityPhysician_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilityPhysician_Persons_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Instructions = table.Column<string>(nullable: true),
                    PhysicianId = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Persons_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientOrder",
                columns: table => new
                {
                    PatientOrderId = table.Column<string>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientOrder", x => x.PatientOrderId);
                    table.ForeignKey(
                        name: "FK_PatientOrder_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhysicianSpecialty",
                columns: table => new
                {
                    PhysicianSpecialtyId = table.Column<string>(nullable: false),
                    DateAcquired = table.Column<DateTime>(nullable: false),
                    PhysicianId = table.Column<string>(nullable: true),
                    SpecialtyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicianSpecialty", x => x.PhysicianSpecialtyId);
                    table.ForeignKey(
                        name: "FK_PhysicianSpecialty_Persons_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicianSpecialty_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    TreatmentId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    PhysicianId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.TreatmentId);
                    table.ForeignKey(
                        name: "FK_Treatment_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Persons_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitEmployee",
                columns: table => new
                {
                    UnitEmployeeId = table.Column<string>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    WorkUnitId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitEmployee", x => x.UnitEmployeeId);
                    table.ForeignKey(
                        name: "FK_UnitEmployee_Persons_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitEmployee_WorkUnit_WorkUnitId",
                        column: x => x.WorkUnitId,
                        principalTable: "WorkUnit",
                        principalColumn: "WorkUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitId = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    OutpatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visit_Persons_OutpatientId",
                        column: x => x.OutpatientId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VitalRecord",
                columns: table => new
                {
                    VitalRecordId = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    VitalId = table.Column<string>(nullable: true),
                    NurseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalRecord", x => x.VitalRecordId);
                    table.ForeignKey(
                        name: "FK_VitalRecord_Persons_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VitalRecord_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VitalRecord_Vitals_VitalId",
                        column: x => x.VitalId,
                        principalTable: "Vitals",
                        principalColumn: "VitalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerSpecialty",
                columns: table => new
                {
                    VolunteerSpecialtyId = table.Column<string>(nullable: false),
                    Expertise = table.Column<string>(nullable: true),
                    SpecialtyId = table.Column<string>(nullable: true),
                    VolunteerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerSpecialty", x => x.VolunteerSpecialtyId);
                    table.ForeignKey(
                        name: "FK_VolunteerSpecialty_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VolunteerSpecialty_Persons_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WardEmployee",
                columns: table => new
                {
                    WardEmployeeId = table.Column<string>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    WardId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardEmployee", x => x.WardEmployeeId);
                    table.ForeignKey(
                        name: "FK_WardEmployee_Persons_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WardEmployee_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    OrderServiceId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderService", x => x.OrderServiceId);
                    table.ForeignKey(
                        name: "FK_OrderService_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PatientOrderId = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_PatientOrder_PatientOrderId",
                        column: x => x.PatientOrderId,
                        principalTable: "PatientOrder",
                        principalColumn: "PatientOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bed_WorkUnitId",
                table: "Bed",
                column: "WorkUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_PatientId",
                table: "Diagnosis",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_PhysicianId",
                table: "Diagnosis",
                column: "PhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSpecialty_EmployeeId",
                table: "EmployeeSpecialty",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSpecialty_SpecialtyId",
                table: "EmployeeSpecialty",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityPhysician_FacilityId",
                table: "FacilityPhysician",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityPhysician_PhysicianId",
                table: "FacilityPhysician",
                column: "PhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PatientId",
                table: "Order",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PhysicianId",
                table: "Order",
                column: "PhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemId",
                table: "OrderItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_PatientOrderId",
                table: "OrderItem",
                column: "PatientOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_OrderId",
                table: "OrderService",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_ServiceId",
                table: "OrderService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOrder_PatientId",
                table: "PatientOrder",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_EmployeeId",
                table: "Persons",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BedId",
                table: "Persons",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_InpatientId",
                table: "Persons",
                column: "InpatientId",
                unique: true,
                filter: "[InpatientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_WardId",
                table: "Persons",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NurseId",
                table: "Persons",
                column: "NurseId",
                unique: true,
                filter: "[NurseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OutpatientId",
                table: "Persons",
                column: "OutpatientId",
                unique: true,
                filter: "[OutpatientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ContactPersonId",
                table: "Persons",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PatientId",
                table: "Persons",
                column: "PatientId",
                unique: true,
                filter: "[PatientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PhysicianId",
                table: "Persons",
                column: "PhysicianId",
                unique: true,
                filter: "[PhysicianId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_JobClassId",
                table: "Persons",
                column: "JobClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_StaffId",
                table: "Persons",
                column: "StaffId",
                unique: true,
                filter: "[StaffId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TechnicianId",
                table: "Persons",
                column: "TechnicianId",
                unique: true,
                filter: "[TechnicianId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SupervisorId",
                table: "Persons",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_WorkUnitId",
                table: "Persons",
                column: "WorkUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicianSpecialty_PhysicianId",
                table: "PhysicianSpecialty",
                column: "PhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicianSpecialty_SpecialtyId",
                table: "PhysicianSpecialty",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_PatientId",
                table: "Treatment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_PhysicianId",
                table: "Treatment",
                column: "PhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_ServiceId",
                table: "Treatment",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitEmployee_EmployeeId",
                table: "UnitEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitEmployee_WorkUnitId",
                table: "UnitEmployee",
                column: "WorkUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorSupply_ItemId",
                table: "VendorSupply",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorSupply_VendorId",
                table: "VendorSupply",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_OutpatientId",
                table: "Visit",
                column: "OutpatientId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalRecord_NurseId",
                table: "VitalRecord",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalRecord_PatientId",
                table: "VitalRecord",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalRecord_VitalId",
                table: "VitalRecord",
                column: "VitalId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerSpecialty_SpecialtyId",
                table: "VolunteerSpecialty",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerSpecialty_VolunteerId",
                table: "VolunteerSpecialty",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_FacilityId",
                table: "Ward",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_WardEmployee_EmployeeId",
                table: "WardEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WardEmployee_WardId",
                table: "WardEmployee",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkUnit_FacilityId",
                table: "WorkUnit",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "EmployeeSpecialty");

            migrationBuilder.DropTable(
                name: "FacilityPhysician");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderService");

            migrationBuilder.DropTable(
                name: "PhysicianSpecialty");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "UnitEmployee");

            migrationBuilder.DropTable(
                name: "VendorSupply");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "VitalRecord");

            migrationBuilder.DropTable(
                name: "VolunteerSpecialty");

            migrationBuilder.DropTable(
                name: "WardEmployee");

            migrationBuilder.DropTable(
                name: "PatientOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Vitals");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "JobClass");

            migrationBuilder.DropTable(
                name: "WorkUnit");

            migrationBuilder.DropTable(
                name: "Facility");
        }
    }
}
