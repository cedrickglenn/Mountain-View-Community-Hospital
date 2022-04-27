using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalayer.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    ConditionId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.ConditionId);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
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
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
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
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobClass", x => x.JobClassId);
                });

            migrationBuilder.CreateTable(
                name: "Procedure",
                columns: table => new
                {
                    ProcedureId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure", x => x.ProcedureId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
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
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
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
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Vital",
                columns: table => new
                {
                    VitalId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vital", x => x.VitalId);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    WardId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FacilityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.WardId);
                    table.ForeignKey(
                        name: "FK_Ward_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId");
                });

            migrationBuilder.CreateTable(
                name: "WorkUnit",
                columns: table => new
                {
                    WorkUnitId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Floor = table.Column<string>(nullable: false),
                    FacilityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkUnit", x => x.WorkUnitId);
                    table.ForeignKey(
                        name: "FK_WorkUnit_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId");
                });

            migrationBuilder.CreateTable(
                name: "VendorSupply",
                columns: table => new
                {
                    VendorSupplyId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    VendorId = table.Column<string>(nullable: false),
                    ItemId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorSupply", x => x.VendorSupplyId);
                    table.ForeignKey(
                        name: "FK_VendorSupply_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_VendorSupply_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId");
                });

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    BedId = table.Column<string>(nullable: false),
                    RoomNumber = table.Column<string>(nullable: false),
                    WorkUnitId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_Bed_WorkUnit_WorkUnitId",
                        column: x => x.WorkUnitId,
                        principalTable: "WorkUnit",
                        principalColumn: "WorkUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MiddleInitial = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DateHired = table.Column<DateTime>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    License = table.Column<string>(nullable: true),
                    JobClassId = table.Column<string>(nullable: true),
                    Technician_License = table.Column<string>(nullable: true),
                    ContactRelationship = table.Column<string>(nullable: true),
                    SubscriberRelationship = table.Column<string>(nullable: true),
                    DateOfContact = table.Column<DateTime>(nullable: true),
                    MedicalRecordNumber = table.Column<string>(nullable: true),
                    InsuranceCompanyName = table.Column<string>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    GroupNumber = table.Column<string>(nullable: true),
                    InsurancePhoneNumber = table.Column<string>(nullable: true),
                    ContactPersonId = table.Column<string>(nullable: true),
                    SubscriberPersonId = table.Column<string>(nullable: true),
                    DateAdmitted = table.Column<DateTime>(nullable: true),
                    DischargeDate = table.Column<DateTime>(nullable: true),
                    BedId = table.Column<string>(nullable: true),
                    WardId = table.Column<string>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    PagerNumber = table.Column<string>(nullable: true),
                    DEANumber = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    HoursWorked = table.Column<int>(nullable: true),
                    SupervisorId = table.Column<string>(nullable: true),
                    WorkUnitId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Bed_BedId",
                        column: x => x.BedId,
                        principalTable: "Bed",
                        principalColumn: "BedId");
                    table.ForeignKey(
                        name: "FK_Person_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "WardId");
                    table.ForeignKey(
                        name: "FK_Person_Person_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Person_SubscriberPersonId",
                        column: x => x.SubscriberPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_JobClass_JobClassId",
                        column: x => x.JobClassId,
                        principalTable: "JobClass",
                        principalColumn: "JobClassId");
                    table.ForeignKey(
                        name: "FK_Person_Person_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Person_WorkUnit_WorkUnitId",
                        column: x => x.WorkUnitId,
                        principalTable: "WorkUnit",
                        principalColumn: "WorkUnitId");
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    DiagnosisId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ConditionId = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: false),
                    PhysicianId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.DiagnosisId);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "ConditionId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnosis_Person_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSpecialty",
                columns: table => new
                {
                    EmployeeSpecialtyId = table.Column<string>(nullable: false),
                    DateAcquired = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false),
                    SpecialtyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSpecialty", x => x.EmployeeSpecialtyId);
                    table.ForeignKey(
                        name: "FK_EmployeeSpecialty_Person_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_EmployeeSpecialty_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId");
                });

            migrationBuilder.CreateTable(
                name: "FacilityPhysician",
                columns: table => new
                {
                    FacilityPhysicianId = table.Column<string>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<string>(nullable: false),
                    PhysicianId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityPhysician", x => x.FacilityPhysicianId);
                    table.ForeignKey(
                        name: "FK_FacilityPhysician_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId");
                    table.ForeignKey(
                        name: "FK_FacilityPhysician_Person_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Instructions = table.Column<string>(nullable: false),
                    PhysicianId = table.Column<string>(nullable: true),
                    PatientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Order_Person_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "PatientOrder",
                columns: table => new
                {
                    PatientOrderId = table.Column<string>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientOrder", x => x.PatientOrderId);
                    table.ForeignKey(
                        name: "FK_PatientOrder_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "PhysicianSpecialty",
                columns: table => new
                {
                    PhysicianSpecialtyId = table.Column<string>(nullable: false),
                    DateAcquired = table.Column<DateTime>(nullable: false),
                    PhysicianId = table.Column<string>(nullable: false),
                    SpecialtyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicianSpecialty", x => x.PhysicianSpecialtyId);
                    table.ForeignKey(
                        name: "FK_PhysicianSpecialty_Person_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_PhysicianSpecialty_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId");
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    TreatmentId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: false),
                    PhysicianId = table.Column<string>(nullable: false),
                    ProcedureId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.TreatmentId);
                    table.ForeignKey(
                        name: "FK_Treatment_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Treatment_Person_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Treatment_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedure",
                        principalColumn: "ProcedureId");
                });

            migrationBuilder.CreateTable(
                name: "UnitEmployee",
                columns: table => new
                {
                    UnitEmployeeId = table.Column<string>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    WorkUnitId = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitEmployee", x => x.UnitEmployeeId);
                    table.ForeignKey(
                        name: "FK_UnitEmployee_Person_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_UnitEmployee_WorkUnit_WorkUnitId",
                        column: x => x.WorkUnitId,
                        principalTable: "WorkUnit",
                        principalColumn: "WorkUnitId");
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitId = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    OutpatientId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visit_Person_OutpatientId",
                        column: x => x.OutpatientId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "VitalRecord",
                columns: table => new
                {
                    VitalRecordId = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: false),
                    VitalId = table.Column<string>(nullable: false),
                    NurseId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalRecord", x => x.VitalRecordId);
                    table.ForeignKey(
                        name: "FK_VitalRecord_Person_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_VitalRecord_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_VitalRecord_Vital_VitalId",
                        column: x => x.VitalId,
                        principalTable: "Vital",
                        principalColumn: "VitalId");
                });

            migrationBuilder.CreateTable(
                name: "VolunteerSpecialty",
                columns: table => new
                {
                    VolunteerSpecialtyId = table.Column<string>(nullable: false),
                    DateAcquired = table.Column<DateTime>(nullable: true),
                    SpecialtyId = table.Column<string>(nullable: false),
                    VolunteerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerSpecialty", x => x.VolunteerSpecialtyId);
                    table.ForeignKey(
                        name: "FK_VolunteerSpecialty_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId");
                    table.ForeignKey(
                        name: "FK_VolunteerSpecialty_Person_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "WardEmployee",
                columns: table => new
                {
                    WardEmployeeId = table.Column<string>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    WardId = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardEmployee", x => x.WardEmployeeId);
                    table.ForeignKey(
                        name: "FK_WardEmployee_Person_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_WardEmployee_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "WardId");
                });

            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    OrderServiceId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderService", x => x.OrderServiceId);
                    table.ForeignKey(
                        name: "FK_OrderService_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrderService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PatientOrderId = table.Column<string>(nullable: false),
                    ItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_OrderItem_PatientOrder_PatientOrderId",
                        column: x => x.PatientOrderId,
                        principalTable: "PatientOrder",
                        principalColumn: "PatientOrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bed_WorkUnitId",
                table: "Bed",
                column: "WorkUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_ConditionId",
                table: "Diagnosis",
                column: "ConditionId");

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
                name: "IX_Person_BedId",
                table: "Person",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_WardId",
                table: "Person",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ContactPersonId",
                table: "Person",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_SubscriberPersonId",
                table: "Person",
                column: "SubscriberPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_JobClassId",
                table: "Person",
                column: "JobClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_SupervisorId",
                table: "Person",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_WorkUnitId",
                table: "Person",
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
                name: "IX_Treatment_ProcedureId",
                table: "Treatment",
                column: "ProcedureId");

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
                name: "Condition");

            migrationBuilder.DropTable(
                name: "PatientOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Procedure");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Vital");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "Person");

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
