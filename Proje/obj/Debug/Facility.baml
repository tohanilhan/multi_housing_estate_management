   M S B A M L   `   `   `  ����@  <Proje, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ProjeProje  5   	       Proje.Facility   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Proje     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Facility��5	   	   $	��450��6   $	��800��6'   .��5
      � .+�5   
   �� $��
FACILITIES��6   $
��Left=�6%   $��
339,10,0,0q�6@   $	��Top=�6T   $
��Bold"�6l   $��20(�6~   �� 5   
   -   5        $��Delete Selected��5      $
��Left=�6+   $��653,192,0,0q�6F   $	��Top=�6[   $	��113��6s   $��38��6    J� RenderTransformOrigin$ -0.029,0.193&�6�   6�   �� 5   
   -   5        $��Update Informations��5      $
��Left=�6/   $��282,322,0,0q�6J   $	��Top=�6_   $	��113��6w   $��38��6�   $ -2.097,2.763&�6�   6�   �� 5   
   -   5        $��	Back Menu��5      $
��Left=�6%   $��653,324,0,0q�6@   $	��Top=�6U   $	��113��6m   $��64��6y   $ 0.819,0.833&�6�   6�   �� 5   
   $��All Facilities��6   $
��Left=�6)   $��
348,52,0,0q�6D   $	��Top=�6X   �� 5   
   $��Choosen Facility:��6   $
��Left=�6,   $��
10,266,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   �� 5   
   -   5         ��Name$ fowner��5      $
��Left=�6"   $��25��6=   $��
75,298,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��168��6�   �� 5   
   -   5         ��Name$ 	addworker��5      $	��Add��6$   $
��Left=�62   $��653,133,0,0q�6M   $	��Top=�6b   $	��113��6z   $��36��6�   6�   �� 5   
   -   5        $ frent��5      $
��Left=�6!   $��25��6<   $��
75,358,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��168��6�   �� 5   
   -   5        $ ftype��5      $
��Left=�6!   $��25��6<   $��
75,328,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��168��6�   �� 5   
   $��Owner��6   $
��Left=�6    $��
10,297,0,0q�6;   $	��Top=�6O   $��45��6g   $��26��6r   �� 5   
   $
��Type��6   $
��Left=�6   $��
10,328,0,0q�6:   $	��Top=�6N   $��60��6f   $��29��6q   $ 0.317,0.448&�6}   �� 5   
   $��Facility Name��6   $
��Left=�6(   $��	50,60,0,0q�6C   $	��Top=�6V   $��88��6n   $��29��6y   $ 
1.03,0.448&�6�   �� 5   
   $��
Rent price��6   $
��Left=�6%   $��
10,356,0,0q�6@   $	��Top=�6T   $��65��6l   $��27��6w   $ -9.222,3&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ fgrid��5      $��214,89,176,163q�6"      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Facility Name��6@   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *F_name+6W     5      $ Facility Type��6@   $		 100 6W   
 6%   �� *F_type+6W     5      $ 
Rent Price��6D   $		 100 6X   
 6%   �� *
Rent_money+6X     5      $
 Name��6>   $		 100 6L   
 6%   �� *Name+6L   5!      �� 5"   
   -	   5        $ fname��5"      $
��Left=�6!   $��23��6<   $��	10,89,0,0q�6H   $
 Wrap=�6[   $	��Top=�6o   $	��168��6�   �� 5#   
   -
   5        $��Search
��5#      $
��Left=�6'   $��
50,133,0,0q�6B   $	��Top=�6V   $��75��6n   $��25��6y   6�   5$      5%      