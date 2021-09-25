using Developers;
using DevTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperTeamManagementApplication
{
    public class KomodoUI
    {
        private DevRepo _devrepo = new DevRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            SeedData();
            MainMenu();
        }
        private void MainMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Welcome to the Komodo Insurance Team Managment System. \n"
                                  + "What would you like to do?\n"
                                  + "1. Manage Developers\n"
                                  + "2. Manage Development Teams\n"
                                  + "3. View Plural Site Access for all Developers \n"
                                  + "4. Exit the Program");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        DeveloperManagementMenu();
                        break;
                    case 2:
                        DevTeamManagementMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Here's a list of all of your developers with PluralSite Access");
                        foreach (Developer dev in _devrepo._developers)
                        {
                            if (dev.HasPluralSightAccess == true)
                            {
                                Console.WriteLine($"{dev.FullName}");
                            }
                        }
                        PressAnyKey();
                        break;
                    case 4:
                        Console.WriteLine("GoodBye\n");
                        PressAnyKey();
                        isRunning = false;
                        break;
                    default:
                        IntSwitchDefault();
                        break;
                }
            }
        }
        private void DeveloperManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n"
                              + "1. Create a new developer\n"
                              + "2. See all of the developers\n"
                              + "3. Find a specific developer\n"
                              + "4. Update a developer's information\n"
                              + "5. Remove a developer \n"
                              + "6. Go Back");
            int devInput = int.Parse(Console.ReadLine());
            switch (devInput)
            {
                case 1://1. Create a new developer
                    Console.Clear();
                    Developer createdDev = CreateDeveloper();
                    _devrepo.CreateDeveloperRepo(createdDev);

                    Console.WriteLine($"{createdDev.FirstName} {createdDev.LastName} was added!");
                    PressAnyKey();
                    break;
                case 2://2. See all of the developers
                    Console.Clear();
                    DisplayAllDevelopers();
                    PressAnyKey();
                    break;
                case 3://3. Find a specific developer
                    Console.Clear();
                    DisplayAllDevelopers();
                    Console.WriteLine("Please enter the ID number of the developers you are looking for:\n");
                    int devId = int.Parse(Console.ReadLine());
                    Developer viewDev = _devrepo.GetDevById(devId);
                    Console.WriteLine($"Here is the information for {viewDev.FirstName}\n\n"
                                      + $"Developer ID: {viewDev.iD}\n"
                                      + $"Name: {viewDev.FullName}\n"
                                      + $"Do they have PluralSite Access: {viewDev.HasPluralSightAccess}");
                    PressAnyKey();
                    break;
                case 4://4. Update a developer's information
                    DisplayAllDevelopers();
                    Console.WriteLine("Which developer would you like to update?\n" +
                        "Please enter their ID number.");
                    int exsistingDev = int.Parse(Console.ReadLine());
                    Developer updatedDev = CreateDeveloper();
                    _devrepo.UpdateDeveloper(exsistingDev, updatedDev);
                    if (_devrepo.UpdateDeveloper(exsistingDev, updatedDev) == true)
                    {
                        Console.WriteLine($"{updatedDev.FirstName} was updated!");
                    }
                    else
                    {
                        Console.WriteLine($"{updatedDev.FirstName} was updated!");
                    }
                    PressAnyKey();
                    break;
                case 5: //5. Remove a developer 
                    DisplayAllDevelopers();
                    Console.WriteLine("Which developer would you like to remove?\n" +
                        "Please enter their ID number.");
                    int deleteDev = int.Parse(Console.ReadLine());
                    _devrepo.DeleteDev(deleteDev);
                    PressAnyKey();
                    break;
                case 6:
                    GoBack();
                    break;
                default:
                    IntSwitchDefault();
                    break;
            }
        }
        private void DevTeamManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n"
                              + "1. Create a new team of developers             5. Remove a developer from a team\n"
                              + "2. View the current teams                      6. Update a teams information\n"
                              + "3. View the members of a team                  7. Remove a team \n"
                              + "4. Add a developer to a team                   8. Go back to the main menu\n"
                              );
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1://1.Create a new team of developers
                    CreateDeveloperTeam(); 
                    break;
                case 2: // 2.View the current teams
                    Console.Clear();
                    DisplayAllTeams();
                    PressAnyKey();
                    break;
                case 3: //3. View the members of a team 
                    DisplayAllTeams();
                    Console.WriteLine("Please enter the Team Id of which you would like to see the team?");
                    int teamPick = int.Parse(Console.ReadLine());
                    DeveloperTeams devTeam = _devTeamRepo.FindDevTeamById(teamPick);
                    Console.Clear();
                    Console.WriteLine($"Team: {devTeam.TeamName}\n");
                    foreach (Developer dev in devTeam.Team)
                    {
                        Console.WriteLine($"Team Member: {dev.FullName}\n");
                    }
                    PressAnyKey();
                    break;
                case 4: //4. Add a developer to a team
                    DisplayAllTeams();
                    Console.WriteLine("\n" +
                        "What team would you like to add a member to?\n" +
                        "Please enter the Team Id.");
                    int addPick = int.Parse(Console.ReadLine());
                    DeveloperTeams addToTeam = _devTeamRepo.FindDevTeamById(addPick);
                    Developer addDev = AddOrRemoveDeveloper();
                    addToTeam.Team.Add(addDev);
                    PressAnyKey();
                    break;
                case 5://5. Remove a developer from a team
                    DisplayAllTeams();
                    Console.WriteLine("\n" +
                        "What team would you like to remove a member from?\n" +
                        "Please enter the Team Id.");
                    int removePick = int.Parse(Console.ReadLine());
                    DeveloperTeams removeFromTeam = _devTeamRepo.FindDevTeamById(removePick);
                    Developer removeDev = AddOrRemoveDeveloper();
                    removeFromTeam.Team.Remove(removeDev);
                    if (removeFromTeam.Team.Remove(removeDev) == true)
                    {
                        Console.WriteLine("The team member was removed!");
                    }
                    else
                    {
                        Console.WriteLine("The team member was not removed!");
                    }
                    PressAnyKey();
                    break;
                case 6://6. Update a teams information
                    DisplayAllTeams();
                    Console.WriteLine("\n" +
                        "What team would you like to update?\n" +
                        "Please enter the Team Id.");
                    int updatePick = int.Parse(Console.ReadLine());
                    DeveloperTeams newTeam = UpdateATeam();
                    _devTeamRepo.UpdateATeamRepo(updatePick, newTeam);
                    if (_devTeamRepo.UpdateATeamRepo(updatePick, newTeam))
                    {
                        Console.WriteLine($"The team {newTeam.TeamName} was updated!");
                    }
                    else
                    {
                        Console.WriteLine($"The team {newTeam.TeamName} was not updated!");
                    }
                    break;
                case 7://7. Remove a team
                    DisplayAllTeams();
                    Console.WriteLine("Please enter the team id of the team you want to remove.");
                    int removeDevTeam = int.Parse(Console.ReadLine());
                    _devTeamRepo.DeleteATeam(removeDevTeam);
                    if (_devTeamRepo.DeleteATeam(removeDevTeam) == false)
                    {
                        Console.WriteLine("The team was not deleted!");
                    }
                    else
                    {
                        Console.WriteLine("The team was deleted!");
                    }
                    PressAnyKey();
                    break;
                case 8:
                    GoBack();
                    break;
                default:
                    IntSwitchDefault();
                    break;
            }
        }
        private DeveloperTeams UpdateATeam()
        {
            Console.Clear();
            bool addingDevsToList = true;
            List<Developer> newDevTeamList = new List<Developer>();
            DeveloperTeams updateDevTeam = new DeveloperTeams();
            Console.WriteLine("What would you like to name this team?");
            updateDevTeam.TeamName = Console.ReadLine();
            do
            {
                Console.WriteLine("Please enter the ID number of the developer you would like to add to the team.");
                Developer addingDev = AddOrRemoveDeveloper();
                newDevTeamList.Add(addingDev);
                Console.WriteLine("Would you like to add another team member? (y/n)");
                string addAnother = Console.ReadLine();
                switch (addAnother)
                {
                    case "y":
                        addingDevsToList = true;
                        break;
                    case "n":
                        addingDevsToList = false;
                        break;
                    default:
                        addingDevsToList = false;
                        break;
                }
            } while (addingDevsToList);
            updateDevTeam.Team = newDevTeamList;
            return updateDevTeam;
        }
        private DeveloperTeams CreateDeveloperTeam()
        {
            Console.Clear();
            bool addingDevsToList = true;
            List<Developer> updatedTeamDevList = new List<Developer>();
            DeveloperTeams newDevTeam = new DeveloperTeams();
            Console.WriteLine("What would you like to name this team?");
            newDevTeam.TeamName = Console.ReadLine();
            do
            {
                Console.WriteLine("Please enter the ID number of the developer you would like to add to the team.");
                Developer addingDev = AddOrRemoveDeveloper();
                updatedTeamDevList.Add(addingDev);
                Console.WriteLine("Would you like to add another team member? (y/n)");
                string addAnother = Console.ReadLine();
                switch (addAnother)
                {
                    case "y":
                        addingDevsToList = true;
                        break;
                    case "n":
                        addingDevsToList = false;
                        break;
                    default:
                        addingDevsToList = false;
                        break;
                }
            } while (addingDevsToList);
            newDevTeam.Team = updatedTeamDevList;
            _devTeamRepo.CreateATeam(newDevTeam);
            if (_devTeamRepo.CreateATeam(newDevTeam))
            {
                Console.WriteLine($"The team {newDevTeam.TeamName} was created!");
            }
            else
            {
                Console.WriteLine($"The team {newDevTeam.TeamName} was not created!");
            }
            return newDevTeam;
        }
        private Developer CreateDeveloper()
        {
            Developer newDev = new Developer();
            Console.WriteLine("What is the developer's first name?");
            string firstName = Console.ReadLine();
            newDev.FirstName = firstName;
            Console.WriteLine("What is their last name?");
            string lastName = Console.ReadLine();
            newDev.LastName = lastName;
            Console.WriteLine("Do you want them to have PluralSite Access? (y/n)");
            string access = Console.ReadLine().ToLower();
            switch (access)
            {
                case "y":
                    newDev.HasPluralSightAccess = true;
                    break;
                case "n":
                    newDev.HasPluralSightAccess = false;
                    break;
                default:
                    newDev.HasPluralSightAccess = false;
                    break;
            }
            return newDev;
        }
        private void IntSwitchDefault()
        {
            Console.WriteLine("Please use a valid number.\n" +
                            "Press any key to try again.");
            Console.ReadKey();
            Console.Clear();
        }
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            foreach (Developer dev in _devrepo._developers)
            {
                Console.WriteLine($"Developer ID: {dev.iD}\n" +
                    $"Name: {dev.FullName}\n" +
                    $"Do they have PluralSite Access: {dev.HasPluralSightAccess}\n");
            }
        }
        private void DisplayAllTeams()
        {
            Console.Clear();
            foreach (DeveloperTeams devTeam in _devTeamRepo._devTeams)
            {
                Console.WriteLine($"Team ID: {devTeam.TeamId}\n" +
                    $"Name: {devTeam.TeamName}\n" +
                    $"There are {devTeam.Team.Count} developers on this team\n");
            }
        }
        private void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void SeedData()
        {
            var dev1 = new Developer("Jon", " Crowe", false);
            var dev2 = new Developer("Jeremy", " Aldrige", true);
            var dev3 = new Developer("Austin", " Bridgewater", true);
            _devrepo.CreateDeveloperRepo(dev1);
            _devrepo.CreateDeveloperRepo(dev2);
            _devrepo.CreateDeveloperRepo(dev3);
            List<Developer> devTeamList1 = new List<Developer>();
            devTeamList1.Add(dev1);
            devTeamList1.Add(dev2);
            devTeamList1.Add(dev3);
            var devTeam1 = new DeveloperTeams(devTeamList1, "Rockets");
            _devTeamRepo.CreateATeam(devTeam1);
        }
        private Developer AddOrRemoveDeveloper()
        {
            DisplayAllDevelopers();
            Console.WriteLine("\nWho would you like to add/remove from this team?\n " +
                "Please enter the team ID of the team member you would like to add.");
            int dev = int.Parse(Console.ReadLine());
            Developer teamDev = _devrepo.GetDevById(dev);
            return teamDev;
        }
        public void GoBack()
        {
            Console.Clear();
            Console.WriteLine("Back to the Main Menu you go.");
            PressAnyKey();
        }
    }
}






