using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            
                 IDocument<string> cert = new Certificate();

                 cert.GenerateDocument();

                IDocument<string> invoice = new Invoice();

                invoice.GenerateDocument();

                IDocument<string> noClaimBonus = new NoClaimBonus();

                noClaimBonus.GenerateDocument();

















            
            // XtraForm1 xtra = new XtraForm1();

           // xtra.ShowDialog();

           // var time = DateTime.Now.TimeOfDay.Hours;
           // var time2 = DateTime.Now.AddHours(12);

           // DateTime datetime = Convert.ToDateTime("12-03-2019 00:01:00");

           // var t3 = datetime.Hour;

           // if(t3 == 0 && datetime.Minute == 1)
           // {
           //     Console.Write("a");
           // }

           // Singleton singleton;

           // singleton = Singleton.Instance;

           // singleton.Display();

           // List<int> a = new List<int> { 1, 2, 3, 4, 5, 6 };
        
           //var v =  a.Where(x => x % 2 == 0).Sum(x=> x).ToString();

           // Console.WriteLine(v);

         //   Console.Read();


        }
    }
}
