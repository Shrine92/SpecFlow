using System;
using System.Collections.Generic;
using GameCore.New;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GameCore.Specs
{
    [Binding]
    public static class CustomConversions
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public static DateTime DaysAgoTransformation(int days)
            => DateTime.Now.Subtract(TimeSpan.FromDays(days));

        [StepArgumentTransformation]
        public static IEnumerable<WeaponClass> DaysAgoTransformation(Table table)
            => table.CreateSet<WeaponClass>();
    }
}
