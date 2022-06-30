using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List1<int> list = new List1<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            foreach(var item in list)
            {
                Console.Write(item+" ");
            }    
        }
    }
}
