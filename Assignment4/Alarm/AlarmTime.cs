using System;

namespace Alarm
{
    public class AlarmTime
    {
        private int hour;
        private int minute;
        private int second;

        public AlarmTime(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public bool isValid()
        {
            return hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60;
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        }
        
    }
}