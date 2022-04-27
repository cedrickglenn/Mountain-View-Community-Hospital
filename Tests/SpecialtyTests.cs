using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using NUnit.Framework;
using Servicelayer.BaseClassService;

namespace Tests
{
    public class SpecialtyTests
    {
        [Test]
        public void AddSpecialtyTest()
        {
            var serv = new SpecialtyService(new MVCHContext());
            serv.AddSpecialty(new Specialty
            {
                Name = "Cardiology",
                Description = "Specializes with the disorders of the heart"
            });
            serv.AddSpecialty(new Specialty
            {
                Name = "Neurology",
                Description = "Specializes with the disorders of the nervous system"
            });
            serv.AddSpecialty(new Specialty
            {
                Name = "Gynecology",
                Description = "Specializes with the matters of the female reproductive system"
            });
            serv.AddSpecialty(new Specialty
            {
                Name = "Andrology",
                Description = "Specializes with the matters of the male reproductive system"
            });
            serv.AddSpecialty(new Specialty
            {
                Name = "Optometry",
                Description = "Specializes with the matters of the eyes"
            });
        }
    }
}
