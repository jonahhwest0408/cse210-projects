"Library Management System Final Project"

+ = "Method"
- = "Variables"

+---------------------+          +-------------------+
|       Library       |<>------->|      Catalog      |
+---------------------+          +-------------------+
| - books: List<Book> |          | - books: List<Book>|
| - members: List<Member>|       +-------------------+
| - transactions: List<Transaction>|
+---------------------+
        |                                   +------------+
        | 1                                 |   Book   |
        |                                   +------------+
        v                                   | - title: string|
+-----------------------+                   | - author: string|
| NotificationManager  |                   | - genre: string|
+-----------------------+                   | - ISBN: string|
| + NotifyOverdueBooks()|                  | - availability: bool|
+-----------------------+                   +------------+
        |
        | 1
        v
+-----------------------+
|     Transaction      |
+-----------------------+
| - book: Book          |
| - member: Member      |
| - date: DateTime      |
| - transactionType: TransactionType|
+-----------------------+
           | 1
           v
+-----------------------+
|       Member          |
+-----------------------+
| - name: string        |
| - ID: int             |
| - contactInfo: string |
| - borrowedBooks: List<Book>|
+-----------------------+
           | 1
           v
+-----------------------+
|        UserInterface |
+-----------------------+
| + DisplayMenu()      |
| + GetUserInput()     |
| + DisplayBooks()     |
| + DisplayMembers()   |
| + HandleTransaction()|
+-----------------------+
           | 1
           v
+-----------------------+
|       Logger          |
+-----------------------+
| + LogTransaction()   |
| + LogError()         |
+-----------------------+
           | 1
           v
+-----------------------+
|       Catalog         |
+-----------------------+
| + AddBook()          |
| + RemoveBook()       |
| + SearchBook()       |
| + ListBooks()        |
+-----------------------+
