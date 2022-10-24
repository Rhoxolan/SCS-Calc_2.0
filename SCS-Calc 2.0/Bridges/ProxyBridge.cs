using System.Windows;

namespace SCS_Calc_2._0.Bridges
{
    public class ProxyBridge : Freezable
    {
        protected override Freezable CreateInstanceCore() => new ProxyBridge();

        public object Source
        {
            get => GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(nameof(Source), typeof(object), typeof(ProxyBridge), new PropertyMetadata(null, SourceChanged));

        private static void SourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ProxyBridge)d).Target = e.NewValue;
        }

        public object Target
        {
            get => GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register(nameof(Target), typeof(object), typeof(ProxyBridge), new FrameworkPropertyMetadata(null) { BindsTwoWayByDefault = true });
    }
}
