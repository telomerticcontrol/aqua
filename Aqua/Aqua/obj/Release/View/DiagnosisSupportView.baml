   M S B A M L   `   `   `  ����   Infragistics.Guidance.AquaA    ;Infragistics.Guidance.Aqua.Client.View.DiagnosisSupportView   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    d `Infragistics3.Wpf.v9.1, Version=9.1.20091.2023, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb/	igWindowshttp://infragistics.com/Windows  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � 	Resources   �� 
TargetType   ChatTextBlockStyle �� Property �� Value  ContactTemplate ��Name  XpsComboBoxItemTemplate  XCLBItemTemplate  ContactItemTemplate � ColumnDefinitions J� Opacity �� TextAlignment �� Stretch	 �� 
StartPoint
 �� EndPoint � Color � Offset $  ContactCondensedViewItemTemplate  TabItemFocusVisual �� StrokeDashArray J� SnapsToDevicePixels  TabControlNormalBorderBrush �� Color  ButtonNormalBackground 	 TabItemHotBackground 
 TabItemSelectedBackground  TabItemHotBorderBrush  TabItemDisabledBackground  TabItemDisabledBorderBrush  LiveContactsTabItemStyle �� 
TargetType �Name ��Name �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value  LiveContactsTabControlStyle-  'System.Windows.Input.KeyboardNavigation   TabNavigation ��Name � RowDefinitions ��Name,  &Infragistics.Windows.Controls.XamPager ��Name K� IsItemsHost  K� ZIndex!   TabIndex" ��Name#   DirectionalNavigation  SendChatButtonStyle  ImageCarouselItemTemplate$ �� Orientation # ContactsListCondensedItemsPanel% $� Orientation��%|  &	        &	 =     &	     &	 ~    &	     &	 �    &	 �	    &	 �	    &	 
    &		 �
    &	
 %    &	 8    &	 K    &	 ^    &	 s    7  7  7  &	 k    7  &	 @    &	 �    &	 �    �� " ��.���  � ��
 �   ���  � ��$
 Wrap=��� .R��� 
�������$��50��$	��200��._�� .+��� $	��100��$	��100��$
��Left=����� *ProfileImage+�� $ txtName��$��60,0,0,0q�$
��Left=����� *Name+�� $��Online��$��Right=�$��0,0,0,10q��� .R��� 
�������._�� .+��� $ txtName��$��2,0,0,0q�$
��Left=����� *Name+�� .R�� $
��Auto��$
��Auto��.+��� ���#FFFFFF�� $
��Auto��$
��Auto��$��Stretch=�$��Stretch=�$��2,2,2,2q����� *	ItemUri+�� .R�� $��0q�$��Stretch=�$
��Auto��$��64�����	#00000000 �� $��96 ��� .+��� $��19.417,19,0,0q�$
��Left=�$	��Top=�$ 1Q�$
��Wrap=�$��12(�$��
GothamBook)�$
 left=����#333333$
��Bold"�$��1������ *Name+F� $��0q�$
��Left=�$��Stretch=�$
��Auto��$��96��$
 Fill=�$ 1Q������ d@�j� d@�j )�@�� )�@��� )�@�� d@�v d@�v� d@�v d�!' d�!'� d�!' Q%�!' Q%�!'� Q%�!' Q%��� Q%���� Q%��� d��� d���� d��� d@�j d@�j	���#a2a2a2$��1������ $ 	 0.4791666666666667,0.15625&�$
 0.4791666666666667,0.75&���� � $ 	#FFffffff��$ 0Q�� $ 	#FFEBEBEB��$ 0.9944000244140625Q�� $ 	#FFebebeb��$ 1Q��� $��	20,42,0,0q�$
��Left=�$	��Top=�$ 1Q�$
��Wrap=�$��12(�$��
GothamBook)�$
 left=����#81b30d$��Online��$��1��F� $��	64,37,0,0q�$
��Left=�$	��Top=�$��15��$��18��$
 Fill=�$ 1Q������p�0 �[�    fGg@ �[@�    �Ss@@�0���@�0��@����@����S@�    M�s@    fGg@��p�0���p�0��@�C��@�C���@�C���mb��@�mb��@��mb��@   @�h@��   @�h@���   @�h@�������������    �8i@����    M�s@�������������0����0��S��    �Ss@    �8i@ �[��� �[Ӑ�� �[p�0 �[p�0 �[	$��1������ $	 0.6111111111111112,-0.2&�$+
 %0.6111111111111112,0.9577189127604167&���� � $ 	#FFbdea22��$ 0Q�� $ 	#FF9cc130��$	 0.5Q�� $ 	#FF77ae01��$ 0.5009999871253967Q�� $ 	#FF9cc130��$ 1Q�� $��4,4,0,4q�$��Center=�.+��� ���	#FFDFDFDF��Z� �� $
��Auto��$
��Auto��$��Stretch=�$��1q�$��Uniform=�$��80������ *ProfileImage+�� .R��� $��50��$��50��
����������	#FFDFDFDF$��1q�$��0,0,5,0q�._��� $
��Auto��$
��Auto��$��Stretch=�$��0q�$��UniformToFill=����� *ProfileImage+�� .���  � �� �� .R��� 
���   �$	 1 2R�$��1��$��3,3,3,1q� . �� $ #8C8E94���� $	
 0,1&�$		 0,0&�.��� $ #F3F3F3��$ 0Q�� $ #EBEBEB��$	 0.5Q�� $ #DDDDDD��$	 0.5Q�� $ #CDCDCD��$ 1Q��� $	
 0,1&�$		 0,0&�.��� $ #EAF6FD��$
 0.15Q�� $ #D9F0FC��$ .5Q�� $ #BEE6FD��$ .5Q�� $ #A7D9F5��$ 1Q��� $ #F9F9F9���� $ #3C7FB1���� $ #F4F4F4���� $ 	#FFC9C7BA���� " ��.���  �@�FocusVisualStyle8   ��  � ��
 �   ���  � ��$ 6,1,6,1q���  � ��8  ��  � ��8  ��  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R�� $
 grid�� . $��0,0,0,16q�.+��� $ Content��# z $��Header����. $��Stretch=�$��5,4,0,4q� P�  �@J�IsMouseOver . P�  �@��
IsSelected . . ���  �@K�ZIndex$ 1���� $
 grid�� � �� �	#FFBFBFBF]�  ��  �@��
IsSelected .  ��  �@J�IsMouseOver . P�  �@��TabStripPlacement$ Bottom=�P�  �@��TabStripPlacement$
 Left=�P�  �@��TabStripPlacement$ Right=�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$	 Top=�./���  � ��$ -2,-2,-2,-1q��� $ Content�� � ��$ 0,0,0,1q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$ Bottom=�./���  � ��$ -2,-1,-2,-2q��� $ Content�� � ��$ 0,1,0,0q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$
 Left=�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$ Right=�./���  � ��$ -1,-2,-2,-2q��� $ Content�� � ��$ 1,0,0,0q�P�  � {� .  . ��� # � �� � ���� " ��.���  � ��# � ����  � ��$ 4,4,4,4q���  � ��$ 1q���  � ��8   ��  � �� �#F9F9F9��  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R�� }�.  . $ Local=� �� $ ColumnDefinition0���� $ ColumnDefinition1��$��0 � �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+�  ��. $
��Auto=�$��0��$��0��.���� $ HeaderPanel��$��2,2,2,0q� . $  1��$! 1����. �� $" ContentPanel��$��0��$��1��$# 	Contained=�$! 2��$ Local=�#��z��#��z��#��z�� P�  �@��TabStripPlacement$ Bottom=�. ��� $ HeaderPanel�� � ��$ 1���� $ ContentPanel�� � ��$ 0���� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$
 Auto ��� $ HeaderPanel�� � ��$ 2,0,2,2q�P�  �@��TabStripPlacement$
 Left=�. ��� $ HeaderPanel�� � ��$ 0���� $ ContentPanel�� � ��$ 0���� $ HeaderPanel�� � ��$ 0���� $ ContentPanel�� � ��$ 1���� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$ 0 ��� $ HeaderPanel�� � ��$ 2,2,0,2q��� $ ColumnDefinition0�� � ��$	 269 ��� $ ColumnDefinition1�� � ��$ * �P�  �@��TabStripPlacement$ Right=�. ��� $ HeaderPanel�� � ��$ 0���� $ ContentPanel�� � ��$ 0���� $ HeaderPanel�� � ��$ 1���� $ ContentPanel�� � ��$ 0���� $ ColumnDefinition0�� � ��$ * ��� $ ColumnDefinition1�� � ��$
 Auto ��� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$ 0 ��� $ HeaderPanel�� � ��$ 0,2,2,2q�P�  � {� .  . ��� # � �� � ���� " ��.���  � �� �� " ��.R�� ��Z� .+�F� $��0,0,0,0q�$
��Left=�$	��Top=�$��28��$��73��$
 Fill=�$ 1Q�l����        �        P�, ?�P�, ?��P�, ?�@�Y ?�@�Y ?��@�Y ?�@�Y@�Y�@�Y    	���	#35000000$��1������ $	 0.5,0&�$
 	0.5,0.599&���� � $ 	#FFffffff��$ 0Q�� $ 	#FFEBEBEB��$ 0.994Q�� $ 	#FFebebeb��$ 1Q��� $
��left=�$��31.664,6,0,0q�$	��top=�# z ��.  P�  �@J�	IsFocused . P�  �@��IsDefaulted . P�  �@J�IsMouseOver . P�  � �� . P�  � {� .  ��  � ��$ 
GothamBook)���  � ��$ 12(���  � �� �	#FF333333�� .R��� ._��  �� $��20 ���  �� .+��� $$ 
Horizontal=�$��Center=�.+��� $ txtTestType��$
��Left=�$��0,0,5,0q�$��12(�$
��Bold"����	#FFFF9900$
��Wrap=�$��Center=����� *Type+�� $ txtTestTimestamp��$
��Left=�$
��Wrap=����	#FF666666$��Center=����� *	Timestamp+�� $��1��$��1��$	��200��$	��200��$��Center=�$��Center=����� *Image+�� .R�$�  . $% 
Horizontal=�.��� 
������� �� $
��0.5* ��� $
��0.5* � �� $
��0.5* ��� $
��0.5* �.+��� -   & ��Name$& ContactsListBox��$ 0Q�#��[ $��0��$��0��y��� *MaximizedStateVisibility+���� *LiveContacts+�� -   $& ContactsListBoxNormal��#���  $��0��$��0��$��2��$��2��#���  y��� *NormalStateVisibility+���� *LiveContacts+1  +Infragistics.Windows.Controls.XamTabControl  -   '  Name$' 
xamTabChat��$��Stretch=�$��Stretch=�$��0��$ 0Q�( J� IsHitTestVisible( .  y��� *MaximizedStateVisibility+� -   $ ImageLibraryContainer��$��1��y��� *MaximizedStateVisibility+ �� �� $	��106 � �� $��22 ��� .+��� ���	#FF666666$	��Top=�$��13��$��2���� ���	#FFA5A5A5$	��Top=�$��1��$��0,11,0,0q�F� $��22��$
 Fill=�$ 1Q�������r8 +#��r8 +#   ���@��#   ���@��#�   ���@��# c�?��# c�?��#� c�?��# c�?@Rd" c�?@Rd"� c�?@Rd"�r8@Rd"�r8@Rd"��r8@Rd"�r8 +#�r8 +#	���#666666$	��121��$��Right=�$��2���� ���	#FFA5A5A5$��Bottom=�$��1��$��Right=�$��0,0,1,1q�$	��104��$��1���� $��Center=�$��Center=�$��1��
�������$��Image Library��$
��Wrap=��� ���	#FF666666$��Right=�$��5��$��1��$��2��F� $
 Fill=�$��Right=�$��0,0,5,0q�$��1��$��1�����Ѐ��`�S р��`ֆ	���	#FFCCCCCC$��2��� $��1��$��2��$
��20,0q�.+�6  0Infragistics.Windows.Controls.XamCarouselListBox  -   )  Name$) ImageCarousel��#��[ $��	15,0,14,0q�$	��Top=����� *ImageLibraryItems+*   ViewSettings* 8  2Infragistics.Windows.Controls.CarouselViewSettings  +   ItemPathAutoPad+ .  ,   ItemPathStretch$
, Fill=�!-   ReserveSpaceForReflections- .  .   ItemSize$. 250,250��/   IsNavigatorVisible/ .  !0   AutoScaleItemContentsToFit0 . 1   ItemsPerPage$1 3��2   ItemPathPadding$2 0q�3   
UseOpacity3 . 4   ItemPath4 �� 5 �� ElementName$5 horizontalPath��6 �� Mode$6 OneWay=�7   ScalingEffectStops7 5  /Infragistics.Windows.Controls.ScalingEffectStop  .  (Infragistics.Windows.Controls.EffectStop8   Value$	8 0.3Q�  9   Offset$	9 0.5Q�$8 1Q�  $9 1Q�$	8 0.3Q�:   OpacityEffectStops: 5  /Infragistics.Windows.Controls.OpacityEffectStop  $9 0Q�$8 0Q�  $	9 0.2Q�$8 0Q�  $
9 0.45Q�$8 1Q�  $
9 0.55Q�$8 1Q�  $	9 0.8Q�  $9 1Q�$8 0Q��� -   ; ��Name$; btnNavigatePrev��$
��Left=�$��14��$��	0,80,0,95q�$	 0.5Q�z�V� .~�T� < T� X$< 0Q�= T� Y$= 0Q��� > �� ScaleX$> 1Q�? �� ScaleY$? 1Q��� @ �� AngleX$@ 0Q�A �� AngleY$A 0Q��� B �� Angle$B 0Q�T� $< 0Q�$= 0Q�T� $< 0Q�$= 0Q����� " ��.���  � �� �� " ��.R�� $ arrowButton��C � Cursor$
C Hand��$��Stretch=�$��0q�$��Stretch=�.+��� D ��Name$D 	rectangle�����	#FF666666$��Stretch=�$��Stretch=���Z� F� $��Center=�$��Center=�$
��11.3��$	��5.6��$
 Fill=�$ 1Q�����p��q   �}x@S��q   �}x@   �}�~@�/N   �}�~@�/N�   �}�~@�/N��q   ���x@��q   ���x@S��q   ���x@��q   �}x@��q   �}x@	���#ffffff P�  �@J�IsMouseOver . . ��� $ 	rectangle�� � �� �	#FF434343P�  � �� . �� -   $; btnNavigateNext��$��Right=�$��14��E J� RenderTransformOrigin$E 0.5,0.5&�$��	0,80,0,95q�$	 0.5Q�z�V� .~��� $> -1Q�$? 1Q��� $@ 0Q�$A 0Q��� $B 0Q�T� ���� " ��.���  � �� �� " ��.R�� $ arrowButton��$
C Hand��$��Stretch=�$��0q�$��Stretch=�.+��� $D 	rectangle�����	#FF666666$��Stretch=�$��Stretch=���Z� F� $��Center=�$��Center=�$
��11.3��$	��5.6��$
 Fill=�$ 1Q�����p��q   �}x@S��q   �}x@   �}�~@�/N   �}�~@�/N�   �}�~@�/N��q   ���x@��q   ���x@S��q   ���x@��q   �}x@��q   �}x@	���#ffffff P�  �@J�IsMouseOver . . ��� $ 	rectangle�� � �� �	#FF434343P�  � �� . F� -   F F�Name$F horizontalPath�����#ffffff$
 Fill=�$��
32,0,180,0q�$	��Top=�$��0��$y�	Collapsed=�����        р��     	� -	   $ DocumentLibraryContainer��$��1��$��1��y��� *MaximizedStateVisibility+ �� �� $	��106 � �� $��22 ��� .+�� $��1��$��0,-8,0,0q�$��Bottom=�$��2�� �� $
��Auto ��� $��* �.+��� -
   G ��Name$G DocumentsComboBox��$��0��$��0��#��[ $��116,10,10,10q�$��Center=�y��� *MaximizedStateVisibility+���� *XpsLibraryItems+Z� -   H Z�Name$H 	DocReader��$��1��$��0��y��� *MaximizedStateVisibility+�� $
��Left=�$��Center=�$��1�����	#FF666666$��Active Document:��$
��Wrap=�$��8,0,0,0q��� ���	#FF666666$	��Top=�$��13��$��2���� ���	#FFA5A5A5$	��Top=�$��1��$��0,11,0,0q�F� $��22��$
 Fill=�$ 1Q�������r8 +#��r8 +#   ���@��#   ���@��#�   ���@��# c�?��# c�?��#� c�?��# c�?@Rd" c�?@Rd"� c�?@Rd"�r8@Rd"�r8@Rd"��r8@Rd"�r8 +#�r8 +#	���#666666$	��121��$��Right=�$��2���� ���	#FFA5A5A5$��Bottom=�$��1��$��Right=�$��0,0,1,1q�$	��104��$��1���� $��Center=�$��Center=�$��1��
�������$��Document Library��$
��Wrap=�� -   $ ChatContainer��$��2��y��� *MaximizedStateVisibility+ �� �� $	��106 � �� $��22 ��� .+��� 
���   �$��1q�
�������$  99��$��1��$	��100��$	��200��$��Center=�$��Center=�I �� CornerRadius$I 8��y��� *ChatDisclaimerVisibility+._��� $
��Wrap=�J �� Padding$J 8q�ecIf you want to use the Live Contact Chat, update the ShowLogin attribute in the app.config to True.  -   $' ContactsChatTab��$��	0,-10,0,0q�#���  #���  #���  $��2��$��1��K �� TabStripPlacement$
K Left=�y��� *MaximizedStateVisibility+���� *LiveContacts+� -   $ 
ChatModule��$��0��$��
276,24,9,7q�$��2��$��2��y��� *MaximizedStateVisibility+ �� �� $
��Auto �.+��� -   L ��Name$L txtChat��$��35��$
��Auto��$��1��$��0q�$��Center=����	#FF747474M �� TextWrapping$
M Wrap=�y��� *MaximizedStateVisibility+���� *
ChatText+$6 TwoWay=��� -   $; btnSend��$
��Send��$��1��$
C Hand��$��Right=�$��0,0,5,0q�#���  $��Center=�$��28��y��� *MaximizedStateVisibility+�� $��Stretch=�.���� .+��� -   $ txtChatHistory��$��0q�#���   $
��Wrap=�$
��Auto=����� *	ChatLog+�� ���	#FF666666$	��Top=�$��13��$��2���� ���	#FFA5A5A5$	��Top=�$��1��$��0,11,0,0q�F� $��22��$
 Fill=�$ 1Q�������r8 +#��r8 +#   ���@��#   ���@��#�   ���@��# c�?��# c�?��#� c�?��# c�?@Rd" c�?@Rd"� c�?@Rd"�r8@Rd"�r8@Rd"��r8@Rd"�r8 +#�r8 +#	���#666666$	��121��$��Right=�$��2���� ���	#FFA5A5A5$��Bottom=�$��1��$��Right=�$��0,0,1,1q�$	��104��$��1���� $��Center=�$��Center=�$��1��
�������$��Support Chat��$
��Wrap=��� ���	#FF666666$��Right=�$��5��$��1��$��2��F� $
 Fill=����	#FFCCCCCC$��Right=�$��0,0,5,0q�$��1��$��1��$��2�����Ѐ��`�S р��`ֆ	