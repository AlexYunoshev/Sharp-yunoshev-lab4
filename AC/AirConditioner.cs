using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.AC
{
    public class AirConditioner : Device.Device, IAirConditioner 
    {
        ACModes currentACMode; // режим кондиціонера
        int currentTemperature;



        public AirConditioner(string serialNumber, string manufacturer, string model) : base(serialNumber, manufacturer, model)
        {
            currentACMode = ACModes.Cooling;
            currentTemperature = 25;
        }

        public void OFF()
        {
            base.OFF();
            StopTimer();
        }

        public override string GetFullProductDescription()
        {
            string output = "";
            output += "Кондиционер " + GetFullProductName() + " с серийным номером " + GetSerialNumber() + "\n";

            if (GetCurrentStateOnOff() == true)
            {
                output += "Кондиционер работает в режиме: " + GetCurrentACMode() +
                        ", установлена температура " + GetTemperature() + " градусов\n";
                if (GetTimerState() == true) output += "Таймер установлен на " + GetTimerValue() + ".\n";
                else output += "Таймер не установлен.\n";
            }
            else output += "Кондиционер выключен\n";

            return output;
        }

        public ACModes GetCurrentACMode()
        {
            return currentACMode;
        }

        public void SetCurrentACMode(ACModes mode)
        {
            currentACMode = mode;
        }

        public int GetTemperature()
        {
            return currentTemperature;
        }

        public void IncrementTemperature()
        {
            if (currentTemperature < 35) currentTemperature++;
        }
        public void DecrementTemperature()
        {
            if (currentTemperature > 15) currentTemperature--;
        }
    }
}
