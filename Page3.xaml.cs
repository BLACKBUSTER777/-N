using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ComplexNumbersLib;

namespace Complex_Interface_WPF
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            // Привязываем событие нажатия кнопки "Do" к обработчику события
            Do.Click += Do_Click_1;
        }

        // Обработчик нажатия на кнопку "Do" для выполнения преобразования
        private void Do_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Определяем систему координат, из которой происходит ввод
                var fromSystem = GetSelectedFromSystem();
                // Определяем целевую систему координат для преобразования
                var toSystem = GetSelectedToSystem();

                if (fromSystem == toSystem)
                {
                    throw new Exception("Выбраны две одинаковые системы!");
                }

                // Получаем введенное комплексное число на основе выбранной системы координат
                var complexNumber = GetComplexNumber(fromSystem);

                // Конвертируем комплексное число в целевую систему координат
                Output_TB.Text = ConvertComplexNumber(complexNumber, toSystem);
                Output_TB.Foreground = Brushes.Black; // Сброс цвета текста на черный в случае успешного выполнения
            }
            catch (Exception ex)
            {
                // В случае ошибки показываем сообщение об ошибке красным цветом
                Output_TB.Text = $"Ошибка: {ex.Message}";
                Output_TB.Foreground = Brushes.Red;
            }
        }

        // Метод для определения выбранной системы координат для ввода
        private string GetSelectedFromSystem()
        {
            if (InputComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                return selectedItem.Name; // Возвращаем имя ComboBoxItem для последующей обработки
            }
            throw new Exception("Пожалуйста, выберите систему координат для ввода.");
        }

        // Метод для определения целевой системы координат
        private string GetSelectedToSystem()
        {
            if (OutputComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                return selectedItem.Name; // Возвращаем имя ComboBoxItem для последующей обработки
            }
            throw new Exception("Пожалуйста, выберите систему координат для вывода.");
        }

        // Метод для получения комплексного числа на основе выбранной системы координат
        private ComplexNumbers GetComplexNumber(string system)
        {
            try
            {
                double real, imaginary, radius, angleDegrees, angleRadians;

                // Декартова система координат (действительная и мнимая часть)
                if (system == "CartesianInput")
                {
                    real = ParseDouble(Input1_TB.Text, "Действительная часть");
                    imaginary = ParseDouble(Input2_TB.Text, "Мнимая часть");
                    return new ComplexNumbers(real, imaginary);
                }
                // Полярная система в градусах (радиус и угол)
                else if (system == "PolarTrigDegreesInput" || system == "PolarExponentialDegreesInput")
                {
                    radius = ParseDouble(Input1_TB.Text, "Радиус");
                    angleDegrees = ParseDouble(Input2_TB.Text, "Угол (в градусах)");
                    // Конвертируем угол из градусов в радианы
                    return new ComplexNumbers(radius, angleDegrees * (Math.PI / 180), true);
                }
                // Полярная система в радианах (радиус и угол)
                else if (system == "PolarTrigRadiansInput" || system == "PolarExponentialRadiansInput")
                {
                    radius = ParseDouble(Input1_TB.Text, "Радиус");
                    angleRadians = ParseDouble(Input2_TB.Text, "Угол (в радианах)");
                    return new ComplexNumbers(radius, angleRadians, true);
                }

                throw new Exception("Не удалось определить систему координат.");
            }
            catch (FormatException fe)
            {
                throw new Exception($"Неверный формат ввода: {fe.Message}");
            }
            catch (OverflowException oe)
            {
                throw new Exception($"Значение ввода вне допустимого диапазона: {oe.Message}");
            }
        }

        // Метод для парсинга double со специфической обработкой ошибок
        private double ParseDouble(string input, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception($"{parameterName} не введено.");
            }

            if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
            {
                throw new Exception($"{parameterName} должно быть числовым значением.");
            }

            return result;
        }

        // Метод для преобразования комплексного числа в целевую систему координат и возврат результата в виде строки
        private string ConvertComplexNumber(ComplexNumbers complexNumber, string toSystem)
        {
            double a = complexNumber.a; // Действительная часть
            double b = complexNumber.b; // Мнимая часть

            // Декартова система координат (действительная и мнимая часть)
            if (toSystem == "CartesianOutput")
            {
                return complexNumber.Display();
            }
            // Полярная система координат
            else if (toSystem.Contains("Polar"))
            {
                double radius = complexNumber.radius;
                double angle = complexNumber.angle;

                // Преобразование угла в градусы, если необходимо
                if (toSystem.Contains("Degrees"))
                {
                    angle = angle * (180 / Math.PI);
                }

                // Экспоненциальное представление
                if (toSystem.Contains("Exponential"))
                {
                    return $"{radius}e^(i{angle})";
                }
                // Тригонометрическое представление
                else
                {
                    return $"r = {radius}; angle = {angle}";
                }
            }

            throw new Exception("Неизвестная целевая система координат.");
        }

        // Метод для удаления текста (привязан к кнопке "✕")
        private void Del_Click_1(object sender, RoutedEventArgs e)
        {
            Input1_TB.Text = string.Empty;
            Input2_TB.Text = string.Empty;
            Output_TB.Text = string.Empty;
            InputComboBox.SelectedIndex = -1;
            OutputComboBox.SelectedIndex = -1;
            Output_TB.Foreground = Brushes.Black; // Сброс цвета текста на черный
        }
    }
}
