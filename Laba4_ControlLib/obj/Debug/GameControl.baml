   M S B A M L   `   `   `  ����K  GLaba4_ControlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Laba4_ControlLibLaba4_ControlLib  5      "    Laba4_ControlLib.GameControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Laba4_ControlLib     5        J� CommandBindings  5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:GameCommands.Start��5      6i     5   
   -   5        $ local:GameCommands.Pause��5      6i     5   
   -   5        $ local:GameCommands.Reset��5      6i   .��5      � ��5   
   �� 5       �� ImageSource$! Assets/grass_background.jpg��6   .+�5   
   �� }�.  � UseLayoutRounding .   � DataContext 5        Laba4_ControlLib.Scene  5      -   5        MyScene��   
whiteHorse 5      !  Laba4_ControlLib.WhiteHorse  5      "  Laba4_ControlLib.HorseObject   
ObjectRect$ 00,10,150,150�6+      
blackHorse 5      !  Laba4_ControlLib.BlackHorse  5      $ 00,250,150,150�6+      
brownHorse 5       !  Laba4_ControlLib.BrownHorse  5!      $ 00,450,200,150�6+   5#      	 � LayoutTransform	 5&      �� 5'      
 �� ScaleY$
 -1Q�6!    � 	Resources 5*       �� 
TargetType �� Property �� Value �� Path��%�  '��       �� 5+      " ��6   .�5,      ��  � �� 6/   �� *Image+�� 5-       �@��Left 64   �� $ ObjectRect.X��� 5.       �@��Top 63   �� $ ObjectRect.Y��� 5/       � �� 6.   �� $ ObjectRect.Width��� 50       � �� 6/   �� $ ObjectRect.Height��� 51       � ��$
 Fill=�60   �� 52       �@�LayoutTransform 53      �� 54      $
 -1Q�6-   56      57      58      .+�5:      �� -   5        $	��150��5:   <    6   �� $ 
whiteHorse�5;   G   �� 5=      -   5        $	��150��5=   <    6   �� $ 
blackHorse�5>   G   �� 5@      -   5        $	��150��5@   <    6   �� $ 
brownHorse�5A   G   5C      5E      5F      