using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        /*static Dictionary<string, object> library = new Dictionary<string, object>()
        {
            {"book",Book },
            {"librrarian OR bookreader",Person }

        };*/

        class Book //کلاس کتاب
        {
            //property
            public string nameBook { get; set; }
            public string nameRite { get; set; }
            public double price { get; set; }
            public int numberPage { get; set; }


            //تابع سازنده

            public Book(string nameBook, string nameRite, double price, int numberPage)
            {
                this.nameBook = nameBook;
                this.nameRite = nameRite;
                this.price = price;
                this.numberPage = numberPage;
            }

            public Book(string nameBook)
            {
                this.nameBook = nameBook;
            }


            //متد
            public void show ()
            {
                Console.WriteLine($"book:{nameBook}, written by:{nameRite}, price:{price}, number page:{numberPage}");
            }

         }//class



        class Person
        {
            //prop
            public string name { get; set; }

            // Book book { get; set; }
            //Book book = new Book();

            private List<Book> book = new List<Book>();



            static Dictionary<string, List<Book>> listbookvorder = new Dictionary<string, List<Book>>()
            {
                {"Listbook" , new List<Book>() },
                {"Listorder" ,  new List<Book>() }
            };


            //تابع سازنده
            public Person(string name)
            {
                this.name = name;
            }


            //متد
            //کتابدار
            public void addBook(Book book)
            {
                try
                {
                    listbookvorder["Listbook"].Add(book);
                }

                catch (Exception e)
                {
                    Console.WriteLine($"Something Went Wrong{e.Message}");
                }

            }


            public void removeBook(string delet)
            {
                foreach (var i in listbookvorder["Listbook"])
                {
                    if(book == null)
                     {
                        Console.WriteLine("it is not a book");
                    }
                        
                   if(i.nameBook == delet)
                    {
                     listbookvorder["Listbook"].Remove(i);
                        Console.WriteLine("DELETED");
                    }
                    else
                    {
                        Console.WriteLine("NOT FOUND");
                    }
                }

                
                

             }




            //کتابخوان

            public void showlistBooks (Book book)
            {
                if(book == null)
                {
                    Console.WriteLine("it is not a book");
                }
                else if(book != null)
                {
                    foreach ( var i in listbookvorder["Listorder"])
                    {
                        Console.WriteLine(book);
                    }
                }
            }

            public void orderBook(Book book)
            {
                try
                {
                    listbookvorder["Listorder"].Add(book);
                    Console.WriteLine("added");
                }

                catch (Exception e)
                {
                    Console.WriteLine($"Something Went Wrong{e.Message}");
                }


            }


            public void listOrder(Book book)
            {
                if (book == null)
                {
                    Console.WriteLine("it is not a book");
                }
                else if (book != null)
                {
                    foreach (var i in listbookvorder["Listorder"])
                    {
                        Console.WriteLine(i);
                    }
                }
            }



        }//class

        static void Main(string[] args)
        {
               Console.WriteLine("ALI'S LIBRARY");

          
            while (true)
            {
                
                try
                {
                    Console.Write("Enter : librrarian OR bookreader "); //type
                    string type = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(type)) //if type null
                    {
                        Console.WriteLine("enter");

                    }

                    else if (type == "librrarian")
                    {
                        Console.WriteLine("ENTER USERNAME :");
                        string userName = Console.ReadLine();

                        Console.Clear();

                        Console.WriteLine($"WELCOME {userName} TO librrarian ");

                        //Person librrarian = new Person();

                        while (true)
                        {

                            Console.WriteLine("Enter 1 for add book");
                            Console.WriteLine("Enter 2 for delete book");
                            //Console.WriteLine("Enter 3 for add price");
                            Console.WriteLine("Enter 0 for COMEBACK");

                            try
                            {
                                char select = Convert.ToChar(Console.ReadLine());



                                if (select == '1')
                                {
                                    Console.Clear();

                                    Console.WriteLine("enter the name of the book: ");
                                    string nameBook = Console.ReadLine();

                                    Console.WriteLine("enter the name of the author of the book : ");
                                    string nameRite = Console.ReadLine();

                                    Console.WriteLine("enter the price of the book : ");
                                    double price = Convert.ToDouble(Console.ReadLine());

                                    Console.WriteLine("enter the number of pages in the book : ");
                                    int numberPage = Int32.Parse(Console.ReadLine());


                                    Book book = new Book(nameBook, nameRite, price, numberPage);


                                    //فراخوانی
                                    //Person librrarian = new Person();
                                    // librrarian.addBook(Book book);


                                    Console.WriteLine("added");

                                    Console.WriteLine("enter 0 to back to the menu");
                                    Console.ReadLine();

                                }

                                else if (select == '2')
                                {
                                    Console.Clear();

                                    Console.WriteLine("enter the name of the book to delete:");
                                    string delet = Console.ReadLine();

                                    // Book book = new Book(nameBook);

                                    //فراخانی

                                    //Console.WriteLine("deleted");

                                    Console.WriteLine("enter 0 to back to the menu");
                                    Console.ReadLine();

                                }

                                else if (select == '0')
                                {
                                    break;
                                }

                            } //try

                            catch (Exception e)
                            {
                                Console.WriteLine($"Something Went Wrong{e.Message}");
                            }


                        }//while

                    }

                    else if (type == "bookreader")
                    {
                        Console.WriteLine("ENTER USERNAME :");
                        string userName = Console.ReadLine();

                        Console.Clear();

                        Console.WriteLine($"WELCOME {userName} TO bookreader ");



                        while (true)
                        {

                            Console.WriteLine("Enter 1 to see the list of books");
                            Console.WriteLine("Enter 2 to order the book");
                            Console.WriteLine("Enter 3 to view the shopping cart");
                            Console.WriteLine("Enter 0 for COMEBACK");

                            try
                            {
                                char select = Convert.ToChar(Console.ReadLine());
                                if (select == '1')
                                {
                                    Console.Clear();

                                    Book book = new Book(userName);
                                    Person bookreader = new Person (userName);
                                    bookreader.showlistBooks(book);

                                    Console.WriteLine("enter 0 to back to the menu");
                                    Console.ReadLine();

                                }

                                else if(select == '2')
                                {
                                    Console.Clear ();

                                    Book book = new Book(userName);
                                    Person bookreader = new Person(userName);
                                    bookreader.orderBook(book);

                                    Console.WriteLine("enter 0 to back to the menu");
                                    Console.ReadLine();
                                }

                                else if (select == '3')
                                {
                                    Console.Clear();

                                    Book book = new Book(userName);
                                    Person bookreader = new Person(userName);
                                    bookreader.orderBook(book);

                                    Console.WriteLine("enter 0 to back to the menu");
                                    Console.ReadLine();
                                }



                                else if (select == '0')
                                {
                                    break;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Something Went Wrong{e.Message}");
                            }

                        }
                    }

                    else //if something
                    {
                        Console.WriteLine("eror");

                    }
                    
                }//TRY

                catch (Exception e)
                {
                    Console.WriteLine($"Something Went Wrong{e.Message}");
                }

            }//WHILE





        }
    }
}
