using System;

public enum TransactionType
{
    CheckOut,
    Return
}

public class Transaction
{
    public LibraryItem Item { get; set; }
    public Member Member { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }

    public Transaction(LibraryItem item, Member member, DateTime date, TransactionType type)
    {
        Item = item;
        Member = member;
        Date = date;
        Type = type;
    }

    public void ExecuteTransaction()
    {
        switch (Type)
        {
            case TransactionType.CheckOut:
                if (Item is LibraryBook book && Member != null)
                {
                    book.CheckOut();
                    Member.BorrowItem(book);
                }
                else
                {
                    Console.WriteLine("Invalid transaction: Unable to check out item.");
                }
                break;
            case TransactionType.Return:
                if (Item is LibraryBook returnBook && Member != null)
                {
                    returnBook.Return();
                    Member.ReturnItem(returnBook);
                }
                else
                {
                    Console.WriteLine("Invalid transaction: Unable to return item.");
                }
                break;
            default:
                Console.WriteLine("Invalid transaction type.");
                break;
        }
    }
}

