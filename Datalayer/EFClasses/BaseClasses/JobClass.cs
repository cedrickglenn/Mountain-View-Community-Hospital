using System.Collections.Generic;
using Datalayer.EFClasses.BaseClasses.PersonClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class JobClass
    {
        public string JobClassId { get; set; }
        public string Name { get; set; }

        public ICollection<Staff>? Staff { get; set; }
    }
}
