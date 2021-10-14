using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.KitchenHood
{
    public class Hood : Device.Device, IHood
    {
        int speed;
        bool backlight;

        public Hood(string serialNumber, string manufacturer, string model) : base(serialNumber, manufacturer, model)
        {
            speed = 0;
            backlight = false;
        }

        public override string GetFullProductDescription()
        {
            string output = "";
            output += "Вытяжка " + GetFullProductName() + " с серийным номером " + GetSerialNumber() + "\n";
            if (GetCurrentStateOnOff() && GetCurrentBacklight() == false)
            {
                output += "Вытяжка включена на скорости " + GetCurrentSpeed() + ", подсветка выключена" + "\n";
            }
            else if (GetCurrentStateOnOff() && GetCurrentBacklight() == true)
            {
                output += "Вытяжка включена на скорости " + GetCurrentSpeed() + ", подсветка включена" + "\n";
            }
            else if (!GetCurrentStateOnOff() && GetCurrentBacklight() == true)
            {
                output += "Вытяжка не работает в активном режиме, подсветка включена" + "\n";
            }
            else output += "Вытяжка выключена\n";
            return output;
        }

        public int GetCurrentSpeed()
        {
            return speed;
        }
        public bool GetCurrentBacklight()
        {
            return backlight;
        }

        public void IncrementSpeed()
        {
            if (speed < 1) ON();
            if (speed < 3) speed++;
        }

        public void DecrementSpeed()
        {
            if (speed > 0) speed--;
            if (speed < 1) OFF();
        }

        public void BacklightON()
        {
            if (!backlight) backlight = true;
        }

        public void BacklightOFF()
        {
            if (backlight) backlight = false;
        }
    }
}
