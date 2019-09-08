using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class M4 : Weapon
    {
        public override int Range { get; set; } = 2;
        protected override int Accuracy { get; set; } = 60;
        protected override double DamageMultiplier { get; set; }
        public override int BaseDamage { get; set; } = 50;
        int EffectiveDamage { get; set; }
        public override int GetSituationDamage(object opposition)
        {
            if (opposition is Vehicle)
            {
                DamageMultiplier = .01;
                int EffectiveDamage = Convert.ToInt32(Math.Ceiling(BaseDamage * DamageMultiplier));
                return EffectiveDamage;
            }
            else
            {
                EffectiveDamage = BaseDamage;
                return EffectiveDamage;
            }

        }
    }
}
