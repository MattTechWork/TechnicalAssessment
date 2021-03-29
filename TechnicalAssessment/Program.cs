using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TechnicalAssessment
{
    class Program
    {

        static string GetFilePath()
        {
            Console.WriteLine("Please enter the path to a txt file");
            String path = Console.ReadLine();
            return path;
        }

        static string GetPropAnswer()
        {
            Console.WriteLine("Would you like to re-order this list?");
            String answer = Console.ReadLine();
            return answer;
        }

        static string GetPropertyOrder()
        {
            Console.WriteLine("Which property would you like to order the data by?.");
            String propertyOrder = Console.ReadLine();
            return propertyOrder;
        }

        static string GetAnswer()
        {
            Console.WriteLine("Would you like to export this list to a new txt file?");
            String answer = Console.ReadLine();
            return answer;
        }

        static string GetNewFilePath()
        {
            Console.WriteLine("Please enter a new file path to a txt file");
            String newFilePath = Console.ReadLine();
            return newFilePath;
        }

        static void Main(string[] args)
        {

            string filePath = GetFilePath();

            var lineCount = File.ReadLines(filePath).Count();
            if (lineCount <= 1)
            {
                Console.WriteLine("You must include multiple lines in your txt document.");
                Environment.Exit(-1);
            }
            else
            {
                List<Customer> customers = new List<Customer>();

                List<string> lines = File.ReadAllLines(filePath).ToList();
                Console.WriteLine();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');

                    Customer newCustomer = new Customer();

                    newCustomer.FirstName = entries[0];
                    newCustomer.LastName = entries[1];
                    newCustomer.Id = entries[2];
                    newCustomer.MobileNumber = entries[3];
                    newCustomer.Email = entries[4];

                    customers.Add(newCustomer);
                }

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.Id} {customer.MobileNumber} {customer.Email}");

                }

                foreach (var customer in customers)
                {
                    string propAnswer = GetPropAnswer();
                    if (propAnswer == "yes")
                    {

                        string propOrder = GetPropertyOrder();

                        switch (propOrder)
                        {
                            case "LastName":
                                Console.WriteLine($"{customer.LastName} {customer.FirstName} {customer.Id} {customer.MobileNumber} {customer.Email}");
                                break;
                            case "Id":
                                Console.WriteLine($"{customer.Id} {customer.FirstName} {customer.LastName} {customer.MobileNumber} {customer.Email}");
                                break;
                            case "MobileNumber":
                                Console.WriteLine($"{customer.MobileNumber} {customer.FirstName} {customer.LastName} {customer.Id} {customer.Email}");
                                break;
                            case "Email":
                                Console.WriteLine($"{customer.Email} {customer.FirstName} {customer.LastName} {customer.Id} {customer.MobileNumber}");
                                break;
                        }
                        break;
                    }
                    break;
                }

                string answer = GetAnswer();
                if (answer == "yes")
                {
                    string newFilePath = GetNewFilePath();
                    StreamWriter OurStream;
                    OurStream = File.CreateText(newFilePath);
                    OurStream.WriteLine();
                    OurStream.Close();
                    Console.WriteLine("File created!");
                }
                else
                {
                    Console.WriteLine("The end of the program");
                }

              Console.ReadLine();
            }
        }
    }
}