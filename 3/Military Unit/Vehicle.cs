using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class Vehicle
    {
        public virtual int Weight { get; set; }
        public virtual int Fuel { get; set; } = 100;
        public virtual int Health { get; set; } = 10000;

        public virtual double MPG { get; set;} = .1;

        public virtual Weapon WeaponAttachment { get; set; } = null;

        Person CurrentDriver { get; set; }

        Person Gunner { get; set; }

        public Vehicle()
        {
            return;
        }

        public Vehicle(Person driver, Person gunner = null)
        {
            CurrentDriver = driver;
            Gunner = gunner;
            if(gunner != null)
            {
                WeaponAttachment = new _50Cal();
            }

            Console.WriteLine("Successfully created vehicle attached with person");
            
        }

        public virtual void ExitVehicle()
        {
            if (CurrentDriver.HasGrenade)
            {

            }
            else
            {
                CurrentDriver.FiftyFiftySprint();
            }
        }

        public virtual void GoBackVehicle(Person driver, Person gunner = null)
        {
            CurrentDriver = driver;
            Gunner = gunner;
        }



    }
}
