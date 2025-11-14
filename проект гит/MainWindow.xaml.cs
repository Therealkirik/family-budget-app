using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FinanceApp
{
    public partial class MainWindow : Window
    {
        private decimal суммаДоходов = 0;
        private decimal суммаРасходов = 0;

        public MainWindow()
        {
            InitializeComponent();
            ОбновитьСчёт();
        }

        private void btnДобавитьДоход_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(tbСумма.Text, out decimal сумма) && сумма > 0)
            {
                суммаДоходов += сумма;
                string описание = string.IsNullOrWhiteSpace(tbОписание.Text) ? "Без описания" : tbОписание.Text;

                TextBlock item = new TextBlock
                {
                    Text = $"Доход: +{сумма} ({описание})",
                    Foreground = Brushes.Green,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 2, 0, 2)
                };
                spИстория.Children.Add(item);

                ОбновитьСчёт();
            }
            tbСумма.Clear();
            tbОписание.Clear();
        }

        private void btnДобавитьРасход_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(tbСумма.Text, out decimal сумма) && сумма > 0)
            {
                суммаРасходов += сумма;
                string описание = string.IsNullOrWhiteSpace(tbОписание.Text) ? "Без описания" : tbОписание.Text;

                TextBlock item = new TextBlock
                {
                    Text = $"Расход: -{сумма} ({описание})",
                    Foreground = Brushes.Red,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 2, 0, 2)
                };
                spИстория.Children.Add(item);

                ОбновитьСчёт();
            }
            tbСумма.Clear();
            tbОписание.Clear();
        }

        private void ОбновитьСчёт()
        {
            lblДоходы.Text = $"Доходы: {суммаДоходов}";
            lblРасходы.Text = $"Расходы: {суммаРасходов}";
            lblОстаток.Text = $"Остаток: {суммаДоходов - суммаРасходов}";
        }
    }
}
