   M S B A M L   `   `   `  ���� U  QInfragistics.Guidance.Aqua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Infragistics.Guidance.Aqua.Client.Converters,Infragistics.Guidance.Aqua.Client.Converters  ;    5Infragistics.Guidance.Aqua.Client.View.VitalSignsView   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    j fInfragistics3.Wpf.Chart.v9.1, Version=9.1.20091.2023, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb+igCharthttp://infragistics.com/Chart  Econv:clr-namespace:Infragistics.Guidance.Aqua.Client.Converters  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  $��Stretch=�$��Stretch=�  � 	Resources  ��%    .��� 
�������.+�� y��� *MaximizedStateVisiblity+ � RowDefinitions �� $	��50* ��� $	��50* � � ColumnDefinitions �� $	��50* ��� $	��50* �.+�� -    �Name$ BPChart�� �� $��* ��� $	��146 � �� $��22 ��� $��* �.+�)  #Infragistics.Windows.Chart.XamChart  -     Name$ BPChartMaximized��$��1��$��2��$��	8,8,-8,-8q�   StartPaletteBrush ��  �� EndPoint$	 1,0&� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FFFEC044��	 � Offset$	 0Q�� $ 	#FFFF9C05��$	 0.889Q�
   Axes
 %  Infragistics.Windows.Chart.Axis     AxisType$ PrimaryX=�   Stroke �	#FFCCCCCC   StrokeThickness$ 1Q�   MajorTickMark %  Infragistics.Windows.Chart.Mark     StrokeThickness$ 0Q�   MajorGridline      Stroke
 �����   Label &   Infragistics.Windows.Chart.Label     
Foreground �	#FF333333   FontSize$ 12(�  $ PrimaryY=�   	AutoRange .     Unit$ 10Q�   Maximum$	 200Q�   Minimum$ 50Q� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�   Series '  !Infragistics.Windows.Chart.Series  -      	ChartType$ Candlestick=�   DataMapping$Q KHigh = BPHigh; Low = BPLow; Open = BPLow; Close = BPHigh; Label = Timestamp��   Stroke �	#FFE00000   
DataSource �� *
BPVitals+   	Animation *  $Infragistics.Windows.Chart.Animation     Fill �� $	 1,0&�$	 0,0&�.��� $ 	#FFFEC044��$	 0Q�� $ 	#FFFF9C05��$	 0.889Q�    Legend  '  !Infragistics.Windows.Chart.Legend  !   Visible! .  �� ���	#FF666666$	��Top=�$��13��$��2���� ���	#FFA5A5A5$	��Top=�$��1��$��	0,11,-8,0q�F� $��22��" �� Stretch$
" Fill=�# J� Opacity$# 1Q�����p��   ��}@S��   ��}@   ���@���   ���@����   ���@���   @,�@���   @,�@����   @,�@���� P%   ��}@� P%   ��}@S� P%   ��}@� P% k� P% kӀ P% k�� k�� k��� k��   ��}@��   ��}@	���#666666$��Center=�$��0q�$	��Top=�$	��131��$��1���� ���	#FFA5A5A5$��Bottom=�$��1��$��Center=�$��0,0,0,1q�$	��105��$��1���� $��Center=�$��Center=�$��1��
�������$��Blood Presure��$
��Wrap=�  -   $ RespiratoryRateChart��$��1��$y�	Collapsed=�$��1��$   Caption$ (  "Infragistics.Windows.Chart.Caption  %   Text$% Respiratory Rate��&   FontSize$& 12(�'   
Foreground
' �����   $! Value=Value;Label=Timestamp��$
 Line=� �� *RespiratoryRateVitals+(   Marker( '	  !Infragistics.Windows.Chart.Marker	  ) 	  Type$) Circle=�* 	  Fill
* �����+ 	  FontSize$+ 12(�, 	  
Foreground
, �����
   $ PrimaryX=�   
 �����$ 12(�  $ PrimaryY=� .  $ 2Q�$ 10Q�$ 22Q�   
 �����$ 12(�� -   $ 	TempChart��$��1�� �� �� $	��106 � �� $��22 ��� .+�  -   $ TemperatureChart��$��1��$��2�� �	#FFE00000
   $ PrimaryX=� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�  $ PrimaryY=� .  $ 3Q�$ 90Q�$	 110Q� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�   $
 Line=�$! Value=Value;Label=Timestamp��-   StrokeThickness$- 2Q� �� *TemperatureVitals+   ( 	  , �	#FF333333    ! .  �� ���	#FF666666$	��Top=�$��13��$��2���� ���	#FFA5A5A5$	��Top=�$��1��$��0,11,0,0q�F� $��22��$
" Fill=�$# 1Q�������r8 +#��r8 +#   ���@��#   ���@��#�   ���@��# c�?��# c�?��#� c�?��# c�?@Rd" c�?@Rd"� c�?@Rd"�r8@Rd"�r8@Rd"��r8@Rd"�r8 +#�r8 +#	���#666666$	��121��$��Right=�$��2���� $��Center=�$��Center=�$��1��
�������$��Temperature��$
��Wrap=��� ���	#FFA5A5A5$��Bottom=�$��1��$��Right=�$��0,0,1,1q�$	��105��$��1��� -   $ PulseChart1��$��1�� �� �� $	��146 � �� $��22 ��� .+�  -   $ 
PulseChart��$��1��$��Bottom=�$��2�� �	#FFE00000   $! Value=Value;Label=Timestamp��$
 Line=�$- 2Q� �� *PulseVitals+   ( 	  , �	#FF333333
   $ PrimaryX=� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�  $ PrimaryY=� .  $ 6Q�$ 60Q�$	 120Q� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�    ! .  �� ���	#FF666666$	��Top=�$��13��$��2���� ���	#FFA5A5A5$	��Top=�$��1��$��	0,11,-8,0q�F� $��22��$
" Fill=�$# 1Q�����p��   ��}@S��   ��}@   ���@���   ���@����   ���@���   @,�@���   @,�@����   @,�@���� P%   ��}@� P%   ��}@S� P%   ��}@� P% k� P% kӀ P% k�� k�� k��� k��   ��}@��   ��}@	���#666666$��Center=�$��0q�$	��Top=�$	��131��$��1���� ���	#FFA5A5A5$��Bottom=�$��1��$��Center=�$��0,0,0,1q�$	��105��$��1���� $��Center=�$��Center=�$��1��
�������$��Pulse��$
��Wrap=�� -	   $ 
PainChart1��$��1��$��1��$��Right=� �� �� $	��106 � �� $��22 ��� .+�  -
   $ 	PainChart��$��2��$��1�� �� $	 1,0&�$	 0,0&�.��� $ 	#FFFEC044��$	 0Q�� $ 	#FFFF9C05��$	 0.889Q�   $! Value=Value;Label=Timestamp��$
 Area=�$- 0Q� �� *
PainVitals+    �� $	 1,0&�$	 0,0&�.��� $ 	#FFFEC044��$	 0Q�� $ 	#FFFF9C05��$	 0.889Q�( 	  $) Circle=�$+ 12(�, �	#FF333333. 	  StrokeThickness$. 0Q�* �	#FFE00000
   $ PrimaryX=� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�  $ PrimaryY=� .  $ 0Q�$ 25Q�$ 5Q� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�    ! .  �� ���	#FF666666$	��Top=�$��13��$��2���� ���	#FFA5A5A5$	��Top=�$��1��$��0,11,0,0q�F� $��22��$
" Fill=�$# 1Q�������r8 +#��r8 +#   ���@��#   ���@��#�   ���@��# c�?��# c�?��#� c�?��# c�?@Rd" c�?@Rd"� c�?@Rd"�r8@Rd"�r8@Rd"��r8@Rd"�r8 +#�r8 +#	���#666666$	��121��$��Right=�$��2���� ���	#FFA5A5A5$��Bottom=�$��1��$��Right=�$��0,0,1,1q�$	��104��$��1���� $��Center=�$��Center=�$��1��
�������$
��Pain��$
��Wrap=��� ���	#FF666666$
��Left=�$��5��$��1��$��2��  -   $ BPChartNormal��$��Stretch=�y��� *NormalStateVisibility+    ! .   �� $	 1,0&�$	 0,0&�.��� $ 	#FFFEC044��$	 0Q�� $ 	#FFFF9C05��$	 0.889Q�
   $ PrimaryX=� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�  $ PrimaryY=� .  $ 20Q�$	 200Q�$ 50Q� �	#FFCCCCCC$ 1Q�   $ 0Q�   
 �����    �	#FF333333$ 12(�   -   $ Candlestick=� �	#FFE00000$Q KHigh = BPHigh; Low = BPLow; Open = BPLow; Close = BPHigh; Label = Timestamp�� �� *
BPVitals+    �� $	 1,0&�$	 0,0&�.��� $ 	#FFFEC044��$	 0Q�� $ 	#FFFF9C05��$	 0.889Q�$   $% Blood Pressure��$& 12(�
' �����