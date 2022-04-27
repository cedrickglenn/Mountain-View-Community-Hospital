using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.AssociativeClasses;

namespace Datalayer.EFClasses.BaseClasses
{
    public class Condition
    {
        public string ConditionId { get; set; }
        public string Name { get; set; }

        public ICollection<Diagnosis>? Diagnoses { get; set; }

    }
}
