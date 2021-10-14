using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.TV
{
    public interface ITV
    {
        ChannelList GetCurrentChannel();
        void IncrementChannel();
        void DecrementChannel();
        int GetCurrentVolume();
        void IncrementVolume();
        void DecrementVolume();
        void MuteVolume();
    }
}
