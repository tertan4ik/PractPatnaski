using System;

namespace WindowsFormsApp3
{
    internal class Game
    {
        int[,] map; // Карта игры, хранящая номера клеток
        int size; // Размер поля
        int space_x, space_y; // Координаты пустой клетки

        // Конструктор игры, принимающий размер поля
        public Game(int size)
        {
            if (size < 2) size = 2; // Минимальный размер поля — 2x2
            if (size > 5) size = 5; // Максимальный размер поля — 5x5
            this.size = size;
            map = new int[size, size]; // Инициализируем карту
        }

        // Преобразуем координаты (x, y) в позицию на поле
        private int coord_to_position(int x, int y)
        {
            if (x < 0) x = 0; // Проверка на выход за пределы
            else if (x > size - 1) x = size - 1; // Проверка на выход за пределы
            if (y < 0) y = 0;
            else if (y > size - 1) y = size - 1;

            return y * size + x; // Возвращаем позицию
        }

        // Преобразуем позицию в координаты (x, y)
        private void position_to_coords(int position, out int x, out int y)
        {
            y = position % size; // Строка
            x = position / size; // Столбец
        }

        // Инициализация игры: заполнение карты номерами
        public void start()
        {
            for (int x = 0; x < size; x++) // Перебираем все строки
                for (int y = 0; y < size; y++) // Перебираем все столбцы
                    map[x, y] = coord_to_position(x, y) + 1; // Заполняем клетки номерами
            space_x = size - 1; // Позиция пустой клетки
            space_y = size - 1;
            map[space_x, space_y] = 0; // Пустая клетка
        }

        // Получаем номер клетки по позиции
        public int get_number(int position)
        {
            int x, y;
            position_to_coords(position, out x, out y); // Преобразуем позицию в координаты
            if (x < 0 || x >= size || y < 0 || y >= size) return 0; // Если координаты вне поля
            return map[x, y]; // Возвращаем номер клетки
        }

        // Перемещаем клетку по позиции
        public void shift(int position)
        {
            int x, y;
            position_to_coords(position, out x, out y); // Преобразуем позицию в координаты
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) != 1) return; // Проверяем, соседняя ли клетка
            map[space_x, space_y] = map[x, y]; // Перемещаем клетку
            map[x, y] = 0; // Освобождаем старую позицию
            space_x = x; // Обновляем координаты пустой клетки
            space_y = y;
        }

        // Перемещаем случайную клетку
        public void shift_random()
        {
            Random random = new Random(); // Генератор случайных чисел
            int a = random.Next(0, 4); // Выбираем направление
            int x = space_x;
            int y = space_y;
            switch (a)
            {
                case 0: x--; break; // Вверх
                case 1: x++; break; // Вниз
                case 2: y--; break; // Влево
                case 3: y++; break; // Вправо
            }
            shift(coord_to_position(x, y)); // Перемещаем клетку
        }
    }
}
