
using Assessment3_OOP;
// Initializes list of SiftMembers 
// Populated with (at least) one member and a skill
List<SiftMember> memberDatabase = new List<SiftMember>()
{
    new SiftMember
    (
        "brynn hamilton", 
        new DateTime(2021,6,11), 
        "Associate Software Engineer in Training", 
        "brynnhamilton1@rocketmortgage.com", 
        new List<string>(){"powerbi", "sql", "excel"}
    )
};
Console.WriteLine("Welcome to Sift!");
ValidInput();


void ValidInput()
{
    // Program continues unless the user decides to quit (ie: #4)
    bool toContinue = true;
    while(toContinue)
    {
        Console.WriteLine("What would you like to do? \n1. Add a team member \n2. Search for a team member and add skills \n3. Print all members \n4. Quit");
        Console.Write("Select an option: ");
        Console.WriteLine();
        string input = Console.ReadLine();
        if (int.TryParse(input, out int ValidInput))
        {
            if (ValidInput == 1)
            {
                AddTeamMember();
            }
            else if (ValidInput == 2)
            {
                SearchandAdd();
            }
            else if (ValidInput == 3)
            {
                PrintAllMembers();
            }
            else if (ValidInput == 4)
            {
                Console.WriteLine("Goodbye!");
                toContinue = false;
            }
        }
    }
 
}

// Give the user the ability to add a new SiftMember object to the list
void AddTeamMember()
{
    Console.Write("Enter the team member's name: ");
    string newName = Console.ReadLine().ToLower();

    Console.Write("\nEnter their anniversary (MM dd yyyy): ");
    string newAnniversary = Console.ReadLine();
    string[] subDates = newAnniversary.Split(" ");
    int month = Convert.ToInt32(subDates[0]);
    int day = Convert.ToInt32(subDates[1]);
    int year = Convert.ToInt32(subDates[2]);

    Console.Write("\nEnter their job title: ");
    string newTitle = Console.ReadLine();
    Console.Write("\nEnter their email: ");
    string newEmail = Console.ReadLine();
    Console.WriteLine();

    memberDatabase.Add(new SiftMember(newName, new DateTime(year, month, day), newTitle, newEmail, new List<string>()));

}

void AddSkills(SiftMember member)
{
    bool anotherSkill = true;
    while (anotherSkill)
    {
        Console.Write("\nEnter a skill, enter 'q' to stop adding skills: ");
        string newSkill = Console.ReadLine().ToLower();
        if (newSkill == "q" || newSkill == "quit")
        {
            anotherSkill = false;
        }
        else
        {
            bool success = member.AddSkill(newSkill);
            if(success == false)
            {
                Console.WriteLine("That sift member already has that skill.");
                anotherSkill = true;
            }
        }
    }
}
 
// Give the user the ability to search the members of Sift by name
// If the member exists, give the user the option to add skills for the searched user
void SearchandAdd()
{
    Console.Write("Enter the full name of the person you'd like to search for: ");
    string searchInput = Console.ReadLine().ToLower();
    bool found = false;
    foreach(SiftMember member in memberDatabase)
    {
        // If the member exists
        // the user is able to add multiple skills to one Sift member
        if(searchInput == member.Name)
        {
            AddSkills(member);
            found = true;
        }
    }
    if(found != true)
    {
        Console.WriteLine("Sorry, that person doesn't exist");
    }
}

// Give the user the ability to view all members of Sift
void PrintAllMembers()
{
    foreach(SiftMember member in memberDatabase)
    {
        Console.WriteLine(member.ToString());
    }
}