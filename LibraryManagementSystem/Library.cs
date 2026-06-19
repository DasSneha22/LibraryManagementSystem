using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        // Helper method to sort books alphabetically by Title
        public void SortBooksByTitle()
        {
            // Uses built-in sorting, comparing the titles alphabetically
            books.Sort((b1, b2) => string.Compare(b1.Title, b2.Title, StringComparison.OrdinalIgnoreCase));
        }

        // --- ALGORITHM 1: LINEAR SEARCH ---
        public Book LinearSearchByTitle(string targetTitle)
        {
            int steps = 0;
            foreach (var book in books)
            {
                steps++;
                // Case-insensitive check
                if (book.Title.Equals(targetTitle, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"(Linear Search took {steps} steps)");
                    return book;
                }
            }
            Console.WriteLine($"(Linear Search took {steps} steps)");
            return null; // Not found
        }

        // --- ALGORITHM 2: BINARY SEARCH ---
        // CRITICAL: The 'books' list MUST be sorted before calling this!
        public Book BinarySearchByTitle(string targetTitle)
        {
            int left = 0;
            int right = books.Count - 1;
            int steps = 0;

            while (left <= right)
            {
                steps++;
                // Find the middle index
                int mid = left + (right - left) / 2;

                // Compare the middle book's title to our target
                int comparison = string.Compare(books[mid].Title, targetTitle, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    // We found it!
                    Console.WriteLine($"(Binary Search took {steps} steps)");
                    return books[mid];
                }
                else if (comparison < 0)
                {
                    // Target is alphabetically AFTER the middle element.
                    // Ignore the left half.
                    left = mid + 1;
                }
                else
                {
                    // Target is alphabetically BEFORE the middle element.
                    // Ignore the right half.
                    right = mid - 1;
                }
            }

            Console.WriteLine($"(Binary Search took {steps} steps)");
            return null; // Not found
        }

        public void DisplayAllBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"[ID: {book.BookId}] {book.Title} by {book.Author}");
            }
        }
    }
}