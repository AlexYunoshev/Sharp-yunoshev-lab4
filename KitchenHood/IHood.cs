using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.KitchenHood
{
    public interface IHood
    {
        int GetCurrentSpeed();
        bool GetCurrentBacklight();
        void IncrementSpeed();
        void DecrementSpeed();
        void BacklightON();
        void BacklightOFF();
    }
}
