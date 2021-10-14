using System;
using yunoshev_lab4.KitchenHood;

namespace yunoshev_lab4
{
    class Program
    {

        public static void PrintMainMenu()
        {
            Console.WriteLine("\nВыберите действие: ");
            Console.WriteLine("1 - создать прибор");
            Console.WriteLine("2 - удалить прибор");
            Console.WriteLine("3 - использовать прибор");
            Console.WriteLine("4 - список приборов конкретного типа");
            Console.WriteLine("5 - посмотреть все приборы");
        }

        static void Main(string[] args)
        {
            //Hood device = new Hood("Hood serial 1", "Vitek", "VM-03");
            //Console.WriteLine(device.GetType().Name); 
            DeviceManager.CreateDevices(); // создание приборов
            while (true)
            {
                DeviceManager.device = null;
                PrintMainMenu();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        DeviceManager.CreateDevice();
                        break;
                    case 2:
                        DeviceManager.device = DeviceManager.ChooseDevice();
                        if (DeviceManager.device != null)
                        {
                            DeviceManager.RemoveDevice(DeviceManager.device);
                        }
                        else Console.WriteLine("Невозможно выполнить операцию! " +
                                "Вероятно, приборов такой категории не существует...");
                        break;
                    case 3:
                        DeviceManager.device = DeviceManager.ChooseDevice();
                        if (DeviceManager.device != null)
                        {
                            DeviceManager.DeviceProcess(DeviceManager.device);
                        }
                        else Console.WriteLine("Невозможно выполнить операцию! " +
                                "Вероятно, приборов такой категории не существует...");
                        break;
                    case 4:
                        DeviceManager.ShowDevicesByCategory();
                        break;
                    case 5:
                        Console.WriteLine("Кондиционеры:"); DeviceManager.PrintDeviceList(DeviceManager.ACList);
                        Console.WriteLine("\nХлебопечи:"); DeviceManager.PrintDeviceList(DeviceManager.breadMakersList);
                        Console.WriteLine("\nВытяжки:"); DeviceManager.PrintDeviceList(DeviceManager.hoodList);
                        Console.WriteLine("\nРадио:"); DeviceManager.PrintDeviceList(DeviceManager.radioList);
                        Console.WriteLine("\nТелевизоры:"); DeviceManager.PrintDeviceList(DeviceManager.TVList);
                        break;
                }
            }
        }
    }
}
