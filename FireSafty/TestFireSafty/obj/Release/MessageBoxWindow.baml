   M S B A M L   `   `   `  ����   TestFireSafty$    TestFireSafty.MessageBoxWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  MessageBoxWindow��$	��220��$	��500�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������� � 
ResizeMode$ NoResize=� � Topmost .  � ShowInTaskbar .     MaterialDesignBody#���   $��Regular"�$��10(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont#���  .���  � ColumnDefinitions �� $
��197* ��� $
��295* �	 � RowDefinitions	 �� $
��auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  -   
  Name$
 
cardHeader��$��0��$��10q�$��0q�+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�  PrimaryHueDarkBrush#���   ! PrimaryHueDarkForegroundBrush#���  $y�Visible=�$��2��.���� .+��� -    ��Name$ txtTitle��$��Center=�$��Stretch=�   MaterialDesignTitleTextBlock#���  $��20(�Message Title�� $��Right=�$��0,5,5,0q�$	��Top=�$��1��.+��� -    ��Name$ btnClose��$��35��$��35��
�������#���   * &MaterialDesignFloatingActionDarkButton#��[ .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�� $��1��$��2��.+�� $��20q�	 �� $
��auto ��� $
��auto ��� $��* �.+�� $��0��	 �� $
��auto ��� $��* �.+�?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect     Kind$ FadeIn=�  $ SlideInFromBottom=�.���� -    ��Name$ 
txtMessage��$��Center=� �� 
IsReadOnly . $��0��$��5q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$  ��$��15(�$��70��#���   �� TextWrapping$
 Wrap=� % !MaterialDesignFloatingHintTextBox#��[ � $��1��$��0,20,0,5q� �� $��* ��� $
��auto ��� $
��auto ��� $��* �.+��� -   $ btnOk��$��1��  MaterialDesignRaisedButton#��[ $��5q�$	��100��$
��Ок�� � ToolTip$ Ok���� -   $ 	btnCancel��$��2��#��[ $��5q�$	��100��$��Отмена��$ Отменить���� -   $ btnYes��$��1��#��[ $��5q�$	��100��$
��Да��$ Принять���� -   $ btnNo��$��2��#��[ $��5q�$	��100��$��Нет��$ Отклонить��