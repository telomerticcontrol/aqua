   M S B A M L   `   `   `  ���� U  QInfragistics.Guidance.Aqua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Infragistics.Guidance.Aqua.Client!Infragistics.Guidance.Aqua.Client  k:clr-namespace:Infragistics.Guidance.Aqua.Client.Converters,Infragistics.Guidance.Aqua.Client.Converters  <    6Infragistics.Guidance.Aqua.Client.View.TestResultsView   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    r nInfragistics3.Wpf.DataPresenter.v9.1, Version=9.1.20091.2023, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb0igDP%http://infragistics.com/DataPresenter  d `Infragistics3.Wpf.v9.1, Version=9.1.20091.2023, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb+igWinhttp://infragistics.com/Windows  8fl/clr-namespace:Infragistics.Guidance.Aqua.Client  j fInfragistics3.Wpf.Chart.v9.1, Version=9.1.20091.2023, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb+igCharthttp://infragistics.com/Chart  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  m,Infragistics_Guidance_Aqua_Client_Converters:clr-namespace:Infragistics.Guidance.Aqua.Client.Converters  $��Stretch=�$��Stretch=�  � 	Resources  W  QInfragistics.Guidance.Aqua.Client.Converters.AvailableSizeToItemsPerPageConverter (  $AvailableSizeToItemsPerPageConverter  SeriesColor �� 
TargetType'  !Infragistics.Windows.Chart.Series �� Property �� Value  XCLBItemTemplate  RadiologyCarouselStyle6  0Infragistics.Windows.Controls.XamCarouselListBox �� 
TargetType ��Name ��Name J� SnapsToDevicePixels  RadiologyNavigatorStyle:  4Infragistics.Windows.Controls.CarouselPanelNavigator �Name	 � ColumnDefinitions
 � RowDefinitions ��Name �� RelativeSource T� X T� Y �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle � Cursor ��Name �� Stretch J� Opacity J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName��%�	  &	        &	      &	 s     &	 �     &	 x      �� "  .���  �@ Stroke
 � � ���  �@ StrokeThickness$ 4Q���  �@ Fill
 � � ��� .R�� .+��� ���#FFFFFF�� $��54��$��50��$��Stretch=�$��Stretch=�$��2,2,2,2q����� *Image+�� "  .���  � �� �� "  .R�� #��z��.+��� .u��� $ Border��#��z��#��z��#��z��._��� $ ItemsPresenter��# z �� "  .���  � ��$ Right=���  � ��$ Bottom=���  � �� �� "  .R�� $ gridButtons��$��Stretch=�$��0,0,0,0q�$��Stretch=�$
��Auto��$
��Auto��	 �� $��14 ��� �� $��14 �
 �� .+��� $ navigateLineRight��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��$7��1igWin:XamCarouselPanelCommands.NavigateToNextItem��$��2������ *CarouselPanel+ �� *TemplatedParent+z�V� .~�T� $ 0Q�$ 0Q��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� $ 0Q�$ 0Q�T� $ 0Q�$ 0Q����� " ��.���  � �� �� " ��.R�� $ arrowButton��$��Stretch=�$��0q�$��Stretch=�$
 Hand��.+��� $ 	rectangle�����	#FF666666$��Stretch=�$��Stretch=���Z� F� $��Center=�$��Center=�$
��11.3��$	��5.6��$
 Fill=�$ 1Q�����p��q   �}x@S��q   �}x@   �}�~@�/N   �}�~@�/N�   �}�~@�/N��q   ���x@��q   ���x@S��q   ���x@��q   �}x@��q   �}x@	���#ffffff$ 0.5,0.5&�z�V� .~��� $ -1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T�  P�  �@J�IsMouseOver . . ��� $ 	rectangle�� � �� �	#FF434343P�  � �� . �� $ navigateLineLeft��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��$;��5igWin:XamCarouselPanelCommands.NavigateToPreviousItem��$��0������ *CarouselPanel+ �� *TemplatedParent+z�V� .~�T� $ 0Q�$ 0Q��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� $ 0Q�$ 0Q�T� $ 0Q�$ 0Q����� " ��.���  � �� �� " ��.R�� $ arrowButton��$
 Hand��$��Stretch=�$��0q�$��Stretch=�.+��� $ 	rectangle�����	#FF666666$��Stretch=�$��Stretch=���Z� F� $��Center=�$��Center=�$
��11.3��$	��5.6��$
 Fill=�$ 1Q�����p��q   �}x@S��q   �}x@   �}�~@�/N   �}�~@�/N�   �}�~@�/N��q   ���x@��q   ���x@S��q   ���x@��q   �}x@��q   �}x@	���#ffffff P�  �@J�IsMouseOver . . ��� $ 	rectangle�� � �� �	#FF434343P�  � �� . .��� .+�1  +Infragistics.Windows.Controls.XamTabControl  -     Name$ XamTabTestResults��.@�-  'Infragistics.Windows.Controls.TabItemEx  $	��Lab��.��4  .Infragistics.Windows.DataPresenter.XamDataGrid  -     Name$ xdgTests��$��0��$��1��$��2��:  4Infragistics.Windows.DataPresenter.DataPresenterBase   GroupByAreaLocation$
 None=�    ScrollingMode$  	Immediate=�!   AutoFit�	  �Infragistics.Windows.Helpers.NullableConverter`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]$
! True	 "   
DataSource" �� *DistinctLabTests+#   FieldLayoutSettings# <
  6Infragistics.Windows.DataPresenter.FieldLayoutSettings
  $ 
  AutoGenerateFields$$ FalseY�% 
  FixedFieldUIType$
% None=�&   FieldSettings& 6  0Infragistics.Windows.DataPresenter.FieldSettings  '   	AllowEdit$' False	 (   FieldLayouts( 4  .Infragistics.Windows.DataPresenter.FieldLayout  )   Fields) .  (Infragistics.Windows.DataPresenter.Field  *   Name$
* Type��+   Label$
+ Name��,   FixedLocation$, FixedToNearEdge=�  $��	Radiology��.��� 
 �� �� $��75 �.+��� ���	#FFD6D6D6���	#FF666666$��1��  -   -  Name$- XCLBRadiology��#��[ $��	11,0,13,0q�#���  $��1������ *RadiologyTests+.   SelectedItem. �� *SelectedRadiologyTest+/ �� Mode$/ TwoWay=�0   ViewSettings0 8  2Infragistics.Windows.Controls.CarouselViewSettings  1   ItemSize$1 58,58��!2   ReserveSpaceForReflections2 .  !3   AutoScaleItemContentsToFit3 . 4   IsNavigatorVisible4 .  "5   ItemPathHorizontalAlignment$5 Stretch=�6   
UseScaling6 .  7   ItemPathPrefixPercent$
7 0.05Q�8   ItemPathSuffixPercent$
8 0.05Q�9   IsListContinuous9 . :   ItemPath: �� ; �� ElementName$; horizontalPath��$/ OneWay=�<   ItemsPerPage< �� *ActualWidth+= �� 	Converter#= [  > �� ConverterParameter$> 65��$; XCLBRadiology��$/ OneWay=�? �� FallbackValue$? 5��F� -   @ F�Name$@ horizontalPath�����#ffffff$
 Fill=�$��32,0,65,104q�$��Bottom=�$��0��$y�	Collapsed=����� H���6�@�/��6	�� -   $ btnNavigatePrev��$
��Left=�$��14��$��0��$��1��z�V� .~�T� $ 0Q�$ 0Q��� $ 1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� $ 0Q�$ 0Q�T� $ 0Q�$ 0Q����� " ��.���  � �� �� " ��.R�� $ arrowButton��$
 Hand��$��Stretch=�$��0q�$��Stretch=�.+��� $ 	rectangle�����	#FF666666$��Stretch=�$��Stretch=���Z� F� $��Center=�$��Center=�$
��11.3��$	��5.6��$
 Fill=�$ 1Q�����p��q   �}x@S��q   �}x@   �}�~@�/N   �}�~@�/N�   �}�~@�/N��q   ���x@��q   ���x@S��q   ���x@��q   �}x@��q   �}x@	���#ffffff P�  �@J�IsMouseOver . . ��� $ 	rectangle�� � �� �	#FF434343P�  � �� . �� -   $ btnNavigateNext��$��Right=�$��14��$��0��$��1��$ 0.5,0.5&�z�V� .~��� $ -1Q�$ 1Q��� $ 0Q�$ 0Q��� $ 0Q�T� ���� " ��.���  � �� �� " ��.R�� $ arrowButton��$
 Hand��$��Stretch=�$��0q�$��Stretch=�.+��� $ 	rectangle�����	#FF666666$��Stretch=�$��Stretch=���Z� F� $��Center=�$��Center=�$
��11.3��$	��5.6��$
 Fill=�$ 1Q�����p��q   �}x@S��q   �}x@   �}�~@�/N   �}�~@�/N�   �}�~@�/N��q   ���x@��q   ���x@S��q   ���x@��q   �}x@��q   �}x@	���#ffffff P�  �@J�IsMouseOver . . ��� $ 	rectangle�� � �� �	#FF434343P�  � �� . �� $��Center=�$	��Top=�A �� Orientation$A 
Horizontal=�$��	10,10,0,0q�.+��� -   B ��Name$B txtTestType��$
��Left=�$��0,0,5,0q�$��12(�$
��Bold"����	#FFFF9900$
��Wrap=�$��Center=����� *SelectedRadiologyTest.Type+�� -   $B txtTestTimestamp��$
��Left=�$
��Wrap=����	#FF666666$��Center=����� *!SelectedRadiologyTest.Timestamp+�� $��20,40,20,20q����	#FFEA2727���	#FF5D5959._�� $��0,0,0,0q����	#FF000000.+��� $	��500��$	��500������ C �� Path$!C SelectedRadiologyTest.Image��� ���	#FF797777$��Stretch=�$��1,1,1,1q���Z�   $��
Cardiology��.��)  #Infragistics.Windows.Chart.XamChart  -	   D  Name$D XCVitalsMaximized��$��1��$��0��
���   �
��� � �$��0q�E   LegendE '  !Infragistics.Windows.Chart.Legend  F   VisibleF .  G   AxesG %  Infragistics.Windows.Chart.Axis  H   AxisType$H PrimaryY=�I   	AutoRangeI .  J   Minimum$	J -30Q�K   Maximum$K 60Q�L   Unit$L 10Q�M   LabelM &   Infragistics.Windows.Chart.Label  N   
Foreground
N � � �O   MajorGridlineO %  Infragistics.Windows.Chart.Mark  P   StrokeThickness$P 1Q�Q   MajorTickMarkQ   $P 0Q�  $H PrimaryX=�I .  $J 0Q�$	K 100Q�$L 20Q�R   StrokeThickness$R 1Q�S   Stroke
S �����O   T   VisibleT .  M   U   VisibleU .  V   SeriesV   -
   W  Name$W Series1��X   	ChartType$
X Line=�#��[ Y   DataMapping$Y 	EKGValues��Z   
DataSourceZ �� *	EKGData+[   Scene[ &   Infragistics.Windows.Chart.Scene  \   Margin$\ 0q�]   
MarginType$] Percent=�^   GridArea^ )  #Infragistics.Windows.Chart.GridArea  _   
MarginType$_ Percent=�`   Margin$` 6,6,3,6q�