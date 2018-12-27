using System;
class Debug {
    
    public static void log(string meg) {
        Console.WriteLine("Debug log:"+meg);

    }

    public static void log(Double meg) {
        log(meg.ToString());
    }
    public static void log(Int32 meg) {
        log(meg.ToString());
    }
}
