using System;
using System.Drawing;
using System.Windows.Forms;
using CUE.NET.Devices.Keyboard;
using CUE.NET;
using CUE.NET.Devices.Keyboard.Keys;
using CUE.NET.Devices.Keyboard.Enums;
using CUE.NET.Brushes;

namespace Corsair_Utils
{
    public partial class Form1 : Form
    {
        private CorsairKeyboard keyboard;
        private RectangleKeyGroup numpadGroup;

        private bool numLockState = Control.IsKeyLocked(Keys.NumLock);
        private Color selectedColor;
        private bool shouldExit = false;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            selectedColor = (Color)Properties.Settings.Default["KeyPadColor"];

            colorPanel.BackColor = selectedColor;
            CueSDK.Initialize();
            keyboard = CueSDK.KeyboardSDK;
            if (keyboard == null)
                MessageBox.Show("Keyboard not found!");

            numpadGroup = new RectangleKeyGroup(keyboard, CorsairKeyboardKeyId.NumLock, CorsairKeyboardKeyId.KeypadEnter);

            refreshNumpad();

            var kh = new KeyboardHook(true);
            kh.KeyUp += Kh_KeyUp;
        }

        private void refreshNumpad()
        {
            if (numLockState)
            {
                numpadGroup.Brush = new SolidColorBrush(selectedColor);
                keyboard.Update();
            }
            else
            {
                numpadGroup.Brush = new SolidColorBrush(Color.Black);
                keyboard.Update();
            }
        }

        private void Kh_KeyUp(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            if (key.Equals(Keys.NumLock))
            {
                if(numLockState)
                {
                    numpadGroup.Brush = new SolidColorBrush(Color.Black);
                    keyboard.Update();
                }
                else
                {
                    numpadGroup.Brush = new SolidColorBrush(selectedColor);
                    keyboard.Update();
                }
                numLockState = !numLockState;
            }
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            DialogResult colorPickerResult = NumpadColorPicker.ShowDialog();
            if (colorPickerResult == DialogResult.OK)
            {
                colorPanel.BackColor = NumpadColorPicker.Color;
                selectedColor = NumpadColorPicker.Color;
                Properties.Settings.Default["KeyPadColor"] = NumpadColorPicker.Color;
                Properties.Settings.Default.Save();
                refreshNumpad();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!shouldExit)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shouldExit = true;
            this.Close();
        }
    }
}
