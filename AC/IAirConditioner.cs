using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.AC
{
    public interface IAirConditioner
    {
        ACModes GetCurrentACMode();
        void SetCurrentACMode(ACModes mode);
        int GetTemperature();
        void IncrementTemperature();
        void DecrementTemperature();
    }
}
