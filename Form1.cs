using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace KeyboardBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            GlobalKeyboardBlocker.UnblockGlobalKeyboard();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelStatus.Text = "Разблокировано";
            button1.Text = "Заблокировать";
        }

        public static bool isBlocked = false;
        public class GlobalKeyboardBlocker
        {
            [DllImport("user32.dll")]
            private static extern bool BlockInput(bool fBlockIt);

            public static void BlockGlobalKeyboard()
            {
                BlockInput(true);
            }

            public static void UnblockGlobalKeyboard()
            {
                BlockInput(false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isBlocked)
            {
                GlobalKeyboardBlocker.UnblockGlobalKeyboard();
                isBlocked = false;
                labelStatus.Text = "Разблокировано";
                button1.Text = "Заблокировать";
            }
            else
            {
                GlobalKeyboardBlocker.BlockGlobalKeyboard();
                isBlocked = true;
                labelStatus.Text = "Заблокировано";
                button1.Text = "Разблокировать";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isBlocked)
            {
                GlobalKeyboardBlocker.UnblockGlobalKeyboard();
            }
        }
    }
}
