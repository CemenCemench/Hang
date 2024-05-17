using MainComp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace frame
{
    public partial class Form1 : Form
    {
        public string name;
        public int score;
        public Form2 form;
        public Form1(int _Complexiti, string NameP, Form2 form2)
        {
            InitializeComponent();
            score = 0;
            name = NameP;
            form = form2;
            LabelName.Text = name + "-" + score;
            class11.Complexiti = _Complexiti;
        }

        private void class11_OnEndGame(object sender, EventArgs e)
        {
            MessageBox.Show("Вас повесили", "Поражение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            Application.OpenForms[0].Show();
            SaveResult(name + "-" + score);
            form.ShowResult();
        }

        private void class11_OnWinGame(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляем вы выйграли!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            score++;
            LabelName.Text = name + "-" + score;
        }

        private void class11_OnClickButton(object sender, EventArgs e)
        {
            MessageBox.Show(class11.ClckedButton, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Show();
            class11.Invalidate();
            SaveResult(name + "-" + score);
            form.ShowResult();
        }


        public static void SaveResult(string res)
        {
            string filePath = "D:\\PROG\\!!Курсовик\\!vis\\MainComp\\ScoreP.txt";
            List<string> list = new List<string>();
            // Проверяем, существует ли файл
            if (File.Exists(filePath))
            {
                // Читаем все строки из файла
                string[] lines = File.ReadAllLines(filePath);

                // Очищаем ListBox перед добавлением новых элементов
                list.Clear();

                // Добавляем строки в ListBox
                foreach (string line in lines)
                {
                    list.Add(line);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
            list.Add(res);
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (string line in list)
                    {
                        sw.WriteLine(line);
                    }
                }
                MessageBox.Show("Результаты игры сохранены", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Неудалось сохранить данные!");
            }
        }
    }
}
