using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApp14
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database1Entities qwe = new Database1Entities();
        public MainWindow()
        {
            InitializeComponent();
            qwe.House.Load();
            kj.ItemsSource = qwe.House.Local.ToBindingList();
        }

        private void Добавить_Click(object sender, RoutedEventArgs e)
        {
            qwe.House.Add(new House()
            {
                ResidentialComplexID = Convert.ToInt32(ResidentialComplex.Text.Trim()),
                Street = Stree.Text.Trim(),
                Number = Numbe.Text.Trim(),
                BuildingCost = Convert.ToInt32(BuildingCos.Text.Trim()),
                HouseValueAdded = Convert.ToInt32(HouseValueAdde.Text.Trim())
            }
            );



            try
            {
                qwe.SaveChanges();
            }
            catch { MessageBox.Show("Dolboeb"); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var id =Convert.ToInt32(ИД.Text.Trim());
            qwe.House.Remove(qwe.House.Where(u => u.ID == id).FirstOrDefault());
            
            qwe.SaveChanges();
            MainWindow TaskWindow = new MainWindow();
            TaskWindow.Show();
            this.Close();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(ИД.Text.Trim());
            var UPD = qwe.House.Where(u => u.ID == id).FirstOrDefault();
            UPD.ResidentialComplexID = Convert.ToInt32(ResidentialComplex.Text);
            UPD.Street = Stree.Text;
            UPD.Number = Numbe.Text;
            UPD.BuildingCost = Convert.ToInt32(BuildingCos.Text);
            UPD.HouseValueAdded = Convert.ToInt32(HouseValueAdde.Text);
            qwe.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            House path = kj.SelectedItem as House;
            MessageBox.Show("ID =" + path.ID + "\n Street=" + path.Street);
        }
    } 
    
}
        
    

