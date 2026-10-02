class GoalManager
{
    public int _score = 0;
    private List<Goal> _goals = new List<Goal>();

    public GoalManager()
    {
    }
    public void Start()
    {
        int exit = 0;

        while (exit != 6)
        {
            //Console.Clear();
            Console.WriteLine($"You have {_score} points");
            Console.WriteLine("[1] - Create New Goal\n[2] - List Goals\n[3] - Save Goals\n[4] - Load Goals\n[5] - Record Event\n[6] - Quit");

            string choice = Console.ReadLine();
            int intChoice = int.Parse(choice);

            if (intChoice == 1)//New goal
            {
                CreateGoal();
            }
            else if (intChoice == 2)//List goal
            {
                ListGoalDetails();
            }
            else if (intChoice == 3)//Save goals
            {
                SaveGoals();
            }
            else if (intChoice == 4)//Load goals
            {
                LoadGoals();
            }
            else if (intChoice == 5)//Record events
            {
                ListGoalNames();
                RecordEvent();
            }
            else if (intChoice == 6)//Quit
            {
                Console.WriteLine("Seeya...");
                exit = intChoice;
            }
            else //User inputs invalid number
            {
                Console.WriteLine("Invalid option");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }

    }
    public void RecordEvent()
    {
        string selected = Console.ReadLine();
        int selectedInt = int.Parse(selected);
        int trueChosen = selectedInt - 1;

        int plus = _goals[trueChosen].RecordEvent();
        _score += plus;
    }
    public void ListGoalNames()
    {
        int i = 1;
        Console.WriteLine("Which goal you want to record an event of? ");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }
    public void ListGoalDetails()
    {
        Console.Clear();
        int i = 1;
        string mark = "";
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete() == true)
            {
                mark = "X";
            }
            else
            {
                mark = "";
            }
            Console.WriteLine($"{i}. [{mark}] {goal.GetDetailsString()}");
            i++;
        }
    }
    public void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("What kind of goal you want to create?:");
        Console.WriteLine("[1] - Simple Goal\n[2] - Eternal Goal\n[3] - Checklist Goal");

        string goalType = Console.ReadLine();
        int goalTypeInt = int.Parse(goalType);

        if (goalTypeInt == 1)     //Simple goal
        {
            Console.WriteLine("What is the goal? ");
            string goal = Console.ReadLine();

            Console.WriteLine("What'd be a short description of it? ");
            string description = Console.ReadLine();

            Console.WriteLine("How many points will you receive after completing it? ");
            string points = Console.ReadLine();

            SimpleGoal simpleGoal = new SimpleGoal(goal, description, points);
            _goals.Add(simpleGoal);

        }
        else if (goalTypeInt == 2)//Eternal goal
        {
            Console.WriteLine("What is the goal? ");
            string goal = Console.ReadLine();

            Console.WriteLine("What'd be a short description of it? ");
            string description = Console.ReadLine();

            Console.WriteLine("How many points will you receive after completing it? ");
            string points = Console.ReadLine();

            EternalGoal eternalGoal = new EternalGoal(goal, description, points);
            _goals.Add(eternalGoal);
        }
        else if (goalTypeInt == 3)//Checklist goal
        {
            Console.WriteLine("What is the goal? ");
            string goal = Console.ReadLine();

            Console.WriteLine("What'd be a short description of it? ");
            string description = Console.ReadLine();

            Console.WriteLine("How many points will you receive everytime you complete it? ");
            string ePoints = Console.ReadLine();

            Console.WriteLine("How many times will you do it before it is finished? ");
            string finished = Console.ReadLine();
            int finishedInt = int.Parse(finished);

            Console.WriteLine("How many bonus points will you receive after completing it? ");
            string bonusPoints = Console.ReadLine();
            int bonusPointsInt = int.Parse(bonusPoints);

            CheckListGoal checkListGoal = new CheckListGoal(goal, description, ePoints, finishedInt, bonusPointsInt);

            _goals.Add(checkListGoal);

        }
        else //invalid input
        {
            Console.Clear();
            Console.WriteLine("Invalid option");
        }
    }
    public void SaveGoals()
    {
        Console.WriteLine("What will be the name of the file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter("../../../" + filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals()
    {
        Console.WriteLine("What's the name of the file you wanna open? ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines("../../../" + filename);

        string firstLine = File.ReadLines("../../../" + filename).First();

        _score = int.Parse(firstLine);

        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(":");

            string id = parts[0];
            string name = parts[1];
            string description = parts[2];
            string points = parts[3];

            if (id == "Simplegoal")
            {
                string status = parts[4];
                bool statusBool = bool.Parse(status);
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                simpleGoal.SetCompletion(statusBool);

                _goals.Add(simpleGoal);
            }
            else if (id == "Checklistgoal")
            {
                string bonusPoints = parts[4];
                string target = parts[5];
                string amountComplete = parts[6];
                int bonusPointsInt = int.Parse(bonusPoints);
                int targetInt = int.Parse(target);
                int amountCompleteInt = int.Parse(amountComplete);

                CheckListGoal checkListGoal = new CheckListGoal(name, description, points, targetInt, bonusPointsInt);

                checkListGoal.SetAmoutComplete(amountCompleteInt);

                _goals.Add(checkListGoal);
            }
            else
            {
                EternalGoal eternalGoal = new EternalGoal(name, description, points);

                _goals.Add(eternalGoal);
            }
        }
    }
}