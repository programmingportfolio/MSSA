using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class App
    {
        public void Run()
        {

            var onFoot = new List<Person>();
            var driver1 = new Person();
            var driver2 = new Person();
            var driver3 = new Person();
            var driver4 = new Person();
            var driver5 = new Person();
            var driver6 = new Person();
            var himars1 = new HIMARS(driver1);
            var himars2 = new HIMARS(driver2);
            var himars3 = new HIMARS(driver3);
            var himars4 = new HIMARS(driver4);
            var humvee1 = new Humvee(driver5);
            var humvee2 = new Humvee(driver6);
            var vehicles = new List<Vehicle>() { himars1, himars2, himars3, himars4, humvee1, humvee2};
            Mission.MoveAnotherBase(vehicles);


        }
    }
}
