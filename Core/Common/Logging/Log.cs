using System;

namespace Common.Logging
{
    public static class Log
    {
        public static void WriteError(Exception exception)
        {
#if DEBUG
            Console.WriteLine(exception.ToString());
#endif
        }

        public static void WriteInfo(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
        }

        public static void WriteWarning(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
        }
    }
}
