//var millo = new User("Camillo", "Musmeci");
//var giuseppe = new User("Giuseppe", "Rossi");

//millo.Register("ok@ok.ok", "ciao94", "095678798");


//var divinaCommedia = new Book("Divini Commedia", "1865", "Romanzo", "5", "Alessandro Manzoni", 400);
//var mobyDick = new Book("Moby Dick", "1865", "Romanzo", "5", "Alessandro Manzoni", 400);
//var decameron = new Book("Decameron", "1865", "Romanzo", "5", "Alessandro Manzoni", 400);


//library.UsersList.Add(millo);

//library.DocumentsList.Add(divinaCommedia);
//library.DocumentsList.Add(mobyDick);
//library.DocumentsList.Add(decameron);

//library.addUser(giuseppe);

//library.SearchLends("Marco", "Musmeci")

//foreach (Document item in library.DocumentsList)
//{
//    Console.WriteLine(item.Title);
//}

//foreach(User item in library.UsersList)
//{
//    Console.WriteLine(item.FirstName);
//}

//var ricerca1 = library.searchDocument(promessiSposi);
//Console.WriteLine(ricerca1);


//var millo = new User("Camillo", "Musmeci");
//millo.Register("ok@ok.com", "fhdjdd", "74839");

var library = new Library();
var millo = new User("Camillo", "Musmeci");
var promessiSposi = new Book("Promessi Sposi", "1865", "Romanzo", "5", "Alessandro Manzoni", 400);
library.DocumentsList.Add(promessiSposi);
millo.Register("ok@ok.com", "fhdjdd", "74839");
library.addUser(millo);
User user = null;
Console.WriteLine("welcome to goLibrary!");
Console.WriteLine("are you registered? (type y/n)");
var answer1 = Console.ReadLine();
if (answer1 == "y")
{
    Console.WriteLine("type your first name");
    var firstName = Console.ReadLine();
    Console.WriteLine("type your last name");
    var lastName = Console.ReadLine();
    Console.WriteLine(library.SearchUsers(firstName, lastName));
    var userObj = Console.WriteLine(library.SearchUserObj(lastName, firstName));
} else
{
    Console.WriteLine("Register Now!");
    Console.WriteLine("type your first name!");
    var firstName = Console.ReadLine();
    Console.WriteLine("type your last name!");
    var lastName = Console.ReadLine();
    user = new User(firstName, lastName);
    Console.WriteLine("type your email");
    var email = Console.ReadLine();
    Console.WriteLine("type your password");
    var password = Console.ReadLine();
    Console.WriteLine("type your phone number");
    var phoneNumber = Console.ReadLine();
    user.Register(email, password, phoneNumber);
    library.addUser(user);
    Console.WriteLine(library.SearchUsers(firstName, lastName));

}

Console.WriteLine("You want to borrow a book? (type y/n)");
var answer2 = Console.ReadLine();
if (answer2 == "y")
{
    Console.WriteLine("Search an item!");
    Console.WriteLine("You want to search by name? (type y/n)");
    var answer3 = Console.ReadLine();
    if(answer3 == "y")
    {
        Console.WriteLine("Type a title!");
        var title = Console.ReadLine();
        var document = library.SearchDocumentsByTitle(title);

        if (document != null)
        {
            Console.WriteLine($"Here's your document {document.Title}");
            Console.WriteLine("You want to borrow it? (type y/n)");
            var answer4 = Console.ReadLine();
            if (answer4 == "y")
            {
                var lend = new Lend(user, document);
                library.LendsList.Add(lend);
                Console.WriteLine("The lend was carried out");
            }
            else
            {
                Console.WriteLine("See you soon!");
            }
        }
        else
        {
            Console.WriteLine("Document not found");
        }
    }

}




//var millo = new User("Camillo", "Musmeci");
//millo.Register("ok@ok.com", "fhdjdd", "74839");
//library.addUser(millo);
//foreach (User item in library.UsersList)
//{
//    Console.WriteLine(item.FirstName);
//}