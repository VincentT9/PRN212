   M S B A M L   `   `   `  ����X  TMyStoreWpfApp_EntityFramework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MyStoreWpfApp_EntityFrameworkMyStoreWpfApp_EntityFramework  5   	   /    )MyStoreWpfApp_EntityFramework.AdminWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:MyStoreWpfApp_EntityFramework     5   	     � Title$  AdminWindow��5   	   $	��505��6   $	��860��6*   .��5	      ]� .+�5
   
   �� $	��Top=�6   
��� ���$��50��6>   .+�5      �� $��Quản trị MyStore��6   $��30(�6/   5      �� 5   
   $��Bottom=�6   
���� ��$��30��6B   .+�5      �� $4��.Được thiết kế bởi: Trần Thị Héo��6   $��15(�6>   5      R� 5   
   -   5         R�Name$ 
tvCategory��5      $��20(�6'   $
��Left=�65   
����� �$	��300��6]   5      ]� 5   
   
���  ��.+�5      �� -   5         ��Name$ 	lvProduct��5   ,   $	��Top=�6   $��22(�6j   $��2��6y   $	��200��6�    �� View 5      �� 5      .P�5      �� $��Mã sản phẩm��6)    �� DisplayMemberBinding 6>   �� *	ProductId+�� 5      $��Tên sản phẩm��6)    �� Width$	 200��6l    6?   �� *ProductName+6l   �� 5      $��Số lượng��6)    6;   �� *UnitsInStock+�� 5      $��
Đơn giá��6)    6:   �� *	UnitPrice+5      5      � 5      
��� ���.+�5       �� $��Product Id:��6   $��20(�6.   $
��Left=�6<   $��10,6,0,0q�6W   $	��Top=�6i   �� 5!      -   5         ��Name$ txtId��5!      $��20(�6)   $
��Left=�67   $��
160,12,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��390��6�   �� 5"      $��Product Name:��6   $��20(�60   $
��Left=�6>   $��	10,42,0,0q�6Y   $	��Top=�6l   �� 5#      -   5        $ txtName��5#      $��20(�6+   $
��Left=�69   $��
160,48,0,0q�6T   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��390��6�   �� 5$      $��	Quantity:��6   $��20(�6,   $
��Left=�6:   $��	10,76,0,0q�6U   $	��Top=�6h   �� 5%      -   5        $ txtQuantity��5%      $��20(�6/   $
��Left=�6=   $��
160,82,0,0q�6X   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��390��6�   �� 5&      $��Price:��6   $��20(�6)   $
��Left=�67   $��
10,109,0,0q�6R   $	��Top=�6f   �� 5'      -   5        $ txtPrice��5'      $��20(�6,   $
��Left=�6:   $��160,115,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��390��6�   �� 5(      -   5         ��Name$ btnClear��5(      $��Clear��6+   $��20(�6;   $
��Left=�6I   $��160,159,0,0q�6d   $	��Top=�6y   $��70��6�   6�   �� 5)      -   5        $ btnSave��5)      $
��Save��6*   $��20(�69   $
��Left=�6G   $��255,159,0,0q�6b   $	��Top=�6w   $��70��6�   6�   �� 5*      -	   5        $ 	btnUpdate��5*      $��Update��6,   $��20(�6=   $
��Left=�6K   $��346,159,0,0q�6f   $	��Top=�6{   $��80��6�   6�   �� 5+      -
   5        $ 	btnDelete��5+      $��Delete��6,   $��20(�6=   $
��Left=�6K   $��455,159,0,0q�6f   $	��Top=�6{   $��80��6�   6�   5,      5-      5.      5/      