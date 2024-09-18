using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ComplexNumbersLib;

namespace Complex_Interface_WPF
{
    /// <summary>
    /// Класс, реализующий логику страницы калькулятора для работы с полярными координатами в радианах.
    /// </summary>
    public partial class CalculatorPolarRad : Page
    {
        /// <summary>
        /// Конструктор класса. Инициализирует компоненты страницы и устанавливает обработчики событий для кнопок.
        /// </summary>
        public CalculatorPolarRad()
        {
            InitializeComponent(); // Инициализирует компоненты пользовательского интерфейса
            // Устанавливает обработчики событий для кнопок
            AddPolarRad.Click += PerformCalculation;
            SubPolarRad.Click += PerformCalculation;
            MultPolarRad.Click += PerformCalculation;
            DivPolarRad.Click += PerformCalculation;
            RestartPolarRad.Click += ClearFields;
        }

        /// <summary>
        /// Метод для выполнения вычислений при нажатии на кнопку.
        /// </summary>
        /// <param name="sender">Объект, вызвавший это событие (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void PerformCalculation(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение значений из текстовых полей
                double r1 = double.Parse(Num1_RRad_TB.Text); // Радиус первого числа
                double theta1 = double.Parse(Num1_CosRad_TB.Text); // Угол первого числа в радианах
                double r2 = double.Parse(Num2_RRad_TB.Text); // Радиус второго числа
                double theta2 = double.Parse(Num2_CosRad_TB.Text); // Угол второго числа в радианах

                // Проверка на пустые поля
                if (string.IsNullOrEmpty(Num1_RRad_TB.Text) || string.IsNullOrEmpty(Num2_RRad_TB.Text) ||
                    string.IsNullOrEmpty(Num1_CosRad_TB.Text) || string.IsNullOrEmpty(Num2_CosRad_TB.Text))
                {
                    throw new InvalidOperationException("Ошибка: Все поля должны быть заполнены.");
                }
                // Преобразование полярных координат в комплексные числа
                ComplexNumbers z1 = new ComplexNumbers(r1, theta1, true);
                ComplexNumbers z2 = new ComplexNumbers(r2, theta2, true);

                ComplexNumbers result = null;


                // Выполнение операции в зависимости от нажатой кнопки
                if (sender == AddPolarRad)
                {
                    result = z1.Add(z2); // Сложение двух комплексных чисел
                }
                else if (sender == SubPolarRad)
                {
                    result = z1.Subtract(z2); // Вычитание второго комплексного числа из первого
                }
                else if (sender == MultPolarRad)
                {
                    result = z1.Multiply(z2); // Умножение двух комплексных чисел
                }
                else if (sender == DivPolarRad)
                {
                    result = z1.Divide(z2); // Деление первого комплексного числа на второе
                }

                // Отображение результата
                ResultPolarRad_TB.Text = result.Display();
                ResultPolarRad_TB.Foreground = Brushes.Black;
            }
            catch (FormatException)
            {
                // Обработка ошибок формата (например, если введены буквы)
                ResultPolarRad_TB.Text = "Ошибка: Пожалуйста, введите числовые значения.";
                ResultPolarRad_TB.Foreground = Brushes.Red; // Устанавливаем цвет текста на красный
            }
            catch (InvalidOperationException ex)
            {
                // Обработка ошибки пустых полей или других операций
                ResultPolarRad_TB.Text = ex.Message;
                ResultPolarRad_TB.Foreground = Brushes.Red; // Устанавливаем цвет текста на красный
            }
            catch (DivideByZeroException)
            {
                // Обработка ошибки деления на ноль
                ResultPolarRad_TB.Text = "Ошибка: Деление на ноль невозможно.";
                ResultPolarRad_TB.Foreground = Brushes.Red; // Устанавливаем цвет текста на красный
            }
            catch (Exception ex)
            {
                // Обработка остальных исключений
                ResultPolarRad_TB.Text = $"Ошибка: {ex.Message}";
                ResultPolarRad_TB.Foreground = Brushes.Red; // Устанавливаем цвет текста на красный
            }
        }

        /// <summary>
        /// Метод для очистки всех текстовых полей на странице.
        /// </summary>
        /// <param name="sender">Объект, вызвавший это событие (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void ClearFields(object sender, RoutedEventArgs e)
        {
            // Очистка текстовых полей
            Num1_RRad_TB.Text = ""; // Очистка радиуса первого числа
            Num1_CosRad_TB.Text = ""; // Очистка угла первого числа
            Num2_RRad_TB.Text = ""; // Очистка радиуса второго числа
            Num2_CosRad_TB.Text = ""; // Очистка угла второго числа
            ResultPolarRad_TB.Text = ""; // Очистка поля результата
            ResultPolarRad_TB.Foreground = Brushes.Black; // Устанавливаем цвет текста на черный после перезагрузки
        }
    }
}

