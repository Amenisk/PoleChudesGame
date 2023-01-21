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
        List<Label>? answer = new List<Label>();
        private string fillWord = "";
        private int _countLetters;
        private int _gamePoint;

        public MainPage()
        {
            InitializeComponent();
            _health = 5;
            GenerateQuestion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateQuestionPage());
        }

        private void SelectLetter(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;

            if (_question != null && fillWord.Length < _question.AnswerText.Length)
            {
                button.IsEnabled = false;
                for(int i = 0; i < _question.AnswerText.Length; i++)
                {
                    if (fillWord.Length == i)
                    {
                        fillWord += button.Content;
                        answer![i].Content = button.Content;
                        answer![i].Background = Brushes.White;
                        return;
                    }
                }
                
            }
        }

        private int[] GetRandomIntArray(int length)
        {
            var array = new int[length];
            int number;

            for (int i = 0; i < length; i++)
            {
                number = rnd.Next(1, 41);
                if(!array.Contains(number))
                {
                    array[i] = number;
                }
                else
                {
                    i--;
                }
            }

            return array;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(fillWord.Length == _question.AnswerText.Length)
            {
                if (fillWord == _question.AnswerText.ToUpper())
                {
                    MessageBox.Show("Ответ верный!");
                    _gamePoint++;
                    tbPointCount.Text = "Кол-во очков: " + _gamePoint;
                }
                else
                {
                    MessageBox.Show("Ответ неверный!");
                    _health--;
                }

                if(_health == 0)
                {
                    MessageBox.Show("Вы проиграли! Игра начнётся заново.");
                    _health = 5;
                    _gamePoint = 0;
                }

                GenerateQuestion();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerateQuestion()
        {
            ClearField();
            _question = QuestionService.UpLoadRandomQuestion();
            tbHealthCount.Text = "Кол-во жизней: " + _health;
            var array = GetRandomIntArray(_question.AnswerText.Length);

            if (_question != null)
            {
                tbQuestion.Text = _question.QuestionText;

                for (int i = 1; i <= 40; i++)
                {
                    Button button = new Button();
                    button.Name = "btnQuestion" + i;
                    button.Height = 30;
                    button.Width = 30;
                    button.Margin = new Thickness(5);
                    if (!array.Contains(i))
                    {
                        button.Content = Convert.ToChar(rnd.Next('А', 'Я' + 1));
                    }
                    else
                    {
                        button.Content = Char.ToUpper(_question.AnswerText[_countLetters]);
                        _countLetters++;

                    }
                    button.Click += SelectLetter;

                    if (i < 11)
                    {
                        spFirstRow.Children.Add(button);
                    }
                    else if (i < 21)
                    {
                        spSecondRow.Children.Add(button);
                    }
                    else if (i < 31)
                    {
                        spThirdRow.Children.Add(button);
                    }
                    else
                    {
                        spFourthRow.Children.Add(button);
                    }
                }

                for (int i = 0; i < _question.AnswerText.Length; i++)
                {
                    var label = new Label();
                    label.BorderThickness = new Thickness(3);
                    label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    label.VerticalContentAlignment = VerticalAlignment.Center;
                    label.BorderBrush = Brushes.Black;
                    label.Margin = new Thickness(1);
                    label.Background = Brushes.Blue;
                    label.Height = 50;
                    label.Width = 50;
                    answer.Add(label);

                    spAnswer.Children.Add(label);
                }
            }
        }

        private void ClearField()
        {
            _countLetters = 0;
            fillWord = "";
            answer = new List<Label>();
            spAnswer.Children.Clear();
            spFirstRow.Children.Clear();
            spSecondRow.Children.Clear();
            spThirdRow.Children.Clear();
            spFourthRow.Children.Clear();
        }
    }
}
