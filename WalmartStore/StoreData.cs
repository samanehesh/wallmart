using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalmartStore
{

    public class StoreData
    {
        public int _storeId { get; }
        public string _date { get; }
        public double _weeklySale { get; }
        public int _holiday { get; }
/// <summary>
/// constructor, split the line and assign to class parameters
/// </summary>
/// <param name="line"></param>
        public StoreData(string line)
        {
            const int START_DATE_STRING = 3;
            const int END_DATE_LENGTH = 7;
            string[] parts = line.Split(',');
            string sDate = parts[1].Substring(START_DATE_STRING, END_DATE_LENGTH);

            try
            {
                this._storeId = int.Parse(parts[0]);
                this._date = sDate;
                this._weeklySale = double.Parse(parts[2]);
                this._holiday = int.Parse(parts[3]);
            }
            catch (Exception)
            {
                Console.WriteLine("Can't read data from file.");
            }
        }

    }
}
