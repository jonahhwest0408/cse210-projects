using System;
using System.Collections.Generic;
using System.Linq;

public class Catalog
{
    private List<LibraryItem> items;

    public Catalog()
    {
        items = new List<LibraryItem>();
    }

    public void AddItem(LibraryItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(LibraryItem item)
    {
        items.Remove(item);
    }

    public List<LibraryBook> SearchBooksByTitle(string title)
    {
        return items.OfType<LibraryBook>().Where(book => book.BookTitle.Contains(title)).ToList();
    }

    public List<LibraryItem> ListItems()
    {
        return items;
    }
}
