using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class MissileSystem : Weapon
    {
        int Range { get; set; } = 360;
        int Accuracy { get; set; } = 100;
        int DamageMultiplier { get; set; } = 1;
    }
}
