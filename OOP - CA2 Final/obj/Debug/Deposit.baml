   M S B A M L   `   `   `  ����J  FOOP - CA2 Final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:OOP___CA2_FinalOOP___CA2_Final  5   	       OOP___CA2_Final.Deposit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:OOP___CA2_Final     5   	   -   5          �Name$  DepositWindow��5   	    � Title$ Deposit��5   	   $	��450��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$
 None=�6W    � 
ResizeMode$ NoResize=�6j   .��5	      � ��5
   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ 	#FFEEEEEE��6    � Offset$ 1Q�61   � 5      $ 	#FF868686��6   $ 0Q�61   5      .+�5   
   ]� $��	0,0,0,429q�6   .+�5      o� $	��Top=�6   $	��450��6(   #��� ��65   .@�5      m� -   5        	 m�Name$	 menuFileMain��5      $
��File��61   .@�5      m� -   5        $	 _dLogOut��5   0   $��Log Out��6   6B   m� 5      -   5        $	 _dExit��5   -   $
��Exit��6   6=   5      m� 5      $��Account��6   .@�5      m� -   5        $	 _dNewAccount��5   4   $��New Account��6   6J   m� 5      -   5        $	 _dEditAccount��5   5   $��Edit Account��6   6L   m� 5      -   5        $	 _dDepositFunds��5   6   $��Deposit Funds��6   6N   m� 5      -   5        $	 _dWithdrawFunds��5   7   $��Withdraw Funds��6   6P   m� 5      -	   5        $	 _dTransferFunds��5   7   $��Transfer Funds��6   6P   m� 5      -
   5        $	 _dViewTransactions��5   :   $��View Transactions��6   6V   5      5      5      �� 5    
   -   5        
 ��Name$
 imgLogo2��5       $
��Left=�6"   $	��184��6=   $��	550,0,0,0q�6J   $��Center=�6]   $	��242��6x   $��images/dbs-bank-logo.png��6�   �� 5!   
   -   5         ��Name$ lblDepositTitle��5!      $��Deposit Funds��6)   $��Center=�6A   $��0,15,0,0q�6^   $	��Top=�6p   $��18(�6�   $��Oblique$�6�   �� 5"   
   -   5        $ lblDepositTo��5"      $��Account Number��6&   $
��Left=�6?   $��	72,71,0,0q�6Z   $	��Top=�6m   $	��140��6�   $
��Bold"�6�   �� 5#   
   -   5         ��Name$ cboAccounts��5#      $
��Left=�6(   $��	72,97,0,0q�6C   $	��Top=�6V   $	��338��6n   $��26��6z   6�   �� 5$   
   -   5        $ lblDisplayName��5$      $�� ��6(   $
��Left=�63   $��49��6N   $��
73,134,0,0q�6Z   $	��Top=�6n   $	��337��6�   $
��Bold"�6�   $��18(�6�   �� 5%   
   -   5        $ lblDepositAmount��5%      $��Deposit Amount €��6*   $
��Left=�6E   $��
72,232,0,0q�6`   $	��Top=�6t   $	��140��6�   $
��Bold"�6�   �� 5&   
   -   5         ��Name$ txtDepositAmount��5&      $
��Left=�6,   $��232,230,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��178��6�   $��26��6�   $��18(�6�   .��6�   ��5'      �� 5(      $ 0.5,1&�6&   $ 0.5,0&�67   .��5)      � $ Black��6#   � 5*      $ White��6#   $ 0.143Q�61   5+      .��5,   "   5-      �� 5.   
   -   5        $ lblDepositCurrentAmt��5.      $��Current Balance €��6.   $
��Left=�6J   $��
73,199,0,0q�6e   $	��Top=�6y   $	��140��6�   $
��Bold"�6�   �� 5/   
   -   5        $ textDepositCurrent��5/      $
��Left=�6.   $��232,199,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��178��6�   $��26��6�   $��18(�6�   .��6�   ��50      �� 51      $ 0.5,1&�6&   $ 0.5,0&�67   .��52      � $ Black��6#   � 53      $ White��6#   $ 0.143Q�61   54      .��55   "   56      �� 57   
   -   5         ��Name$ 
btnDeposit��57      $��DEPOSIT��6%   $
��Left=�67   $��313,393,0,0q�6R   $	��Top=�6g   
�������$��97��6�   $��26��6�   $��14(�6�   $
��Bold"�6�   ��58      �� 59      $ 0.5,1&�6&   $ 0.5,0&�67   .��5:      � $ Black��6#   � 5;      $ White��6#   $ 0.143Q�61   5<      5>      5?      5@      