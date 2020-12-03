using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain
{
    public class DateTimeValueObject : ValueObject
    {
        private DateTime value;

        public DateTimeValueObject(DateTime value)
        {
            this.value = value;
        }

        public DateTime GetValue()
        {
            return this.value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.value;
        }
    }
}
