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

namespace frame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ShowResult();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!CheckforName())
            {
                return;
            }
            if (NameTextBox.Text != "")
            {
                var form = new Form1(1, NameTextBox.Text,this);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Вы не ввели имя пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!CheckforName())
            {
                return;
            }
            if (NameTextBox.Text != "")
            {
                var form = new Form1(3, NameTextBox.Text, this);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Вы не ввели имя пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckforName())
            {
                return;
            }
            if (NameTextBox.Text != "")
            {
                var form = new Form1(2, NameTextBox.Text, this);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Вы не ввели имя пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CheckforName()
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
            foreach (string line in list)
            {
                string[] parts = line.Split('-');
                if (NameTextBox.Text.Equals(parts[0]))
                {
                    MessageBox.Show("Такой игрок уже есть!");
                    return false;
                }
            }
            return true;
        }

        public void ShowResult() //метод для чтения и передачи слова из текстового файла в отдельную переменную
        {
            // Укажите путь к вашему текстовому файлу
            string filePath = "D:\\PROG\\!!Курсовик\\!vis\\MainComp\\ScoreP.txt";

            // Проверяем, существует ли файл
            if (File.Exists(filePath))
            {
                // Читаем все строки из файла
                string[] lines = File.ReadAllLines(filePath);

                // Очищаем ListBox перед добавлением новых элементов
                listBox1.Items.Clear();

                // Добавляем строки в ListBox
                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
        }


    }
}
