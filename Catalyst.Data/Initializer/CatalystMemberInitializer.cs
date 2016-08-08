using Catalyst.Data.Context;
using Catalyst.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Catalyst.Data.Initializer
{
    public class CatalystMemberInitializer : CreateDatabaseIfNotExists<CatalystDbContext>
    {
        protected override void Seed(CatalystDbContext context)
        {
            var clubMembers = new List<CatalystMember>{
                new CatalystMember { FirstName = "Peter", LastName =" Darson",  Address ="Newyork", age =22, interests="Movies"},
                new CatalystMember {FirstName = "David", LastName =" Jacob",  Address ="chicago", age =32, interests="Playing"},
                new CatalystMember {FirstName = "Christoper", LastName =" Nelson",  Address ="utah", age =42, interests="Reading"},
                new CatalystMember { FirstName = "Adam", LastName =" Nolan",  Address ="newjersey", age =25, interests="Travelling"}
            };

            clubMembers.ForEach(category => context.DbEntities.Add(category));
        }
    }
}
