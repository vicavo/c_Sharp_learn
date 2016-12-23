using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTC_Notify
{
    public interface FloatBarListener
    {
        void OnRightMouseClick(System.Drawing.Point point);
        void OnLeftMouseDoubleClick();
    }
}
