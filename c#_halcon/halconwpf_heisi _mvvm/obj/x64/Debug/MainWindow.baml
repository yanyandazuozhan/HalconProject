   M S B A M L   `   `   `  ����T  Phalcondotnet, Version=23.5.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8A0clr-namespace:HalconDotNet;assembly=halcondotnetHalconDotNet  5   	   F Bhalconwpf01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:halconwpf01halconwpf01 5   	      halconwpf01.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Chalcon0clr-namespace:HalconDotNet;assembly=halcondotnet     5   	   +localclr-namespace:halconwpf01     5   	   T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	        � Title$  阈值提取demo��5   	   $	��550��6   $	��800��6'    � 	Resources 5       �� MergedDictionaries �� Source   FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels�� 5   
    5      �� 5      $ /style/Dictionary1.xaml?�6%   5      %�   &	        �� 5      .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6(   $	 1 2R�63   #��� ��6I    . $��1��6�   5      5      5      5      .��5      �  � ColumnDefinitions 5    
   �� 5!      $��4* �6   6,   �� 5"      $��1* �6   6,   .+�5$   
   � $��0��6   .+�5%      $   HalconDotNet.HWindowControlWPF  -   5        	  Name$
	 Hwin��5%   (   5'      5(      �� 5)   
   $��1��6   .+�5*      ��   NewRowBtnStyle#���  6   $	��126��6?   $��56��6K   
 �� Left$
 16��6W   
 �� Top$ 62��6h   $��初 始 化��6x   $
��Left=�5+   5   $��Center=�6P   ��6   �� *initCommand+6P   �� 5,      -   5         ��Name$ rgb_gray��5,      #���  6'   $	��126��6P   $��56��6\   $
 15��6h   $	 131��6y   $��	彩变灰��6�   $
��Left=�5-   9   $��Center=�6T   ��6   �� *RgbToGrayCommand+6r   �� 5.      -   5        $ 	threshold��5.      #���  6(   $	��126��6Q   $��56��6]   $
 15��6i   $	 198��6z   $��阈值提取��6�   $��Center=�5/   :   $��Center=�6W   ��6   �� *ThreSholdCommand+6u   �� 51      -   5        $	 eld��51   >   #���  6   $	��126��6L   $��56��6X   $
 13��6d   $	 320��6u   $��阈值提取��6�   $
��Left=�52   3   $	��Top=�6N   ��6   �� *ThreSholdCommand+6i   �� 53      $��	路径：��6   $��11(�6"   $��40��60   $��26��6;   $
 11��6G   $ 20��6X   $
��Left=�6h   $��Center=�6�   6�   �� 54      $��阈值左侧��6   $��25��6#   $��69��6/   $
 9��6:   $	 264��6J   $��Center=�6[   $	��Top=�6x   6�   �� 55      $��阈值右侧��6   $��25��6#   $��65��6/   $
 85��6:   $	 265��6K   $��Center=�6\   $	��Top=�6y   6�   �� 57      $	��100��6   $
 44��6#   $ 20��64   $
��Left=�6D   $��Center=�6_     SizeComboBox#���  58      ��57   z   �� *
imgSources+ �� SelectedItem 58   ?   �� *
selectPath+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 59      +  %Microsoft.Xaml.Behaviors.EventTrigger  5:         	EventName$ SelectionChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5;      -  'Prism.Interactivity.InvokeCommandAction     Command 64   �� *TypeChanged+5<      5?      �� 5@      $
��Left=�6   $	��Top=�61   $��49��6I   $
 17��6T   $	 292��6e   ��5A      �� *	yuzhileft+63   �� 5B      $
��Left=�6   $��Center=�61   $��49��6L   $
 92��6W   $	 292��6h   ��5C      �� *
yuzhiright+64   �� 5D      $��阈值左侧��6   $��25��6#   $��69��6/   $
 13��6:   $	 375��6K   $
��Left=�6\   $	��Top=�6w   �� 5E      $��阈值右侧��6   $��25��6#   $��65��6/   $
 86��6:   $	 376��6K   $
��Left=�6\   $	��Top=�6w   �� 5F      $��49��6   $
 19��6!   $	 405��62   $
��Left=�5G   ,   $	��Top=�6G   ��6   �� *	yuzhileft+6G   �� 5H      $��49��6   $��19��5I   )   $
 88��65   $	 407��6F   ��6   �� *
yuzhiright+6F   5J      5K      5L      