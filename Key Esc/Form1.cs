#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

#endregion

namespace Key_Esc
{
    public sealed partial class Form1 : Form
    {
        
        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        [Flags]
        enum MouseFlags
        {
            Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008,
            RightUp = 0x0010, Absolute = 0x8000
        };

        public Form1()
        {
            InitializeComponent();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void timer1_Tick(object sender, EventArgs e)
        {
            const int x = 64700;
            const int y = 1900;
            mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x, y, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(100);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x, y, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(500);
            const int x1 = 32768;
            const int y1 = 33190;
            mouse_event(MouseFlags.Absolute | MouseFlags.Move, x1, y1, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, x1, y1, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(100);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, x1, y1, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("{ESC}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
            button2.BackColor = Color.LightGreen;
            timer1.Enabled = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightCoral;
            button2.BackColor = Color.LightCoral;
            timer1.Enabled = false;
        }
    }
}