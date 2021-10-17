using System;
using System.Diagnostics;
using yunoshev_lab4.KitchenHood;

namespace yunoshev_lab4
{
    class Program
    {
        static Stopwatch stopWatch = new Stopwatch();
        
        ///////////////////////////////////////// Check RunTime  /////////////////////////////////////
        static void Main(string[] args)
        {
            stopWatch.Start();
            for (int i = 0; i < 100; i++)
                DeviceManager.CreateDevices();

            for (int i = 0; i < 100; i++)
            {
                DeviceManager.PrintDeviceList(DeviceManager.ACList);
                DeviceManager.PrintDeviceList(DeviceManager.breadMakersList);
                DeviceManager.PrintDeviceList(DeviceManager.hoodList);
                DeviceManager.PrintDeviceList(DeviceManager.radioList);
                DeviceManager.PrintDeviceList(DeviceManager.TVList);
            }
                

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
            Console.WriteLine("RunTime (h:m:s:ms) " + elapsedTime);
        }





        ///////////////////////////////////////// program with user menu /////////////////////////////////////

        //public static void PrintMainMenu()
        //{
        //    Console.WriteLine("\nВыберите действие: ");
        //    Console.WriteLine("1 - создать прибор");
        //    Console.WriteLine("2 - удалить прибор");
        //    Console.WriteLine("3 - использовать прибор");
        //    Console.WriteLine("4 - список приборов конкретного типа");
        //    Console.WriteLine("5 - посмотреть все приборы");
        //}

        //static void Main(string[] args)
        //{ 
        //    DeviceManager.CreateDevices(); // создание приборов
        //    while (true)
        //    {
        //        DeviceManager.device = null;
        //        PrintMainMenu();
        //        switch (Convert.ToInt32(Console.ReadLine()))
        //        {
        //            case 1:
        //                DeviceManager.CreateDevice();
        //                break;
        //            case 2:
        //                DeviceManager.device = DeviceManager.ChooseDevice();
        //                if (DeviceManager.device != null)
        //                {
        //                    DeviceManager.RemoveDevice(DeviceManager.device);
        //                }
        //                else Console.WriteLine("Невозможно выполнить операцию! " +
        //                        "Вероятно, приборов такой категории не существует...");
        //                break;
        //            case 3:
        //                DeviceManager.device = DeviceManager.ChooseDevice();
        //                if (DeviceManager.device != null)
        //                {
        //                    DeviceManager.DeviceProcess(DeviceManager.device);
        //                }
        //                else Console.WriteLine("Невозможно выполнить операцию! " +
        //                        "Вероятно, приборов такой категории не существует...");
        //                break;
        //            case 4:
        //                DeviceManager.ShowDevicesByCategory();
        //                break;
        //            case 5:
        //                Console.WriteLine("Кондиционеры:"); DeviceManager.PrintDeviceList(DeviceManager.ACList);
        //                Console.WriteLine("\nХлебопечи:"); DeviceManager.PrintDeviceList(DeviceManager.breadMakersList);
        //                Console.WriteLine("\nВытяжки:"); DeviceManager.PrintDeviceList(DeviceManager.hoodList);
        //                Console.WriteLine("\nРадио:"); DeviceManager.PrintDeviceList(DeviceManager.radioList);
        //                Console.WriteLine("\nТелевизоры:"); DeviceManager.PrintDeviceList(DeviceManager.TVList);
        //                break;
        //        }
        //    }
        //}
    }
}
