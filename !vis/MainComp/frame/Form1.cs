using MainComp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frame
{
    public partial class Form1 : Form
    {
        public Form1( int _Complexiti)
        {
            
            InitializeComponent();
            class11.Complexiti = _Complexiti;
        }

        private void class11_OnEndGame(object sender, EventArgs e)
        {
            MessageBox.Show("Вас повесили", "Поражение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void class11_OnWinGame(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляем вы выйграли!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void class11_OnClickButton(object sender, EventArgs e)
        {
            MessageBox.Show(class11.ClckedButton, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Show();
        }
    }
}
