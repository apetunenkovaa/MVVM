using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MVVM
{
    class Model
    {
        public static string firstOperand; 
        public static string secondOperand; 
        public static string result = ""; 
        public static int indexComboBox = -1; 
        public static List<string> dataListDisplay = new List<string>() { "Сложение", "Вычитание", "Умножение", "Деление" }; 
        public static List<string> dataListValue = new List<string>() { "+", "-", "*", "/" }; 
    }
}
