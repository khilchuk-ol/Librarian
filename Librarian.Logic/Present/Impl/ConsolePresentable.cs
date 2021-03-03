using Librarian.Domain.Models.Core;
using Librarian.Domain.Services.Abstract;
using System;
using System.Linq;
using System.Threading;

namespace Librarian.Domain.Present.Impl
{
    public class ConsolePresentable : IPresentable
    {
        private IBookService _bs;
        private IAuthorService _as;
        private IReaderService _rs;

        public ConsolePresentable(IBookService bsc, IReaderService rsc, IAuthorService asc)
        {
            _bs = bsc;
            _as = asc;
            _rs = rsc;
        }

        public void Show()
        {
            Menu(_rs, _as, _bs);

            Console.Clear();
            Console.WriteLine("Bye");
            Thread.Sleep(500);
        }

        private static void Menu(IReaderService rs, IAuthorService asc, IBookService bs)
        {
            Console.Clear();
            Console.WriteLine("Choose options: \n" +
                "b - find book\n" +
                "r - find reader\n" +
                "e - exit");
            var inp = Console.ReadLine().Trim();

            switch (inp.Trim())
            {
                case "b":
                case "B":
                    FindBooks(bs, asc);
                    Menu(rs, asc, bs);
                    break;
                case "r":
                case "R":
                    FindReaders(rs);
                    Menu(rs, asc, bs);
                    break;
                case "e":
                case "E":
                    return;
                default:
                    Menu(rs, asc, bs);
                    break;
            }
        }

        private static void FindReaders(IReaderService rs)
        {
            Console.Clear();
            Console.WriteLine("Choose value to search by:\n" +
                "t - ticket number\n" +
                "n - name\n\n" +
                "any other symbol - return to menu");
            var inp = Console.ReadLine();

            switch (inp.Trim())
            {
                case "t":
                case "T":
                    FindReadersByTicket(rs);
                    break;
                case "n":
                case "N":
                    FindReadersByName(rs);
                    break;
                default:
                    return;
            }
        }

        private static void FindReadersByName(IReaderService rs)
        {
            Console.Clear();
            Console.WriteLine("You have chosen finding readers by name");
            Console.Write("Input name: ");
            var str = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Bad input");
                Console.Write("Press any key to return to menu");
                Console.ReadLine();
                return;
            }

            var res = rs.FindReadersByName(str);

            if (res.Count() == 0)
                Console.WriteLine("Nothing was found");
            else
            {
                Console.WriteLine("\nResult\n");
                Console.WriteLine($"{"Full name",-25} | {"Ticket number",-12} | {"Phone number",-20}");

                foreach (var r in res)
                {
                    Console.WriteLine($"{r.Fullname,-25} | {r.TicketNumber,-12} | {r.Phone,-20}");
                }
            }

            Console.Write("Press any key to return to menu");
            Console.ReadLine();
        }

        private static void FindReadersByTicket(IReaderService rs)
        {
            Console.Clear();
            Console.WriteLine("You have chosen finding readers by ticket");
            Console.Write("Input ticket number: ");
            var ticketIn = Console.ReadLine();

            if (int.TryParse(ticketIn, out int num))
            {
                var readers = rs.FindReaderByTicket(num);

                if (readers == null || readers.Count() == 0)
                {
                    Console.WriteLine("nothing was found");
                }
                else if (readers.Count() > 1)
                {
                    Console.WriteLine("It seems that there is more than one reader with such ticket number");
                }
                else
                {
                    var res = readers.FirstOrDefault();

                    Console.WriteLine("\nResult\n");
                    Console.WriteLine($"{"Full name",-25} | {"Ticket number",-12} | {"Phone number",-20}");
                    Console.WriteLine($"{res.Fullname,-25} | {res.TicketNumber,-12} | {res.Phone,-20}");

                    Console.WriteLine("To see activity choose:\n" +
                        "r - to see returned books\n" +
                        "b - to see currently borrowed books\n" +
                        "any key to return to menu");

                    var inp = Console.ReadLine();

                    switch (inp.Trim())
                    {
                        case "r":
                        case "R":
                            GetReturnedBooks(res);
                            break;
                        case "b":
                        case "B":
                            GetBorrowedBooks(res);
                            break;
                        default:
                            return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Bad input");
            }

            Console.Write("Press any key to return to menu");
            Console.ReadLine();
        }

        private static void FindBooks(IBookService bs, IAuthorService asc)
        {
            Console.Clear();
            Console.WriteLine("Choose value to search by:\n" +
                "t - book title\n" +
                "a - author name\n\n" +
                "any other symbol - return to menu");
            var inp = Console.ReadLine();

            switch (inp.Trim())
            {
                case "t":
                case "T":
                    FindBooksByTitle(bs);
                    break;
                case "a":
                case "A":
                    FindBooksByAuthor(bs, asc);
                    break;
                default:
                    return;
            }
        }

        private static void FindBooksByAuthor(IBookService bs, IAuthorService asc)
        {
            Console.Clear();
            Console.WriteLine("You have chosen finding books by author");
            Console.Write("Input author's name: ");
            var str = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Bad input");
                Console.Write("Press any key to return to menu");
                Console.ReadLine();
                return;
            }

            var authors = asc.FindAuthorsByName(str);

            if (authors.Count() == 0)
                Console.WriteLine("Nothing was found");
            else
            {
                var res = authors.SelectMany(a => bs.FindBooksByAuthor(a)).ToHashSet();

                if (res.Count() == 0)
                {
                    Console.WriteLine("No books found of such author");
                }
                else
                {
                    Console.WriteLine("\nResult\n");
                    Console.WriteLine($"{"Title",-25} | {"Book number",-12} | {"Is borrowed",-7}");

                    foreach (var r in res)
                    {
                        Console.WriteLine($"{r.Title,-25} | {r.Number,-12} | {r.IsBorrowed,-7}");
                    }
                }
            }

            Console.Write("Press any key to return to menu");
            Console.ReadLine();
        }

        private static void FindBooksByTitle(IBookService bs)
        {
            Console.Clear();
            Console.WriteLine("You have chosen finding books by title");
            Console.Write("Input title: ");
            var str = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Bad input");
                Console.Write("Press any key to return to menu");
                Console.ReadLine();
                return;
            }

            var res = bs.FindBooksByTitle(str);

            if (res.Count() == 0)
                Console.WriteLine("Nothing was found");
            else
            {
                Console.WriteLine("\nResult\n");
                Console.WriteLine($"{"Title",-25} | {"Book number",-12} | {"Is borrowed",-7}");

                foreach (var r in res)
                {
                    Console.WriteLine($"{r.Title,-25} | {r.Number,-12} | {r.IsBorrowed,-7}");
                }
            }

            Console.Write("Press any key to return to menu");
            Console.ReadLine();
        }

        private static void GetReturnedBooks(Reader r)
        {
            Console.Clear();
            Console.WriteLine($"Information about returned books of {r.Fullname}");

            var list = r.ReturnedBooks;

            if (list.Count() == 0)
            {
                Console.WriteLine("This reader has not returned any books yet");
            }
            else
            {
                Console.WriteLine($"{"Title",-25} | {"Book number",-12}");

                foreach (var b in list)
                {
                    Console.WriteLine($"{b.Title,-25} | {b.Number,-12}");
                }
            }
        }

        private static void GetBorrowedBooks(Reader r)
        {
            Console.Clear();
            Console.WriteLine($"Information about currently borrowed books of {r.Fullname}");

            var list = r.CurrentlyBorrowedBooks;

            if (list.Count() == 0)
            {
                Console.WriteLine("This reader has no borrowed books right now");
            }
            else
            {
                Console.WriteLine($"{"Title",-25} | {"Book number",-12}");

                foreach (var b in list)
                {
                    Console.WriteLine($"{b.Title,-25} | {b.Number,-12}");
                }
            }
        }
    }
}
