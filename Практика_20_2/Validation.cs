using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_20
{
    public static class Validation
    {
        // проверка, что строка не пустая
        public static string ValidateString(string value, string str)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return $"Поле {str} не может быть пустым.";
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsLetter(str[i]))
                    {
                        return $"Поле {str} должно содержать только буквы.";
                    }
                }
            }
            return string.Empty ;
        }

        // проверка, что число положительное
        public static string ValidateInt(int value, string number)
        {
            if (value <= 0)
            {
                return $"Поле '{number}' должно быть положительным числом.";
            }
            else
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if (!char.IsDigit(number[i]))
                    {
                        return $"Поле '{number}' должно содержать только цифры.";
                    }
                }
            }
            return string.Empty;
        }

        public static string ValidateDuration(int duration)
        {
            if (duration < 1 || duration > 365)
            {
                return $"Продолжительность путевки должна быть от 1 до 365 дней.\n";
            }
            
            return string.Empty;
        }

    }
}
