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
using Demo21.Utils;
using Demo21.Model;

namespace Demo21
{
    /// <summary>
    /// Логика взаимодействия для PageAgents.xaml
    /// </summary>
    public partial class PageAgents : Page
    {
        public PageAgents()
        {
            InitializeComponent();
            var allTypes = Demo2021Entities.GetContext().AgentTypes.ToList();
            allTypes.Insert(0, new AgentTypes {TypeName = "Все типы" });
            cbFilter.ItemsSource = allTypes;
            cbFilter.SelectedIndex = 0;
            cbSort.Items.Add("Название по возрастанию");
            cbSort.Items.Add("Размер скидки по возрастанию");
            cbSort.Items.Add("Приоритет по возрастанию");
            cbSort.Items.Add("Название по убыванию");
            cbSort.Items.Add("Размер скидки по убыванию");
            cbSort.Items.Add("Приотритет по убыванию");
            cbSort.SelectedIndex = 0;
            tbPoisk.Text = "";
            UpdateAgents();
        }

        
        private void tbPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             UpdateAgents();
        }
        private void UpdateAgents()
        {
            var currentAgents = Demo2021Entities.GetContext().Agents.ToList();
                
            if (cbFilter.SelectedIndex > 0)
            {
                AgentTypes agentTypes = cbFilter.SelectedItem as AgentTypes;
                string filter = agentTypes.TypeName.ToString();
                currentAgents = currentAgents.Where(p => p.AType.Contains(filter)).ToList();
            } 
            else currentAgents = Demo2021Entities.GetContext().Agents.ToList();
            switch (cbSort.SelectedIndex)
            {
                case 0:
                    currentAgents = currentAgents.OrderBy(p => p.NameCompany).ToList();
                    break;
                case 1:
                     currentAgents = currentAgents.OrderBy(p => p.Skidka).ToList();
                    break;
                case 2:
                    currentAgents = currentAgents.OrderBy(p => p.Priority).ToList();
                    break;
                case 3:
                     currentAgents = currentAgents.OrderByDescending(p => p.NameCompany).ToList();
                    break;
                case 4:
                    currentAgents = currentAgents.OrderByDescending(p => p.Skidka).ToList();
                    break;
                case 5:
                    currentAgents = currentAgents.OrderByDescending(p => p.Priority).ToList();
                    break;
            }
            if (tbPoisk.Text !="")
            currentAgents = currentAgents.Where(p => p.NameCompany.ToLower().Contains(tbPoisk.Text.ToLower()) ||
            p.Phone.ToLower().Contains(tbPoisk.Text.ToLower()) || p.Email.ToLower().Contains(tbPoisk.Text.ToLower())).ToList();
            
            lvAgents.ItemsSource = currentAgents;
        }

        private void btAddAgent_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAddAgent());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //if (Visibility==Visibility.Visible)
            //{
            //    Demo2021Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            //    lvAgents.ItemsSource = Demo2021Entities.GetContext().Agents.ToList();
            //}
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAgents();
        }
    }
}
