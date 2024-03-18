//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Models.Auth;
using e_shop.Services.Auth;
namespace UserManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            LogInService logInService = new LogInService();
            string userChoice;
            int choice = 0;
            do
            {
                Print();
                Console.Write("Enter your choice: ");
                userChoice = Console.ReadLine();
                try
                {
                    choice = Convert.ToInt32(userChoice);
                    switch (choice)
                    {
                        case 1:
                            {
                                Credential credential = new Credential();
                                Console.Write("Enter your username: ");
                                string newUserName = Console.ReadLine();
                                credential.UserName = newUserName;
                                Console.Write("Enter your password: ");
                                string newUserPassword = Console.ReadLine();
                                credential.Password = newUserPassword;
                                logInService.AddCredential(credential);
                            }
                            break;

                        case 2:
                            {
                                Credential credential = new Credential();
                                Console.Write("Username: ");
                                string userName = Console.ReadLine();
                                credential.UserName = userName;
                                Console.Write("Password: ");
                                string password = Console.ReadLine();
                                credential.Password = password;
                                logInService.CheckCredentialLogIn(credential);
                            }
                            break;

                        case 0:
                            {
                                Console.WriteLine("Exiting program...");
                                break;
                            }
                        default:
                            {
                                throw new Exception("Invalid choice. Please enter a valid option.");
                            }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer choice.");
                    choice = -1;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                Console.Write("Do you want to continue yes(y) or no(n): ");
                string continueChoice = Console.ReadLine();

                if (continueChoice.ToLower() != "y")
                {
                    Console.WriteLine("Thank you for using our console app");
                    break;
                }

            } while (choice != 0);
        }
        static void Print()
        {
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Log In");
            Console.WriteLine("0. Exit");
        }

    }
}