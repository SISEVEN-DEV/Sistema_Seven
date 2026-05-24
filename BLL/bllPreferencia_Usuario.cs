using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BLL
{
    public class bllPreferencia_Usuario
    {
        [DllImport("coredll.dll")]
        public extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);
        //
        [DllImport("coredll.dll")]
        public extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        public static void GetTime()
        {
            // Call the native GetSystemTime method
            // with the defined structure.
            SYSTEMTIME stime = new SYSTEMTIME();
            GetSystemTime(ref stime);

            // Show the current time.           
            Debug.WriteLine("Current Time: " +
                stime.wHour.ToString() + ":"
                + stime.wMinute.ToString());
        }

        public static void SetTime()
        {
            // Call the native GetSystemTime method
            // with the defined structure.
            SYSTEMTIME systime = new SYSTEMTIME();
            GetSystemTime(ref systime);

            // Set the system clock ahead one hour.
            systime.wHour = (short)(systime.wHour + 1 % 24);
            SetSystemTime(ref systime);
            Debug.WriteLine("New time: " + systime.wHour.ToString() + ":"
                + systime.wMinute.ToString());
        }

        static void Main(string[] args)
        {
            SetTime();
        }
    }

}

