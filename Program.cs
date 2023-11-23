using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{

    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

            FillLabelKeys();
            NextKey();
        }

        private Dictionary<Keys, Label> list_labels = new Dictionary<Keys, Label>();
        private void FillLabelKeys()
        {
            list_labels.Add(Keys.Q, lbl_Q);
            list_labels.Add(Keys.W, lbl_W);
            list_labels.Add(Keys.E, lbl_E);
            list_labels.Add(Keys.R, lbl_R);
        }

        Keys NeedToPress = Keys.Space;
        Random random = new Random();
        private void NextKey()
        {
            int index = random.Next(0, list_labels.Count);
            Keys key = list_labels.ElementAt(index).Key;
            NeedToPress = key;
            Set_NeedPress(list_labels[key]);
        }

        private void Set_NeedPress(Label sender)
        {
            sender.ForeColor = Color.Red;

        }
        private void UnSet_NeedPress(Label sender)
        {
            sender.ForeColor = Color.Black;
        }

        private void Pressed(Keys key)
        {
            if (NeedToPress == key)
            {
                /*
                 * TODO: оповестить о корректности ввода
                 */
            }
            else
            {
                /*
                 * TODO: оповестить о корректности ввода
                 */
            }
            UnSet_NeedPress(list_labels[NeedToPress]);
            NextKey();
        }


        private void Demo_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyData;
            if (list_labels.ContainsKey(key))
            {
                Label lbl = list_labels[key];
                lbl.BorderStyle = BorderStyle.Fixed3D;
                Pressed(key);
            }
        }

        private void Demo_KeyUp(object sender, KeyEventArgs e)
        {
            if (list_labels.ContainsKey(e.KeyData))
            {
                Label lbl = list_labels[e.KeyData];
                lbl.BorderStyle = BorderStyle.FixedSingle;
            }
        }
    }
}