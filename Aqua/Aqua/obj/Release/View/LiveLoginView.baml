   M S B A M L   `   `   `  ����   Infragistics.Guidance.Aqua:    4Infragistics.Guidance.Aqua.Client.View.LiveLoginView   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    >d2http://schemas.microsoft.com/expression/blend/2008    Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    $	��440��$	��350��  � 	Resources     SignInButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType J� Opacity �� Stretch �� 
StartPoint �� EndPoint	 � Color
 � Offset J� SnapsToDevicePixels �� Triggers P� Property P� Value��%  &	        �� " ��.���  �@�Cursor$
 Hand����  � �� �� " ��.R�� ��Z� .+�� $��77��$��31��$ 1Q�$��0,0,0,0q�$
��Left=�$	��Top=�.+�F� $��0,0,0,0q�$
��Left=�$	��Top=�$��31��$��77��$
 Fill=�$ 1Q������        �        �����    ��@���@����@���@�@f@�@f�@�@f �� ��� ��    	���� $ 0.441,0.032&�$ 0.441,1.129&���� � $	 	#FFff6b02��$
 0Q�� $	 	#FFff6b02��$
 0.177Q�� $	 	#FFfbcc5e��$
 0.983Q�F� $��1,1,0,0q�$
��Left=�$	��Top=�$��1��$��59��$
 Fill=�$	 0.4Q�d����@B @B �@B @B  �� ��� ��@B  ����  ���� � ���� �� �� �@B �� 	���#ffffffF� $��1,2,0,0q�$
��Left=�$	��Top=�$��29��$��1��$
 Fill=�$ 1Q�������R h� ��R h� �% h� �% h� ��% h� �% ���% ����% ���R ���R ����R ���R h� �R h� 	���� $	 0,0&�$	 0,1&���� � $	 	#66ffffff��$
 0Q�� $	 	#17ffffff��$
 1Q��� $��Center=�$��Center=�# z ��. $��0,1,5,0q� P�  �@J�	IsFocused . P�  �@��IsDefaulted . P�  �@J�IsMouseOver . P�  � �� . P�  � {� .  ��  � ��$ 
GothamBold)���  � ��$ 13(���  � ��
 �����.���  � ColumnDefinitions �� $
��100* ��� $
��246* � � RowDefinitions �� $��32 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $	��121 ��� .+��� ���	#FF00B5EE$��2,0,2,2q�$��2��$��5��
�������$��1��� $��Center=�$��2��$��0��$��2�� �� $��75 ��� $	��225 � �� $��30 ��� $��30 �.+��� -    ��Name$ lbluserName��$��Right=�$��	UserName:��$��Center=�$��0,0,6,0q��� -    ��Name$ txtUserName��$��Center=�$	��220��$��1���� -   $ lblPassword��$��Right=�$��	Password:��$��Center=�$��0,0,6,0q�$��1��G� -    G�Name$ txtPassword��$��Center=�$	��220��$��1��$��1��9� $��5��$��0��$��2��$
��Left=�$	��Top=�$��20,40,20,-70q�$
��Auto��$	��310��$��Login Information�� 9� ExpandDirection$
 Down=�.���� ���	#FF00B7F0 �� CornerRadius$ 2��$��2q�._�� 
�������.+���  �� TextAlignment$
 Left=�$
��Wrap=�$��6,6,6,4q���This screen takes a LiveID and password as a login, but does not validate it. We are using an internal UserName and Password combination. To disable this login screen, update the ShowLogin attribute in the app.config to False. However, disabling the login will cause the Live contact chat in the Diagnosis Support Panel to be disabled.�� -    ��Name$ Loginbtn��$��5��$��0q� �� 	IsDefault . $	��Top=�$
��Left=�$��Sign In��#���   $��1���� $��4��$��1��$��	0,20,10,0q�$��Stretch=�$	��Top=��� .��� ���#00B7F0$�Forgot my password?���� -    ��Name$ cbRememberMe��$��1��$��4��$��
0,45,10,60q�$"��Remember me on this computer���� -   $ cbRememberPass��$��1��$��4��$��	0,70,10,0q�$��16��$	��Top=�$��Remember my Password��� -    �Name$ header�� . $��1��$��0q�$��2����Z�  �� $��* ��� $��13 �.+��� ���	#FF00B7F0F� -	    F�Name$	 p50��$��50��$��13��$
 Fill=�$ 1Q������@�%@#�@�%@#���@#���@#Ӏ��@#���   �(�O@���   �(�O@S���   �(�O@    \�~@�2
    \�~@�2
�    \�~@�2
@�%�2
@�%�2
�@�%�2
@�%@#@�%@#	$��1��$y�	Collapsed=����� $. (12.300246018629808,-0.000001983642578125&�$, &-12.300246018629808,0.5973309326171875&���� � $	 	#FF00b7f0��$
 0Q�� $	 	#FF00b7f0��$
 0.949999988079071Q�� $	 	#FF00b7f0��$
 0.9833329916000366Q��� ���	#FF73D9F7$��1,1,0,0q�$��1��$	��Top=�F� -
   $	 p32��$��32��$
��Auto��$
 Fill=�$ 1Q������@�%�z��@�%�z�����z�����z�Ӏ���z�����������Ӏ�����,�2
�,�2
��,�2
@�%�2
@�%�2
�@�%�2
@�%�z�@�%�z�	$��1��$��0q����� $. (12.300246018629808,-0.000001983642578125&�$, &-12.300246018629808,0.5973309326171875&���� � $	 	#FF00b7f0��$
 0Q�� $	 	#FF00b7f0��$
 0.949999988079071Q�� $	 	#FF00b7f0��$
 0.9833329916000366Q��� -   $ 
textBlock1��$��13.493,7.38,0,0q�$��Sign In��$	��Top=�$ Center=�$��14(�$
��Bold"�$��18.62��$
��Left=�
��������� $��Center=�$��	0,31,0,23q�$	��Top=�$	��228��$��56��$��1��$;��5/Infragistics.Guidance.Aqua;Component/Images/Logo.png��$
��Fill=�$��2��