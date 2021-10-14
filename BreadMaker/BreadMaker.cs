using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.BreadMaker
{
    public class BreadMaker : Device.Device, IBreadMaker
    {
        bool activeCook; // обрано режим приготування
        bool capOpenState; // true = open
        BreadCookingModes currentBreadCookingMode;
        DoughCookingModes currentDoughCookingMode;


        public BreadMaker(string serialNumber, string manufacturer, string model) : base(serialNumber, manufacturer, model)
        {
            activeCook = false;
            capOpenState = false;
            currentBreadCookingMode = BreadCookingModes.None;
            currentDoughCookingMode = DoughCookingModes.None;
        }

        public override string GetFullProductDescription()
        {
            string output = "";
            output += "Хлебопечь " + GetFullProductName() + " с серийным номером " + GetSerialNumber() + "\n";
            if (GetCapOpenState() == true) output += "Крышка открыта\n";
            else output += "Крышка закрыта\n";

            if (GetCurrentStateOnOff() == true)
            {
                output += "Хлебопечь включена и ";
                if (GetActiveCookingState() == true)
                {
                    if (currentDoughCookingMode == DoughCookingModes.None && currentBreadCookingMode != BreadCookingModes.None)
                    {
                        output += "работает в режиме приготовления хлеба: " + GetCurrentBreadCookingMode() + "\n";
                    }
                    else if (currentDoughCookingMode != DoughCookingModes.None && currentBreadCookingMode == BreadCookingModes.None)
                    {
                        output += "работает в режиме приготовления теста: " + GetCurrentDoughCookingMode() + "\n";
                    }
                    if (GetTimerState() == true) output += "Таймер установлен на " + GetTimerValue() + ".\n";
                    else output += "Таймер не установлен.\n";
                }
                else output += "находится не в режиме приготовления\n";
            }
            else
            {
                output += "Хлебопечь выключена.";
            }
            return output;
        }

        public bool GetActiveCookingState()
        {
            return activeCook;
        }

        public BreadCookingModes GetCurrentBreadCookingMode()
        {
            return currentBreadCookingMode;
        }

        public void SetCurrentBreadCookingMode(BreadCookingModes mode)
        {
            currentDoughCookingMode = DoughCookingModes.None;
            currentBreadCookingMode = mode;
        }

        public DoughCookingModes GetCurrentDoughCookingMode()
        {
            return currentDoughCookingMode;
        }

        public void SetCurrentDoughCookingMode(DoughCookingModes mode)
        {
            currentBreadCookingMode = BreadCookingModes.None;
            currentDoughCookingMode = mode;
        }

        public bool StartCurrentMode()
        {
            if (GetCurrentStateOnOff() && capOpenState == false && 
                (currentDoughCookingMode != DoughCookingModes.None || 
                currentBreadCookingMode != BreadCookingModes.None))
            {
                activeCook = true;
                return true;
            }
            return false;
        }

        public void StopCurrentMode()
        {
            activeCook = false;
            currentBreadCookingMode = BreadCookingModes.None;
            currentDoughCookingMode = DoughCookingModes.None;
            StopTimer();
        }

        public void OFF()
        {
            base.OFF();
            StartCurrentMode();
        }

        public bool GetCapOpenState()
        {
            return capOpenState;
        }

        public void OpenCap()
        {
            capOpenState = true;
        }

        public void CloseCap()
        {
            capOpenState = false;
        }
    }
}
