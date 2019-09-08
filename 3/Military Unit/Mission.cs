using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Unit
{
    class Mission
    {
        static int distance = 100;
        public static void MoveAnotherBase(List<Vehicle> vehicles)
        {
            foreach(Vehicle vehicle in vehicles)
            {
                vehicle.Fuel -= FuelCost(distance, vehicle.MPG);
               
            }
            Console.WriteLine("You have completed your journey.");
        }

        static int FuelCost(int Distance, double mpg)
        {
            return Convert.ToInt32(Math.Ceiling(Distance * mpg));
        }
    }
}
