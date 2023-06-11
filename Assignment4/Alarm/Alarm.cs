using System;
using System.Threading;

namespace Alarm
{
    public delegate void AlarmActionHandle();

    public class Alarm
    {
        public event AlarmActionHandle SendAlarmMessage;
        public event AlarmActionHandle SendTickMessage;

        AlarmTime currentTime;
        AlarmTime alarmTime;

        public Alarm()
        {
            alarmTime = new AlarmTime(0, 0, 0);
            currentTime = new AlarmTime(0, 0, 0);
        }

        public AlarmTime getCurrentTime()
        {
            return currentTime;
        }
        
        public void setAlarmTime(AlarmTime time)
        {
            alarmTime = time;
        }
        
        public void Ring()
        {
            if (SendAlarmMessage == null || SendTickMessage == null)
            {
                throw new NullReferenceException("AlarmActionHandle is null");
            }
            while (true)
            {
                currentTime = new AlarmTime(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                if (currentTime.isValid())
                {
                    if (currentTime.ToString().Equals(alarmTime.ToString()))
                    {
                        SendAlarmMessage();
                    }
                    else
                    {
                        SendTickMessage();
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}