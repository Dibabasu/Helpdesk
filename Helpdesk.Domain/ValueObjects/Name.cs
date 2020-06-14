using Helpdesk.Domain.Infrastructure;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public String FirstMidName { get; private set; }

        public String LastName { get; private set; }

        private Name()
        {
        }

        public Name(string firstmidname, string lastname)
        {
            FirstMidName = firstmidname;
            LastName = lastname;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstMidName;
            yield return LastName;
        }
    }
}