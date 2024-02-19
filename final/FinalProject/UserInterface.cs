using System;
using System.Linq;

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
        foreach (var book in library.GetCatalog().ListBooks())
        {
            // Check if the book is currently checked out by any member
            bool isAvailable = !library.GetMembers().Any(member => member.GetCheckedOutBooks().Contains(book));

            string availabilityStatus = isAvailable ? "Available" : "Not Available";
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, ISBN: {book.ISBN}, Availability: {availabilityStatus}");
        }
    }



    public void DisplayMembers()
    {
        Console.WriteLine("Members of the Library:");
        foreach (var member in library.GetMembers())
        {
            Console.WriteLine($"Member ID: {member.MemberID}, Name: {member.Name}, Contact Info: {member.ContactInfo}");
            Console.WriteLine("Books Checked Out:");
            foreach (var book in member.GetCheckedOutBooks())
            {
                Console.WriteLine($"- Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, ISBN: {book.ISBN}");
            }
            Console.WriteLine();
        }
    }


    public void HandleTransaction()
    {
        Console.WriteLine("Transaction Menu:");
        Console.WriteLine("1. Check Out");
        Console.WriteLine("2. Return");
        Console.Write("Enter your choice: ");
        int transactionChoice = Convert.ToInt32(Console.ReadLine());

        switch (transactionChoice)
        {
            case 1:
                // Check out
                Console.Write("Enter the title of the book to check out: ");
                string bookTitle = Console.ReadLine();

                // Find the book in the catalog
                List<LibraryBook> foundBooks = library.GetCatalog().SearchBooksByTitle(bookTitle);
                if (foundBooks.Count == 0)
                {
                    Console.WriteLine("No matching books found.");
                    return;
                }

                // Display the found books
                Console.WriteLine("Matching books found:");
                foreach (var book in foundBooks)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
                }

                // Prompt for member ID
                Console.Write("Enter your member ID: ");
                int memberId = Convert.ToInt32(Console.ReadLine());

                // Find the member
                Member member = library.GetMembers().FirstOrDefault(m => m.MemberID == memberId);
                if (member == null)
                {
                    Console.WriteLine("Member not found.");
                    return;
                }

                // Perform the check out transaction
                LibraryBook checkedOutBook = foundBooks.First();
                Transaction checkOutTransaction = new Transaction(checkedOutBook, member, DateTime.Now, TransactionType.CheckOut);
                checkOutTransaction.ExecuteTransaction();
                break;

        case 2:
            Console.WriteLine("Enter the title of the book to return: ");
            string returnBookTitle = Console.ReadLine();

            Console.WriteLine("Enter your member ID: ");
            int returnMemberId = Convert.ToInt32(Console.ReadLine());

            // Find the member with the given ID
            Member returnMember = library.GetMembers().FirstOrDefault(m => m.MemberID == returnMemberId);
            if (returnMember != null)
            {
                // Find the book with the given title
                LibraryBook bookToReturn = returnMember.GetCheckedOutBooks().FirstOrDefault(b => b.BookTitle == returnBookTitle);
                if (bookToReturn != null)
                {
                    // Create a new transaction to return the book
                    Transaction returnTransaction = new Transaction(bookToReturn, returnMember, DateTime.Now, TransactionType.Return);
                    library.AddTransaction(returnTransaction);

                    // Remove the returned book from the member's list of checked out books
                    returnMember.ReturnItem(bookToReturn);

                    Console.WriteLine($"{returnBookTitle} returned successfully.");
                }
                else
                {
                    Console.WriteLine($"Book with title '{returnBookTitle}' not found.");
                }
            }
            else
            {
                Console.WriteLine($"Member with ID '{returnMemberId}' not found.");
            }
            break;

        }
    }

}
