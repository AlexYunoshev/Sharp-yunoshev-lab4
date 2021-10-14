using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.Device
{
    public abstract class Device : IDevice
    {
        private bool currentStateOnOff;
        private readonly string serialNumber;
        private readonly string manufacturer;
        private readonly string model;
        private int timerHours;
        private int timerMinutes;
        private bool isTimer;

        public Device(string serialNumber, string manufacturer, string model)
        {
            this.serialNumber = serialNumber;
            this.manufacturer = manufacturer;
            this.model = model;
            currentStateOnOff = false;
            isTimer = false;
        }

        public void ON()
        {
            currentStateOnOff = true;
        }
        public void OFF()
        {
            currentStateOnOff = false;
        }

        public bool GetCurrentStateOnOff()
        {
            return currentStateOnOff;
        }

        public string GetSerialNumber()
        {
            return serialNumber;
        }

        public string GetFullProductName()
        {
            return manufacturer + " " + model;
        }

        public virtual string GetFullProductDescription()
        {
            return "Девайс " + GetFullProductName() + " с серийным номером " + GetSerialNumber();
        }

        public bool GetTimerState()
        {
            return isTimer;
        }
        public string GetTimerValue()
        {
            return timerHours + " : " + timerMinutes + " (часы : минуты)";
        }

        public void StopTimer()
        {
            isTimer = false;
        }

        public void SetTimer(int hours, int minutes)
        {
            this.timerHours = hours;
            this.timerMinutes = minutes;
            isTimer = true;
        }

        public void ConsoleSetTimer()
        {
            int hours;
            int minutes;
            Console.WriteLine("Введите часы и минуты.");
            Console.WriteLine("Часы: ");
            hours = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Минуты: ");
            minutes = Convert.ToInt32(Console.ReadLine());
            this.SetTimer(hours, minutes);
        }
    }
}
