//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Models.Auth;
using e_shop.Models.Product;
using e_shop.Services.Auth;
using e_shop.Services.Order;
using e_shop.Services.Storage;
namespace UserManagement
{
    class Program
    {
        static ILogInService logInService = new LogInService();
        static ICredentialService credentialService = new CredentialService();
        static IProductService productService = new ProductService();
        static IList<IShipping> shippings = new List<IShipping> { new Sea(), new Air(), new Ground() };
        static void Main(string[] args)
        {
            Console.WriteLine("------------ Welcome to online shopping -----------");
            Console.Write("Input your name: ");
            string userNameInput = Console.ReadLine();
            Console.Write("Input your password: ");
            string passwordInput = Console.ReadLine(); 
            Credential credential = GetCredential(userNameInput, passwordInput);

            if(logInService.CheckCredentialLogIn(credential))
            {
                List<Product> selectedProducts = new List<Product>();
                bool choosingProduct = true;
                do
                {
                    PrintProduct();
                    Console.Write("Select product: ");
                    string input = Console.ReadLine();
                    int selectedIndex = Convert.ToInt32(input);
                    if (selectedIndex == 0)
                    {
                        choosingProduct = false;
                    }
                    else
                    {
                        Console.Write("Enter weight: ");
                        string inputWeight = Console.ReadLine();
                        double weight = Convert.ToDouble(inputWeight);
                        productService.GetProducts()[selectedIndex-1].Weight = weight;
                        selectedProducts.Add(productService.GetProducts()[selectedIndex - 1]);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        PrintSuccessfullMessage("Successfully added ");
                        Console.ResetColor();
                    }
                } while (choosingProduct);

                Console.Clear();
                OrderService order = new OrderService(selectedProducts);
                PrintShippingTypes();
                Console.Write("Select shipping type: ");
                string inputShipping = Console.ReadLine();
                int selectedShippingType = Convert.ToInt32(inputShipping);
                order.SetShippingType(shippings[selectedShippingType]);
                Console.Clear();
                PrintSuccessfullMessage("Shipping successfully added");
                PrintOrderDetails(order);
            }
            else
            {
                credentialService.AddCredential(credential);
            }
        }
        static void PrintSuccessfullMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void PrintProduct()
        {
            Console.WriteLine("\t 0. Order create");
            int index = 1;
            foreach(var item in productService.GetProducts())
            {
                Console.WriteLine(index++ + "." + item.Name);
            }
        }

        static void PrintShippingTypes()
        {
            int index = 0; 
            foreach (var item in shippings)
            {
                Console.WriteLine(index++ + "." + item.GetType().Name);
            }
        }

        static Credential GetCredential(string userName, string password)
        {
            return new Credential()
            {
                UserName = userName,
                Password = password
            };
        }
        static void PrintOrderDetails(OrderService order)
        {
            Console.WriteLine($"Shipping cost: {order.GetShippingCost()}");
            Console.WriteLine($"Shipping weight: {order.GetTotalWeight()}");
            Console.WriteLine($"Shipping date: {order.GetShippingDate()}");
        }

    }
}