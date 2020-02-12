﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    public class StartUp
    {
        public static void Main()
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            List<int> defensePlates = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> warriorsPower = new Stack<int>();

            for (int i = 1; i <= numberOfWaves; i++)
            {
                int[] inputWarriorPower = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int k = 0; k < inputWarriorPower.Length; k++)
                {
                    warriorsPower.Push(inputWarriorPower[k]);
                }

                if (i % 3 == 0)
                {
                    int extraPalte = int.Parse(Console.ReadLine());

                    defensePlates.Add(extraPalte);
                }

                while (defensePlates.Any() && warriorsPower.Any())
                {
                    int currentPlate = defensePlates[0];
                    int currentWarrior = warriorsPower.Peek();

                    if (currentPlate == currentWarrior)
                    {
                        defensePlates.RemoveAt(0);
                        warriorsPower.Pop();
                    }

                    if (currentPlate > currentWarrior)
                    {
                        defensePlates[0] -= currentWarrior;
                        warriorsPower.Pop();
                    }

                    if (currentWarrior > currentPlate)
                    {
                        warriorsPower.Push(warriorsPower.Pop() - currentPlate);
                        defensePlates.RemoveAt(0);
                    }
                }

                if (!defensePlates.Any())
                {
                    break;
                }
            }

            if (defensePlates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", defensePlates)}");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriorsPower)}");
            }
        }
    }
}
