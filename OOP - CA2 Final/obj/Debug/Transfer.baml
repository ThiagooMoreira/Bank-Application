   M S B A M L   `   `   `  ����J  FOOP - CA2 Final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:OOP___CA2_FinalOOP___CA2_Final  5   	       OOP___CA2_Final.Transfer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:OOP___CA2_Final     5   	   -   5          �Name$  TransferWindow��5   	    � Title$ Transfer��5   	   $	��450��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�63    � WindowStyle$
 None=�6X    � 
ResizeMode$ NoResize=�6k   .��5	      � ��5
   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ 	#FFEEEEEE��6    � Offset$ 1Q�61   � 5      $ 	#FF868686��6   $ 0Q�61   5      .+�5   
   ]� $��	0,0,0,429q�6   .+�5      o� $	��Top=�6   $	��450��6(   #��� ��65   .@�5      m� -   5        	 m�Name$	 menuFileTransfers��5      $
��File��66   .@�5      m� -   5        $	 _tLogOut��5   0   $��Log Out��6   6B   m� 5      -   5        $	 _tExit��5   -   $
��Exit��6   6=   5      m� 5      $��Account��6   .@�5      m� -   5        $	 _tNewAccount��5   4   $��New Account��6   6J   m� 5      -   5        $	 _tEditAccount��5   5   $��Edit Account��6   6L   m� 5      -   5        $	 _tDepositFunds��5   6   $��Deposit Funds��6   6N   m� 5      -   5        $	 _tWithdrawFunds��5   7   $��Withdraw Funds��6   6P   m� 5      -	   5        $	 _tTransferFunds��5   7   $��Transfer Funds��6   6P   m� 5      -
   5        $	 _tViewTransactions��5   :   $��View Transactions��6   6V   5      5      5      �� 5    
   -   5        
 ��Name$
 imgLogo2��5       $
��Left=�6"   $	��184��6=   $��	550,0,0,0q�6J   $��Center=�6]   $	��242��6x   $��images/dbs-bank-logo.png��6�   �� 5!   
   -   5         ��Name$ lblTransferTitle��5!      $*��$How much you wish to transfer today?��6*   $��Center=�6Y   $��0,15,0,0q�6v   $	��Top=�6�   $��18(�6�   $��Oblique$�6�   �� 5"   
   -   5        $ lblFr��5"      $
��FROM��6   $
��Left=�6.   $��	74,76,0,0q�6I   $	��Top=�6\   $��72��6t   $
��Bold"�6   �� 5#   
   -   5        $ lblTo��5#      $��TO��6   $
��Left=�6,   $��
73,248,0,0q�6G   $	��Top=�6[   $��72��6s   $
��Bold"�6~   �� 5$   
   -   5         ��Name$ cboAccounts��5$      $
��Left=�6(   $��	74,98,0,0q�6C   $	��Top=�6V   $	��444��6n   $��26��6z   6�   �� 5%   
   -   5        $ lblTransferCurrentAmount��5%      $��Balance��62   $
��Left=�6D   $��
74,157,0,0q�6_   $	��Top=�6s   $	��214��6�   $
��Bold"�6�   $��14(�6�   �� 5&   
   -   5        $ lbltransferAccType��5&      $��Account Type��6,   $
��Left=�6C   $��
74,274,0,0q�6^   $	��Top=�6r   $
��Bold"�6�   ���	#FF292929 J� RenderTransformOrigin$ 0.5,0.5&�6�   $��95��6�   $��26��6�   z�5'      V� 5(      .~�5)      �� �� 5*      �� 5+      T� 5,       T� X$ 0Q�6)   5-      ��5/      �� 50      $ 0.5,1&�6&   $ 0.5,0&�67   .��51      � $ Black��6#   � 52      $ White��6#   $ 0.143Q�61   53      55      	� 56   
   -   5         	�Name$ rdotransfCurrent��56      $��Current Account��60   $
��Left=�6J   $��181,280,0,0q�6e   $	��Top=�6z   
�������6�   	� 57   
   -   5        $ rdotransfSavings��57      $��Savings Account��60   $
��Left=�6J   $��305,280,0,0q�6e   $	��Top=�6z   
�������6�   �� 59   
   -   5        $ lbltransferAccNo_��59      $��Account No.��6+   $
��Left=�6A   $��
74,362,0,0q�6\   $	��Top=�6p   $
��Bold"�6�   ���	#FF292929$ 0.5,0.5&�6�   $��95��6�   $��26��6�   z�5:      V� 5;      .~�5<      �� �� 5=      �� 5>      T� 5?      $ 0Q�6)   5@      ��5B      �� 5C      $ 0.5,1&�6&   $ 0.5,0&�67   .��5D      � $ Black��6#   � 5E      $ White��6#   $ 0.143Q�61   5F      5H      �� 5I   
   -   5         ��Name$ txtTransferAccNo_��5I      $
��Left=�6-   $��194,362,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��323��6�   $��26��6�   $��14(�6�   .��6�   ��5J      �� 5K      $ 0.5,1&�6&   $ 0.5,0&�67   .��5L      � $ Black��6#   � 5M      $ White��6#   $ 0.143Q�61   5N      .��5O   "   5P      �� 5Q   
   -   5        $ lblTransferAmount��5Q      $��Amount      (€)��6+   $
��Left=�6E   $��
73,420,0,0q�6`   $	��Top=�6t   $
��Bold"�6�   ���	#FF292929$ 0.5,0.5&�6�   $��96��6�   $��26��6�   z�5R      V� 5S      .~�5T      �� �� 5U      �� 5V      T� 5W      $ 0Q�6)   5X      ��5Z      �� 5[      $ 0.5,1&�6&   $ 0.5,0&�67   .��5\      � $ Black��6#   � 5]      $ White��6#   $ 0.143Q�61   5^      5`      �� 5a   
   -   5        $ txtTransferTo��5a      $
��Left=�6)   $��194,420,0,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   $	��323��6�   $��26��6�   $��14(�6�   .��6�   ��5b      �� 5c      $ 0.5,1&�6&   $ 0.5,0&�67   .��5d      � $ Black��6#   � 5e      $ White��6#   $ 0.143Q�61   5f      .��5g   "   5h      �� 5i   
   -   5        $ 
lblBalFrom��5i      $�� ��6$   $
��Left=�6/   $��404,160,0,0q�6J   $	��Top=�6_   $	��108��6w   $
��Bold"�6�   $��14(�6�   �� 5j   
   -   5         ��Name$ btnTransfer��5j      $��INT. TRANSFER��6&   $
��Left=�6>   $��522,402,0,0q�6Y   $	��Top=�6n   
�������$	��120��6�   $��43��6�   $
��Bold"�6�   ��5k      �� 5l      $ 0.5,1&�6&   $ 0.5,0&�67   .��5m      � $ Black��6#   � 5n      $ White��6#   $ 0.143Q�61   5o      5q      �� 5r   
   -   5        $ lblEuro��5r      $	��€��6!   $
��Left=�6-   $��356,184,0,0q�6H   $	��Top=�6]   $��20��6u   $
��Bold"�6�   $��32��6�   $��16(�6�   �� 5s   
   -   5        $ lblDisplayName��5s      $�� ��6(   $
��Left=�63   $��29��6N   $��
74,126,0,0q�6Z   $	��Top=�6n   $	��444��6�   $
��Bold"�6�   $��14(�6�   �� 5t   
   -   5        $ cboAccTo��5t      $
��Left=�6%   $��
73,303,0,0q�6@   $	��Top=�6T   $	��444��6l   $��26��6x   6�   	� 5u   
   -   5        $ rdoOtherBank��5u      $��
Other Bank��6,   $
��Left=�6A   $��439,280,0,0q�6\   $	��Top=�6q   
�������6�   �� 5v   
   -   5        $# lblTransferCurrentAmount_Copy��5v      $��Current Amount��67   $
��Left=�6P   $��
73,332,0,0q�6k   $	��Top=�6   $	��120��6�   $
��Bold"�6�   $��14(�6�   �� 5w   
   -   5        $ lblEuro_Copy��5w      $	��€��6&   $
��Left=�62   $��358,329,0,0q�6M   $	��Top=�6b   $��20��6z   $
��Bold"�6�   $��32��6�   $��16(�6�   �� 5x   
   -    5        $ lblBalTo��5x      $�� ��6"   $
��Left=�6-   $��402,332,0,0q�6H   $	��Top=�6]   $	��110��6u   $
��Bold"�6�   $��14(�6�   �� 5y   
   -!   5        $ lblAccountHolder��5y      $��Acc. Holder��6*   $
��Left=�6@   $��
73,390,0,0q�6[   $	��Top=�6o   $
��Bold"�6�   ���	#FF292929$ 0.5,0.5&�6�   $��96��6�   $��26��6�   z�5z      V� 5{      .~�5|      �� �� 5}      �� 5~      T� 5      $ 0Q�6)   5�      ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   � 5�      $ White��6#   $ 0.143Q�61   5�      5�      �� 5�   
   -"   5        $ txtAccHolder��5�      $
��Left=�6(   $��194,390,0,0q�6C   $
 Wrap=�6X   $	��Top=�6l   $	��323��6�   $��26��6�   $��14(�6�   .��6�   ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   � 5�      $ White��6#   $ 0.143Q�61   5�      .��5�   "   5�      �� 5�   
   -#   5        $ lblAccSavings��5�      $&�� Is the Source's Account Savings?��6'   $
��Left=�6R   $��40��6m   $��	73,45,0,0q�6y   $	��Top=�6�   $	��326��6�   $
��Bold"�6�   $��14(�6�   	� 5�   
   -$   5        $ rdoSavingsYes��5�      $	��Yes��6-   $
��Left=�6;   $��
389,49,0,0q�6V   $	��Top=�6j   
�������$��16(�6�   $
��Bold"�6�   $��56��6�   6�   	� 5�   
   -%   5        $ rdoSavingsNo��5�      $��No��6,   $
��Left=�69   $��
461,49,0,0q�6T   $	��Top=�6h   
�������$��16(�6�   $
��Bold"�6�   $��56��6�   6�   �� 5�   
   -&   5        $ btnout��5�      $��OUT. TRANSF��6!   $
��Left=�67   $��670,402,0,0q�6R   $	��Top=�6g   
�������$	��120��6�   $��43��6�   $
��Bold"�6�   ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ Black��6#   � 5�      $ White��6#   $ 0.143Q�61   5�      5�      �� 5�   
   -'   5        $ lblOverdraftLimit��5�      $��Overdraft Limit��6+   $
��Left=�6E   $��
74,188,0,0q�6`   $	��Top=�6t   $	��214��6�   $
��Bold"�6�   $��14(�6�   �� 5�   
   -(   5        $ lblEuro_Copy1��5�      $	��€��6'   $
��Left=�63   $��356,154,0,0q�6N   $	��Top=�6c   $��20��6{   $
��Bold"�6�   $��32��6�   $��16(�6�   �� 5�   
   -)   5        $ lblOverdraft��5�      $�� ��6&   $
��Left=�61   $��404,187,0,0q�6L   $	��Top=�6a   $	��108��6y   $
��Bold"�6�   $��14(�6�   �� 5�   
   -*   5        $ lblTotalBalance��5�      $��Total Balance��6)   $
��Left=�6A   $��
74,220,0,0q�6\   $	��Top=�6p   $	��214��6�   $
��Bold"�6�   $��14(�6�   �� 5�   
   -+   5        $ lblTotal��5�      $�� ��6"   $
��Left=�6-   $��404,217,0,0q�6H   $	��Top=�6]   $	��108��6u   $
��Bold"�6�   $��14(�6�   �� 5�   
   -,   5        $ lblEuro_Copy2��5�      $	��€��6'   $
��Left=�63   $��356,216,0,0q�6N   $	��Top=�6c   $��20��6{   $
��Bold"�6�   $��32��6�   $��16(�6�   5�      5�      