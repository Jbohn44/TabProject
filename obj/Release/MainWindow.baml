   M S B A M L   `   `   `  ���� @  <TabIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TabItTabIt  )clr-namespace:TabIt.ViewsTabIt.Views      TabIt.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:TabIt     +Viewsclr-namespace:TabIt.Views       � Title$  TAB MAKER 3000��$	��800��$	��960�� � WindowState$ 	Maximized=����	#FFC7C235$��1q����	#FF7292FD����  �� Color$ 	#FF3D3F48��.���  � ColumnDefinitions �� $��10 ��� �� �� �� �� �� �� $��10 � � RowDefinitions �� $��10 ��� �� �� �� �� �� �� �� $��* ��� $��10 �.+�� -    �Name$ ProjectMenu��$��1��$��1��$��8��
���iii� �� �� �� ��  �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� .+��� -    ��Name$ 
exitButton��$��3��$��Right=�$	��Top=�$��	0,0,0.2,0q�$��X��
��� ���$y�Hidden=�$��19���� -   $ NewBassProject��$��1��$��4��$��2��$��Stretch=�$��Stretch=�
������ ���	#FF3D3F48
�������.���� $��New Bass Project��$
��Wrap=� �� TextAlignment$ Center=�$��16(��� -   $ NewGuitarProject��$��3��$��4��$��2��$��Stretch=�$��Stretch=�
������ ���	#FF3D3F48
�������.���� $��New Guitar Project��$
��Wrap=�$ Center=�$��16(��� -   $ OpenSavedProjec��$��5��$��4��$��2��$��Stretch=�$��Stretch=�
������ ���	#FF3D3F48
�������.���� $��Open Project��$
��Wrap=�$ Center=�$��16(� � -     �Name$ ProjectFrame��$��Stretch=�$��8��$��5��$��Stretch=�$��2��$��1��