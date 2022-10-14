namespace SCSCalc
{
    // Класс, предназначенный для сообщения о возникновении исключений, вызванных несоответствиями вводимых значений и прочими ошибками в логике прложения.
    // Пример - превышение допустимой длины постоянного линка (Permanent link).
    //
    // ИСКЛЮЧЕНИЯ НЕ ДОЛЖНЫ ОБРАБАТЫВАТЬСЯ В ПРИЛОЖЕНИИ!

    /// <summary>
    /// Обработка ошибок в логике приложения SCSCalc
    /// </summary>
    public class SCSCalcException : Exception
    {
        public SCSCalcException()
        {
        }

        public SCSCalcException(string message)
            : base(message)
        {
        }

        public SCSCalcException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}