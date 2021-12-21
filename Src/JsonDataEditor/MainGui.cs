using System;
using System.Windows.Forms;

namespace JsonDataEditor
{
    public partial class MainGui : Form
    {
        public MainGui()
        {
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error:\t");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("this is an error log");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Warn:\t");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("this is a warn log");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Normal:\t");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("this is a normal log");
#endif
            InitializeComponent();
        }

        private void SkillDataBtn_Click(object sender, EventArgs e)
        {
            SkillDataEditor SkillDataEditor = new SkillDataEditor();
            this.Hide();
            SkillDataEditor.Show();
        }

        private void ItemDataBtn_Click(object sender, EventArgs e)
        {
            ItemDataEditor itemDataEditor = new ItemDataEditor();
            this.Hide();
            itemDataEditor.Show();
        }

        private void MobDataBtn_Click(object sender, EventArgs e)
        {
            MobDataEditor mobDataEditor = new MobDataEditor();
            this.Hide();
            mobDataEditor.Show();
        }
    }
}