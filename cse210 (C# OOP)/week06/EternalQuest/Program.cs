using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();

    }
} 

//I added a verification in the SimpleGoal and CheckListGoal Classes whenever you will Register that you've already finished it, if you already have done it the program won't let you complete it again.