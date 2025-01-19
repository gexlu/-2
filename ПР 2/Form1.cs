using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NCalc;
using OxyPlot;
using OxyPlot.Series;

namespace ПР_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик для кнопки "Решение"
        private void решениеToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            double a, b, e;
            string fx = txtFunction.Text;

            // Валидация входных данных
            if (!double.TryParse(txtA.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out a))
            {
                MessageBox.Show("Некорректное значение a.");
                return;
            }

            if (!double.TryParse(txtB.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out b))
            {
                MessageBox.Show("Некорректное значение b.");
                return;
            }

            // Проверка корректности значения e
            if (!double.TryParse(txtE.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out e) || e <= 0)
            {
                MessageBox.Show("Некорректное значение e. Введите положительное число.");
                return;
            }

            if (a >= b)
            {
                MessageBox.Show("a должно быть меньше b.");
                return;
            }

            // Проверка корректности выражения
            if (!IsValidExpression(fx))
            {
                MessageBox.Show("Некорректное выражение f(x).");
                return;
            }

            // Поиск минимума
            double min = FindMinimum(a, b, e, fx);

            if (double.IsNaN(min))
            {
                MessageBox.Show("Ошибка при поиске минимума.");
                return;
            }

            double minY = EvaluateFunction(fx, min);

            if (double.IsNaN(minY))
            {
                MessageBox.Show("Ошибка при вычислении функции.");
                return;
            }

            // Вывод результата
            lblResult.Text = $"Минимум при x = {min:F4}, f(x) = {minY:F4}";

            // Построение графика
            PlotFunction(a, b, fx, min);
        }

        // Обработчик для кнопки "Очистить"
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtE.Clear();
            txtFunction.Clear();
            lblResult.Text = "";
            plotView.Model = null; // Очистка графика
            plotView.Invalidate(); // Обновление PlotView
        }

        // Метод для поиска минимума методом дихотомии
        private double FindMinimum(double a, double b, double e, string fx)
        {
            while (b - a >= e)
            {
                double c = a + (b - a) / 3;
                double d = a + 2 * (b - a) / 3;

                double fc = EvaluateFunction(fx, c);
                double fd = EvaluateFunction(fx, d);

                if (double.IsNaN(fc) || double.IsNaN(fd))
                {
                    return double.NaN; // Возвращаем NaN в случае ошибки
                }

                if (fc < fd)
                    b = d;
                else
                    a = c;
            }
            return (a + b) / 2;
        }

        // Метод для вычисления значения функции
        private double EvaluateFunction(string fx, double x)
        {
            try
            {
                // Заменяем переменную x на её значение с использованием InvariantCulture
                string expressionString = fx.Replace("x", x.ToString(CultureInfo.InvariantCulture));

                // Приводим имена функций к правильному формату (с заглавной буквы)
                expressionString = expressionString
                    .Replace("sin(", "Sin(")
                    .Replace("cos(", "Cos(")
                    .Replace("tan(", "Tan(")
                    .Replace("log(", "Log(")
                    .Replace("exp(", "Exp(")
                    .Replace("sqrt(", "Sqrt(");

                var expression = new Expression(expressionString);
                return Convert.ToDouble(expression.Evaluate());
            }
            catch (EvaluationException ex)
            {
                MessageBox.Show($"Ошибка при вычислении выражения: {ex.Message}");
                return double.NaN; // Возвращаем NaN в случае ошибки
            }
        }

        // Метод для проверки корректности выражения
        private bool IsValidExpression(string expression)
        {
            // Разрешаем цифры, операторы, скобки, переменную x и математические функции
            string pattern = @"^[0-9x+\-*/^().,Sin|Cos|Tan|Sqrt|Log|Exp|Abs]+$";
            return Regex.IsMatch(expression, pattern);
        }

        // Метод для построения графика функции
        private void PlotFunction(double a, double b, string fx, double min)
        {
            // Создаем модель графика
            var plotModel = new PlotModel { Title = "График функции" };

            // Создаем серию для графика функции
            var functionSeries = new LineSeries { Title = "f(x)" };
            int points = 100;
            double step = (b - a) / (points - 1);

            for (int i = 0; i < points; i++)
            {
                double x = a + i * step;
                double y = EvaluateFunction(fx, x);
                functionSeries.Points.Add(new DataPoint(x, y));
            }

            // Добавляем серию на график
            plotModel.Series.Add(functionSeries);

            // Создаем серию для точки минимума
            var minPointSeries = new ScatterSeries { Title = "Минимум", MarkerType = MarkerType.Circle };
            double minY = EvaluateFunction(fx, min);
            minPointSeries.Points.Add(new ScatterPoint(min, minY));

            // Добавляем серию точки минимума на график
            plotModel.Series.Add(minPointSeries);

            // Привязываем модель к PlotView
            plotView.Model = plotModel;
        }
    }
}