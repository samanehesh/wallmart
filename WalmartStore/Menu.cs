using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalmartStore;

namespace WalmartStore
{
    public class Menu
    {
        public Menu() { }
/// <summary>
/// makes the walmart header
/// </summary>
        public void MakeHeader()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\t\t\t\t\t*****************************************************");
            Console.WriteLine("\t\t\t\t\t*\t\tWALMART SALES MANAGER\t\t    *");
            Console.WriteLine("\t\t\t\t\t*****************************************************");
        }
/// <summary>
/// makes the maim menu
/// </summary>
        public void GetMainMenu()
        {
            bool isNotExit = true;
            while (isNotExit)
            {
                MakeHeader();
                Console.WriteLine("\n\n\n\t\t\t\t\tMAIN MENU\n");
                Console.WriteLine("\t\t\t\t\t1. Individual Store Statistics");
                Console.WriteLine("\t\t\t\t\t2. All Store Statistics");
                Console.WriteLine("\t\t\t\t\t3. Quit");
                Console.Write("\n\t\t\t\t\tPlease enter your selection:  ");

                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        int storeNumber = AskStoreNumber();
                        GetSubMenu("1", storeNumber);
                        break;

                    case "2":
                        GetSubMenu("2", 0);
                        break;

                    case "3":
                        MakeHeader();
                        Console.WriteLine("\n\n\n\t\t\t\t\tThank you for using the Walmart Sales Manager system.");
                        Console.Write("\n\t\t\t\t\tPress any key to exit.");
                        Console.ReadKey();
                        isNotExit = false;
                        break;

                    default:
                        Console.WriteLine("\n\t\t\t\t\tYour selection was invalid. Please try again:");
                        PressEnter();
                        break;
                }
                
            }

        }
/// <summary>
/// aska the user for store number and returns it
/// </summary>
/// <returns></returns>
        public int AskStoreNumber()
        {
            bool isNotExit = true;
            while (isNotExit)
            {
                MakeHeader();

                Console.Write("\n\n\n\t\t\t\t\tPlease enter store number (1-45): ");

                bool success = int.TryParse(Console.ReadLine(), out int storeNumber);
                if (success && storeNumber > 0 && storeNumber < 46)
                {
                    isNotExit = false;
                    return storeNumber;
                }
                else
                {
                    Console.WriteLine("\n\t\t\t\t\tYour selection was invalid. Please try again.");
                    PressEnter();
                }
            }
            return 0;
        }

/// <summary>
/// makes the sub menu
/// </summary>
/// <param name="choice"></param>
/// <param name="storeNumber"></param>
        public void GetSubMenu(string choice, int storeNumber)
        {
            StoreStatistics statistics = new StoreStatistics(storeNumber, choice);
            bool isNotExit = true;
            while (isNotExit)
            {
                MakeHeader();
                if (choice == "2")
                {
                    Console.WriteLine($"\n\n\n\t\t\t\t\tAll STORES\n");
                }
                else if (choice == "1")
                {
                    Console.WriteLine($"\n\n\n\t\t\t\t\tSTORE NUMBER {storeNumber}\n");
                }
                Console.WriteLine("\t\t\t\t\t1. Get total sales");
                Console.WriteLine("\t\t\t\t\t2. Get total monthly sales");
                Console.WriteLine("\t\t\t\t\t3. Get holiday sales");
                Console.WriteLine("\t\t\t\t\t4. Return to main menu");

                Console.Write("\n\t\t\t\t\tPlease enter your selection:  ");

                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        statistics.GetTotalSales();
                        break;

                    case "2":
                        string date = AskforDate();
                        statistics.GetTotalMonthlySales(date);
                        break;

                    case "3":
                        statistics.GetHolidaySales();
                        break;

                    case "4":
                        isNotExit = false;
                        break;

                    default:
                        Console.WriteLine("\n\t\t\t\t\tYour selection was invalid. Please try again:");
                        PressEnter();
                        break;
                }

            }
        }

/// <summary>
/// asks the user to input the date in a pre defined format and returns it
/// </summary>
/// <returns></returns>
        public string AskforDate()
        {
            string sDate = string.Empty;
            bool isNotExit = true;
            while (isNotExit)
            {
                MakeHeader();

                Console.Write("\n\n\n\t\t\t\t\tPlease enter the month and year in the format MM-YYYY: ");
                sDate = Console.ReadLine().Trim();
                bool success = DateTime.TryParse(sDate, out DateTime date);
                string formattedDate = date.ToString("MM-yyyy");

                if (success && date < DateTime.Today && sDate == formattedDate)
                {

                    isNotExit = false;
                }
                else
                {
                    Console.WriteLine("\n\t\t\t\t\tInvalid date. Please try again.");
                    PressEnter();
                }
            }
            return sDate;
        }
        public void PressEnter()
        {
            Console.Write("\n\t\t\t\t\tPress enter to continue.");
            Console.ReadKey();
        }
    }
}
