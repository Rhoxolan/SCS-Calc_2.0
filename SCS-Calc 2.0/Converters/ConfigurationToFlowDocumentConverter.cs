using HandyControl.Tools.Extension;
using SCSCalc.WindowsDesktop;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;

namespace SCS_Calc_2._0.Converters
{
    public class ConfigurationToFlowDocumentConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Configuration configuration = (Configuration)value;
                FlowDocument flowDocument = new();
                Paragraph paragraph = new();
                paragraph.Inlines.Add(new Run($"Дата и время записи конфигурации СКС: {configuration.RecordTime.ToShortDateString()} " +
                    $"{configuration.RecordTime.ToLongTimeString()}"));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run($"Наименьшая длина постоянного линка: {configuration.MinPermanentLink} м."));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run($"Наибольшая длина постоянного линка: {configuration.MaxPermanentLink} м."));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run($"Средняя длина постоянного линка: {configuration.MaxPermanentLink} м."));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run($"Количество рабочих мест: {configuration.NumberOfWorkplaces}"));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run($"Количество портов на 1 рабочее место: {configuration.NumberOfPorts}"));
                paragraph.Inlines.Add(new LineBreak());
                if (configuration.CableHankMeterage != null)
                {
                    paragraph.Inlines.Add(new Run($"Необходимое количество кабеля: {configuration.СableQuantity}"));
                    paragraph.Inlines.Add(new LineBreak());
                    paragraph.Inlines.Add(new Run($"Метраж кабеля в 1-й бухте: {configuration.CableHankMeterage}"));
                    paragraph.Inlines.Add(new LineBreak());
                    paragraph.Inlines.Add(new Run($"Необходимое количество бухт кабеля: {configuration.HankQuantity}"));
                    paragraph.Inlines.Add(new LineBreak());
                }
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run($"Итоговое необходимое количество кабеля: {configuration.TotalСableQuantity} м.") { FontWeight = FontWeights.Medium });
                if (!String.IsNullOrEmpty(configuration.Recommendations))
                {
                    paragraph.Inlines.Add(new LineBreak());
                    paragraph.Inlines.Add(new LineBreak());
                    paragraph.Inlines.Add(new LineBreak());
                    paragraph.Inlines.Add(new Run("Рекомендации по подбору кабеля:"));
                    paragraph.Inlines.Add(new LineBreak());
                    paragraph.Inlines.Add(new Run(configuration.Recommendations));
                }
                flowDocument.Blocks.Add(paragraph);
                return flowDocument;
            }
            return Binding.DoNothing;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        public static ConfigurationToFlowDocumentConverter Instance { get; } = new();
    }
}
