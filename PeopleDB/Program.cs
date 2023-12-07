using PeopleDB;

/*
 
Opdracht: ga op zoek naar de comments die starten met TODO
en voeg daar de nodig code toe.
De opdrachten zitten in dit bestand, en in het bestand Group.cs
*/

Group group = new Group();
string filePath = "../../../database.json";

// try to load data
LoadFromDisk();

// Menu setup
Menu menu = new Menu();
menu.AddOption('1', "Set Group Name", SetGroupName);
menu.AddOption('2', "Add Person", AddPerson);
menu.AddOption('3', "Show Members", ShowMembers);

menu.Start();

// menu had ended. Save everything
SaveToDisk();


// Hier beginnen de opdrachten
void SetGroupName()
{
    // TODO: vraag om een groepsnaam en wijs die toe aan de groep
    Console.Write("Geef je groepsnaam: ");
    group.Name = Console.ReadLine();
}

void AddPerson()
{
    Person person = new Person();

    // TODO: vraag naam, leeftijd, en hobbies en wijs die toe aan de persoon
    Console.Write("Enter person's name: ");
    person.Name = Console.ReadLine();

    Console.Write("Enter person's age: ");
    int age;
    while (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.Write("Invalid input. Please enter a valid age: ");
    }
    person.Age = age;

    Console.Write("Enter person's hobbies (comma-separated): ");
    person.Hobbys = Console.ReadLine().Split(',').Select(h => h.Trim()).ToList();

    group.People.Add(person);
}
void ShowMembers()
{
    // TODO: toon de naam van de groep, en info over alle leden
    Console.WriteLine($"Group Name: {group.Name}");
    foreach (var person in group.People)
    {
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Hobbies: {string.Join(", ", person.Hobbys)}");
    }
}
void SaveToDisk()
{
    // TODO: gebruik de variabele filePath (hierboven gedeclareerd) 
    // om een JSON versie van de groep op te slaan. Voeg foutafhandeling toe.
    try
    {
        string json = group.Serialize();
        File.WriteAllText(filePath, json);
        Console.WriteLine("Data saved to disk successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving data to disk: {ex.Message}");
    }
}

void LoadFromDisk()
{
    // TODO: gebruik de variabele filePath (hierboven gedeclareerd) 
    // om een JSON versie van de groep te laden. Voeg foutafhandeling toe.
    try
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            group = Group.Deserialize(json);
            Console.WriteLine("Data loaded from disk successfully.");
        }
        else
        {
            Console.WriteLine("No saved data found. Starting with an empty group.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading data from disk: {ex.Message}");
    }
}