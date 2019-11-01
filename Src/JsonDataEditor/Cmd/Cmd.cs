using System;
using System.Diagnostics;

internal class Cmd
{
    public Cmd()
    {
        Process p = new Process();
        String str = null;
        p.StartInfo.FileName = "cmd.exe";

        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        //p.StartInfo.CreateNoWindow = true; //不跳出cmd視窗

        p.Start();
        p.StandardInput.WriteLine("aaaa");
        p.StandardInput.WriteLine("exit");

        str = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        p.Close();

        Console.WriteLine(str);
    }

    public static void WriteLine(string format, params object[] args)
    {
        WriteLine(string.Format(format, args));
    }
}