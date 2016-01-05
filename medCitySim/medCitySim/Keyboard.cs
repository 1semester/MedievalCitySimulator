using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MedCitySim
{
    static class Keyboard
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        private enum KeyStates {None = 0, Down =1, }

        private static HashSet<Keys> keysDown = new HashSet<Keys>();
        private static HashSet<Keys> prevKeysDown = new HashSet<Keys>();
        private static readonly Keys[] keysToCheck = new Keys[] {Keys.Escape, Keys.U, Keys.E, Keys.D , Keys.R, Keys.B, Keys.C, Keys.F, Keys.H, Keys.L, Keys.W, Keys.S, Keys.A, Keys.P, Keys.Q, Keys.M, Keys.O, Keys.T, Keys.Space, Keys.Up, Keys.Down, Keys.Left, Keys.Right };
        //static Keyboard()
        //{
        //    var keyNames = Enum.GetNames(typeof(Keys));
        //    List<Keys> keys = new List<Keys>();
        //    foreach (string name in keyNames)
        //    {
        //        Keys key = (Keys)Enum.Parse(typeof(Keys), name);
        //        keys.Add(key);
        //    }
        //    keysToCheck = keys.ToArray();
        //}

        public static void Update()
        {
            foreach (var key in keysToCheck)
            {
                if (GetKeyState(key) == KeyStates.Down)
                {
                    if (keysDown.Add(key))
                    {
                        prevKeysDown.Add(key);
                    }
                    else
                    {
                        prevKeysDown.Remove(key);
                    }
                }
                else
                {
                    if (keysDown.Remove(key))
                    {
                        prevKeysDown.Remove(key);
                    }
                }
            }
        }
        private static KeyStates GetKeyState(Keys key)
        {
            KeyStates state = KeyStates.None;

            short retVal = GetKeyState((int)key);

            if ((retVal & 0x8000) == 0x8000)
            {
                state = KeyStates.Down;
            }

            return state;
        }

        public static bool IsKeyDown(Keys key)
        {
            return keysDown.Contains(key);
            //return GetKeyState(key) == KeyStates.Down;
        }
        public static bool IsKeyPressed(Keys key)
        {
            return prevKeysDown.Contains(key);
        }
    }
}
