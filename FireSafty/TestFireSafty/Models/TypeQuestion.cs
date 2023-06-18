using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestFireSafty.Models
{
    class TypeQuestion
    {
       static Encoding encoding = Encoding.GetEncoding(65001);
      
        public static StackPanel Radio(StackPanel stack ,string str)
        {
           
            RadioButton[] arrRB = new RadioButton[4];
            //for (int i = 0; i < stack.Children.Count; i++)
            //{
            //    stack.Children.Remove(stack.Children[i]);
            //}

            
            for (int i=0; i < 4; i++)
            {

                RadioButton rb = new RadioButton
                {
                    Content = str.Split('|')[i + 2],
                    Foreground = Brushes.White,
                    FontSize=15
                };
               // MessageBox.Show(i.ToString());
                arrRB[i] = rb;
               
            }
            MyRandom r = new MyRandom(0, 4);
            for (int i = 0; i < r.Count; i++)
            {
                RadioButton loc_ch = arrRB[r.Next()];
                stack.Children.Add(loc_ch);
               
            }



            return stack;
        }

        public static StackPanel Check(StackPanel stack, string str)
        {
           
            CheckBox[] arrRB = new CheckBox[4];
            //for (int i = 0; i < stack.Children.Count; i++)
            //{
            //    stack.Children.Remove(stack.Children[i]);
            //  //  MessageBox.Show(i.ToString());
            //}

          
            for (int i = 0; i < 4; i++)
            {
                TextBlock tb = new TextBlock();
                CheckBox rb = new CheckBox
                {
                    Content = str.Split('|')[i + 2],
                    Foreground = Brushes.White,
                    FontSize = 15,
                   
                    

                };
               
                arrRB[i] = rb;
            }
            MyRandom r = new MyRandom(0, 4);
            for (int i = 0; i < r.Count; i++)
            {
                CheckBox loc_ch = arrRB[r.Next()];
                stack.Children.Add(loc_ch);
                
            }
        
            return stack;
        }

        public static StackPanel STR(StackPanel stack, string str)
        {
           
            //for (int i = 0; i < stack.Children.Count; i++)
            //    stack.Children.Remove(stack.Children[i]);
           
            TextBox tb = new TextBox
            {
                FontSize = 20,
                TextAlignment=System.Windows.TextAlignment.Center,
                Foreground = Brushes.White
            };
            Label lb = new Label
            {
                FontSize = 20,
                Content = "Введите ответ без начальных и конечных пробелов",
                HorizontalAlignment=HorizontalAlignment.Center,
                Foreground = Brushes.White

            };
            stack.Children.Add(lb);
                
                stack.Children.Add(tb);
            
           
          
            
            return stack;
        }

      
    }

    public class MyRandom
    {
        private int[] _shuffled;
        private int _index;
        private readonly int _start;

        public int Count { get; private set; }

        public MyRandom(int start, int end)
        {
            Count = end - start;
            Random r = new Random();
            _shuffled = Enumerable.Range(start, Count).OrderBy(x => r.Next()).ToArray();
            _start = start;
        }
        public int Next()
        {
            if (_index == _shuffled.Length)
            {
                _index = 0;
            }
            return _shuffled[_index++];
        }

        public void Shuffle()
        {
            Random r = new Random();
            _shuffled = Enumerable.Range(_start, Count).OrderBy(x => r.Next()).ToArray();
        }
    }
}
