   M S B A M L   `   `   `  ����   Modeling_System_In_Energetic-    'Modeling_System_In_Energetic.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   R NOxyPlot.Wpf, Version=2.2.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0Y UOxyPlot.Wpf.Shared, Version=2.2.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0"oxyhttp://oxyplot.org/wpf   5   	     � Title$:  4Графіки Сонячних Параметрів��5   	   $	��800��6-   $
��1200��6:   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5	      $��* �6   �� 5
      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
     OxyPlot.Wpf.PlotView  $��0��6=   $��0��6J     OxyPlot.Wpf.PlotViewBase   Model 6   �� *ZenithPlotModels[0]+6J     5   
   $��0��6>   $��1��6K    6   �� *AzimuthPlotModels[0]+6K     5   
   $��0��6A   $��2��6N    6   �� *IrradiancePlotModels[0]+6N     5   
   $��1��6=   $��0��6J    6   �� *ZenithPlotModels[1]+6J     5   
   $��1��6>   $��1��6K    6   �� *AzimuthPlotModels[1]+6K     5   
   $��1��6A   $��2��6N    6   �� *IrradiancePlotModels[1]+6N     5   
   $��2��6=   $��0��6J    6   �� *ZenithPlotModels[2]+6J     5   
   $��2��6>   $��1��6K    6   �� *AzimuthPlotModels[2]+6K     5   
   $��2��6A   $��2��6N    6   �� *IrradiancePlotModels[2]+6N     5!   
   $��3��6=   $��0��6J    6   �� *ZenithPlotModels[3]+6J     5"   
   $��3��6>   $��1��6K    6   �� *AzimuthPlotModels[3]+6K     5#   
   $��3��6A   $��2��6N    6   �� *IrradiancePlotModels[3]+6N   5$      5%      