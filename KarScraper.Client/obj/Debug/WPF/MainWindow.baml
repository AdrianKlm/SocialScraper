   M S B A M L   `   `   `  ����L  HKarScraper.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KarScraper
KarScraper  5   	   ;"clr-namespace:KarScraper.ViewModelKarScraper.ViewModel  5   	       KarScraper.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $localclr-namespace:KarScraper  5   	   0localVM"clr-namespace:KarScraper.ViewModel  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStyle$ SingleBorderWindow=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Social Scraper��5   	   $	��720��5   	   $
��1280��6   $	��720��5   	   $
��1280��6    � DataContext 5      .   (KarScraper.ViewModel.MainWindowViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5       $��* �6   .+�5$   
   #  MaterialDesignThemes.Wpf.Card  $��Stretch=�6   $��0��6.   $��0��6>   .��5%      �  5&      �� 5'      $
��auto �6$   �� 5(      $
��auto �6$   �� 5)      $��* �6$   .+�5,      &   System.Windows.Controls.DataGrid  $��0��5-      
������ $	��550��5/      	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  $��0,0,0,0q�52         HeadersVisibility$
 None=�53      "   VerticalScrollBarVisibility$
 Auto=�54      ��5,      �� *
ViewModels+   Columns 55      4  .System.Windows.Controls.DataGridTemplateColumn  56      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 25 61      CellTemplate 57      �� 58   "   .R�59   &   �� $��
-5,0,-10,0q�6/     MaterialDesignCheckBox#��[ 5:   /    d� 	IsChecked 5;   /   �� *	Checked+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5<   #   5>        5?      $ * 61    5@      �� 5A   "   .R�5B   &   �� ��6-   ��  �� Path$ ViewModel.Content���5C   -   �� $# DataContext.NavigateToCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType" ���5D   -   �� 5E   #   5G        5H       5I      �� 5J   "   .R�5K   &   �� $��X��6-   $��25��69   $��-28,0.8,0,0q�6D   $��-5q�6Y    " MaterialDesignRaisedDarkButton#��[ 5L   -   ��5M   -   �� $( "DataContext.DeleteViewModelCommand� �� *FindAncestor+" ���5N   -   �� 5O   #   5Q      5S      �� 5T      $��1��6   .+�5U      �� $
��0,10q�6    �� 5V      $��Nowe wyszukiwanie��6   $��5q�69   ��6D   �� *NewSearchCommand+�� 5W      $��Porównaj zaznaczone��6   $��5q�6;   ��6F   �� *CompareCommand+5X      �� 5Y      $��2��6   $��	2,-10,0,0q�6*   $
��Left=�6=   $��Bottom=�6X   .+�5Z      �� $
��v0.1��6    5[      5\      5]      �� 5`   
   -   5         ��Name$ Pages��5`   H   $��1��6   $��0��6)   $��0,0,0,25q�66   ��6W   �� *SelectedViewModel+5a      5b      