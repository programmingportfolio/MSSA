using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class Person
    {
        public static int Health { get; set; } = 100;
        Weapon weapon { get; set; } = new M4();
        public bool HasGrenade { get; set; } = false;

        public Person(bool hasGrenade = false)
        {
            if (hasGrenade)
            {
                HasGrenade = true;
            }
            
        }

        internal void FiftyFiftySprint()
        {
            throw new NotImplementedException();
        }

    }
}
