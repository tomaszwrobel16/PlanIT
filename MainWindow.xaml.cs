using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _selectedMonth = DateTime.Now.Month;
        private int _selectedYear = DateTime.Now.Year;


        public MainWindow()
        {
            InitializeComponent();
            GenerateMonthGrid(4,2019);
            SelectedMothName.Content = "April";
        }

        private void GenerateMonthGrid(int monthNmb, int yearNmb)
        {
            IEnumerable<TextBlock> collection = MonthGrid.Children.OfType<TextBlock>();
            collection = collection.Skip(7);
            int dayNumber = 1;

            DateTime date = new DateTime(yearNmb, monthNmb, 1);
            DateTime today = DateTime.Today;

            var dayOfweek = (int)date.DayOfWeek;

            collection = collection.Skip((dayOfweek+6)%7);

            foreach (var day in collection)
            {
                day.Text = dayNumber.ToString();
                if(today.Year == yearNmb &&
                    today.Month == monthNmb &&
                    today.Day == dayNumber)
                {
                    day.Background = new SolidColorBrush(Color.FromRgb(161,209,237));
                }

                dayNumber++;

                if (dayNumber > DateTime.DaysInMonth(yearNmb, monthNmb))
                {
                    break;
                    //dayNumber = 1;
                }
            }
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            _selectedMonth--;
            if(_selectedMonth < 1)
            {
                _selectedMonth = 12;
                _selectedYear--;
            }
            GenerateMonthGrid(_selectedMonth, _selectedYear);
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
