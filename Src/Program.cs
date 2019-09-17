using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JsonDataEditor {
    static class Program {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
#if DEBUG
            AllocConsole();
#endif

            //Cmd cmd = new Cmd();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGui());
            Debug.log(2);

            FreeConsole();


        }
    }
}
