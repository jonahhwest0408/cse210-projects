using System;

public class UserInterface
{
    private Library library;

    public UserInterface(Library library)
    {
        this.library = library;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Library Management System Menu:");
        Console.WriteLine("1. Display Books");
        Console.WriteLine("2. Display Members");
        Console.WriteLine("3. Handle Transaction");
        Console.WriteLine("4. Exit");
    }

    public int GetUserInput()
    {
        Console.Write("Enter your choice: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Books in the Library:");
        foreach (var item in library.GetCatalog().ListItems())
        {
            if (item is LibraryBook book)
            {
                Console.WriteLine($"Title: {book.BookTitle}, Author: {book.Author}, Genre: {book.Genre}, ISBN: {book.ISBN}, Availability: {(book.CurrentAvailability ? "Available" : "Not Available")}");
            }
        }
    }

    public void DisplayMembers()
    {
        Console.WriteLine("Members of the Library:");
        foreach (var member in library.GetMembers())
        {
            Console.WriteLine($"Name: {member.Name}, ID: {member.ID}, Contact Info: {member.ContactInfo}");
        }
        //future logic for displaying members//
    }

    public void HandleTransaction()
    {
        //future logic for handling transactions//
    }
}
