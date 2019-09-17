using JsonDataEditor.Manager;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JsonDataEditor
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {

            new BaseDataManager();
#if DEBUG
            AllocConsole();
#endif

            //Cmd cmd = new Cmd();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGui());
            Debug.log(2);
#if DEBUG
            FreeConsole();
#endif
        }
    }
}