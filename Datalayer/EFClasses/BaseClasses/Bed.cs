using System.Collections.Generic;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Bed
    {
        public string BedId { get; set; }
        public string RoomNumber { get; set; }


        public ICollection<Inpatient> Inpatients { get; set; }
        public WorkUnit WorkUnitLink { get; set; }
        public string? WorkUnitId { get; set; }
    }
}
