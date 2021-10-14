using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.Device
{
    public interface IDevice
    {
        bool GetCurrentStateOnOff();
        string GetSerialNumber();
        string GetFullProductName();
        string GetFullProductDescription();
        void ON();
        void OFF();
        bool GetTimerState();
        string GetTimerValue();
        void StopTimer();
        void SetTimer(int hours, int minutes);
        void ConsoleSetTimer();
    }
}
