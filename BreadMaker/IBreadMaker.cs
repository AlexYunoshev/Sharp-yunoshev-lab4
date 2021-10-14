using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yunoshev_lab4.BreadMaker
{
    public interface IBreadMaker
    {
        bool GetActiveCookingState();
        BreadCookingModes GetCurrentBreadCookingMode();
        void SetCurrentBreadCookingMode(BreadCookingModes mode);
        DoughCookingModes GetCurrentDoughCookingMode();
        void SetCurrentDoughCookingMode(DoughCookingModes mode);
        bool GetCapOpenState();
        void OpenCap();
        void CloseCap();
        bool StartCurrentMode();
        void StopCurrentMode();
    }
}
