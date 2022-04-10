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
using Demo21.Model;
using Demo21.Utils;

namespace Demo21
{
    /// <summary>
    /// Логика взаимодействия для PageAddAgent.xaml
    /// </summary>
    public partial class PageAddAgent : Page
    {
        private Agents _currentAgent = new Agents();
        public PageAddAgent()
        {
            InitializeComponent();
            DataContext = _currentAgent;
            cbType.ItemsSource = Demo2021Entities.GetContext().AgentTypes.ToList();
            cbType.SelectedIndex = 0;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentAgent.Id == 0)
                Demo2021Entities.GetContext().Agents.Add(_currentAgent);
            
            try
            {
                Demo2021Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
