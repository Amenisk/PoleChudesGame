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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Question _question;
        private int _health;
        Random rnd = new Random();
        public MainPage()
        {
            InitializeComponent();
            _question = QuestionService.UpLoadRandomQuestion();
            _health = 5;

            tbQuestion.Text = _question.QuestionText;
            for (int i = 1; i <= 40; i++)
            {
                Button button = new Button();
                button.Name = "btnQuestion" + i;
                button.Height = 30;
                button.Width = 30;
                button.Margin = new Thickness(5);
                button.Content = Convert.ToChar(rnd.Next('А', 'Я' + 1));
                button.Click += SelectLetter;

                if(i < 11)
                {
                    spFirstRow.Children.Add(button);
                }
                else if(i < 21)
                {
                    spSecondRow.Children.Add(button);
                }
                else if(i < 31)
                {
                    spThirdRow.Children.Add(button);
                }
                else
                {
                    spFourthRow.Children.Add(button);
                }
            }

            for(int i = 0; i < 10; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.FontSize = 24;
                textBlock.Name = "tbAnswer" + i;
                textBlock.Height = 30;
                textBlock.Width = 30;
                textBlock.Text = i.ToString();
                textBlock.Margin = new Thickness(5);
                textBlock.Background = new SolidColorBrush(Colors.LightGray);
                textBlock.TextAlignment = TextAlignment.Center;
                    
                spAnswer.Children.Add(textBlock);
            }

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateQuestionPage());
        }

        private void SelectLetter(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
        }
    }
}
