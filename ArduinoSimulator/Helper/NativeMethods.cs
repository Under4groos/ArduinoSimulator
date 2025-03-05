using ArduinoSimulator.Strucures;
using Stuctures;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ArduinoSimulator.Helper
{
    public static class NativeMethods
    {
        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);


        public delegate void MonitirsChangedEvent(NativeBackgroundScreenWorker screenWorker, ObservableCollection<MONITORINFOEX> monitors);



        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDisplayMonitors(IntPtr hdc,
                                                IntPtr lprcClip,
                                                MonitorEnumDelegate lpfnEnum,
                                                IntPtr dwData);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFOEX lpmi);


        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            // NOTE: If you need error handling
            // bool success = GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

    }
}
