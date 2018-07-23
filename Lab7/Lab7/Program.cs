using System;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the input validator. It validates inputs. Purpose unknown.");
            String name, email, phone, date, html;
            bool repeat = false;
            do
            {
                do
                {
                    name = GetValidName();
                    Console.WriteLine(name);
                } while (!IsRepeating());
                do
                {
                    email = GetValidEmail();
                    Console.WriteLine(email);
                } while (!IsRepeating());
                do
                {
                    phone = GetValidPhone();
                    Console.WriteLine(phone);
                } while (!IsRepeating());
                do
                {
                    date = GetValidDate();
                    Console.WriteLine(date);
                } while (!IsRepeating());

                do
                {
                    html = GetValidHTML();
                    Console.WriteLine(html);
                } while (!IsRepeating());

                Console.WriteLine("Continue to exit program. Otherwise, restart from the beginning.");
            } while (!IsRepeating());
            Console.Write("Goodbye! Press enter to close...");
            Console.Read();
        }

        static String GetValidName()
        {
            while (true)
            {
                Console.Write("Please enter a valid name: ");
                String name = Console.ReadLine();
                String pattern = @"^[A-Z][a-zA-Z]{0,29}$";
                if (Regex.IsMatch(name, pattern))
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("Invalid. Name must start with a capital letter, consist only of alphabets, and be no longer than 30 characters.");
                }
            }
        }

        static String GetValidEmail()
        {
            while (true)
            {
                Console.Write("Please enter a valid email: ");
                String email = Console.ReadLine();
                String pattern = @"^[a-zA-Z0-9]{5,30}@[a-zA-Z0-9]{5,10}\.[a-zA-Z0-9]{2,3}$";
                if (Regex.IsMatch(email, pattern))
                {
                    return email;
                }
                else
                {
                    Console.WriteLine("Invalid. Email should consist of the following three sections:");
                    Console.WriteLine("A combination of alphanumeric characters, length between 5 and 30, no special characters");
                    Console.WriteLine("An @ symbol followed by a combination of alphanumeric characters, length between 5 and 10, no special characters");
                    Console.WriteLine("A period followed by a combination of alphanumeric characters, length between 2 and 3, no special characters");
                }
            }
        }

        static String GetValidPhone()
        {
            while (true)
            {
                Console.Write("Please enter a valid phone number: ");
                String phone = Console.ReadLine();
                String pattern = @"^\d{3}-\d{3}-\d{4}$";
                if (Regex.IsMatch(phone, pattern))
                {
                    return phone;
                }
                else
                {
                    Console.WriteLine("Invalid. Phone number must be of form ###-###-####.");
                }
            }
        }

        static String GetValidDate()
        {
            while (true)
            {
                Console.Write("Please enter a valid date: ");
                String date = Console.ReadLine();
                String pattern = @"^\d{2}\/\d{2}\/\d{4}$";
                if (Regex.IsMatch(date, pattern))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid. Date must be of form dd/mm/yyyy.");
                }
            }
        }

        static String GetValidHTML()
        {
            while (true)
            {
                Console.Write("Please enter a valid HTML element: ");
                String html = Console.ReadLine();
                String pattern = @"^<(\w+)\s?[^>]*>(.*)<\/\1>$";
                Match match;
                if (Regex.IsMatch(html, pattern))
                {
                    match = Regex.Match(html, pattern);
                    if (ValidateInternals(match.Groups[2].Value))
                    {
                        return html;
                    }
                    else
                    {
                        Console.WriteLine("Invalid HTML.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid HTML.");
                }
            }
        }

        static bool ValidateInternals(String internals)
        {
            String pattern = @"(.*?)<(\w+)\s?[^>]*>(.*?)<\/\2>(.*)";
            Match match;
            if (Regex.IsMatch(internals, pattern))
            {
                match = Regex.Match(internals, pattern);
                return (ValidateInternals(match.Groups[1].Value) &&
                    ValidateInternals(match.Groups[3].Value) &&
                    ValidateInternals(match.Groups[4].Value));
            }
            else
            {
                pattern = @"<.*?>";
                if (Regex.IsMatch(internals, pattern))
                {
                    return false;
                }
                return true;
            }
        }

        static bool IsRepeating()
        {
            while (true)
            {
                Console.Write("Continue? (y/n): ");
                String input = Console.ReadLine().ToLower();
                if (Regex.IsMatch(input, "^y$|^yes$"))
                {
                    return true;
                }
                else if (Regex.IsMatch(input, "^n$|^no$"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}
