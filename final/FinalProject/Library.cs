using System.Collections.Generic;

public class Library
{
    private List<LibraryBook> books;
    private List<Member> members;
    private List<Transaction> transactions;
    private Catalog catalog;
    private NotificationManager notificationManager;
    private Logger logger;

    public Library()
    {
        books = new List<LibraryBook>();
        members = new List<Member>();
        transactions = new List<Transaction>();
        catalog = new Catalog();
        notificationManager = new NotificationManager();
        logger = new Logger();
    }

    // Methods for managing books
    public void AddBook(LibraryBook book)
    {
        books.Add(book);
        catalog.AddItem(book);
    }

    public void RemoveBook(LibraryBook book)
    {
        books.Remove(book);
        catalog.RemoveItem(book);
    }

    //methods for managing members//
    public void AddMember(Member member)
    {
        members.Add(member);
    }

    public void RemoveMember(Member member)
    {
        members.Remove(member);
    }

    //methods for managing transactions//
    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
        logger.LogTransaction(transaction);
    }

    //getter methods for accessing internal collections//
    public List<LibraryBook> GetBooks()
    {
        return books;
    }

    public List<Member> GetMembers()
    {
        return members;
    }

    public List<Transaction> GetTransactions()
    {
        return transactions;
    }

    public Catalog GetCatalog()
    {
        return catalog;
    }
}
