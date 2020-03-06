using System;
using System.Collections.Generic;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses.PersonClasses
{
    public class Volunteer : Person
    {
        public string VolunteerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HoursWorked { get; set; }

        public Person SupervisorLink { get; set; }
        public WorkUnit WorkUnitLink { get; set; }
        public ICollection<VolunteerSpecialty> VolunteerSpecialties { get; set; }
        public string? SupervisorId { get; set; }
        public string? WorkUnitId { get; set; }
    }
}
