using System;
using System.ComponentModel;

namespace Catalyst.Data.Entities
{
    public class CatalystMember
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int age { get; set; }

        public string interests { get; set; }

        public byte[] picture { get; set; }



    }
}
