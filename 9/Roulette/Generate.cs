using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    abstract class Generate
    {
        public static (int[], string[,]) RouletteTable()
        {
            var numbers = new int[38];
            var colorAndName = new string[38, 2];
            int i = 0;
            int stop = 37;
            for(; i < stop; i++)
            {
                if (i == 0)
                {
                    numbers[i] = 0;
                    colorAndName[i, 0] = "green";
                    colorAndName[i, 1] = "Green 0";

                }
                else if (i % 2 == 1)
                {
                    numbers[i] = i;
                    colorAndName[i, 0] = "red";
                    colorAndName[i, 1] = $"Red {i}";
                }
                else if (i % 2 == 0)
                {
                    numbers[i] = i;
                    colorAndName[i, 0] = "black";
                    colorAndName[i, 1] = $"Black {i}";
                }
            }
            numbers[i] = i;
            colorAndName[37, 0] = "green";
            colorAndName[37, 1] = $"Green 00 at {i}";

            return (numbers, colorAndName);
        }

        public static (int[], int[], int[]) BetNumbers()
        {
            var array1 = new int[36 / 3];
            var array2 = new int[36 / 3];
            var array3 = new int[36 / 3];
            var temp = new int[36];
            int i = 1;
            int j = 1;
            int array1i = 0;
            int array2i = 0;
            int array3i = 0;
            foreach(int number in temp)
            {
                if(j == 1)
                {
                    array1[array1i] = i;
                    i++;
                    j++;
                    array1i++;
                }
                else if(j == 2)
                {
                    array2[array2i] = i;
                    i++;
                    j++;
                    array2i++;
                }
                else if(j == 3)
                {
                    
                    array3[array3i] = i;
                    i++;
                    j = 1;
                    array3i++;
                }
            }

            return (array1, array2, array3);
        }

    }
}
