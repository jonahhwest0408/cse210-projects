using System;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        LibraryBook book1 = new LibraryBook("The Great Gatsby", "F. Scott Fitzgerald", "Classic", "978-0743273565", true);
        LibraryBook book2 = new LibraryBook("To Kill a Mockingbird", "Harper Lee", "Fiction", "978-0061120084", true);
        LibraryBook book3 = new LibraryBook("1984", "George Orwell", "Dystopian", "978-0451524935", true);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        UserInterface ui = new UserInterface(library);

        List<Member> members = new List<Member>();
        Member member1 = new Member(90211, "John Doe", "john@gmail.com");
        members.Add(member1);

        foreach (var member in members)
        {
            library.AddMember("John Doe", "john@gmail.com");
        }

        new UserInterface(library);
        
        bool exit = false;
        while (!exit)
        {
            ui.DisplayMenu();
            int choice = ui.GetUserInput();
            switch (choice)
            {
                case 1:
                    ui.DisplayBooks();
                    break;
                case 2:
                    ui.DisplayMembers();
                    break;
                case 3:
                    ui.HandleTransaction();
                    break;
                case 4:
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

