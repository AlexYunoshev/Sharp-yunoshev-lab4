using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.TV
{
    public class TV : Device.Device, ITV
    {
        ChannelList currentChannel;
        int currentVolume, volume;
        bool isMute;

        public TV(string serialNumber, string manufacturer, string model) : base(serialNumber, manufacturer, model)
        {
            currentChannel = ChannelList.Espresso;
            currentVolume = 20;
            isMute = false;
        }

        public override string GetFullProductDescription()
        {
            string output = "";
            output += "Телевизор " + GetFullProductName() + " с серийным номером " + GetSerialNumber() + "\n";
            if (GetCurrentStateOnOff() == true)
            {
                output += "Телевизор включен, выбран канал " + GetCurrentChannel() + " с громкостью " + GetCurrentVolume() + "\n";
            }
            else output += "Телевизор выключен\n";
            return output;
        }

        public ChannelList GetCurrentChannel()
        {
            return currentChannel;
        }

        public void IncrementChannel()
        {
            currentChannel = ((int)currentChannel == Enum.GetValues(typeof(ChannelList)).Length - 1) ?
                0 :
                currentChannel + 1;
        }

        public void DecrementChannel()
        {
            currentChannel = ((int)currentChannel == 0) ?
                (ChannelList)Enum.GetValues(typeof(ChannelList)).Length - 1 :
                currentChannel - 1;
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

        public void MuteVolume()
        {
            if (!isMute)
            {
                isMute = true;
                volume = currentVolume;
                currentVolume = 0;
            }
            else
            {
                isMute = false;
                currentVolume = volume;
            }

        }
    }
}
