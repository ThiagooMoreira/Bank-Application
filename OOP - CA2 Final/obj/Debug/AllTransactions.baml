   M S B A M L   `   `   `  ����J  FOOP - CA2 Final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:OOP___CA2_FinalOOP___CA2_Final  5   	   %    OOP___CA2_Final.AllTransactions   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:OOP___CA2_Final     5   	   -   5          �Name$  AllTransactionsWindows��5   	    � Title$ AllTransactions��5   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6:    � WindowStyle$
 None=�6_    � 
ResizeMode$ NoResize=�6r   .��5	      � ��5
   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ 	#FFEEEEEE��6    � Offset$ 1Q�61   � 5      $ 	#FF868686��6   $ 0Q�61   5      .+�5   
   ]� $��	0,0,0,429q�6   .+�5      o� $	��Top=�6   $	��450��6(   #��� ��65   .@�5      m� -   5        	 m�Name$	 menuFile��5      $
��File��6-   .@�5      m� -   5        $	 
_allLogOut��5   0   $��Log Out��6   6D   m� 5      -   5        $	 _allExit��5   -   $
��Exit��6   6?   5      m� 5      $��Account��6   .@�5      m� -   5        $	 _allNewAccount��5   4   $��New Account��6   6L   m� 5      -   5        $	 _allEditAccount��5   5   $��Edit Account��6   6N   m� 5      -   5        $	 _allDepositFunds��5   6   $��Deposit Funds��6   6P   m� 5      -   5        $	 _allWithdrawFunds��5   7   $��Withdraw Funds��6   6R   m� 5      -	   5        $	 _allTransferFunds��5   7   $��Transfer Funds��6   6R   m� 5      -
   5        $	 _allViewTransactions��5   :   $��View Transactions��6   6X   5      5      5      �� 5    
   -   5        
 ��Name$
 imgLogo2��5       $
��Left=�6"   $	��184��6=   $��	550,0,0,0q�6J   $��Center=�6]   $	��242��6x   $��images/dbs-bank-logo.png��6�   �� 5!   
   -   5         ��Name$ lblAllTranTitle��5!      $��All Transactions��6)   $��Center=�6D   $��0,15,0,0q�6a   $	��Top=�6s   $��18(�6�   $��Oblique$�6�   �� 5"   
   -   5         ��Name$ lstView��5"      $
��Left=�6#   $	��323��6>   $��9,90,0,0q�6K   $	��Top=�6]   $	��573��6u   ���	#FFD0D0D0$��2,2,2,2q�6�   .@�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgvtransac��5#      $	��204��6,   $	��506��69   $��
24,70,25,0q�6E   �� 5$      -   5         ��Name$ cboAType��5$      $��21��6)   $	��120��66   $��130,-482,0,0q�6B   6X   �� 5%      -   5         ��Name$ btnByAccType1��5%      $��By Account Type��6,   $��21��6F   $	��100��6R   $��24,-490,0,0q�6^   6s   �� 5&      -   5        $ btnAllAccounts��5&      $��All Accounts��6-   $��21��6D   $	��100��6P   $��295,-497,0,0q�6\   6r   �� 5(      -   5        $ 
btnShowAll��5(      $��Show All��6)   $��21��6<   $	��100��6H   $��429,-503,0,0q�6T   6j   5,      5-      5.      