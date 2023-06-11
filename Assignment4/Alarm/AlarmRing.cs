using System;

namespace Alarm
{
    public class AlarmRing
    {
        Alarm alarm;

        public AlarmRing(Alarm alarm)
        {
            this.alarm = alarm;
        }
        void TickHandle()
        {
            Console.WriteLine("Tick" + alarm.getCurrentTime());
        }
        void AlarmHandle()
        {
            Console.WriteLine("ding!ding!ding!");
        }
        public void Ring()
        {
            alarm.SendAlarmMessage += AlarmHandle;
            alarm.SendTickMessage += TickHandle;
            alarm.Ring();
        }
    }
}