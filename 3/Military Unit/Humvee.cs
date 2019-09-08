using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class Humvee : Vehicle
    {
        public override Weapon WeaponAttachment { get; set; } = new _50Cal();
        public Humvee(Person driver, Person gunner = null)
            : base(driver, gunner)
        {

        }
}
}
