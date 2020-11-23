using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        List<Movie> movieList = new List<Movie>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void MovieList()
        {
            richTextBox1.Text = "";
            for (var i = 0; i < this.movieList.Count; ++i)
            {
                var movie = this.movieList[i];
                if (movie is Film)
                {
                    richTextBox1.Text = richTextBox1.Text + ("\n Фильм");
                }
                if (movie is Serial)
                {
                    richTextBox1.Text = richTextBox1.Text + ("\n Сериал");
                }
                if (movie is TVprogramm)
                {
                    richTextBox1.Text = richTextBox1.Text + ("\n ТВ-программа"); ;
                }
            }
        }
        private void ShowInfo()
        {
            //Счетчики под каждый тип
            int FilmCount = 0;
            int SerialCount = 0;
            int TVCount = 0;

            //Пройдемся по всему списку
            foreach (var movie in this.movieList)
            {
                if (movie is Film) 
                {
                    FilmCount += 1;
                }
                else if (movie is Serial)
                {
                    SerialCount += 1;
                }
                else if (movie is TVprogramm)
                {
                    TVCount += 1;
                }
            }
            txtInfo.Text = "Фильмы\tСериалы\tТВ-программы";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", FilmCount, SerialCount, TVCount);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            this.movieList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) //Генерируется случайное число от 0 до 2
                {
                    case 0: // если 0, то фильм
                        this.movieList.Add(Film.Generate());
                        break;
                    case 1: // если 1 то сериал
                        this.movieList.Add(Serial.Generate());
                        break;
                    case 2: // если 2 то ТВ-программа
                        this.movieList.Add(TVprogramm.Generate());
                        break;
                }
            }
            ShowInfo();
            MovieList();
        }

        private void ButtonGetter_Click(object sender, EventArgs e)
        {
            //Если список пуст, то напишем что пусто и выйдем из функции
            if (this.movieList.Count == 0)
            {
                txtOut.Text = "Автомат пуст";
                return;
            }

            // Взяли первое комическое тело
            var movie = this.movieList[0];
            // Взятие это на самом деле создание указателя на область в памяти
            // где хранится экземпляр класса, так что удаление надо прописать отдельно
            this.movieList.RemoveAt(0);
            txtOut.Text = movie.GetInfo();
            if (movie is Film)
            {
                pictureBox1.Image = Properties.Resources._1;
            }
            if  (movie is Serial)
            {
                pictureBox1.Image = Properties.Resources._2;
            }
            if (movie is TVprogramm)
            {
                pictureBox1.Image = Properties.Resources._3;
            }
            //Обновим информацию о количестве товара на форме
            ShowInfo();
            MovieList();   
    }

        private void ButtonInfo_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
    


