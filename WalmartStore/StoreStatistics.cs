using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WalmartStore
{
    internal class StoreStatistics
    {
        private int _storeNumber;
        private string _choice;
        private List<StoreData> _dataList;

/// <summary>
/// constructor: choice comes from menu choice(1 or 2) - individual store or all stores
/// </summary>
/// <param name="storeNumber"></param>
/// <param name="choice"></param>
        public StoreStatistics(int storeNumber, string choice)
        {
            this._storeNumber = storeNumber;
            this._choice = choice;

            ReadFile();
        }
/// <summary>
/// Read file and creats list of StoreData objects
/// </summary>
        public void ReadFile()
        {
            const string FILE_PATH = "../../files/Walmart_Store_Data.csv";

            if (File.Exists(FILE_PATH))
            {
                using (StreamReader reader = new StreamReader(FILE_PATH))
                {
                    _dataList = new List<StoreData>();

                    string line = reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        StoreData data = new StoreData(line);
                        _dataList.Add(data);

                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }

        }
/// <summary>
/// calculates the total sale of all stores or a store based on store number
/// </summary>
        public void GetTotalSales()
        {
            double totalSale = 0;
            if (_choice == "1")
            {
                foreach (StoreData storeData in _dataList)
                {
                    if (storeData._storeId == _storeNumber)
                    {
                        totalSale = storeData._weeklySale + totalSale;
                    }
                }
                Console.WriteLine($"\n\t\t\t\t\tTotal sale at store number #{_storeNumber}: {totalSale.ToString("C")}");

            }
            else if (_choice == "2")
            {
                foreach (StoreData storeData in _dataList)
                {
                    totalSale = storeData._weeklySale + totalSale;
                }
                Console.WriteLine($"\n\t\t\t\t\tTotal sale at all stores: {totalSale.ToString("C")}");

            }
            PressEnter();
        }
/// <summary>
/// calculate the monthly sale of all stores or a store based on store number
/// </summary>
/// <param name="date"></param>
        public void GetTotalMonthlySales(string date)
        {
            double totalSale = 0;
            if (_choice == "1")
            {
                foreach (StoreData storeData in _dataList)
                {
                    if (storeData._storeId == _storeNumber && storeData._date == date)
                    {
                        totalSale = storeData._weeklySale + totalSale;
                    }
                }
                Console.WriteLine($"\n\t\t\t\t\t{date} Total sale at store number #{_storeNumber}: {totalSale.ToString("C")}");

            }
            else if (_choice == "2")
            {
                foreach (StoreData storeData in _dataList)
                {
                    if (storeData._date == date)
                    {
                        totalSale = storeData._weeklySale + totalSale;

                    }
                }
                Console.WriteLine($"\n\t\t\t\t\t{date} Total sale at all stores: {totalSale.ToString("C")}");


            }
            PressEnter();
        }
/// <summary>
/// calculates the holiday sale of one store or all stors
/// </summary>
/// <param name="choice"></param>
/// <param name="storeNumber"></param>
        public void GetHolidaySales()
        {
            double totaholidaylSale = 0;

            if (_choice == "1")
            {
                foreach (StoreData storeData in _dataList)
                {
                    if (storeData._storeId == _storeNumber && storeData._holiday == 1)
                    {
                        totaholidaylSale = storeData._weeklySale + totaholidaylSale;
                    }
                }
                Console.WriteLine($"\n\t\t\t\t\tTotal holiday sale at store number #{_storeNumber}: {totaholidaylSale.ToString("C")}");

            }
            else if (_choice == "2")
            {
                foreach (StoreData storeData in _dataList)
                {
                    if (storeData._holiday == 1)
                    {
                        totaholidaylSale = storeData._weeklySale + totaholidaylSale;

                    }
                }
                Console.WriteLine($"\n\t\t\t\t\tTotal holiday sale at all stores: {totaholidaylSale.ToString("C")}");
            }
            PressEnter();
        }

        public void PressEnter()
        {
            Console.Write("\n\t\t\t\t\tPress enter to continue.");
            Console.ReadKey();
        }
    }
}
