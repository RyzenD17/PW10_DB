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

namespace PW10_DB
{
    /// <summary>
    /// Логика взаимодействия для AdminShowOrders.xaml
    /// </summary>
    public partial class AdminShowOrders : Page
    {
        public AdminShowOrders()
        {
            InitializeComponent();
            LVOrders.ItemsSource = BaseClass.Base.OrdersTable.ToList();
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<WorkersTable> WT = BaseClass.Base.WorkersTable.Where(x => x.IDOrder == index).ToList();
            string str = "";
            foreach(WorkersTable s in WT)
            {
                str += s.ServicesTable.Service + " ,";
            }

            tb.Text = "Предоставляемые услуги: "+ str.Substring(0, str.Length - 2);
        }

        private void TextBlock_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<TimeTable> TT = BaseClass.Base.TimeTable.Where(x => x.IDOrder == index).ToList();
            string str = "";
            foreach (TimeTable s in TT)
            {
                str += s.WorkTimeTable.WorkTime + " ,";
            }

            tb.Text = "Время работы: " + str.Substring(0, str.Length - 2);
        }

        private void TextBlock_Loaded_2(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<WorkersTable> WT = BaseClass.Base.WorkersTable.Where(x => x.IDOrder == index).ToList();
            List<OrdersTable> OT = BaseClass.Base.OrdersTable.Where(x => x.IDOrder == index).ToList();
            int sum = 0;
            
            foreach (WorkersTable s in WT)
            {
                foreach(OrdersTable o in OT)
                {
                    sum += s.ServicesTable.ServiceCost * o.WorkTime;
                }
               
            }
            tb.Text = sum + " рублей";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new AdminPage());
        }
    }
   
}






