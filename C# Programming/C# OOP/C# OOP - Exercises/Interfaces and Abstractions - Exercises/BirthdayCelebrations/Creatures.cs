using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public abstract class IBirthable
    {
        public string Id { get; private set; }
        public string Birthdate { get; set; }
        public IBirthable(string id)
        {
            this.Id = id;
        }
    }
}
