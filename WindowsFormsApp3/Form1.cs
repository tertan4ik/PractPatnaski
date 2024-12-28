using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Game game; // Объект игры
        private int size; // Размер поля игры
        private Image originalImage; // Оригинальное изображение, которое будем разделять

        // Конструктор формы, где задается размер поля
        public Form1(int size)
        {
            InitializeComponent();
            this.size = size; // Устанавливаем размер поля
            game = new Game(size); // Создаем игру с этим размером
            // Загружаем картинку, которую будем разделять
            originalImage = Image.FromFile("tiger.jpg"); // Путь к картинке
        }

        // Событие загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            start_game(); // Запуск игры при загрузке формы
        }

        // Метод для начала игры
        private void start_game()
        {
            game.start(); // Инициализация игры
            CreateButtons(); // Создание кнопок для каждой клетки
            refresh(); // Обновление отображения игры
        }

        // Метод для создания кнопок для каждой клетки поля
        private void CreateButtons()
        {
            tableLayoutPanel1.Controls.Clear(); // Очищаем все предыдущие элементы
            tableLayoutPanel1.RowCount = size; // Устанавливаем количество строк
            tableLayoutPanel1.ColumnCount = size; // Устанавливаем количество столбцов

            // Настройка кнопок
            for (int row = 0; row < size; row++) // Перебираем все строки
            {
                for (int col = 0; col < size; col++) // Перебираем все столбцы
                {
                    Button btn = new Button(); // Создаем кнопку
                    btn.Size = new Size(80, 80); // Устанавливаем размер кнопки
                    btn.Click += new EventHandler(Button_Click); // Обработчик клика
                    btn.Tag = row * size + col; // Сохраняем позицию кнопки
                    tableLayoutPanel1.Controls.Add(btn, col, row); // Добавляем кнопку в таблицу
                }
            }
        }

        // Обработчик клика по кнопке
        private void Button_Click(object sender, EventArgs e)
        {
            int position = (int)((Button)sender).Tag; // Получаем позицию кнопки
            game.shift(position); // Перемещаем клетку
            refresh(); // Обновляем отображение
        }

        // Метод для обновления отображения кнопок
        private void refresh()
        {
            int rows = size; // Количество строк
            int cols = size; // Количество столбцов

            // Размеры частей изображения
            int partWidth = originalImage.Width / cols; // Ширина каждой части изображения
            int partHeight = originalImage.Height / rows; // Высота каждой части изображения

            for (int position = 0; position < size * size; position++) // Перебираем все позиции
            {
                int nr = game.get_number(position); // Получаем номер для текущей позиции
                Button btn = (Button)tableLayoutPanel1.GetControlFromPosition(position % size, position / size); // Получаем кнопку для текущей клетки
                if (nr > 0) // Если клетка не пустая
                {
                    btn.Text = ""; // Убираем текст на кнопке

                    // Вычисляем координаты части изображения
                    int partX = (nr - 1) % cols;  // Определяем столбец для части изображения
                    int partY = (nr - 1) / cols;  // Определяем строку для части изображения

                    // Создаем прямоугольник для вырезания части изображения
                    Rectangle srcRect = new Rectangle(partX * partWidth, partY * partHeight, partWidth, partHeight);

                    // Создаем изображение для кнопки
                    Bitmap buttonImage = new Bitmap(partWidth, partHeight);
                    using (Graphics g = Graphics.FromImage(buttonImage))
                    {
                        g.DrawImage(originalImage, new Rectangle(0, 0, partWidth, partHeight), srcRect, GraphicsUnit.Pixel);
                    }

                    // Устанавливаем картинку на кнопку
                    btn.BackgroundImage = buttonImage;
                    btn.BackgroundImageLayout = ImageLayout.Stretch; // Растягиваем изображение по кнопке
                }
                else
                {
                    btn.BackgroundImage = null; // Пустая клетка, без изображения
                }
            }
        }
    }
}
