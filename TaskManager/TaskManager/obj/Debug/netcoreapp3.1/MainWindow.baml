   M S B A M L   `   `   `  ����  TaskManager    TaskManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Task manager��5   	   $	��700��6   $
��1200��6+    � WindowStartupLocation$ CenterScreen=�68   .��5      � {�6   �� *IsControlEnabled+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��4.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   o� $��0��6   $��0��6   $��3��6,   .@�5      m� $	��IDs��6    m� Command 6$   �� *
SortById+6C   m� 5      $��Process names��6    6.   �� *
SortByName+6O   m� 5      $��IsActive��6    6)   �� *SortByIsActive+6N   m� 5      $��% of CPU��6    6)   �� *SortByCPUPercents+6Q   m� 5      $��memory amount��6    6.   �� *SortByRAMAmount+6T   m� 5      $��Threads��6    6(   �� *SortByThreadsNumber+6R   m� 5      $
��User��6    6%   �� *
SortByUser+6F   m� 5      $��Path to file��6    6-   �� *SortByFilepath+6R   m� 5      $��Starting time��6    6.   �� *SortByStartingTime+6W   5      &   System.Windows.Controls.DataGrid  5   
   $��1��6   $��0��6    $��3��60      AutoGenerateColumns$ False��5!      $
��True��5#         
IsReadOnly$
 True��5$      	   CanUserSortColumns$	 False��6%   
 �� SelectedIndex$
 0��6@   ��5       �� *	Processes+$ OneWay=�$ PropertyChanged=� �� SelectedValue 5"      �� *SelectedProcess+$ TwoWay=�$ PropertyChanged=�   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$	 IDs��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 45 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *ID+$ OneWay=�6n     5'      $ Process name��6%   $	 180 6A    6O   �� *Name+$ OneWay=�6w     5(      $ IsActive��6%   $ 50 6;    6I   �� *
IsActive+$ OneWay=�6u     5)      $ % of CPU��6%   $ 70 6<    6J   �� *CPUPercents+$ OneWay=�6y     5*      $ memory��6%   $
 Auto 69    6G   �� *	RAMAmount+$ OneWay=�6t     5+      $ Threads��6%   $
 Auto 69    6G   �� *	Threads+$ OneWay=�6r     5,      $
 User��6%   $
 Auto 69    6G   �� *User+$ OneWay=�6o     5-      $ Path to file��6%   $	 400 6=    6J   �� *
Filepath+$ OneWay=�6v     5.      $ Starting time��6%   $
 Auto 6<    6J   �� *StartingTime+$ OneWay=�6z   50      �� 51   
   $��2��6   $��0��6   $
��10 5q�6.   $��Show list of threads��6<   
���  ����6l   �� *ShowThreads+$ PropertyChanged=�6�   �� 52   
   $��2��6   $��1��6   $
��10 5q�6.   $��Open folder��6<   
���  ����6c   �� *
OpenFolder+$ PropertyChanged=�6�   �� 53   
   $��2��6   $��2��6   $
��10 5q�6.   $��Show list of modules��6<   
���  ����6l   �� *ShowModules+$ PropertyChanged=�6�   �� 54   
   $��3��6   $��0��6   $	��200��6.   $��Right=�6:   $��0 5 15 5q�6V   $��End Task��6h   
���  ��$
��Bold"�6�   ��6�   �� *	EndTask+$ PropertyChanged=�6�   55      56      