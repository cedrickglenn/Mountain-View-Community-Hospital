using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using NUnit.Framework;
using Servicelayer.BaseClassService;

namespace Tests
{
    public class ProcedureTests
    {
        [Test]
        public void AddProcedureTest()
        {
            var serv = new ProcedureService(new MVCHContext());
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.01",
                Name = "Therapeutic ultrasound of vessels of head and neck"
            });
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.02",
                Name = "Therapeutic ultrasound of heart"
            }); 
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.03",
                Name = "Therapeutic ultrasound of peripheral vascular vessels"
            });
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.09",
                Name = "Other therapeutic ultrasound"
            });
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.91",
                Name = "Transplant from live related donor"
            });
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.92",
                Name = "Transplant from live non-related donor"
            });
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.93",
                Name = "Transplant from cadaver"
            });
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.94",
                Name = "Intra-operative neurophysiologic monitoring"
            });
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.95",
                Name = "Injection or infusion of glucarpidase"
            });
            serv.AddProcedure(new Procedure
            {
                ProcedureId = "00.96",
                Name = "Infusion 4F-PCC"
            });
        }
    }
}
