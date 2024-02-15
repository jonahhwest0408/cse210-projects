using System;

public enum TransactionType
{
    CheckOut,
    Return
}
public class Transaction
{
    public LibraryItem LibraryItem { get; set; }
    public Member Member { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }

    public Transaction(LibraryItem libraryItem, Member member, DateTime date, TransactionType type)
    {
        LibraryItem = libraryItem;
        Member = member;
        Date = date;
        Type = type;
    }

    public void ExecuteTransaction()
    {
        switch (Type)
        {
            case TransactionType.CheckOut:
                LibraryItem.CheckOut();
                Member.BorrowItem(LibraryItem);
                break;
            case TransactionType.Return:
                LibraryItem.Return();
                Member.ReturnItem(LibraryItem);
                break;
            default:
                Console.WriteLine("Invalid transaction type.");
                break;
        }
    }
}

