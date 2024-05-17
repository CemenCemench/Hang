using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MainComp
{
    public class Class1 : Control
    {

        public Color _PatColor;
        public Color _TextAlfColor;
        protected int _PatSize;
        protected int _CountMistake;
        protected string _HiddenWord;
        public string _GuessedWord;
        protected string _ClckedButton;//возможность отслежевания происходящего изнутри
        public Color _HiddenTextColor;
        public Color _SeparatorColor;
        public Color _DashColor;
        public Color _CrossOutColor;
        public Color _BackgroundColor;
        public int _Complexiti;
        public string _ssr;

        public Class1() : base()
        {
            _BackgroundColor = Color.White;
            _CrossOutColor = Color.Red;
            _DashColor = Color.Black;
            _SeparatorColor = Color.Black;
            _HiddenTextColor = Color.Black;
            _TextAlfColor = Color.White;
            _PatColor = Color.Blue;
            _HiddenWord = GetWord();
            _GuessedWord = "";
            _PatSize = 97;
            _CountMistake = 0;
            _ClckedButton = "";
            _Complexiti = 0;
            _ssr = "";
            CreateData();
        }
        public int[,] _Data;
        protected virtual int this[int Row, int Col]
        {
            get
            {
                Row = 11;
                Col = 3;
                if ((Row >= 0) && (Row < _Data.GetLength(0)) && (Col >= 0) && (Col < _Data.GetLength(1)))
                {
                    return _Data[Row, Col];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Row = 11;
                Col = 3;
                if ((Row >= 0) && (Row < _Data.GetLength(0)) && (Col >= 0) && (Col < _Data.GetLength(1)))
                {
                    if (_Data[Row, Col] != value)
                    {
                        _Data[Row, Col] = value;
                    }
                }
            }
        }
        protected event EventHandler _OnEndGame;

        public event EventHandler OnEndGame
        {
            add
            {
                _OnEndGame += value;
            }
            remove
            {
                _OnEndGame -= value;
            }
        }

        protected void DoOnEndGame()// возможность отслежевания проигрыш
        {
            if (_OnEndGame != null)
            {
                _OnEndGame(this, new EventArgs());
            }
        }

        protected event EventHandler _OnWinGame;

        public event EventHandler OnWinGame
        {
            add
            {
                _OnWinGame += value;
            }
            remove
            {
                _OnWinGame -= value;
            }
        }

        protected void DoOnWinGame()// возможность отслежевания выйгрыш
        {
            if (_OnWinGame != null)
            {
                _OnWinGame(this, new EventArgs());
            }
        }

        protected event EventHandler _OnClickButton;

        public event EventHandler OnClickButton
        {
            add
            {
                _OnClickButton += value;
            }
            remove
            {
                _OnClickButton -= value;
            }
        }

        protected void DoOnClickButton()//возможность отслежевания происходящего из нутри
        {
            if (_OnClickButton != null)
            {
                _OnClickButton(this, new EventArgs());
            }
        }

        public Color PatColor
        {
            get
            {
                return _PatColor;
            }
            set
            {
                if (value != _PatColor)
                {
                    _PatColor = value;
                    Invalidate();
                }
            }

        }

        public Color HiddenTextColor
        {
            get
            {
                return _HiddenTextColor;
            }
            set
            {
                if (value != _HiddenTextColor)
                {
                    _HiddenTextColor = value;
                    Invalidate();
                }
            }
        }

        public int Complexiti
        {
            get
            {
                return _Complexiti;
            }
            set
            {
                if (value != _Complexiti)
                {
                    _Complexiti = value;
                    _HiddenWord = GetWord();
                    Invalidate();
                }
            }
        }

        public string ssr
        {
            get
            {
                return _ssr;
            }
            set
            {
                if (value != _ssr)
                {
                    _ssr = value;
                    Invalidate();
                }
            }
        }

        public Color TextAlfColor
        {
            get
            {
                return _TextAlfColor;
            }
            set
            {
                if (value != _TextAlfColor)
                {
                    _TextAlfColor = value;
                    Invalidate();
                }
            }
        }


        public Color SeparatorColor
        {
            get
            {
                return _SeparatorColor;
            }
            set
            {
                if (value != _SeparatorColor)
                {
                    _SeparatorColor = value;
                    Invalidate();
                }
            }
        }

        public Color DashColor
        {
            get
            {
                return _DashColor;
            }
            set
            {
                if (value != _DashColor)
                {
                    _DashColor = value;
                    Invalidate();
                }
            }
        }

        public Color CrossOutColor
        {
            get
            {
                return _CrossOutColor;
            }
            set
            {
                if (value != _CrossOutColor)
                {
                    _CrossOutColor = value;
                    Invalidate();
                }
            }
        }


        public String GuessedWord
        {
            get
            {
                return _GuessedWord;
            }
            set
            {

            }
        }
        public Color BackgroundColor
        {
            get
            {
                return _BackgroundColor;
            }
            set
            {
                if (value != _BackgroundColor)
                {
                    _BackgroundColor = value;
                    Invalidate();
                }
            }
        }


        public String ClckedButton
        {
            get
            {
                return _ClckedButton;
            }
            set
            {

            }
        }

        protected virtual void CreateData()// расположение букв в клавиатуре
        {
            _Data = new int[3, 11];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    _Data[i, j] = i * 11 + j + 1;
                }
            }
            Invalidate();
        }

        public virtual string GetWord() //метод для чтения и передачи слова из текстового файла в отдельную переменную
        {
            String line;
            string Word = "";
            int cnt = 0;
            int random;
            Random rand = new Random();
            switch (_Complexiti)
            {
                case 1:
                    _ssr = "D:\\PROG\\!!Курсовик\\Low.txt";
                    break;
                case 2:
                    _ssr = "D:\\PROG\\!!Курсовик\\Medium.txt";
                    break;
                case 3:
                     _ssr = "D:\\PROG\\!!Курсовик\\Hight.txt";
                    break;
                default:
                    _ssr = "D:\\PROG\\!!Курсовик\\Low.txt";
                    break;
            }
            try
            {
                StreamReader sr = new StreamReader(_ssr); // создание первого читатиля для подсчитывания строк в текстовом файле
                line = sr.ReadLine();
                while (line != null)
                {
                    cnt++;
                    line = sr.ReadLine();
                }
                cnt++;
                sr.Close();// закртыие первого читатиля
                StreamReader sr2 = new StreamReader(_ssr); // создание второго читателя для нахождения случайного слова и передача его в переменную
                random = rand.Next(1, cnt);
                line = sr2.ReadLine();
                cnt = 0;
                while (line != null)
                {
                    cnt++;
                    if (random == cnt)
                    {
                        Word = line.ToUpper();
                    }
                    line = sr2.ReadLine();
                }
                sr2.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Word = e.Message;
            }
            Invalidate();
            return Word;
        }

        private string step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\1step.png";
        protected override void OnPaint(PaintEventArgs e) // Метод на отрисовку компонента и его элементов
        {
            base.OnPaint(e);
            switch (_CountMistake) // смена картинки при мзменении количества ошибок 
            {
                case 0:
                    step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\1step.png";
                    break;
                case 1:
                    step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\2step.png";
                    break;
                case 2:
                    step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\3step.png";
                    break;
                case 3:
                    step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\4step.png";
                    break;
                case 4:
                    step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\5step.png";
                    break;
                case 5:
                    step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\6step.png";
                    break;
                case 6:
                    step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\7step.png";
                    break;
                default:
                    step1 = @"D:\PROG\!!Курсовик\!vis (1)\MainComp\MainComp\1step.png";
                    break;
            }
            // создание переменных цвета, разеров,шрифтов и расположения текста 
            Brush B = new SolidBrush(_BackgroundColor);
            e.Graphics.FillRectangle(B, ClientRectangle);
            Brush PatBrush = new SolidBrush(_PatColor);
            Pen ReadPen = new Pen(_CrossOutColor);
            Pen DashPen = new Pen(_DashColor);
            Pen SepPen = new Pen(_SeparatorColor);
            ReadPen.Width = 5;
            int FontSize = (int)Math.Round((_PatSize - 16) * 45/*72*/ / e.Graphics.DpiY);
            int FontSizeHiddenWord = (int)Math.Round(((Width - Width / 11 * 4) / _HiddenWord.Length) * 45/*72*/ / e.Graphics.DpiY);
            if (FontSize <= 0)
            {
                FontSize = 1;
            }
            Font Font = new Font("Ubuntu Mono", FontSize);
            Font FontHiddenWord = new Font("Ubuntu Mono", FontSizeHiddenWord);
            SolidBrush TextBrush = new SolidBrush(_TextAlfColor);
            SolidBrush ZagadBrush = new SolidBrush(_HiddenTextColor);
            StringFormat Fmt = new StringFormat();
            Fmt.Alignment = StringAlignment.Center;
            Fmt.LineAlignment = StringAlignment.Center;
            StringFormat FmtZ = new StringFormat();
            FmtZ.Alignment = StringAlignment.Center;
            FmtZ.LineAlignment = StringAlignment.Far;
            string Alf = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            for (int i = 2; i >= 0; i--)//для отрисовки клавиатуры
            {
                for (int j = 10; j >= 0; j--)
                {
                    int x1 = _PatSize * (j);
                    int x2 = x1 + _PatSize;
                    int y1 = Height - _PatSize * (i + 1);
                    int y2 = Height - y1 + _PatSize;
                    e.Graphics.FillRectangle(PatBrush, x1 + 1, y1 + 1, _PatSize - 2, _PatSize - 2); //отрисовка клавиатуры
                    RectangleF Rect = new RectangleF(x1 + 2, y1 + 2, _PatSize - 4, _PatSize - 4);
                    String S = Alf[Alf.Length - _Data[i, 10 - j]].ToString();
                    e.Graphics.DrawString(S, Font, TextBrush, Rect, Fmt);//отрисовка в клавитуре алфавита 
                    if (_GuessedWord.IndexOf(Alf[Alf.Length - _Data[i, 10 - j]]) >= 0) //зачёркивание уже нажатых букв
                    {
                        e.Graphics.DrawLine(ReadPen, x1 + 1, y1 + 1, x1 + _PatSize - 2, y1 + _PatSize - 2);
                    }
                }
            }
            int contchar = _HiddenWord.Length;
            for (int c = 0; c < contchar; c++)
            {
                int Widthline = (Width - (Width / 11 * 4)) / contchar;
                int HeightChar = Widthline * 13 / 7;
                int Heightline = (Height - HeightChar - _PatSize * 3) / 2 + HeightChar;
                // создание полосок для загаданого слово
                e.Graphics.DrawLine(DashPen, Widthline / 6 + Widthline * c + Width / 11 * 4, Heightline - Heightline / 5, Widthline * (c + 1) + Width / 11 * 4 - Widthline / 6, Heightline - Heightline / 5);
                //отрисовки загаданого слова
                if (_GuessedWord.IndexOf(_HiddenWord[c]) >= 0)
                {
                    RectangleF rect = new RectangleF(Widthline / 6 + Widthline * c + (int)(Width / 111.0 * 40), Heightline - HeightChar - Heightline / 5, Widthline - Widthline / 6, HeightChar);
                    string w = _HiddenWord[c].ToString();
                    e.Graphics.DrawString(w, FontHiddenWord, ZagadBrush, rect, FmtZ);
                }
            }
            e.Graphics.DrawLine(SepPen, Width / 11 * 4, 0, Width / 11 * 4, Height / 8 * 5);
            Bitmap bitmap = new Bitmap(step1);//для отрисовки картинки с висильницой
            e.Graphics.DrawImage(bitmap, 0, 0, Width / 11 * 4, Height / 8 * 5);
        }
        protected override CreateParams CreateParams //буферезация изоброжения
        {
            get
            {
                CreateParams P = base.CreateParams;
                P.ExStyle = P.ExStyle | 0x02000000;
                return P;
            }
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) //смена размеров компонента при мзменении формы
        {
            _PatSize = Math.Min(width / 11, height / 8);
            width = _PatSize * 11;
            height = _PatSize * 8;
            base.SetBoundsCore(x, y, width, height, specified);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e) //воздействие игрока на игру
        {
            base.OnMouseDown(e);
            if (e.Y >= _PatSize * 5)
            {
                int x = e.X / _PatSize + (e.Y - _PatSize * 5) / _PatSize * 11;
                string Alf = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                _ClckedButton = (Alf[x]).ToString();
                if (_GuessedWord.IndexOf(Alf[x]) < 0)
                {
                    if (_HiddenWord.IndexOf(Alf[x]) < 0)
                    {
                        _CountMistake++;
                    }
                    _GuessedWord += Alf[x].ToString();
                    DoOnClickButton();
                }
                int cnt = 0;
                Invalidate();
                for (int i = 0; i < _HiddenWord.Length; i++)
                {
                    if (_GuessedWord.IndexOf(_HiddenWord[i]) >= 0)
                    {
                        cnt++;// счёт количества угаданных букв
                    }
                    if (cnt == _HiddenWord.Length)
                    {
                        DoOnWinGame();
                        _CountMistake = 0;
                        _HiddenWord = GetWord();
                        _GuessedWord = "";
                    }
                }
                Invalidate();
                if (_CountMistake == 6) //счёт количества ошибок
                {
                    DoOnEndGame();
                    _CountMistake = 0;
                    _HiddenWord = GetWord();
                    _GuessedWord = "";
                }
            }
        }
    }
}