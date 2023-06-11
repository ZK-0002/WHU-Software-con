namespace Alarm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Alarm a = new Alarm();
            AlarmRing ar = new AlarmRing(a);
            AlarmTime time = new AlarmTime(9, 35, 40);
            a.setAlarmTime(time);
            ar.Ring();
        }
    }
}