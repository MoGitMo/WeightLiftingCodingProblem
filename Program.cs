using System;
using System.Collections;
using System.Collections.Generic;

namespace WeightLiftingCodingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string prompt = "Please enter weight or -1 to exit application";
            Console.WriteLine(prompt);
            string intput = Console.ReadLine();

            while (intput != "-1")
            {
                const int barWeight = 45;
                double weightInput;

                if (!Double.TryParse(intput, out weightInput))
                    Console.WriteLine("{0} is not a valid input.", intput);

                else if (weightInput < barWeight)
                    Console.WriteLine("Not Rackable.");

                else if (weightInput == barWeight)
                    Console.WriteLine("Empty bar.");
                else
                {
                    //Plate sizes
                    double[] platesArr = { 45, 35, 25, 10, 5, 2.5 };

                    //Create list of plates on bar
                    List<Plate> plateList = new List<Plate>();

                    //Substract bar weight
                    double remainder = weightInput - barWeight;

                    foreach (double denom in platesArr)
                    {
                        double twoPlates = denom * 2;
                        if (remainder >= twoPlates)
                        {
                            Plate plate = new Plate();
                            plate.Denomination = denom;
                            while (remainder >= twoPlates)
                            {
                                remainder = remainder - twoPlates;
                                plate.Quantity += 2;
                            }

                            plateList.Add(plate);
                        }
                    }
                    Console.WriteLine();
                    if (plateList.Count > 0)
                    {
                        Console.WriteLine("Plate distribution:");

                        foreach (Plate plate in plateList)
                        {
                            Console.WriteLine("{0} x {1}lbs", plate.Quantity.ToString(), plate.Denomination.ToString());
                        }
                    }

                    if (remainder > 0)
                        Console.WriteLine("Remainder: {0}lbs", remainder);
                   Console.WriteLine("Total weight to be lifted: {0}lbs", weightInput - remainder);
                }
                Console.WriteLine();
                Console.WriteLine(prompt);
                intput = Console.ReadLine();
            }
            Console.WriteLine("Stretch you must. May the gains be with you.");

        }


    }
}
