using mathgame;
var date = DateTime.UtcNow;
var games = new List<string>(); 
string name = GetName(); 
var menu = new Menu();
menu.ShowMenu(name, date);
string GetName(){
    Console.WriteLine("Please enter your name");
    string name = Console.ReadLine();
    return name;
}
//methods

