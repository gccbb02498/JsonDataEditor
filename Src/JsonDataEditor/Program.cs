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
            BaseDataManager manager = BaseDataManager.Instance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            AllocConsole();
#endif

            //Cmd cmd = new Cmd();
            Application.Run(new MainGui());
            Debug.log(2);
#if DEBUG
            FreeConsole();
#endif
        }
    }
}