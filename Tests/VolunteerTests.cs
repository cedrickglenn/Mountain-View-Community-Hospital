using System;
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
    public class VolunteerTests
    {
        [Test]
        public void AddVolunteerTest()
        {
            var serv = new VolunteerService(new MVCHContext());
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                HoursWorked = 0,
                SupervisorId = "PER-000011",
                WorkUnitId = "WKS-000001"

            });
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.MinValue,
                HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                SupervisorId = "PER-000012",
                WorkUnitId = "WKS-000002"
            });
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.MinValue,
                HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                SupervisorId = "PER-000013",
                WorkUnitId = "WKS-000003"
            });
            serv.AddVolunteer(new Volunteer
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
                    StartDate = DateTime.MinValue,
                    HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                    SupervisorId = "PER-000014",
                    WorkUnitId = "WKS-000004"
            });
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.MinValue,
                HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                SupervisorId = "PER-000015",
                WorkUnitId = "WKS-000005"
            });
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.MinValue,
                HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                SupervisorId = "PER-000016",
                WorkUnitId = "WKS-000006"
            });
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.MinValue,
                HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                SupervisorId = "PER-000017",
                WorkUnitId = "WKS-000007"

            });
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.MinValue,
                HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                SupervisorId = "PER-000018",
                WorkUnitId = "WKS-000008"
            });
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.MinValue,
                HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                SupervisorId = "PER-000019",
                WorkUnitId = "WKS-000009"
            });
            serv.AddVolunteer(new Volunteer
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
                StartDate = DateTime.MinValue,
                HoursWorked = DateTime.Now.Hour - DateTime.MinValue.Hour,
                SupervisorId = "PER-000020",
                WorkUnitId = "WKS-000010"
            });

        }
    }
}
