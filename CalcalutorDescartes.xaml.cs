using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ComplexNumbersLib;

namespace Complex_Interface_WPF
{
    /// <summary>
    /// Логика взаимодействия для страницы CalculatorDescartes, которая выполняет операции с комплексными числами
    /// в декартовом представлении (действительная и мнимая части).
    /// </summary>
    public partial class CalcalutorDescartes : Page
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CalcalutorDescartes"/>.
        /// Привязывает обработчики событий к кнопкам операций и кнопке перезагрузки.
        /// </summary>
        public CalcalutorDescartes()
        {
            InitializeComponent();

            // Привязываем обработчики событий к кнопкам операций (Сложение, Вычитание, Умножение, Деление)
            AddDesc.Click += Operation_Click;
            SubDesc.Click += Operation_Click;
            MultDesc.Click += Operation_Click;
            DivDesc.Click += Operation_Click;

            // Привязываем обработчик события к кнопке перезагрузки
            RestartDesc.Click += RestartDesc_Click;
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопок операций (Сложение, Вычитание, Умножение, Деление).
        /// Считывает ввод из текстовых полей, выполняет выбранную операцию с комплексными числами
        /// и отображает результат.
        /// </summary>
        /// <param name="sender">Кнопка, которая была нажата (Сложение, Вычитание, Умножение или Деление).</param>
        /// <param name="e">Данные события, связанные с нажатием кнопки.</param>
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Считываем действительную и мнимую части первого комплексного числа из текстовых полей
                var num1Re = double.Parse(Num1_Re_TB.Text);
                var num1Im = double.Parse(Num1_Im_TB.Text);

                // Считываем действительную и мнимую части второго комплексного числа из текстовых полей
                var num2Re = double.Parse(Num2_Re_TB.Text);
                var num2Im = double.Parse(Num2_Im_TB.Text);

                // Создаем объекты комплексных чисел на основе введенных значений
                ComplexNumbers num1 = new ComplexNumbers(num1Re, num1Im);
                ComplexNumbers num2 = new ComplexNumbers(num2Re, num2Im);

                // Определяем, какая кнопка операции была нажата
                Button button = sender as Button;
                ComplexNumbers result = null; // Переменная для хранения результата операции

                // Выполняем соответствующую операцию в зависимости от нажатой кнопки
                if (button == AddDesc)
                {
                    // Операция сложения
                    result = num1.Add(num2);
                }
                else if (button == SubDesc)
                {
                    // Операция вычитания
                    result = num1.Subtract(num2);
                }
                else if (button == MultDesc)
                {
                    // Операция умножения
                    result = num1.Multiply(num2);
                }
                else if (button == DivDesc)
                {
                    // Операция деления
                    result = num1.Divide(num2);
                }

                // Если операция выполнена успешно, отображаем результат
                if (result != null)
                {
                    ResultDesc_TB.Text = result.Display(); // Отображаем результат в текстовом поле результата
                    ResultDesc_TB.Foreground = Brushes.Black; // Устанавливаем цвет текста на черный
                }
            }
            catch (FormatException)
            {
                // Обработка ошибок формата, например, если введены буквы
                if (string.IsNullOrEmpty(Num1_Re_TB.Text) || string.IsNullOrEmpty(Num1_Im_TB.Text) ||
                    string.IsNullOrEmpty(Num2_Re_TB.Text) || string.IsNullOrEmpty(Num2_Im_TB.Text))
                {
                    ResultDesc_TB.Text = "Ошибка: Все поля должны быть заполнены.";
                }
                else if (HasNonNumericInput(Num1_Re_TB.Text) || HasNonNumericInput(Num1_Im_TB.Text) ||
                         HasNonNumericInput(Num2_Re_TB.Text) || HasNonNumericInput(Num2_Im_TB.Text))
                {
                    ResultDesc_TB.Text = "Ошибка: Введите только числовые значения.";
                }
                else
                {
                    ResultDesc_TB.Text = $"Ошибка: Неверный формат ввода. Убедитесь, что все значения числовые.";
                }

                ResultDesc_TB.Foreground = Brushes.Red; // Устанавливаем цвет текста на красный
            }
            catch (DivideByZeroException)
            {
                // Обработка ошибки деления на ноль
                ResultDesc_TB.Text = "Ошибка: Деление на ноль невозможно.";
                ResultDesc_TB.Foreground = Brushes.Red; // Устанавливаем цвет текста на красный
            }
            catch (Exception ex)
            {
                // Обработка остальных исключений
                ResultDesc_TB.Text = $"Ошибка: {ex.Message}";
                ResultDesc_TB.Foreground = Brushes.Red; // Устанавливаем цвет текста на красный
            }
        }

        // Проверка, содержит ли текст нечисловые символы
        private bool HasNonNumericInput(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '.' && c != '-' && c != ',')
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Обрабатывает событие нажатия кнопки перезагрузки.
        /// Очищает все текстовые поля ввода и поля результата, подготавливая форму для нового вычисления.
        /// </summary>
        /// <param name="sender">Кнопка, которая была нажата (Кнопка перезагрузки).</param>
        /// <param name="e">Данные события, связанные с нажатием кнопки.</param>
        private void RestartDesc_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем все текстовые поля, чтобы сбросить ввод и результат
            Num1_Re_TB.Text = ""; // Очищаем действительную часть первого комплексного числа
            Num1_Im_TB.Text = ""; // Очищаем мнимую часть первого комплексного числа
            Num2_Re_TB.Text = ""; // Очищаем действительную часть второго комплексного числа
            Num2_Im_TB.Text = ""; // Очищаем мнимую часть второго комплексного числа
            ResultDesc_TB.Text = ""; // Очищаем поле результата
            ResultDesc_TB.Foreground = Brushes.Black; // Устанавливаем цвет текста на черный после перезагрузки
        }

        
    }
}


