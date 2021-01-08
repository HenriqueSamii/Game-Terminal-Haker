using System.Collections.Generic;
using UnityEngine;
//using Random = System.Random;

public class Haker : MonoBehaviour
{
    //Game configuration data
    //Random r = new Random();
    List<string> level1 = new List<string>(){"password","test","cat"};
    List<string> level2 = new List<string>(){"police","batton","enforcement"};
    List<string> level3 = new List<string>(){"cosmonaut","pluto","uranus"};
    //Game state
    int level;

    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;

    string password = null;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Ben");
    }

    void OnUserInput(string input){
        //print("User input was " + input);
        input = input.ToLower();
        if (input == "menu")  //Can go to main menu any time
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu("Hello Ben");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            RunWin(input);
        }
    }

    private void RunWin(string input)
    {
        currentScreen = Screen.MainMenu;
        ShowMainMenu("Hello Ben");
    }

    void CheckPassword(string input){
        if (input == password)
        {
            currentScreen = Screen.Win;
            Terminal.ClearScreen();
            Terminal.WriteLine("You'r in hakerman. You got " + password + " as the right password");
            Terminal.WriteLine("Progress enter to go to main menu");
        }
        else
        {
            StartGame();
        }
    }
    void RunMainMenu(string input){
        switch(input) 
        {
        case "1":
        case "2":
        case "3":
            level = int.Parse(input);
            StartGame();
            break;
        case "007":
            Terminal.WriteLine("Hello mister Bond");
            break;
        default:
            currentScreen = Screen.MainMenu;
            ShowMainMenu("Option " + input + " does not exist, try again");
            break;
        }
    }
    void ShowMainMenu(string greetings){
        currentScreen = Screen.MainMenu;
        password = null;

        Terminal.ClearScreen();

        Terminal.WriteLine(greetings);
        
        Terminal.WriteLine("What would you like to hack into?\n\n"+
                            "Press 1 for the local library\n"+
                            "Press 2 for the police station\n"+
                            "Press 3 for NASA\n\n"+
                            "Enter your selection:");
    }

    void StartGame(){
        currentScreen = Screen.Password;
        //Terminal.WriteLine("Option "+ level +" was successfully chosen");
        if (password == null)
        {
            password = getPassword();
        }
        Terminal.ClearScreen();
        Terminal.WriteLine("Passeord Level: " + level);
        //Terminal.WriteLine("Password Anagram: " + randomiseString(password));
        Terminal.WriteLine("Password Anagram: " + password.Anagram());
        Terminal.WriteLine("What's the Password?");
    }
    private string randomiseString(string stri)
    {
        var stringToList = new List<string>(stri.Split());
        //var jumbledString = stringToList.OrderBy(x => Guid.NewGuid()).ToList();
        string jumbledString = "";
        while (stringToList.Count > 0)
        {
            int indexPasswordToList = Random.Range(0,stringToList.Count);
            jumbledString = jumbledString + stringToList[indexPasswordToList];
            stringToList.RemoveAt(indexPasswordToList);
        }
        return jumbledString;
    }
    private string getPassword()
    {
        switch(level) 
        {
        case 1:
            return level1[Random.Range(0,level1.Count)];
        case 2:
            return level2[Random.Range(0,level2.Count)];
        case 3:
            return level3[Random.Range(0,level3.Count)];
        default:
            print("Erro on GetPassword");
            return null;
        }
    }
}
