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
using PoleChudesGame.Classes;

namespace PoleChudesGame.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateQuestionPage.xaml
    /// </summary>
    public partial class CreateQuestionPage : Page
    {
        public CreateQuestionPage()
        {
            InitializeComponent();
        }

        private void btnCreateQuestion_Click(object sender, RoutedEventArgs e)
        {
            if(tbQuestion.Text != "" && tbAnswer.Text != "")
            {
                QuestionService.LoadQuestion(new Question(tbQuestion.Text, tbAnswer.Text));
                tbQuestion.Clear();
                tbAnswer.Clear();
            }
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
