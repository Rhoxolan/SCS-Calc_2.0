using Microsoft.Win32;
using SCSCalc;
using System;
using System.IO;
using System.Text;

namespace SCS_Calc_2._0
{
    //Методы расширения класса Configuration. Методы создаются для удобства работы с объектами
    //класса Configuration в разных частях приложения.
    public static class ConfigurationExtension
    {
        /// <summary>
        /// Строка, предназначенная для сохранения конфигурации СКС
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static string ToSaveString(this Configuration configuration)
        {
            StringBuilder saveStringBuilder = new();
            saveStringBuilder.AppendLine("Конфигурация создана в приложении SCS-Calc 2.0");
            saveStringBuilder.AppendLine();
            saveStringBuilder.AppendLine();
            saveStringBuilder.AppendLine($"Дата и время записи конфигурации СКС: {configuration.RecordTime.ToShortDateString()} " +
                    $"{configuration.RecordTime.ToLongTimeString()}");
            saveStringBuilder.AppendLine($"Наименьшая длина постоянного линка: {configuration.MinPermanentLink} м.");
            saveStringBuilder.AppendLine($"Наибольшая длина постоянного линка: {configuration.MaxPermanentLink} м.");
            saveStringBuilder.AppendLine($"Средняя длина постоянного линка: {configuration.AveragePermanentLink} м.");
            saveStringBuilder.AppendLine($"Количество рабочих мест: {configuration.NumberOfWorkplaces}");
            saveStringBuilder.AppendLine($"Количество портов на 1 рабочее место: {configuration.NumberOfPorts}");
            if (configuration.CableHankMeterage != null)
            {
                saveStringBuilder.AppendLine($"Количество портов на 1 рабочее место: {configuration.NumberOfPorts}");
                saveStringBuilder.AppendLine($"Метраж кабеля в 1-й бухте: {configuration.CableHankMeterage}");
                saveStringBuilder.AppendLine($"Необходимое количество бухт кабеля: {configuration.HankQuantity}");
            }
            saveStringBuilder.AppendLine($"Итоговое необходимое количество кабеля: {configuration.TotalСableQuantity} м.");
            if (!String.IsNullOrEmpty(configuration.Recommendations))
            {
                saveStringBuilder.AppendLine();
                saveStringBuilder.AppendLine("Рекомендации по подбору кабеля:");
                saveStringBuilder.AppendLine(configuration.Recommendations);
            }
            return saveStringBuilder.ToString();
        }

        /// <summary>
        /// Сохранение конфигурации СКС в текстовый документ
        /// </summary>
        /// <param name="configuration"></param>
        public static void SaveToTXT(this Configuration configuration)
        {
            SaveFileDialog sfd = new()
            {
                Filter = "Текстовые документы(*.txt)|*.txt",
                FileName = $"Конфигурация СКС {configuration.RecordTime.ToShortDateString()} " +
                $"{configuration.RecordTime.Hour:00}.{configuration.RecordTime.Minute:00}." +
                $"{configuration.RecordTime.Second:00}.txt"
            };
            if (Equals(sfd.ShowDialog(), true))
            {
                using FileStream fs = new(sfd.FileName, FileMode.Create);
                using StreamWriter sw = new(fs);
                sw.WriteLine(configuration.ToSaveString());
            }
        }
    }
}
