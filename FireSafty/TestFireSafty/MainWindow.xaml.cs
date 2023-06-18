using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
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
using System.Windows.Threading;
using TestFireSafty.Models;


namespace TestFireSafty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
            //SplashScreen splash = new SplashScreen(@"C: \Users\Admin\source\repos\FireSafty1\TestFireSafty\bin\fire.png");
            //splash.Show(false);
            //splash.Close(TimeSpan.FromSeconds(5));

        }

        int question_count;
        int correct_answer;
        int wrong_answer;
        string str_correct;
     

        string[] arrray;
        string str;
        string [] strSplit;
        int box_count, r_count=0;

     
       
        string[] questions= new string[36];
        
        StreamReader Read;
        StackPanel s= new StackPanel();
        MyRandom r;

        DispatcherTimer timer, timerPB;
        TimeSpan _time;

       


        private void Next_Click(object sender, RoutedEventArgs e)
        {
           

           
            if (strSplit[0] == "radio")
            {
                if (GetFocusRadio(s) == str_correct)
                    correct_answer += 1;
                else
                {
                    wrong_answer += 1;
                    arrray[wrong_answer] = lb1.Text+"("+(question_count)+")";
                }
            }
            if (strSplit[0] == "box")
            {
                if (GetFocusBox(s) == box_count)
                    correct_answer += 1;
                else
                {
                    wrong_answer += 1;
                    arrray[wrong_answer] = lb1.Text + "(" + (question_count ) + ")";
                }
            }
            if (strSplit[0] == "string")
            {
                if (GetStringTB(s) == str_correct)
                    correct_answer += 1;
                else
                {
                    wrong_answer += 1;
                    arrray[wrong_answer] = lb1.Text + "(" + (question_count ) + ")";
                }
            }



            if (Next_bt.Content=="Начать заново")
            {
                //rb1.Visibility = rb2.Visibility = rb3.Visibility = rb4.Visibility = Visibility.Visible;
               
                //lb1.Visibility = Visibility.Collapsed;
                question_count = 0;
                correct_answer = 0;
                wrong_answer = 0;
                switch(r_count)
                {
                    case 1:
                        generateQuestion(0, 12);
                        break;
                    case 2:
                        generateQuestion(12, 24);
                        break;
                    case 3:
                        generateQuestion(24, 36);
                        break;
                }
                lb1.Visibility = Visibility.Visible;
                pb.Value = 0;
                tim.Visibility = Visibility.Visible;
                testbro.Visibility = Visibility.Collapsed;
                timer.Stop();

                timerPB.Stop();
                start();
                // start();
                return;
            }

            if (Next_bt.Content=="Завершить")
            {
                timer.Stop();
                timerPB.Stop();
                grid1.Children.Remove(s);
                pb.Visibility = Visibility.Collapsed;
                tim.Visibility = Visibility.Hidden;
                //rb1.Visibility = rb2.Visibility = rb3.Visibility = rb4.Visibility = Visibility.Hidden;

                lb1.Text= string.Format("Тестирование завершено.\n" +
                    "Правильных ответов {0} из {1}\n" +
                    "Набранные баллы {2:F2}({3}%)", correct_answer, question_count, (correct_answer * 5.0F) / question_count, (int)((double)correct_answer/ (double)question_count*100));


                Next_bt.Content = "Начать заново";
                var Str = "Список ошибок" +
                    ":\n\n";
                for (int i = 1; i <=wrong_answer; i++)
                    Str += (i)+")"+arrray[i] + "\n";

                if (wrong_answer != 0)
                {
                    
                    MessageBox.Show(Str, "Тестирование завершено");
                }
               
                question_count = 0;
                correct_answer = 0;
                wrong_answer = 0;
               
               

            }  
            if(Next_bt.Content=="След. Вопрос")
            {
                readQuestion();
                pb.Value = 0;
                //timer.Stop();
               
               // timerPB.Stop();
               
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            s.Children.Clear();
            timer.Stop();
            testbro.Visibility = Visibility.Visible;
            timerPB.Stop();
            pb.Value = 0;
            pb.Visibility = Visibility.Collapsed;
            question_count = 0;
            correct_answer = 0;
            wrong_answer = 0;
            Next_bt.Visibility = Visibility.Collapsed;
            Cancel_bt.Visibility = Visibility.Collapsed;
            first.Visibility = Visibility.Visible;
            second.Visibility = Visibility.Visible;
            third.Visibility = Visibility.Visible;
            lb1.Visibility = Visibility.Collapsed;
            tim.Visibility = Visibility.Collapsed;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var encoding = Encoding.GetEncoding(65001);
            Read = new StreamReader(Directory.GetCurrentDirectory() + @"\test.txt", encoding);
            bro.Navigate("file:///" + Directory.GetCurrentDirectory() + "/Tema.html");
            bro.Visibility = Visibility.Visible;
            int i = 0;
            while (!Read.EndOfStream)
            {
                questions[i] = Read.ReadLine();
                i++;
            }
            Read.Close();
            Next_bt.Visibility = Visibility.Collapsed;
            Cancel_bt.Visibility = Visibility.Collapsed;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timerPB = new DispatcherTimer();
            timerPB.Tick += TimerPB_Tick;

            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tim.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);


        }

        private void TimerPB_Tick(object sender, EventArgs e)
        {
            
            if (pb.Value >= 100)
            {
                pb.Value = 0;
                if (Cancel_bt.Content == "Завершить")
                    return;
                else
                {
                    if (Next_bt.Content == "Завершить")
                    {
                        timer.Stop();
                        timerPB.Stop();
                        grid1.Children.Remove(s);
                        pb.Visibility = Visibility.Collapsed;
                        tim.Visibility = Visibility.Hidden;
                        //rb1.Visibility = rb2.Visibility = rb3.Visibility = rb4.Visibility = Visibility.Hidden;

                        lb1.Text = string.Format("Тестирование завершено.\n" +
                            "Правильных ответов {0} из {1}\n" +
                            "Набранные баллы {2:F2}({3}%)", correct_answer, question_count, (correct_answer * 5.0F) / question_count, (int)((double)correct_answer / (double)question_count * 100));


                        Next_bt.Content = "Начать заново";
                        var Str = "Список ошибок" +
                            ":\n\n";
                        for (int i = 1; i <= wrong_answer; i++)
                            Str += (i) + ")" + arrray[i] + "\n";

                        if (wrong_answer != 0)
                        {

                            MessageBox.Show(Str, "Тестирование завершено");
                        }

                        question_count = 0;
                        correct_answer = 0;
                        wrong_answer = 0;



                    }
                    else
                        readQuestion();
                }   

            }
            else
                pb.Value++;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void start()
        {
            //  r = new MyRandom(0, 8);
            pb.Visibility = Visibility.Visible;
            Next_bt.Visibility = Visibility.Visible;
            Cancel_bt.Visibility = Visibility.Visible;
            Next_bt.Content = "След. Вопрос";
            lb1.Visibility = Visibility.Visible;
            
            try 
            {
              
             
               // this.Title = Read.ReadLine();
                 question_count=0;
                 correct_answer=0;
                 wrong_answer=0;

                arrray = new string[25];

            }
            catch (Exception)
            {
                MessageBox.Show("Error1");
            }
            readQuestion();
        }


        void readQuestion()
        {
            try
            {
               
                s.Children.RemoveRange(0, s.Children.Count);
                grid1.Children.Remove(s);
                str = questions[r.Next()];
                strSplit = str.Split('|');
                lb1.Text = strSplit[1];
                

                if (strSplit[0] == "radio")
                {
                    _time = TimeSpan.FromSeconds(30);
                    timer.Start();
                    Grid.SetRow(TypeQuestion.Radio(s, str), 1);
                    grid1.Children.Add(s); 
                    timerPB.Interval = TimeSpan.FromMilliseconds(251);
                    timerPB.Start();
                    str_correct = strSplit[strSplit.Length - 1];
                };
                if (strSplit[0] == "box")
                {
                    _time = TimeSpan.FromSeconds(60);
                    timer.Start();
                    timerPB.Interval = TimeSpan.FromMilliseconds(520);
                    timerPB.Start();
                    Grid.SetRow(TypeQuestion.Check(s, str), 1);
                    grid1.Children.Add(s);
                    box_count = strSplit[strSplit.Length - 1].Split(';').Length;
                    str_correct = strSplit[strSplit.Length - 1];
                };
                if (strSplit[0] == "string")
                {
                    _time = TimeSpan.FromSeconds(60);
                    timer.Start();
                    timerPB.Interval = TimeSpan.FromMilliseconds(520);
                    timerPB.Start();
                    Grid.SetRow(TypeQuestion.STR(s, str), 1);
                    grid1.Children.Add(s);
                    str_correct = strSplit[strSplit.Length - 1].ToLower();
                };

                question_count += 1;
          

                if (question_count>9)
                {
                    Next_bt.Content = "Завершить";
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Обнаружена пустая cтрока в файле!");
            }
        }

       string GetFocusRadio(StackPanel stack)
        {
          string val="";
            
            for (int i = 0; i < 4; i++)
            {
                RadioButton rb = (RadioButton)stack.Children[i];
                   if(rb.IsChecked==true)
                   {
                    val = rb.Content.ToString();
                   
                    break;
                   }
      
            }
            return val;
        }

        int GetFocusBox(StackPanel stack)
        {
            string[] val = new string[stack.Children.Count];

            int k = 0;
            for (int i = 0; i < stack.Children.Count; i++)
            {
               
            
                CheckBox ch = (CheckBox)stack.Children[i];
                if (ch.IsChecked == true)
                {
                    val[i]=ch.Content.ToString();
                 
                   
                }
              
            }

            for(int i=0;i< val.Length; i++)
            {
                
                if (val[i] == null)
                    continue;
                for(int j=0; j<str_correct.Split(';').Length;j++)
                {
                    
                   
                    if (val[i]== str_correct.Split(';')[j])
                    {
                        k++;
                      
                    }
                }
            }
         
           
            return k;
        }

        string GetStringTB(StackPanel stak)
        {
            TextBox tb = (TextBox)stak.Children[1];
            return tb.Text.ToLower();
        }

        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            bro.Navigate("file:///" + Directory.GetCurrentDirectory() + "/Tema.html#" + tvItem.Tag);
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            bro.Navigate("file:///" +Directory.GetCurrentDirectory() + "/Tema.html#" + tvItem.Tag);
            
        }

        private void first_Click(object sender, RoutedEventArgs e)
        {
            generateQuestion(0,12);
          
            r_count = 1;
            first.Visibility = Visibility.Collapsed;
            second.Visibility = Visibility.Collapsed;
            third.Visibility = Visibility.Collapsed;
            lb1.Visibility = Visibility.Visible;
            pb.Value = 0;
            tim.Visibility = Visibility.Visible;
            testbro.Visibility = Visibility.Collapsed;
            timer.Stop();

            timerPB.Stop();
            start();
        }

        private void second_Click(object sender, RoutedEventArgs e)
        {
            generateQuestion(12, 24);
            
           
            r_count = 2;
            first.Visibility = Visibility.Collapsed;
            second.Visibility = Visibility.Collapsed;
            third.Visibility = Visibility.Collapsed;
            lb1.Visibility = Visibility.Visible;
            pb.Value = 0;
            tim.Visibility = Visibility.Visible;
            testbro.Visibility = Visibility.Collapsed;
            timer.Stop();

            timerPB.Stop();
            start();
        }

        private void third_Click(object sender, RoutedEventArgs e)
        {
            generateQuestion(24, 36);
            
            
            r_count = 3;
            first.Visibility = Visibility.Collapsed;
            second.Visibility = Visibility.Collapsed;
            third.Visibility = Visibility.Collapsed;
            lb1.Visibility = Visibility.Visible;
            tim.Visibility = Visibility.Visible;
            testbro.Visibility = Visibility.Collapsed;
            pb.Value = 0;
            timer.Stop();

            timerPB.Stop();
            start();
        }

       

        private void Questions_Click(object sender, RoutedEventArgs e)
        {
            TreeGrid1.Visibility = Visibility.Collapsed;
            Welcome.Visibility = Visibility.Collapsed;
            grid1.Visibility = Visibility.Visible;
            testbro.Navigate("file:///" + Directory.GetCurrentDirectory() + "/Test.html" );
            testbro.Visibility = Visibility.Visible;
            timer.Stop();
            lb1.Visibility = Visibility.Collapsed;
            Next_bt.Visibility = Visibility.Collapsed;
            Cancel_bt.Visibility = Visibility.Collapsed;
            first.Visibility = Visibility.Visible;
            second.Visibility = Visibility.Visible;
            third.Visibility = Visibility.Visible;
            pb.Value = 0;

            pb.Visibility = Visibility.Collapsed;
            tim.Visibility = Visibility.Collapsed;
            timerPB.Stop();

            s.Children.Clear();

        }

        private void teory_Click(object sender, RoutedEventArgs e)
        {
            Welcome.Visibility = Visibility.Collapsed;
            TreeGrid1.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Collapsed;
            testbro.Visibility = Visibility.Collapsed;
            timer.Stop();
            lb1.Visibility = Visibility.Collapsed;
            Next_bt.Visibility = Visibility.Collapsed;
            Cancel_bt.Visibility = Visibility.Collapsed;
            first.Visibility = Visibility.Visible;
            second.Visibility = Visibility.Visible;
            third.Visibility = Visibility.Visible;
            pb.Value = 0;
          
            pb.Visibility = Visibility.Collapsed;
            tim.Visibility = Visibility.Collapsed;
            timerPB.Stop();

            s.Children.Clear();
        }

        private void TreeView_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            bro.Visibility = Visibility.Visible;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AP_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxWindow window = new MessageBoxWindow("Обучающая программа \"Противопожарная профилактика в учебных учреждениях\", версия: 1.0.0","О программе",MessageType.Info,MessageButtons.Ok);
            window.ShowDialog();
        }

        private void UG_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxWindow window = new MessageBoxWindow("User guid", "Руководство пользователя",MessageType.Info, MessageButtons.Ok);
            window.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TreeView_GotFocus(object sender, RoutedEventArgs e)
        {
            bro.Visibility = Visibility.Visible;
        }

        private void generateQuestion(int start_random, int end_random)
        {
            r = new MyRandom(start_random, end_random);

            Next_bt.Content = "След. Вопрос";
            Cancel_bt.Content = "Выбрать другой раздел";
            Next_bt.IsEnabled = true;
        }
    }
    


}
