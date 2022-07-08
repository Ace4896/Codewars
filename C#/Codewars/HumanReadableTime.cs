namespace Codewars
{
    public static class TimeFormat
    {
        // NOTE: Other option is to perform the math directly from the number of seconds
        public static string GetReadableTime(int seconds)
        {
            int tmp = seconds;

            int hours = seconds / 3600;
            tmp -= hours * 3600;

            int minutes = tmp / 60;
            tmp -= minutes * 60;

            return $"{hours:D2}:{minutes:D2}:{tmp:D2}";
        }
    }
}
