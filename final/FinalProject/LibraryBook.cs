using System;

public class LibraryBook : LibraryItem
{
    public string BookTitle { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string ISBN { get; set; }
    public bool CurrentAvailability { get; set; }

    public LibraryBook(string title, string author, string genre, string isbn, bool availability)
        : base(title) 
    {
        BookTitle = title; 
        Author = author;
        Genre = genre;
        ISBN = isbn;
        CurrentAvailability = availability; 
    }
}
