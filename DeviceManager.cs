using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yunoshev_lab4.AC;
using yunoshev_lab4.Device;
using yunoshev_lab4.BreadMaker;
using yunoshev_lab4.KitchenHood;
using yunoshev_lab4.Radio;
using yunoshev_lab4.TV;


namespace yunoshev_lab4
{
    public class DeviceManager
    {
        static string inputstring;
        static string manufacturer, model, serial;
        public static List<AirConditioner> ACList = new List<AirConditioner>();
        public static List<BreadMaker.BreadMaker> breadMakersList = new List<BreadMaker.BreadMaker>();
        public static List<Hood> hoodList = new List<Hood>();
        public static List<Radio.Radio> radioList = new List<Radio.Radio>();
        public static List<TV.TV> TVList = new List<TV.TV>();
        public static Device.Device device;


        public static void PrintDeviceTypeChoosing()
        {
            Console.WriteLine("Выберите тип прибора: ");
            Console.WriteLine("1 - кондиционер");
            Console.WriteLine("2 - хлебопечь");
            Console.WriteLine("3 - вытяжка");
            Console.WriteLine("4 - радио");
            Console.WriteLine("5 - телевизор");
        }

        public static void PrintDeviceList<T>(List<T> list) where T : Device.Device
        {
            if (list.Count > 0)
            {
                int position = 1;
                foreach (T listItem in list)
                {
                    Console.WriteLine(position + ". " 
                        + listItem.GetFullProductDescription());
                    position++;
                }
            }
            else Console.WriteLine("Не существует созданных приборов этого типа!");
        }

        private static void AirConditionerProcess(AirConditioner device)
        {
            while (true)
            {
                Console.WriteLine(device.GetFullProductDescription());
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Включить/выключить");
                Console.WriteLine("2 - Выбрать режим");
                Console.WriteLine("3 - Изменить температуру");
                Console.WriteLine("4 - Установить таймер");
                Console.WriteLine("0 - Выход");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: return;
                    case 1:
                        if (device.GetCurrentStateOnOff())
                            device.OFF();
                        else
                            device.ON();
                        break;
                    case 2:
                        if (device.GetCurrentStateOnOff())
                        {
                            Console.WriteLine("Выберите режим: ");
                            Console.WriteLine("1 - " + ACModes.Cooling);
                            Console.WriteLine("2 - " + ACModes.Heating);
                            Console.WriteLine("3 - " + ACModes.Ventilation);
                            Console.WriteLine("4 - " + ACModes.Dehumidification);
                            Console.WriteLine("5 - " + ACModes.AirPurification);
                            Console.WriteLine("0 - Назад");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 0:
                                    break;
                                case 1:
                                    device.SetCurrentACMode(ACModes.Cooling);
                                    Console.WriteLine("Выбран режим " + ACModes.Cooling);
                                    break;
                                case 2:
                                    device.SetCurrentACMode(ACModes.Heating);
                                    Console.WriteLine("Выбран режим " + ACModes.Heating);
                                    break;
                                case 3:
                                    device.SetCurrentACMode(ACModes.Ventilation);
                                    Console.WriteLine("Выбран режим " + ACModes.Ventilation);
                                    break;
                                case 4:
                                    device.SetCurrentACMode(ACModes.Dehumidification);
                                    Console.WriteLine("Выбран режим " + ACModes.Dehumidification);
                                    break;
                                case 5:
                                    device.SetCurrentACMode(ACModes.AirPurification);
                                    Console.WriteLine("Выбран режим " + ACModes.AirPurification);
                                    break;
                                default:
                                    Console.WriteLine("Такого режима не существует");
                                    break;
                            }
                        }
                        else Console.WriteLine("Кондиционер выключен, нельзя выбрать режим.");
                        break;
                    case 3:
                        if (device.GetCurrentStateOnOff())
                        {
                            bool run = true;
                            while (run)
                            {
                                Console.WriteLine("Температура: " + device.GetTemperature());
                                Console.WriteLine("1 - Увеличить");
                                Console.WriteLine("2 - Уменьшить");
                                Console.WriteLine("0 - Назад");
                                switch (Convert.ToInt32(Console.ReadLine()))
                                {
                                    case 0:
                                        run = false;
                                        break;
                                    case 1:
                                        device.IncrementTemperature();
                                        break;
                                    case 2:
                                        device.DecrementTemperature();
                                        break;
                                    default:
                                        Console.WriteLine("Повторите попытку!");
                                        break;
                                }
                            }
                        }
                        else Console.WriteLine("Кондиционер выключен, нельзя изменить температуру.");
                        break;

                    case 4:
                        if (device.GetCurrentStateOnOff())
                        {
                            Console.WriteLine("1 - Установить таймер, если он не установлен");
                            Console.WriteLine("2 - Выключить таймер");
                            Console.WriteLine("0 - Назад");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 0:
                                    break;
                                case 1:
                                    device.ConsoleSetTimer();
                                    break;
                                case 2:
                                    device.StopTimer();
                                    break;
                                default:
                                    Console.WriteLine("Повторите попытку!");
                                    break;
                            }
                        }
                        else Console.WriteLine("Кондиционер выключен, нельзя установить таймер.");
                        break;
                    default:
                        Console.WriteLine("Повторите попытку!");
                        break;
                }
            }

        }

        private static void BreadMakerProcess(BreadMaker.BreadMaker device)
        {
            while (true)
            {
                Console.WriteLine(device.GetFullProductDescription());
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Включить/выключить");
                Console.WriteLine("2 - Открыть/закрыть крышку");
                Console.WriteLine("3 - Выбрать режим приготовления хлеба");
                Console.WriteLine("4 - Выбрать режим приготовления теста");
                Console.WriteLine("5 - Начать/остановить приготовление текущего режима");
                Console.WriteLine("6 - Установить таймер");
                Console.WriteLine("0 - Выход");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: return;
                    case 1:
                        if (device.GetCurrentStateOnOff())
                            device.OFF();
                        else
                            device.ON();
                        break;
                    case 2:
                        if (device.GetCapOpenState())
                            device.CloseCap();
                        else
                            device.OpenCap();
                        break;
                    case 3:
                        Console.WriteLine("Выберите режим: ");
                        Console.WriteLine("1 - " + BreadCookingModes.GlutenFreeBread);
                        Console.WriteLine("2 - " + BreadCookingModes.DietaryBread);
                        Console.WriteLine("3 - " + BreadCookingModes.WheatBread);
                        Console.WriteLine("4 - " + BreadCookingModes.SweetPastries);
                        Console.WriteLine("5 - " + BreadCookingModes.FrenchBread);
                        Console.WriteLine("6 - " + BreadCookingModes.WholeGrainBread);
                        Console.WriteLine("7 - " + BreadCookingModes.FastBaking);
                        Console.WriteLine("0 - Назад");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 0:
                                break;
                            case 1:
                                device.SetCurrentBreadCookingMode(BreadCookingModes.GlutenFreeBread);
                                Console.WriteLine("Выбран режим приготовления хлеба " + BreadCookingModes.GlutenFreeBread);
                                break;
                            case 2:
                                device.SetCurrentBreadCookingMode(BreadCookingModes.DietaryBread);
                                Console.WriteLine("Выбран режим приготовления хлеба " + BreadCookingModes.DietaryBread);
                                break;
                            case 3:
                                device.SetCurrentBreadCookingMode(BreadCookingModes.WheatBread);
                                Console.WriteLine("Выбран режим приготовления хлеба " + BreadCookingModes.WheatBread);
                                break;
                            case 4:
                                device.SetCurrentBreadCookingMode(BreadCookingModes.SweetPastries);
                                Console.WriteLine("Выбран режим приготовления хлеба " + BreadCookingModes.SweetPastries);
                                break;
                            case 5:
                                device.SetCurrentBreadCookingMode(BreadCookingModes.FrenchBread);
                                Console.WriteLine("Выбран режим приготовления хлеба " + BreadCookingModes.FrenchBread);
                                break;
                            case 6:
                                device.SetCurrentBreadCookingMode(BreadCookingModes.WholeGrainBread);
                                Console.WriteLine("Выбран режим приготовления хлеба " + BreadCookingModes.WholeGrainBread);
                                break;
                            case 7:
                                device.SetCurrentBreadCookingMode(BreadCookingModes.FastBaking);
                                Console.WriteLine("Выбран режим приготовления хлеба " + BreadCookingModes.FastBaking);
                                break;
                            default:
                                Console.WriteLine("Такого режима не существует");
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Выберите режим: ");
                        Console.WriteLine("1 - " + DoughCookingModes.Unleavened);
                        Console.WriteLine("2 - " + DoughCookingModes.Yeast);
                        Console.WriteLine("3 - " + DoughCookingModes.Pizza);
                        Console.WriteLine("0 - Назад");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 0:
                                break;
                            case 1:
                                device.SetCurrentDoughCookingMode(DoughCookingModes.Unleavened);
                                Console.WriteLine("Выбран режим приготовления теста " + DoughCookingModes.Unleavened);
                                break;
                            case 2:
                                device.SetCurrentDoughCookingMode(DoughCookingModes.Yeast);
                                Console.WriteLine("Выбран режим приготовления теста " + DoughCookingModes.Yeast);
                                break;
                            case 3:
                                device.SetCurrentDoughCookingMode(DoughCookingModes.Pizza);
                                Console.WriteLine("Выбран режим приготовления теста " + DoughCookingModes.Pizza);
                                break;
                            default:
                                Console.WriteLine("Такого режима не существует");
                                break;
                        }
                        break;
                    case 5:

                        if (device.GetActiveCookingState() == false)
                        {
                            bool isStart = device.StartCurrentMode();
                            if (isStart == false)
                            {
                                Console.WriteLine("Невозможно начать приготовление! " +
                                        "Возможно, Вы не включили прибор, не выбрали режим " +
                                        "или не закрыли крышку.");
                            }
                        }
                        else device.StopCurrentMode();

                        break;

                    case 6:
                        Console.WriteLine("1 - Установить таймер, если он не установлен");
                        Console.WriteLine("2 - Выключить таймер");
                        Console.WriteLine("0 - Назад");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 0:
                                break;
                            case 1:
                                device.ConsoleSetTimer();
                                break;
                            case 2:
                                device.StopTimer();
                                break;
                            default:
                                Console.WriteLine("Повторите попытку!");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Повторите попытку!");
                        break;
                }
            }

        }

        private static void HoodProcess(Hood device)
        {
            while (true)
            {
                Console.WriteLine(device.GetFullProductDescription());
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Включить/выключить подсветку");
                Console.WriteLine("2 - Добавить скорость");
                Console.WriteLine("3 - Убавить скорость");
                Console.WriteLine("4 - Установить таймер");
                Console.WriteLine("0 - Выход");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: return;
                    case 1:
                        if (device.GetCurrentBacklight())
                            device.BacklightOFF();
                        else
                            device.BacklightON();
                        break;
                    case 2:
                        if (device.GetCurrentSpeed() >= 3)
                        {
                            Console.WriteLine("Скорость установлена максимальная, невозможно увеличить.");
                        }
                        else device.IncrementSpeed();
                        break;
                    case 3:
                        if (device.GetCurrentSpeed() <= 0)
                        {
                            Console.WriteLine("Вытяжка выключена, невозможно уменьшить скорость");
                        }
                        else device.DecrementSpeed();
                        break;
                    case 4:
                        if (device.GetCurrentStateOnOff() || device.GetCurrentBacklight())
                        {
                            Console.WriteLine("1 - Установить таймер, если он не установлен");
                            Console.WriteLine("2 - Выключить таймер");
                            Console.WriteLine("0 - Назад");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 0:
                                    break;
                                case 1:
                                    device.ConsoleSetTimer();
                                    break;
                                case 2:
                                    device.StopTimer();
                                    break;
                                default:
                                    Console.WriteLine("Повторите попытку!");
                                    break;
                            }
                        }
                        else Console.WriteLine("Невозможно установить таймер, вытяжка выключена");
                        break;
                    default:
                        Console.WriteLine("Повторите попытку!");
                        break;
                }
            }

        }

        private static void RadioProcess(Radio.Radio device)
        {
            while (true)
            {
                Console.WriteLine(device.GetFullProductDescription());
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Включить/выключить");
                Console.WriteLine("2 - Переключить канал вперёд");
                Console.WriteLine("3 - Переключить канал назад");
                Console.WriteLine("4 - Добавить громкость");
                Console.WriteLine("5 - Убавить громкость");
                Console.WriteLine("6 - Установить таймер");
                Console.WriteLine("0 - Выход");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: return;
                    case 1:
                        if (device.GetCurrentStateOnOff())
                            device.OFF();
                        else
                            device.ON();
                        break;
                    case 2:
                        device.IncrementStation();
                        break;
                    case 3:
                        device.DecrementStation();
                        break;
                    case 4:
                        if (device.GetCurrentVolume() < 100) device.IncrementVolume();
                        else Console.WriteLine("Громкость максимальная");
                        break;
                    case 5:
                        if (device.GetCurrentVolume() > 0) device.DecrementVolume();
                        else Console.WriteLine("Громкость минимальная");
                        break;
                    case 6:
                        if (device.GetCurrentStateOnOff())
                        {
                            Console.WriteLine("1 - Установить таймер, если он не установлен");
                            Console.WriteLine("2 - Выключить таймер");
                            Console.WriteLine("0 - Назад");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 0:
                                    break;
                                case 1:
                                    device.ConsoleSetTimer();
                                    break;
                                case 2:
                                    device.StopTimer();
                                    break;
                                default:
                                    Console.WriteLine("Повторите попытку!");
                                    break;
                            }
                        }
                        else Console.WriteLine("Невозможно установить таймер, радио выключено");
                        break;
                    default:
                        Console.WriteLine("Повторите попытку!");
                        break;
                }
            }

        }

        private static void TVProcess(TV.TV device)
        {
            while (true)
            {
                Console.WriteLine(device.GetFullProductDescription());
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Включить/выключить");
                Console.WriteLine("2 - Переключить канал вперёд");
                Console.WriteLine("3 - Переключить канал назад");
                Console.WriteLine("4 - Добавить громкость");
                Console.WriteLine("5 - Убавить громкость");
                Console.WriteLine("6 - Выключить звук");
                Console.WriteLine("7 - Установить таймер");
                Console.WriteLine("0 - Выход");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: return;
                    case 1:
                        if (device.GetCurrentStateOnOff())
                            device.OFF();
                        else
                            device.ON();
                        break;
                    case 2:
                        device.IncrementChannel();
                        break;
                    case 3:
                        device.DecrementChannel();
                        break;
                    case 4:
                        if (device.GetCurrentVolume() < 100) device.IncrementVolume();
                        else Console.WriteLine("Громкость максимальная");
                        break;
                    case 5:
                        if (device.GetCurrentVolume() > 0) device.DecrementVolume();
                        else Console.WriteLine("Громкость минимальная");
                        break;
                    case 6:
                        device.MuteVolume();
                        break;
                    case 7:
                        if (device.GetCurrentStateOnOff())
                        {
                            Console.WriteLine("1 - Установить таймер, если он не установлен");
                            Console.WriteLine("2 - Выключить таймер");
                            Console.WriteLine("0 - Назад");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 0:
                                    break;
                                case 1:
                                    device.ConsoleSetTimer();
                                    break;
                                case 2:
                                    device.StopTimer();
                                    break;
                                default:
                                    Console.WriteLine("Повторите попытку!");
                                    break;
                            }
                        }
                        else Console.WriteLine("Невозможно установить таймер, телевизор выключен");
                        break;
                    default:
                        Console.WriteLine("Повторите попытку!");
                        break;
                }
            }

        }

        public static void DeviceProcess(Device.Device device)
        {
            AirConditioner airConditioner;
            BreadMaker.BreadMaker breadMaker;
            Hood hood;
            Radio.Radio radio;
            TV.TV tv;
            switch (device.GetType().Name)
            {
                case "AirConditioner":
                    airConditioner = (AirConditioner)device;
                    AirConditionerProcess(airConditioner);
                    break;
                case "BreadMaker":
                    breadMaker = (BreadMaker.BreadMaker)device;
                    BreadMakerProcess(breadMaker);
                    break;
                case "Hood":
                    hood = (Hood)device;
                    HoodProcess(hood);
                    break;
                case "Radio":
                    radio = (Radio.Radio)device;
                    RadioProcess(radio);
                    break;
                case "TV":
                    tv = (TV.TV)device;
                    TVProcess(tv);
                    break;
                default:
                    Console.WriteLine("Error in DeviceProcess method");
                    return;
            }


        }

        public static void RemoveDevice(Device.Device device)
        {
            try
            {
              
                switch (device.GetType().Name)
                {
                    case "AirConditioner":
                        ACList.Remove((AirConditioner)device);
                        Console.WriteLine("Успешно!");
                        break;
                    case "BreadMaker":
                        breadMakersList.Remove((BreadMaker.BreadMaker)device);
                        Console.WriteLine("Успешно!");
                        break;
                    case "Hood":
                        hoodList.Remove((Hood)device);
                        Console.WriteLine("Успешно!");
                        break;
                    case "Radio":
                        radioList.Remove((Radio.Radio)device);
                        Console.WriteLine("Успешно!");
                        break;
                    case "TV":
                        TVList.Remove((TV.TV)device);
                        Console.WriteLine("Успешно!");
                        break;
                    default:
                        Console.WriteLine("Такой категории не существует");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так...");
            }
        }


        public static Device.Device ChooseDevice()
        {
            int devicePosition;
            PrintDeviceTypeChoosing();
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    if (ACList.Count > 0)
                    {
                        PrintDeviceList(ACList);
                        Console.WriteLine("Выберите прибор по номеру: ");
                        devicePosition = Convert.ToInt32(Console.ReadLine()) - 1;
                        return ACList[devicePosition];
                    }
                    return null;

                case 2:
                    if (breadMakersList.Count > 0)
                    {
                        PrintDeviceList(breadMakersList);
                        Console.WriteLine("Выберите прибор по номеру: ");
                        devicePosition = Convert.ToInt32(Console.ReadLine()) - 1;
                        return breadMakersList[devicePosition];
                    }
                    return null;

                case 3:
                    if (hoodList.Count > 0)
                    {
                        PrintDeviceList(hoodList);
                        Console.WriteLine("Выберите прибор по номеру: ");
                        devicePosition = Convert.ToInt32(Console.ReadLine()) - 1;
                        return hoodList[devicePosition];
                    }
                    return null;

                case 4:
                    if (radioList.Count > 0)
                    {
                        PrintDeviceList(radioList);
                        Console.WriteLine("Выберите прибор по номеру: ");
                        devicePosition = Convert.ToInt32(Console.ReadLine()) - 1;
                        return radioList[devicePosition];
                    }
                    return null;

                case 5:
                    if (TVList.Count > 0)
                    {
                        PrintDeviceList(TVList);
                        Console.WriteLine("Выберите прибор по номеру: ");
                        devicePosition = Convert.ToInt32(Console.ReadLine()) - 1;
                        return TVList[devicePosition];
                    }
                    return null;

                default:
                    return null;
            }
        }

        public static void CreateDevices()
        {
            ACList.Add(new AirConditioner("AC serial 1", "Cooper Hunter", "Prima Plus"));
            ACList.Add(new AirConditioner("AC serial 2", "Cooper Hunter", "Winner"));
            ACList.Add(new AirConditioner("AC serial 3", "NeoClima", "Therminator"));
            ACList.Add(new AirConditioner("AC serial 4", "Mitsubishi", "Classic MS-GF60"));
            ACList.Add(new AirConditioner("AC serial 5", "Midea", "Ultimate Comfort"));

            breadMakersList.Add(new BreadMaker.BreadMaker("BreadMaker serial 1", "Gorenje", "BM1400E"));
            breadMakersList.Add(new BreadMaker.BreadMaker("BreadMaker serial 2", "Gorenje", "BM1600WG"));
            breadMakersList.Add(new BreadMaker.BreadMaker("BreadMaker serial 3", "Panasonic", "SD-2510"));

            hoodList.Add(new Hood("Hood serial 1", "Vitek", "VM-03"));

            radioList.Add(new Radio.Radio("Radio serial 1", "Philips", "Virtual50"));

            TVList.Add(new TV.TV("TV serial 1", "Samsung", "Pq30TV55HD"));
        }

        public static AirConditioner CreateAC()
        {
            Console.WriteLine("Введите производителя кондиционера: ");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Введите модель кондиционера: ");
            model = Console.ReadLine();
            Console.WriteLine("Введите серийный номер кондиционера: ");
            serial = Console.ReadLine();
            return new AirConditioner(serial, manufacturer, model);
        }

        public static BreadMaker.BreadMaker CreateBreadMaker()
        {
            Console.WriteLine("Введите производителя хлебопечки: ");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Введите модель хлебопечки: ");
            model = Console.ReadLine();
            Console.WriteLine("Введите серийный номер хлебопечки: ");
            serial = Console.ReadLine();
            return new BreadMaker.BreadMaker(serial, manufacturer, model);
        }

        public static Hood CreateKitchenHood()
        {
            Console.WriteLine("Введите производителя вытяжки: ");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Введите модель вытяжки: ");
            model = Console.ReadLine();
            Console.WriteLine("Введите серийный номер вытяжки: ");
            serial = Console.ReadLine();
            return new Hood(serial, manufacturer, model);
        }

        public static Radio.Radio CreateRadio()
        {
            Console.WriteLine("Введите производителя радио: ");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Введите модель радио: ");
            model = Console.ReadLine();
            Console.WriteLine("Введите серийный номер радио: ");
            serial = Console.ReadLine();
            return new Radio.Radio(serial, manufacturer, model);
        }

        public static TV.TV CreateTV()
        {
            Console.WriteLine("Введите производителя телевизора: ");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Введите модель телевизора: ");
            model = Console.ReadLine();
            Console.WriteLine("Введите серийный номер телевизора: ");
            serial = Console.ReadLine();
            return new TV.TV(serial, manufacturer, model);
        }

        public static void CreateDevice()
        {
            Console.WriteLine("Выберите тип прибора: ");
            Console.WriteLine("1 - кондиционер");
            Console.WriteLine("2 - хлебопечь");
            Console.WriteLine("3 - вытяжка");
            Console.WriteLine("4 - радио");
            Console.WriteLine("5 - телевизор");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        ACList.Add(CreateAC());
                        break;
                    case 2:
                        breadMakersList.Add(CreateBreadMaker());
                        break;
                    case 3:
                        hoodList.Add(CreateKitchenHood());
                        break;
                    case 4:
                        radioList.Add(CreateRadio());
                        break;
                    case 5:
                        TVList.Add(CreateTV());
                        break;
                }
                Console.WriteLine("Успешно!");
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так...");
            }

        }

        public static void ShowDevicesByCategory()
        {
            Console.WriteLine("Выберите тип прибора: ");
            Console.WriteLine("1 - кондиционер");
            Console.WriteLine("2 - хлебопечь");
            Console.WriteLine("3 - вытяжка");
            Console.WriteLine("4 - радио");
            Console.WriteLine("5 - телевизор");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    PrintDeviceList(ACList);
                    break;
                case 2:
                    PrintDeviceList(breadMakersList);
                    break;
                case 3:
                    PrintDeviceList(hoodList);
                    break;
                case 4:
                    PrintDeviceList(radioList);
                    break;
                case 5:
                    PrintDeviceList(TVList);
                    break;
            }
        }
    }
}
