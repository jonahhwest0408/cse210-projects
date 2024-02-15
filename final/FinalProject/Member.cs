using System.Collections.Generic;

public class Member
{
    public string Name { get; set; }
    public int ID { get; set; }
    public string ContactInfo { get; set; }
    private List<LibraryItem> BorrowedItems { get; }

    public Member(string name, int id, string contactInfo)
    {
        Name = name;
        ID = id;
        ContactInfo = contactInfo;
        BorrowedItems = new List<LibraryItem>();
    }

    public void BorrowItem(LibraryItem item)
    {
        BorrowedItems.Add(item);
    }

    public void ReturnItem(LibraryItem item)
    {
        BorrowedItems.Remove(item);
    }
}
