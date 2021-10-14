using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.Radio
{
    public class Radio : Device.Device, IRadio
    {
        StationList currentStation;
        int currentVolume;

        public Radio(string serialNumber, string manufacturer, string model) : base(serialNumber, manufacturer, model)
        {
            currentStation = StationList.RadioRelax;
            currentVolume = 20;
        }

        public override string GetFullProductDescription()
        {
            string output = "";
            output += "Радио " + GetFullProductName() + " с серийным номером " + GetSerialNumber() + "\n";
            if (GetCurrentStateOnOff() == true)
            {
                output += "Радио включено, выбрана станция " + GetCurrentStation() + "с громкостью " + GetCurrentVolume() + "\n";
            }
            else output += "Радио выключено\n";
            return output;
        }

        public StationList GetCurrentStation()
        {
            return currentStation;
        }

        public void IncrementStation()
        {
            currentStation = ((int)currentStation == Enum.GetValues(typeof(StationList)).Length - 1) ?
                0 : 
                currentStation + 1;
        }

        public void DecrementStation()
        {
            currentStation = ((int)currentStation == 0) ? 
                (StationList)Enum.GetValues(typeof(StationList)).Length - 1 : 
                currentStation - 1;
        }

        public int GetCurrentVolume()
        {
            return currentVolume;
        }

        public void IncrementVolume()
        {
            if (currentVolume < 100) currentVolume++;
        }

        public void DecrementVolume()
        {
            if (currentVolume > 0) currentVolume--;
        }
    }
}
