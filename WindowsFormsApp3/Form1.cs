using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Game game;
        private int size;
        private Image originalImage;

        public Form1(int size)
        {
            InitializeComponent();
            this.size = size;
            game = new Game(size);
            // Загружаем картинку, которую будем разделять
            originalImage = Image.FromFile("tiger.jpg"); // Путь к вашей картинке
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            start_game();
        }

        private void start_game()
        {
            game.start();
            CreateButtons();
            refresh();
        }

        private void CreateButtons()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = size;
            tableLayoutPanel1.ColumnCount = size;

            // Настройка кнопок
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(80, 80); // Размер кнопок
                    btn.Click += new EventHandler(Button_Click);
                    btn.Tag = row * size + col; // Сохраняем позицию
                    tableLayoutPanel1.Controls.Add(btn, col, row);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int position = (int)((Button)sender).Tag;
            game.shift(position);
            refresh();
        }

        private void refresh()
        {
            int rows = size;
            int cols = size;

            // Размеры частей изображения
            int partWidth = originalImage.Width / cols;
            int partHeight = originalImage.Height / rows;

            for (int position = 0; position < size * size; position++)
            {
                int nr = game.get_number(position);
                Button btn = (Button)tableLayoutPanel1.GetControlFromPosition(position % size, position / size);
                if (nr > 0)
                {
                    btn.Text = ""; // Убираем текст

                    // Вычисляем, какие координаты (x, y) для этой части картинки
                    int partX = (nr - 1) % cols;  // Определяем, на каком столбце
                    int partY = (nr - 1) / cols;  // Определяем, на какой строке

                    // Создаем прямоугольник для части картинки
                    Rectangle srcRect = new Rectangle(partX * partWidth, partY * partHeight, partWidth, partHeight);

                    // Создаем новое изображение для кнопки
                    Bitmap buttonImage = new Bitmap(partWidth, partHeight);
                    using (Graphics g = Graphics.FromImage(buttonImage))
                    {
                        g.DrawImage(originalImage, new Rectangle(0, 0, partWidth, partHeight), srcRect, GraphicsUnit.Pixel);
                    }

                    // Устанавливаем картинку для кнопки
                    btn.BackgroundImage = buttonImage;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    btn.BackgroundImage = null; // Пустая клетка
                }
            }
        }
    }
}
