using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class _50Cal : Weapon
    {
        public sealed override int Range { get; set; } = 2;
        protected override int Accuracy { get; set; } = 60;
        protected override double DamageMultiplier { get; set; }
        public override int BaseDamage { get; set; } = 10000;
        int EffectiveDamage { get; set; }

        public override int TotalAmmo { get; set; } = 1000;

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
