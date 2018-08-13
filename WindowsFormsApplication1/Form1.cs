using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        int countplayer = 0;    // счётчик для суммы очков игрока
        int countdealer = 0;    // счётчик для суммы очков дилера  

        DialogResult res;
      
        List<Cards> card = new List<Cards>
            {
                new Cards {Name=@"Cards\2ч.jpeg", Numb = 2 },  //0
                new Cards {Name=@"Cards\3ч.jpeg", Numb = 3 },  //1
                new Cards {Name=@"Cards\4ч.jpeg", Numb = 4 },//2
                new Cards {Name=@"Cards\5ч.jpeg", Numb = 5 }, //3
                new Cards {Name=@"Cards\6ч.jpeg", Numb = 6 },//4
                new Cards {Name=@"Cards\7ч.jpeg", Numb = 7 }, //5
                new Cards {Name=@"Cards\8ч.jpeg", Numb = 8 },//6
                new Cards {Name=@"Cards\9ч.jpeg", Numb = 9 }, //7
                new Cards {Name=@"Cards\10ч.jpeg", Numb = 10 }, //8
                new Cards {Name=@"Cards\Вч.jpeg", Numb = 10 }, //9
                new Cards {Name=@"Cards\Дч.jpeg", Numb = 10 }, //10
                new Cards {Name=@"Cards\Кч.jpeg", Numb = 10 }, //11
                new Cards {Name=@"Cards\Тч.jpeg", Numb = 11 }, //12
                new Cards {Name=@"Cards\2т.jpeg", Numb = 2 }, //13
                new Cards {Name=@"Cards\3т.jpeg", Numb = 3 }, //14
                new Cards {Name=@"Cards\4т.jpeg", Numb = 4 }, //15
                new Cards {Name=@"Cards\5т.jpeg", Numb = 5 }, //16
                new Cards {Name=@"Cards\6т.jpeg", Numb = 6 }, //17
                new Cards {Name=@"Cards\7т.jpeg", Numb = 7 }, //18
                new Cards {Name=@"Cards\8т.jpeg", Numb = 8 }, //19
                new Cards {Name=@"Cards\9т.jpeg", Numb = 9 }, //20
                new Cards {Name=@"Cards\10т.jpeg", Numb = 10 }, //21
                new Cards {Name=@"Cards\Вт.jpeg", Numb = 10 }, //22
                new Cards {Name=@"Cards\Дт.jpeg", Numb = 10 }, //23
                new Cards {Name=@"Cards\Кт.jpeg", Numb = 10 }, //24
                new Cards {Name=@"Cards\Тт.jpeg", Numb = 11 }, //25
                new Cards {Name=@"Cards\2б.jpeg", Numb = 2 }, //26
                new Cards {Name=@"Cards\3б.jpeg", Numb = 3 }, //27 
                new Cards {Name=@"Cards\4б.jpeg", Numb = 4 }, //28
                new Cards {Name=@"Cards\5б.jpeg", Numb = 5 }, //29
                new Cards {Name=@"Cards\6б.jpeg", Numb = 6 }, //30
                new Cards {Name=@"Cards\7б.jpeg", Numb = 7 }, //31
                new Cards {Name=@"Cards\8б.jpeg", Numb = 8 }, //32
                new Cards {Name=@"Cards\9б.jpeg", Numb = 9 }, //33
                new Cards {Name=@"Cards\10б.jpeg", Numb = 10 }, //34
                new Cards {Name=@"Cards\Вб.jpeg", Numb = 10 }, //35
                new Cards {Name=@"Cards\Дб.jpeg", Numb = 10 }, //36
                new Cards {Name=@"Cards\Кб.jpeg", Numb = 10 }, //37
                new Cards {Name=@"Cards\Тб.jpeg", Numb = 11 }, //38
                new Cards {Name=@"Cards\2п.jpeg", Numb = 2 }, //39
                new Cards {Name=@"Cards\3п.jpeg", Numb = 3 }, //40
                new Cards {Name=@"Cards\4п.jpeg", Numb = 4 }, //41
                new Cards {Name=@"Cards\5п.jpeg", Numb = 5 }, //42
                new Cards {Name=@"Cards\6п.jpeg", Numb = 6 }, //43
                new Cards {Name=@"Cards\7п.jpeg", Numb = 7 }, //44
                new Cards {Name=@"Cards\8п.jpeg", Numb = 8 }, //45
                new Cards {Name=@"Cards\9п.jpeg", Numb = 9 }, //46
                new Cards {Name=@"Cards\10п.jpeg", Numb = 10 }, //47
                new Cards {Name=@"Cards\Вп.jpeg", Numb = 10 }, //48
                new Cards {Name=@"Cards\Дп.jpeg", Numb = 10 }, //49
                new Cards {Name=@"Cards\Кп.jpeg", Numb = 10 }, //50
                new Cards {Name=@"Cards\Тп.jpeg", Numb = 11 } //51
            };
        
        Cards tempplayer = new Cards();
        Cards tempdealer = new Cards();

        List<int> player = new List<int>();  // массив карт игрока для статистики
        List<int> dealer = new List<int>();  // массив карт дилера для статистики
        
        public Form1()
        {
            InitializeComponent();
        }
        private void More1(object sender, EventArgs e)
        {
            foreach (var i in card)
                tempplayer = card[r.Next(0, card.Count)];
            countplayer += tempplayer.Numb;
            player.Add(tempplayer.Numb);

            pictureBox4.Image = Image.FromFile(tempplayer.Name);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            textBox1.Text = countplayer.ToString();
            card.Remove(tempplayer);
            if (countplayer > 21)
            {
                res = MessageBox.Show($"У вас перебор: {countplayer} очков\nДилер выиграл\n\nХотите начать заново?", "Пичалька", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (res == DialogResult.Yes)
                {
                    Process.Start(Application.ExecutablePath);
                    this.Close();
                }
                else                
                    this.Close();                
            }
            button3.Click -= More1; //отписываем это же событие посте отработки
            button3.Click += More2; // переходим на следующее событие для повторного нажаьтя кнопки "ещё"
        }

        private void More2(object sender, EventArgs e)
        {
            foreach (var i in card)
                tempplayer = card[r.Next(0, card.Count)];
            countplayer += tempplayer.Numb;
            player.Add(tempplayer.Numb);

            pictureBox5.Image = Image.FromFile(tempplayer.Name);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            textBox1.Text = countplayer.ToString();
            card.Remove(tempplayer);
            if (countplayer > 21)
            {
                res = MessageBox.Show($"У вас перебор: {countplayer} очков\nДилер выиграл\n\nХотите начать заново?", "Пичалька", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (res == DialogResult.Yes)
                {
                    Process.Start(Application.ExecutablePath);
                    this.Close();
                }
                else
                    this.Close();
            }

            button3.Click -= More2;
            button3.Click += More3;
        }

        private void More3(object sender, EventArgs e)
        {
            foreach (var i in card)
                tempplayer = card[r.Next(0, card.Count)];
            countplayer += tempplayer.Numb;
            player.Add(tempplayer.Numb);

            pictureBox6.Image = Image.FromFile(tempplayer.Name);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            textBox1.Text = countplayer.ToString();
            card.Remove(tempplayer);
            if (countplayer > 21)
            {
                res = MessageBox.Show($"У вас перебор: {countplayer} очков\nДилер выиграл\n\nХотите начать заново?", "Пичалька", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (res == DialogResult.Yes)
                {
                    Process.Start(Application.ExecutablePath);
                    this.Close();
                }
                else
                    this.Close();
            }
        }

        void MoreDeal1()
        {
            foreach (var i in card)
                tempdealer = card[r.Next(0, card.Count)];
            countdealer += tempdealer.Numb;
            dealer.Add(tempdealer.Numb);

            pictureBox9.Image = Image.FromFile(tempdealer.Name);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            textBox2.Text = countdealer.ToString();
            card.Remove(tempdealer);
        }

        void MoreDeal2()
        {
            foreach (var i in card)
                tempdealer = card[r.Next(0, card.Count)];
            countdealer += tempdealer.Numb;
            dealer.Add(tempdealer.Numb);

            pictureBox10.Image = Image.FromFile(tempdealer.Name);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            textBox2.Text = countdealer.ToString();
            card.Remove(tempdealer);
        }

        void MoreDeal3()
        {
            foreach (var i in card)
                tempdealer = card[r.Next(0, card.Count)];
            countdealer += tempdealer.Numb;
            dealer.Add(tempdealer.Numb);

            pictureBox11.Image = Image.FromFile(tempdealer.Name);
            pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
            textBox2.Text = countdealer.ToString();
            card.Remove(tempdealer);
        }

        void MoreDeal4()
        {
            foreach (var i in card)
                tempdealer = card[r.Next(0, card.Count)];
            countdealer += tempdealer.Numb;
            dealer.Add(tempdealer.Numb);

            pictureBox12.Image = Image.FromFile(tempdealer.Name);
            pictureBox12.SizeMode = PictureBoxSizeMode.Zoom;
            textBox2.Text = countdealer.ToString();
            card.Remove(tempdealer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var i in card)
                tempplayer = card[r.Next(0, card.Count)];  //  вытаскиваем рандом из Cards

            countplayer = tempplayer.Numb;
            player.Add(tempplayer.Numb);
                       
           pictureBox1.Image = Image.FromFile(tempplayer.Name);
           pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // подстраиваем под pictureBox2
           textBox1.Text = countplayer.ToString();
           card.Remove(tempplayer);   // выкидываем эту карту в отбой!!!

            foreach (var i in card)
                tempplayer = card[r.Next(0, card.Count)];
            countplayer += tempplayer.Numb;
            player.Add(tempplayer.Numb);

            pictureBox2.Image = Image.FromFile(tempplayer.Name);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            textBox1.Text = countplayer.ToString();
            card.Remove(tempplayer);

            if ((pictureBox1.Image == Image.FromFile(@"Cards\Тч.jpeg") ||
                pictureBox1.Image == Image.FromFile(@"Cards\Тт.jpeg") ||
                pictureBox1.Image == Image.FromFile(@"Cards\Тб.jpeg") ||
                pictureBox1.Image == Image.FromFile(@"Cards\Тп.jpeg")) 
                &&
                (pictureBox2.Image == Image.FromFile(@"Cards\Тч.jpeg") ||
                pictureBox2.Image == Image.FromFile(@"Cards\Тт.jpeg") ||
                pictureBox2.Image == Image.FromFile(@"Cards\Тб.jpeg") ||
                pictureBox2.Image == Image.FromFile(@"Cards\Тп.jpeg")))
                countplayer = 12; // если вывалит 2 туза

            if (countplayer == 21)
            {
                res = MessageBox.Show("!!!BLACK JACK!!!", "Поздравляшки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    Process.Start(Application.ExecutablePath);
                    this.Close();
                }
            }

            button1.Enabled = false; // блокируем кнопку после первых двух карт.
            button3.Enabled = true; // запуск кнопки "ещё".
            button4.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var i in card)
                tempplayer = card[r.Next(0, card.Count)];
            countplayer += tempplayer.Numb;
            player.Add(tempplayer.Numb);

            pictureBox3.Image = Image.FromFile(tempplayer.Name);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            textBox1.Text = countplayer.ToString();
            card.Remove(tempplayer);
            if (countplayer > 21)
            {
                res = MessageBox.Show($"У вас перебор: {countplayer} очков\nДилер выиграл\n\nХотите начать заново?", "Пичалька", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (res == DialogResult.Yes)
                {
                    Process.Start(Application.ExecutablePath);
                    this.Close();
                }
                else
                    this.Close();
            }

            button3.Click -= button3_Click;     //прервать событие       
            button3.Click += More1;             // событие запускает другие события
                 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var i in card)
                tempdealer = card[r.Next(0, card.Count)];
            countdealer += tempdealer.Numb;
            dealer.Add(tempdealer.Numb);

            pictureBox7.Image = Image.FromFile(tempdealer.Name);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            textBox2.Text = countdealer.ToString();
            card.Remove(tempdealer);   // выкидываем эту карту в отбой!!!

            foreach (var i in card)
                tempdealer = card[r.Next(0, card.Count)];
            countdealer += tempdealer.Numb;
            dealer.Add(tempdealer.Numb);

            pictureBox8.Image = Image.FromFile(tempdealer.Name);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;

            if ((pictureBox7.Image == Image.FromFile(@"Cards\Тч.jpeg") ||
                pictureBox7.Image == Image.FromFile(@"Cards\Тт.jpeg") ||
                pictureBox7.Image == Image.FromFile(@"Cards\Тб.jpeg") ||
                pictureBox7.Image == Image.FromFile(@"Cards\Тп.jpeg"))
                &&
                (pictureBox8.Image == Image.FromFile(@"Cards\Тч.jpeg") ||
                pictureBox8.Image == Image.FromFile(@"Cards\Тт.jpeg") ||
                pictureBox8.Image == Image.FromFile(@"Cards\Тб.jpeg") ||
                pictureBox8.Image == Image.FromFile(@"Cards\Тп.jpeg")))
                countdealer = 12;

            textBox2.Text = countdealer.ToString();
            card.Remove(tempdealer);
            
            if (countdealer <= 16)   // ссыкливый бот всё же боится когда набирает 16 очков и не жедает больше рисковать
                MoreDeal1();

            if (countdealer <= 16)
                MoreDeal2();

            if (countdealer <= 16)
                MoreDeal3();

            if (countdealer <= 16)
                MoreDeal4();

            if ((countdealer > countplayer) && (countdealer <= 21))
            {
                res = MessageBox.Show($"Дилер выиграл\n\nХотите начать заново?", "Пичалька", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (res == DialogResult.Yes)
                {
                    Process.Start(Application.ExecutablePath);
                    this.Close();
                }
                else
                    this.Close();
            }
            else if (countdealer == countplayer)
            {
                res = MessageBox.Show($"НИЧЬЯ!\n\nХотите начать заново?", "Ну такое", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (res == DialogResult.Yes)
                {
                    Process.Start(Application.ExecutablePath);
                    this.Close();
                }
                else
                    this.Close();
            }
            else if ((countdealer < countplayer) || (countdealer > 21))
            {
                res = MessageBox.Show($"Вы выиграли!\n\nХотите начать заново?", "Радость", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    Process.Start(Application.ExecutablePath);
                    this.Close();
                }
                else
                    this.Close();
            }

        }        
       
        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
            this.Close();
        }
    }
}
