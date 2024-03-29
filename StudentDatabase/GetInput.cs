﻿using static StudentDatabase.GlobalVariables;

namespace StudentDatabase
{
    internal class GetInput
    {
        public static uint GetInt()
        {
            bool isGood = false;
            uint output = 0;
            Console.Clear();
            Console.WriteLine($"Welcome! Which student would you like to learn more about?");

            do
            {
                Console.Write($"Enter the students name or number 1-{name.Length}\nEnter list to see a list of students : ");
                string input = Console.ReadLine().Trim();
                Console.Clear();

                if(list.Contains(input.ToLower()))
                {
                    Console.WriteLine("List of students");
                    for(int i = 0; i < name.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} {name[i]}");
                    }
                }
                else if(name.Contains(input))
                {
                    output = (uint)Array.IndexOf(name , input) + 1;
                    isGood = true;
                }
                else
                {
                    try
                    {
                        output = uint.Parse(input);
                        if(output > 0 && output <= name.Length) isGood = true;
                        else Console.WriteLine("That index is not listed");
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Sorry that is not a number.");                       
                    }
                    catch(OverflowException)
                    {
                        Console.WriteLine("Sorry that number is out of range.");                      
                    }
                }
            } while(!isGood);
            return output;
        }

        public static bool Continue()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("You you like to look up anouther student Y/N?");
                string input = Console.ReadLine().ToLower().Trim();
                if(yes.Contains(input)) return true;
                else if(no.Contains(input)) return false; 
            } while(true);
        }
    }
}