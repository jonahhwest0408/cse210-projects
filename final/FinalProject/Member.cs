using System.Collections.Generic;

public class Member
{
    public int MemberID { get; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    private List<LibraryBook> CheckedOutBooks { get; }

    public Member(int memberId, string name, string contactInfo)
    {
        MemberID = memberId;
        Name = name;
        ContactInfo = contactInfo;
        CheckedOutBooks = new List<LibraryBook>();
    }

    public void BorrowItem(LibraryBook book)
    {
        CheckedOutBooks.Add(book);
    }

    public void ReturnItem(LibraryBook book)
    {
        CheckedOutBooks.Remove(book);
    }

    public List<LibraryBook> GetCheckedOutBooks()
    {
        return CheckedOutBooks;
    }
}
