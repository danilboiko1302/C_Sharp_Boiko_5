   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TaskManager.WindowsTaskManager.Windows  5   	   +    %TaskManager.Windows.ShowModulesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TaskManager.Windows     5   	     � Title$  Modules��5   	   $	��450��6   $	��500��6&    � WindowStartupLocation$ CenterScreen=�62   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   5      �� 5      $��8* �6   6*   .+�5   
   �� $��20(�60   $
��Bold"�6>   $��Center=�6P   ��6   �� *ProcessName+6o   &   System.Windows.Controls.DataGrid  5   
   $��1��6      AutoGenerateColumns$ False��5      $
��True��5         
IsReadOnly$
 True��5         CanUserSortColumns$ False��6%   ��5       �� *	Modules+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Name+$ OneWay=�6m     5      $	 Filepath��6%   $	
 350 67    6E   �� *
Filepath+$ OneWay=�6q   5      5      5      