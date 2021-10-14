using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.Radio
{
    public interface IRadio
    {
        StationList GetCurrentStation();
        void IncrementStation();
        void DecrementStation();
        int GetCurrentVolume();
        void IncrementVolume();
        void DecrementVolume();
    }
}
