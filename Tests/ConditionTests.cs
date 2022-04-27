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
    public class ConditionTests
    {
        [Test]
        public void AddConditionTest()
        {
            var serv = new ConditionService(new MVCHContext());
            serv.AddCondition(new Condition
            {
                ConditionId = "001.0",
                Name = "Cholera d/t vib cholerae"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "001.1",
                Name = "Cholera d/t vib el tor"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "001.9",
                Name = "Cholera NOS"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "002.0",
                Name = "Typhoid Fever"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "002.1",
                Name = "Paratyphoid Fever A"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "002.2",
                Name = "Paratyphoid Fever B"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "002.3",
                Name = "Paratyphoid Fever C"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "002.9",
                Name = "Paratyphoid Fever NOS"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.0",
                Name = "Salmonella enteritis"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.1",
                Name = "Salmonella septicemia"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.2",
                Name = "Local Salmonella inf NOS"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.21",
                Name = "Salmonella meningitis"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.22",
                Name = "Salmonella pneumonia"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.23",
                Name = "Salmonella arthritis"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.24",
                Name = "Salmonella osteomyelitis"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.29",
                Name = "Local Salmonella inf NEC"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.8",
                Name = "Salmonella infection NEC"
            });
            serv.AddCondition(new Condition
            {
                ConditionId = "003.9",
                Name = "Salmonella infection NOS"
            });

        }
    }
}
