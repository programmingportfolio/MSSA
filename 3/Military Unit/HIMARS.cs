using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class HIMARS : Vehicle
    {
        public new Weapon WeaponAttachment = new MissileSystem();

        public HIMARS(Person driver, Person gunner = null)
            : base(driver, gunner)
        {

        }

    }
}
