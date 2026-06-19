using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library();

            // 1. Add some books (Note: They are currently out of alphabetical order)
            myLibrary.AddBook(new Book(1, "The Coded Triangle", "Shreedhar Priyan"));
            myLibrary.AddBook(new Book(2, "Wings of Fire", "Dr. A.P.J Abdul Kalam"));
            myLibrary.AddBook(new Book(3, "Conundrum", "Anuj Dhar & Chandrachur Ghosh"));
            myLibrary.AddBook(new Book(4, "The White Tiger", "Arvind Adiga"));
            myLibrary.AddBook(new Book(5, "Feluda", "Satyajit Ray"));
            myLibrary.AddBook(new Book(6, "Chander Pahar", "Bibhutibhusan Bandhyapadhayay"));

            // 2. Test Linear Search (Works fine on unsorted data)
            Console.WriteLine("--- Testing Linear Search ---");
            Book foundLinear = myLibrary.LinearSearchByTitle("Satyajit Ray");
            if (foundLinear != null)
                Console.WriteLine($"Found: '{foundLinear.Title}' by {foundLinear.Author}");
            else
                Console.WriteLine("Book not found.");

            // 3. Sort the data (Required for Binary Search)
            Console.WriteLine("\n--- Sorting books alphabetically by title... ---");
            myLibrary.SortBooksByTitle();
            myLibrary.DisplayAllBooks();

            // 4. Test Binary Search (Data is now sorted)
            Console.WriteLine("\n--- Testing Binary Search ---");
            Book foundBinary = myLibrary.BinarySearchByTitle("Wings of Fire");
            if (foundBinary != null)
                Console.WriteLine($"Found: '{foundBinary.Title}' by {foundBinary.Author}");
            else
                Console.WriteLine("Book not found.");

            // Keep console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}