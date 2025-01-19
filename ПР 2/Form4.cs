using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammB
{
    public partial class Form4 : Form
    {
        private Random random; // Объект для генерации случайных чисел
        private int[] data; // Массив для хранения данных

        public Form4()
        {
            InitializeComponent();
            random = new Random(); // Инициализация объекта Random
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Настройка DataGridView
            dataGridView2.Columns.Clear(); // Очистка существующих столбцов
            dataGridView2.Columns.Add("Algorithm", "Алгоритм");
            dataGridView2.Columns.Add("Iterations", "Итерации");
            dataGridView2.Columns.Add("Value", "Значение");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Генерация случайных данных
            int size = 100; // Размер массива по умолчанию
            if (checkBox5.Checked) // Если выбрана BOGO сортировка
            {
                size = 8; // Ограничиваем размер массива до 8 элементов
            }

            data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = random.Next(1, 101); // Ограничиваем диапазон чисел от 1 до 100
            }

            // Очистка DataGridView перед добавлением новых данных
            dataGridView2.Rows.Clear();

            // Сортировка и измерение времени
            if (checkBox1.Checked) // Пузырьковая сортировка
            {
                MeasureSortingTime(BubbleSort, "Пузырьковая сортировка");
            }
            if (checkBox2.Checked) // Сортировка вставками
            {
                MeasureSortingTime(InsertionSort, "Сортировка вставками");
            }
            if (checkBox3.Checked) // Шейкерная сортировка
            {
                MeasureSortingTime(ShakerSort, "Шейкерная сортировка");
            }
            if (checkBox4.Checked) // Быстрая сортировка
            {
                MeasureSortingTime(QuickSort, "Быстрая сортировка");
            }
            if (checkBox5.Checked) // BOGO сортировка
            {
                // Запускаем BOGO сортировку в отдельном потоке с тайм-аутом
                await MeasureSortingTimeAsync(BogoSort, "BOGO сортировка", 5000); // Тайм-аут 5 секунд
            }
        }
        private void MeasureSortingTime(Func<int[], int> sortMethod, string sortName)
        {
            int[] dataCopy = (int[])data.Clone();
            Stopwatch stopwatch = Stopwatch.StartNew();
            int iterations = sortMethod(dataCopy); // Получаем количество итераций
            stopwatch.Stop();

            // Используем TotalMilliseconds для точного измерения времени
            double elapsedTime = stopwatch.Elapsed.TotalMilliseconds;

            // Добавляем данные в dataGridView2
            dataGridView2.Rows.Add(sortName, iterations, $"{elapsedTime:F4} ms");
        }

        private async Task MeasureSortingTimeAsync(Func<int[], int> sortMethod, string sortName, int timeoutMilliseconds)
        {
            int[] dataCopy = (int[])data.Clone();
            Stopwatch stopwatch = Stopwatch.StartNew();
            int iterations = 0;

            // Запускаем сортировку в отдельном потоке
            var task = Task.Run(() => sortMethod(dataCopy));

            // Ожидаем завершения задачи или тайм-аута
            if (await Task.WhenAny(task, Task.Delay(timeoutMilliseconds)) == task)
            {
                // Сортировка завершена
                iterations = task.Result;
                stopwatch.Stop();
                double elapsedTime = stopwatch.Elapsed.TotalMilliseconds;

                // Добавляем данные в dataGridView2
                dataGridView2.Invoke((MethodInvoker)(() =>
                {
                    dataGridView2.Rows.Add(sortName, iterations, $"{elapsedTime:F4} ms");
                }));
            }
            else
            {
                // Тайм-аут
                stopwatch.Stop();
                MessageBox.Show($"BOGO сортировка прервана по тайм-ауту ({timeoutMilliseconds} мс).", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int BubbleSort(int[] array)
        {
            int iterations = 0; // Счетчик итераций
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    iterations++; // Увеличиваем счетчик итераций
                    if (array[j] > array[j + 1])
                    {
                        // Меняем местами
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return iterations; // Возвращаем количество итераций
        }

        private int InsertionSort(int[] array)
        {
            int iterations = 0; // Счетчик итераций
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    iterations++; // Увеличиваем счетчик итераций
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            return iterations; // Возвращаем количество итераций
        }

        private int ShakerSort(int[] array)
        {
            int iterations = 0; // Счетчик итераций
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    iterations++; // Увеличиваем счетчик итераций
                    if (array[i] > array[i + 1])
                    {
                        // Меняем местами
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    iterations++; // Увеличиваем счетчик итераций
                    if (array[i] < array[i - 1])
                    {
                        // Меняем местами
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                }
                left++;
            }
            return iterations; // Возвращаем количество итераций
        }

        private int QuickSort(int[] array)
        {
            int iterations = 0; // Счетчик итераций
            QuickSort(array, 0, array.Length - 1, ref iterations);
            return iterations;
        }

        private void QuickSort(int[] array, int low, int high, ref int iterations)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high, ref iterations);
                QuickSort(array, low, pi - 1, ref iterations);
                QuickSort(array, pi + 1, high, ref iterations);
            }
        }

        private int Partition(int[] array, int low, int high, ref int iterations)
        {
            int pivot = array[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                iterations++; // Увеличиваем счетчик итераций
                if (array[j] < pivot)
                {
                    i++;
                    // Меняем местами
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            // Меняем местами
            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;
            return i + 1;
        }

        private int BogoSort(int[] array)
        {
            int iterations = 0; // Счетчик итераций
            while (!IsSorted(array))
            {
                iterations++; // Увеличиваем счетчик итераций
                Shuffle(array);
            }
            return iterations;
        }

        private bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                    return false;
            }
            return true;
        }

        private void Shuffle(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                // Меняем местами
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очистка всех строк в dataGridView2
            dataGridView2.Rows.Clear();

            // Сброс массива данных (если нужно)
            data = null;

            MessageBox.Show("DataGridView очищен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}