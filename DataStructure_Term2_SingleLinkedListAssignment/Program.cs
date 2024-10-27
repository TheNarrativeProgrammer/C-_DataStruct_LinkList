using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Term2_SingleLinkedListAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //add
            LinkedList<string> myFamilyList = new LinkedList<string>();
            myFamilyList.AddToHead("Reid");
            myFamilyList.AddToHead("Lauren");
            myFamilyList.AddToHead("Morgan");
            myFamilyList.AddToHead("mike");
            myFamilyList.Append_akaAddToTail("Sandy");
            myFamilyList.Insert("Will", 2);

            //Print
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(0);
            myFamilyList.GetDataAtIndex(2);
            myFamilyList.GetDataAtIndex(5);
            myFamilyList.GetDataAtIndex(7);

            //delete - from head
            Console.ReadLine();
            Console.Clear();
            myFamilyList.RemoveFromBeginning_akaHead();

            //Print
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(0);
            myFamilyList.GetDataAtIndex(2);
            myFamilyList.GetDataAtIndex(5);
            myFamilyList.GetDataAtIndex(7);


            //delete - from tail
            Console.ReadLine();
            Console.Clear();
            myFamilyList.RemoveFromEnd_akaTail();

          
            //Print
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(0);
            myFamilyList.GetDataAtIndex(2);
            myFamilyList.GetDataAtIndex(5);
            myFamilyList.GetDataAtIndex(7);


            //add
            myFamilyList.AddToHead("Dog - Lucy");
            myFamilyList.AddToHead("Dog - Raff");
            myFamilyList.Append_akaAddToTail("Ed");
            myFamilyList.Append_akaAddToTail("Bill");
            myFamilyList.Append_akaAddToTail("Lawerence");
            myFamilyList.Append_akaAddToTail("Lucette");
            myFamilyList.Insert("Luke", 2);
            myFamilyList.Insert("Baby", 4);

            //Print - new addtions
            Console.ReadLine();
            Console.Clear();
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(0);
            myFamilyList.GetDataAtIndex(2);
            myFamilyList.GetDataAtIndex(5);
            myFamilyList.GetDataAtIndex(7);

            //delete - from index - 0 
            Console.ReadLine();
            Console.Clear();
            myFamilyList.RemoveAtIndex(0);



            //Print
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(0);
            myFamilyList.GetDataAtIndex(2);
            myFamilyList.GetDataAtIndex(3);

            //delete - from index - 2
            Console.ReadLine();
            Console.Clear();
            myFamilyList.RemoveAtIndex(2);



            //Print
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(5);
            myFamilyList.GetDataAtIndex(6);
            myFamilyList.GetDataAtIndex(7);


            //delete - from index - 5
            Console.ReadLine();
            Console.Clear();
            myFamilyList.RemoveAtIndex(5);



            //Print
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(5);
            myFamilyList.GetDataAtIndex(6);
            myFamilyList.GetDataAtIndex(7);


            //delete - from index
            Console.ReadLine();
            Console.Clear();
            myFamilyList.RemoveAtIndex(6);



            //Print
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(5);
            myFamilyList.GetDataAtIndex(6);
            myFamilyList.GetDataAtIndex(7);


            //replace data at index
            Console.ReadLine();
            Console.Clear();
            myFamilyList.ReplaceDataAtIndex(5,"Robot");



            //Print
            myFamilyList.PrintAllDataInListDetail();
            myFamilyList.PrintAllDataInListStandard();
            myFamilyList.GetDataAtIndex(5);
            myFamilyList.GetDataAtIndex(6);
            myFamilyList.GetDataAtIndex(7);




            //prevent window from closing
            Console.ReadLine();
        }

       
    }
}
