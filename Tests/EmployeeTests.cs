﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using NUnit.Framework;
using Servicelayer.BaseClassService;

namespace Tests
{
    public class EmployeeTests
    {
        [Test]
        public void AddEmployeeTests()
        {
            var serv = new EmployeeService(new MVCHContext());
            serv.AddNurse(new Nurse
            {
                FirstName = "Cedrick",
                LastName = "Sederiosa",
                MiddleInitial = "S.",
                Address = "3212 Kahel St., Sto. Domingo II, Pampanga",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "cedrickglenn@gmail.com",
                PhoneNumber = "+639495940509",
                Zip = "8000",
                Degree = "RN",
                License = "123"

            });
            serv.AddNurse(new Nurse
            {
                FirstName = "John",
                LastName = "Branzuela",
                MiddleInitial = "C.",
                Address = "Sasa Dose",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("10/04/1999", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "jb@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                Degree = "LPN",
                License = "123"
            });
            serv.AddNurse(new Nurse
            {
                FirstName = "Nathan",
                LastName = "Naanep",
                MiddleInitial = "G.",
                Address = "Ilonggo",
                City = "Koronadal City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("03/25/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "ahyahwa@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                Degree = "RN",
                License = "123"
            });
            serv.AddNurse(new Nurse
            {
                    FirstName = "Mecca",
                    LastName = "Umapas",
                    MiddleInitial = "S.",
                    Address = "Surigao",
                    City = "Surigao",
                    State = "Philippines",
                    BirthDate = DateTime.ParseExact("10/30/1999", "mm/dd/yyyy", new CultureInfo("en-PH")),
                    Email = "iwanttodestroykonoha@gmail.com",
                    PhoneNumber = "+63969696969",
                    Zip = "8000",
                    Degree = "LPN",
                    License = "123"
            });
            serv.AddStaff(new Staff
            {
                FirstName = "Yoshi",
                LastName = "Aizawa",
                MiddleInitial = "M.",
                Address = "Mintal",
                City = "Davao City",
                State = "Japan",
                BirthDate = DateTime.ParseExact("12/13/1999", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "ilovezan@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                JobClassId = "JOB-000001"
            });
            serv.AddStaff(new Staff
            {
                FirstName = "Adrian",
                LastName = "De Guzman",
                MiddleInitial = "A.",
                Address = "Ilonggo",
                City = "Tacurong City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("06/08/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "aids@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                JobClassId = "JOB-000001"
            });
            serv.AddStaff(new Staff
            {
                FirstName = "Abigail",
                LastName = "M.",
                MiddleInitial = "M.",
                Address = "3212 Kahel St., Sto. Domingo II, Pampanga",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "lalalaala@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                JobClassId = "JOB-000001"
            });
            serv.AddTechnician(new Technician
            {
                FirstName = "Anna",
                LastName = "O.",
                MiddleInitial = "O.",
                Address = "3212 Kahel St., Sto. Domingo II, Pampanga",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "lalalaala@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                License = "123"
            });
            serv.AddTechnician(new Technician
            {
                FirstName = "Katriana",
                LastName = "B.",
                MiddleInitial = "B.",
                Address = "3212 Kahel St., Sto. Domingo II, Pampanga",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "lalalaala@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                License = "123"
            });
            serv.AddTechnician(new Technician
            {
                FirstName = "Dexie",
                LastName = "Badilles",
                MiddleInitial = ".",
                Address = "Sasa",
                City = "Davao City",
                State = "Philippines",
                BirthDate = DateTime.ParseExact("09/02/2000", "mm/dd/yyyy", new CultureInfo("en-PH")),
                Email = "lalalaala@gmail.com",
                PhoneNumber = "+63969696969",
                Zip = "8000",
                License = "123"
            });

        }
    }
}
