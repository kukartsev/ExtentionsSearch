   M S B A M L   `   `   `  ����K  GExtentionsSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ExtentionsSearch.ClassesExtentionsSearch.Classes  5   	   | xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization 5   	   �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	   !    ExtentionsSearch.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4c&clr-namespace:ExtentionsSearch.Classes     5   	   �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   -   5          � Title$  ExtentionsSearch��5   	   $	��489��6"   $��785.4��6/    � 	Resources 5      ;   5ExtentionsSearch.Classes.BooleanToDataSourseConverter   BooleanConverter��%   &	          5	   
   6D   5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ button��5      $��Выбрать папку��6!   $��	10,17,0,0q�6�   $	��Top=�6�   $��24��6�   ���	#FFEEF9EF���	#FFACACAC$
��Left=�6�   $	��101��6  ��69   �� *ChooseDirectoryCommand+{�6d   �� *Busy+6  � 5   
   -   5         �Name$ SearchProgress��5      $��24��6.   $��123,17,10,0q�6:   $	��Top=�6�   ���	#FF0CCB5A � Value 6O   �� *
Progress+ � IsIndeterminate 6j   �� *Indeterminate+6�   �� 5   
   -   5         ��Name$ SelectedPathName��5      $	��Top=�6K   $��133,20,93,0q�6c   $��21��6x   ��6.   �� *
TargetPath+6x   �� 5   
   -   5         ��Name$ label��5      $!��Сортировать по��6   $
��Left=�68   $��	10,46,0,0q�6S   $	��Top=�6f   $��30��6~   	� 5   
   -   5        	 	�Name$	 SortByNumberOfFilesRB��5      $'��!количеству файлов��65   $
��Left=�6�   $��
123,52,0,0q�6�   $	��Top=�6�   
 	� 	GroupName$
 Sorting��6�   ��6Q   �� *SortByNumberOfFilesCommand+{�6�   �� *Busy+6�   	� 5   
   -   5        $	 SortByTotalSizeRB��5      $!��общему размеру��61   $
��Left=�6�   $��
264,52,0,0q�6�   $	��Top=�6�   $
 Sorting��6�   ��6J   �� *SortByTotalSizeCommand+{�6u   �� *Busy+6�   �� 5   
   -   5         ��Name$ 
tabControl��5      $��	0,76,0,28q�6)   .@�5      �� $��Таблица��6   .��5      �  5      �� 5      $��* �6+   .+�5      �� -	   5         ��Name$ listview��5      $��0��62   ��6C   �� *ExtentionsList+ �� View 5      �� 5      .P�5   "   �� $��Расширение��61    �� DisplayMemberBinding 5      �� *Name+�� 5    "   $'��!Количество файлов��61    5!      �� *NumberOfFiles+�� 5"   "   $$��Общий размер (Кб)��61    5#      �� *	TotalSize+�� 5$   "   $#��Наименьший файл��61    5%      �� *SmallestFile+�� 5&   "   $#��Наибольший файл��61    5'      �� *
BigestFile+5(      5*      5+      5,      �� 5-      $��Диаграмма��6   .��5.      �  5/      �� 50      $��* �6+   .+�52      >  8System.Windows.Controls.DataVisualization.Charting.Chart  -
   5        $��ExtChart��52          Series 54      B  <System.Windows.Controls.DataVisualization.Charting.PieSeries  -   5        $��	PieSeries��54   ,   ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Диаграмма��6=   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   ItemsSource 6O   �� *ExtentionsListForPie+   IndependentValueBinding 6|   �� *Name+   DependentValueBinding 6�   �� *	TotalSize+55      57      58      59      5:      �� 5;   
   -   5        $ lastcheckLabel��5;      $
��Left=�6J   $��10,0,0,0q�6e   $��28��6w   $��Bottom=�6�   ��6(   �� *LastCheckInfo+6�   5<      5=      