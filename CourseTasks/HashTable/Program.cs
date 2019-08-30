using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> wood = new HashTable<string>();

            wood.Add("береза");
            wood.Add("осина");
            wood.Add("сосна");
            wood.Add("ель");
            wood.Add("рябина");
            wood.Add("ольха");
            wood.Add("дуб");
            wood.Add("бук");
            wood.Add("липа");
            wood.Add("акация");
        }
    }
}
