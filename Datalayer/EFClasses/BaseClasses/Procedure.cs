using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Procedure
    {
        public string ProcedureId { get; set; }
        public string Name { get; set; }

        public ICollection<Treatment>? Treatments { get; set; }
    }
}
