   M S B A M L   `   `   `  ����F  BOneKeyInput, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OneKeyInputOneKeyInput  5   	       OneKeyInput.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   %localclr-namespace:OneKeyInput  5   	   -   5          � WindowStyle$
  None=�5	   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 登录��5   	   $	��400��6   $	��700��6!   
������ .��5      � $��10q�6   
�������.+�5   
   �� -   5        $��625,5,5,325q�5       &  "MaterialDesignIconForegroundButton#��[  63    � ToolTip$ 关闭��6o   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�6&   
���  ��67   5      A� 5   
   $��100,0q�6    A� Columns$ 1��6%   $��Center=�61   .+�5      �� $��Center=�6   $��Right=�64    �� Orientation$ 
Horizontal=�6P   .+�5      �� -   5         ��Name$ 	PathField��5      	 �� 
IsReadOnly	 . $��30��5      $	��300��6   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 文件路径��5         
HelperText$* $输入需要导入的字体文件夹��5      �� 5      -   5        $
��20,0q�5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5      $1 +MaterialDesignFloatingActionMiniLightButton��5      
���  ��
���  ��.��5        $
 Plus=�5      $��24��5      $��24��5       5!      5"      �� 5$      -   5        $��NextBtn��5)   X   $��	0,120,0,0q�5&      #��[  5'      $ 	下一页��5(      +  %MaterialDesignThemes.Wpf.RippleAssist   Feedback �	#FF000000{�.  
���  ��
���������5)   x   Z� .��5*        $ SkipNextOutline=�6+   
�������6B   5+      5,      '  !MaterialDesignThemes.Wpf.Snackbar  5-   
   -   5          Name$ SnackbarThree��5/         MessageQueue 5.      4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5/       J� Effect 50   
   3  -System.Windows.Media.Effects.DropShadowEffect  51         ShadowDepth$ 0Q�6      Opacity$	 0.6Q�6/   6?   53      54      