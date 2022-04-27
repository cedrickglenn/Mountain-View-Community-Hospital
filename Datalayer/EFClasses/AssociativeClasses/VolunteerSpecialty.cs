using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.AssociativeClasses
{
    public class VolunteerSpecialty
    {
        public string VolunteerSpecialtyId { get; set; }
        public DateTime? DateAcquired { get; set; }

        public Specialty SpecialtyLink { get; set; }
        public Volunteer VolunteerLink { get; set; }
        public string SpecialtyId { get; set; }
        public string VolunteerId { get; set; }

    }
}
