   M S B A M L   `   `   `  ����@  <Proje, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ProjeProje  5   	       Proje.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Proje     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Worker��5	   	   $	��450��6   $	��800��6%    � 	Resources 5
         Proje.PROJECT_DbDataSet1   pROJECT_DbDataSet1  guestViewSource �� Source �� Source  workerViewSource��%�   &	        &	      7   &	 >     7     5   
   6#   �� 5   
    67   �� *Guest+8   �� 5   
    68   �� *Worker+8   5      .��5      �  � DataContext# [ 6   .+�5   
   �� $��WORKERS��6   $
��Left=�6"   $��
339,10,0,0q�6=   $	��Top=�6Q   $
��Bold"�6i   $��20(�6{   �� 5   
   -   5        $��Delete Selected��5      $
��Left=�6+   $��653,192,0,0q�6F   $	��Top=�6[   $	��113��6s   $��38��6    J� RenderTransformOrigin$ -0.029,0.193&�6�   �� 5   
   -   5        $��Update Informations��5      $
��Left=�6/   $��282,322,0,0q�6J   $	��Top=�6_   $	��113��6w   $��38��6�   $ -2.097,2.763&�6�   �� 5   
   -   5        $��	Back Menu��5      $
��Left=�6%   $��653,324,0,0q�6@   $	��Top=�6U   $	��113��6m   $��64��6y   $ 0.819,0.833&�6�   �� 5   
   $��All Workers��6   $
��Left=�6&   $��
348,52,0,0q�6A   $	��Top=�6U   �� 5   
   $��Choosen Worker:��6   $
��Left=�6*   $��
10,266,0,0q�6E   $	��Top=�6Y   $
��Bold"�6q   �� 5   
   -   5         ��Name$ twname��5      $
��Left=�6"   $��25��6=   $��
75,298,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��168��6�   �� 5   
   -   5        	 ��Name$	 	addworker��5      $	��Add��6$   $
��Left=�62   $��653,133,0,0q�6M   $	��Top=�6b   $	��113��6z   $��36��6�   6�   �� 5   
   -   5        $ twsalary��5      $
��Left=�6$   $��25��6?   $��
75,358,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��168��6�   �� 5   
   -   5        $ 	twsurname��5      $
��Left=�6%   $��25��6@   $��
75,328,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��168��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��
10,297,0,0q�6:   $	��Top=�6N   $��42��6f   $��26��6q   �� 5   
   $��Surname��6   $
��Left=�6"   $��
10,328,0,0q�6=   $	��Top=�6Q   $��60��6i   $��29��6t   $ 0.317,0.448&�6�   �� 5   
   $	��SSN��6   $
��Left=�6   $��	63,60,0,0q�69   $	��Top=�6L   $��33��6d   $��29��6o   �� 5   
   $��Salary��6   $
��Left=�6!   $��
10,356,0,0q�6<   $	��Top=�6P   $��45��6h   $��27��6s   $ -9.222,3&�6   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 wgrid��5      $��214,89,168,163q�6"      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$	 SSN��6D      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
Ssn_worker+6Q     5!      $
 Name��6>   $	 100 6L    6%   �� *Name+6L     5"      $ Surname��6A   $	 100 6R    6%   �� *	Surname+6R     5#      $ Salary��6@   $	 100 6P    6%   �� *Salary+6P   5%      �� 5&   
   -	   5        $ twssn��5&      $
��Left=�6!   $��23��6<   $��	10,89,0,0q�6H   $
 Wrap=�6[   $	��Top=�6o   $	��168��6�   �� 5'   
   -
   5        $��Search��5'      $
��Left=�6"   $��
50,144,0,0q�6=   $	��Top=�6Q   $��75��6i   $��25��6t   6�   5(      5)      