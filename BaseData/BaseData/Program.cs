using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData
{
    class Program
    {
       static string BigDataReader()
        {
            // чтение из файла
            using (FileStream fstream = File.OpenRead($"C:\\Users\\user\\Desktop\\database.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);

                //Console.WriteLine($"Текст из файла: {textFromFile}");
                return textFromFile;
            }
        }
        static void SortBigData(string[] bigData , string[] newMassive, int from)
        {
            int count = from;
            for (int i = 0; i < 149; i++)
            {
                newMassive[i] = bigData[count];
                count += 21;
            }
        }
        static void SwapElements(string[] MiddleData, int[] TransOrderPriority, int[] TransOrderData, int[] TransShipData, int i, int j)
        {
            string temp; int tomp;
            tomp = TransShipData[i];
            TransShipData[i] = TransShipData[j];
            TransShipData[j] = tomp;

            tomp = TransOrderData[i];
            TransOrderData[i] = TransOrderData[j];
            TransOrderData[j] = tomp;

            tomp = TransOrderPriority[i];
            TransOrderPriority[i] = TransOrderPriority[j];
            TransOrderPriority[j] = tomp;

            temp = MiddleData[i];
            MiddleData[i] = MiddleData[j];
            MiddleData[j] = temp;
        }
        static void SortMiddleData(string[] MiddleData, int[] TransOrderPriority, int[] TransOrderData, int[] TransShipData)
        {
            for (int i = 0; i < 149; i++)
            {
                for (int j = i + 1; j < 149; j++)
                {
                    if (TransOrderPriority[i] > TransOrderPriority[j])
                    {
                        SwapElements(MiddleData, TransOrderPriority, TransOrderData, TransShipData, i, j);
                    }
                    if (TransOrderPriority[i] == TransOrderPriority[j])
                    {
                        if (TransOrderData[i] > TransOrderData[j])
                        {
                            SwapElements(MiddleData, TransOrderPriority, TransOrderData, TransShipData, i, j);
                        }
                    }
                    if (TransOrderPriority[i] == TransOrderPriority[j])
                    {
                        if (TransOrderData[i] == TransOrderData[j])
                        {
                            if (TransShipData[i] > TransShipData[j])
                            {
                                SwapElements(MiddleData, TransOrderPriority, TransOrderData, TransShipData, i, j);
                            }
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string[] bigData = BigDataReader().Split(new char[] { ';' });

            string[] ShipData = new string[149];
            string[] OrderPriority = new string[149];
            string[] OrderData = new string[149];
            string[] ProductName = new string[149];
            string[] MiddleData = new string[149];

            SortBigData(bigData, ShipData, 20);
            SortBigData(bigData, OrderPriority, 3);
            SortBigData(bigData, OrderData, 2);
            SortBigData(bigData, ProductName, 16);

            int[] TransOrderData = new int[149];
            int[] TransShipData = new int[149];
            int[] TransOrderPriority = new int[149];

            TransForData(OrderData, TransOrderData);
            TransForData(ShipData, TransShipData);
            TransForPriority(OrderPriority, TransOrderPriority);

            for (int i = 0; i < MiddleData.Length; i++)
            {
                MiddleData[i] = MiddleData[i] + ProductName[i] + " " + OrderPriority[i] + " " + OrderData[i] + " " + ShipData[i];
            }

            SortMiddleData(MiddleData, TransOrderPriority, TransOrderData, TransShipData);

            for (int i = 0; i < MiddleData.Length; i++)
            {
                MiddleData[i] = MiddleData[i] + $"\t*{i + 1}*";
            }

            while (true) 
            {
                for (int i = 0; i < MiddleData.Length; i++)
                {
                    Console.WriteLine(MiddleData[i]);
                }
                AbilityToCancelAnOrder(MiddleData);
                Console.Clear();
            }
        }
        static void AbilityToCancelAnOrder(string[] MiddleData)
        {
            Console.WriteLine("Какой заказ отменить?");
            int key = Convert.ToInt32(Console.ReadLine())-1;
            while (Convert.ToInt32(key)<=0 && Convert.ToInt32(key)>149)
            {
                Console.WriteLine("Нет такого заказа");
                key = Convert.ToInt32(Console.ReadLine())+1;
            }
            MiddleData[key] = "";
        }
        static void TransForData(string[] data, int[] newArray)
        {
            for (int i = 0; i < data.Length; i++)
            {
                string[] str = data[i].Split(new char[] { '.' });
                newArray[i] = Convert.ToInt32(str[0]) + Convert.ToInt32(str[1]) * 30 + Convert.ToInt32(str[2]) * 365;
            }
        }
        static void TransForPriority(string[] priority, int[] newArray)
        {
            for (int i = 0; i < priority.Length; i++)
            {
                string str = priority[i];
                if (str == "Low") newArray[i] = 1;
                if (str == "Medium") newArray[i] = 2;
                if (str == "High") newArray[i] = 3;
                if (str == "Critical") newArray[i] = 4;
                if (str == "Not Specified") newArray[i] = 0;
            }
        }
    }
}
