   M S B A M L   `   `   `  ����J  FOOP - CA2 Final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:OOP___CA2_FinalOOP___CA2_Final  5   	       OOP___CA2_Final.Welcome   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:OOP___CA2_Final     5   	   -   5          �Name$  WelcomeWindow��5   	    � Title$ Welcome��5   	   $	��450��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$
 None=�6W    � 
ResizeMode$ NoResize=�6j   .��5	      � ��5
   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ 	#FFEEEEEE��6    � Offset$ 1Q�61   � 5      $ 	#FF868686��6   $ 0Q�61   5      .+�5   
   ]� $��	0,0,0,429q�6   .+�5      o� $	��Top=�6   $	��450��6(   #��� ��65   .@�5      m� -   5        	 m�Name$	 menuFileMain��5      $
��File��61   .@�5      m� -   5        $	 _wLogOut��5   0   $��Log Out��6   6B   m� 5      -   5        $	 _wExit��5   -   $
��Exit��6   6=   5      m� 5      $��Account��6   .@�5      m� -   5        $	 _wNewAccount��5   4   $��New Account��6   6J   m� 5      -   5        $	 _wEditAccount��5   5   $��Edit Account��6   6L   m� 5      -   5        $	 _wDepositFunds��5   6   $��Deposit Funds��6   6N   m� 5      -   5        $	 _wWithdrawFunds��5   7   $��Withdraw Funds��6   6P   m� 5      -	   5        $	 _wTransferFunds��5   7   $��Transfer Funds��6   6P   m� 5      -
   5        $	 _wViewTransactions��5   :   $��View Transactions��6   6V   5      5      5      �� 5    
   -   5        
 ��Name$
 imgLogo2��5       $
��Left=�6"   $	��184��6=   $��	550,0,0,0q�6J   $��Center=�6]   $	��242��6x   $��images/dbs-bank-logo.png��6�   �� 5!   
   -   5         ��Name$ lblWelcomeTitle��5!      $ ��How can we help you today?��6)   $��Center=�6N   $��0,15,0,0q�6k   $	��Top=�6}   $��18(�6�   $��Oblique$�6�   �� 5"   
   
���   �$��1q�6%   ._�5#      �� -   5         ��Name$ lstView��5#      $
��Left=�6'   $	��323��6B   $��9,90,0,0q�6O   $	��Top=�6a   $	��573��6y   ���	#FFD0D0D0$��2,2,2,2q�6�   .@�5$      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgvWelcome��5$      $	��286��60   $	��500��6=   $��
25,15,25,0q�6I      
IsReadOnly . 6]   5%      5&      5'      5(      