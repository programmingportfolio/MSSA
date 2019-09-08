using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class Weapon
    {
        public virtual int Range { get; set; }
        protected virtual int Accuracy { get; set; }
        protected virtual double DamageMultiplier { get; set; }
        public virtual int BaseDamage { get; set; } = 100;
        public virtual int TotalAmmo { get; set; }
        public virtual int ReloadSpeed { get; set; } = 2;

        int EffectiveDamage { get; set; }

        int AmmoCapacity { get; set; } = 120;

        public virtual int GetSituationDamage(object opposition)
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
