using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


public class User
{
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string PhoneNumber { get; set; } = "";

    public bool IsRegistered = false;

    public void Register(string email, string password, string phoneNumber)
    {
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        IsRegistered = true;
    }
}

public class Document
{
    public Document(string title, string year, string subject, string bookshelf, string author)
    {
        var randomNumber = new Random();
        Code = randomNumber.Next(10, 500);
        Title = title;
        Year = year;
        Subject = subject;
        Bookshelf = bookshelf;
        Author = author;
    }

    public int Code { get; private init; }
    public string Title { get; set; } = "";
    public string Year { get; set; } = "";
    public string Subject { get; set; } = "";
    public string Bookshelf { get; set; } = "";
    public string Author { get; set; } = "";
}

public class Book : Document
{
    public Book (string title, string year, string subject, string bookshelf, string author, int pagesNumber) : base (title, year, subject, bookshelf, author)
    {
        PagesNumber = pagesNumber;
    }

    public int PagesNumber { get; set; }
}

public class Dvd : Document
{
    public Dvd(string title, string year, string subject, string bookshelf, string author, int duration) : base(title, year, subject, bookshelf, author)
    {
        Duration = duration;
    }

    public int Duration { get; set; }
}

public class Lend
{
    public Lend(User user, Document document)
    {
        User = user;
        Document = document;
        LendDate = DateTime.Now;
        LendRestitution = LendDate.AddDays(30);
    }

    public User User { get; private set; }
    public Document Document { get; private set; }
    public DateTime LendDate { get; private init; }
    public DateTime? LendRestitution { get; private init; }
}



public class Library
{
    public Library()
    {
        UsersList = new List<User>();
        DocumentsList = new List<Document>();   

    }
    public List<User> UsersList { get; private init; }
    public List<Document> DocumentsList { get; private init; }
    public List<Lend> LendsList { get; private init; }

    public void addUser(User user)
    {
        UsersList.Add(user);
    }
    public void addDocument(Document document) {

        DocumentsList.Add(document);
    }
    public string SearchUsers(string firstName, string lastName)
    {
        var filteredUsersList = new List<User>();

        foreach (var item in UsersList)
        {
            if (item.FirstName == firstName && item.LastName == lastName)
            {
                filteredUsersList.Add(item);
            }
        }

        if (filteredUsersList.Count > 0)
        {

            return "You are logged in!";
        }
        else
        {
            return "Not Found";
        }
    }

    public Document? SearchDocumentsByTitle(string title)
    {
        foreach (var item in DocumentsList)
        {
            if (item.Title == title)
            {
                return item;
            }
        }

        return null;
    }

    public User? SearchUserObj(string firstName, string lastName)
    {
        foreach (var item in UsersList)
        {
            if (item.FirstName == firstName && item.LastName == lastName)
            {
                return item;
            }
        }

        return null;
    }

    public string SearchLends(string firstName, string lastName)
    {
        var filteredLendsList = new List<Lend>();

        foreach (var item in LendsList)
        {
            if (item.User.FirstName == firstName && item.User.LastName == lastName)
            {
                filteredLendsList.Add(item);
            }
        }

        if (filteredLendsList.Count > 0)
        {
            var result = "";
            foreach (var item in filteredLendsList)
            {
                result += $"Titolo: {item.Document.Title}, Autore: {item.Document.Author}, Data di prestito: {item.LendRestitution}\n";
            }
            return result;
        }
        else
        {
            return "Nessun risultato trovato";
        }
    }



}




