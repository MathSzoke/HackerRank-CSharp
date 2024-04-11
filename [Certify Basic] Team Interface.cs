/*
Implement inheritance as described below.

Create a class Team that has the following:

A member variable teamName [string].
A member variable noOfPlayers [integer].
A constructor function:
It takes 2 parameters and assigns them to teamName and noOfPlayers respectively.
A member function AddPlayer(count):
It takes an integer count as a parameter and increases noOfPlayers by count.
A member function RemovePlayer(count):
It takes an integer count as a parameter and tries to decrease noOfPlayers by count.
If decreasing makes noOfPlayers negative, then this function simply returns false.
Else, decrease noOfPlayers by count and return true.
Create a class Subteam that inherits from the above class Team. It has the following:

A constructor function:
It takes 2 parameters, teamName and noOfPlayers, and calls the base class constructor with these parameters.
A member function ChangeTeamName(name):
It takes a string name as a parameter and changes teamName to name.
Note: Declare all the members as public so that they are accessible by the stubbed code.

Your implementation of the function will be tested by a stubbed code on several input files.
Each input file contains parameters for the function calls.
The functions will be called with those parameters, and the result of their executions will be printed to the standard output by the stubbed code.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
	public class Team
	{
		public string teamName;
		public int noOfPlayers;

		public Team(string teamName, int noOfPlayers)
		{
			this.teamName = teamName;
			this.noOfPlayers = noOfPlayers;
		}

		public void AddPlayer(int count)
		{
			noOfPlayers += count;
		}

		public bool RemovePlayer(int count)
		{
			if (noOfPlayers - count < 0)
			{
				return false;
			}
			else
			{
				noOfPlayers -= count;
				return true;
			}
		}
	}

	public class Subteam : Team
	{
		public Subteam(string teamName, int noOfPlayers) : base(teamName, noOfPlayers)
		{
		}

		public void ChangeTeamName(string name)
		{
			teamName = name;
		}
	}
    

    class Solution
	{
         static void Main(string[] args)
		 {

            if (!typeof(Subteam).IsSubclassOf(typeof(Team)))
			{
                throw new Exception("Subteam class should inherit from Team class");
            }
            
            String str = Console.ReadLine();
            String[] strArr = str.Split();
            string initialName = strArr[0];
            int count = Convert.ToInt32(strArr[1]);
            Subteam teamObj = new Subteam(initialName, count);
            Console.WriteLine("Team " + teamObj.teamName + " created");
            
            str = Console.ReadLine();
            count = Convert.ToInt32(str);
            Console.WriteLine("Current number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
            teamObj.AddPlayer(count);
            Console.WriteLine("New number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
            
            
            str = Console.ReadLine();
            count = Convert.ToInt32(str);
            Console.WriteLine("Current number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
            var res = teamObj.RemovePlayer(count);
            if (res) {
                Console.WriteLine("New number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
            } else {
                Console.WriteLine("Number of players in team " + teamObj.teamName + " remains same");
            }
            
            str = Console.ReadLine();
            teamObj.ChangeTeamName(str);
            Console.WriteLine("Team name of team " + initialName + " changed to " + teamObj.teamName);
        }
    }
}