   M S B A M L   `   `   `  ���� H  DTestFireSafty, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TestFireSaftyTestFireSafty  ;"clr-namespace:TestFireSafty.ModelsTestFireSafty.Models      TestFireSafty.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:TestFireSafty     1rd"clr-namespace:TestFireSafty.Models     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  
MainWindow��$	��450��$��884.831��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont#���  ���	#DDFFFFFF$	��450��$	��450��$��884.831��$��884.831�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 	Resources ��%    ����  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$ 0.5,0&�.��� 	 � Color$	 	#FF768F9B��
 � Offset$
 1Q�� $	 	#FF131719��.��� -    �Name$ maingrid�� � RowDefinitions �� $��30 ��� $��50 ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��0��$��Right=�.+��� -    ��Name$ UG��$��6(�$
��Auto�� � ToolTip$5 /Руководство пользователя����0  *MaterialDesignThemes.Wpf.PackIconExtension  *AccountQuestion+�� -   $ AP��$��6(�$
��Auto��$ О программе����  *InformationVariant+�� -   $
 Exit��$
��Auto��$��6(�$' !Закрыть программу����  *Close+�� $��1��$ 
Horizontal=�$��4q�.+�	� -    	�Name$ teory��   MaterialDesignTabRadioButton#��[ $��4q� d� 	IsChecked$ FalseY�$��Теория��$	��Top=�$
��Left=�$	��440�����	#FF673AB7	� -   $ 	Questions��#��[ $��4q�$ FalseY�$��Тест��$	��Top=�$
��Left=�$	��420�����	#FF673AB7� -   $ 	TreeGrid1��$y�	Collapsed=�$��2�� � ColumnDefinitions �� $	��320 ��� $��* �.+�R� -	   $	��220�����	#DDFFFFFF.@�Q� $L��FПонятие противопожарной профилактики��.@�Q� -
   $=��7Противопожарная профилактика��
 � Tag$ 0��Q� -   $1��+Задачи и мероприятия ПП��$ 1��Q� -   $D��>Требования пожарной безлпасности��$ 2��Q� $>��8Обязанности ответственных лиц��.@�Q� -   $��Инструктажи��$ 3��Q� -   $!��Правовые нормы��$ 4��Q� $*��$Действия при пожаре��.@�Q� -   $;��5Действия учащихся при пожаре��$ 5��Q� -   $��Эвакуация��$ 6��Q� -   $?��9Личная безопасность при пожаре��$ 7��(  "System.Windows.Controls.WebBrowser  -     Name$	 bro��$��1��$y�	Collapsed=�$��Hidden=�$��
10,10,10,0q��� -    ��Name$ Welcome�� $  MaterialDesignHeadline4TextBlock#��[ $
��Left=�$��10,81,-20,118q�$��2��$	��170��$
��Bold"� �� TextAlignment$ Center=�$��39(��� $O�IДобро пожаловать в обучающую программу ���� �� $B�<'Противопожарная профилактика в ���� �� $>�8образовательных учереждениях'��� -   $ grid1��$y�	Collapsed=�$��2�� �� $��* ��� $	��150 ��� $��50 �.+��� $��0��$ 
Horizontal=�$��Center=�.+�  -   $ testbro��$	��853��$��Disabled=�$��10,0,10,-122q��� -   $	 lb1��$y�	Collapsed=�$	��600��$
��Wrap=�$��20(��� -    ��Name$ stack1��$��1���� $��2��$ 
Horizontal=�$��Center=�.+��� -   $ first��$=��7Противопожарная профилактика��$
��Auto��$��40��$��	30,0,20,0q��� -   $ second��$>��8Обязанности ответственных лиц��$
��Auto��$��40��$��	20,0,20,0q��� -   $ third��$*��$Действия при пожаре��$
��Auto��$��40��$��	20,0,30,0q��� -   $ Next_bt��$	��200��$��
120,9,70,9q��� -   $ 	Cancel_bt��$	��200���� -   $	 tim��$y�	Collapsed=�$��	50,20,0,0q�� -    �Name$ pb��$	��100��$��20��$y�	Collapsed=�$��60,0,0,0q�$��Right=����	#FF768F9B���	#FF1DF113�� 