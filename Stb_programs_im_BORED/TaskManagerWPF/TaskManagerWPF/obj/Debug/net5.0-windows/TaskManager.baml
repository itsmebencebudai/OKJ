   M S B A M L   `   `   `  ����  TaskManagerWPF     TaskManagerWPF.TaskManager   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Task Manager��5   	   $	��450��6   $	��600��6+   .��5      � .+�5   
   �� -   5        $��taskListBox��5      $
��Left=�6%   $	��Top=�6@   $	��400��6X   $	��300��6d   $��	22,61,0,0q�6q   ��5      �� 5      .R�5	      �� .+�5
      �� $
��Bold"�6:   ��6$   �� *Name+6:   �� 5      $��Italic$�6A   ��6$   �� *Description+6A   �� 5      ��6$   �� *	DueDate+ �� StringFormat$ Due Date: {0:dd/MM/yyyy}���� 5      ��6$   �� *
Priority+��6>   �� *
Priority+   PriorityColorConverter �� 	Converter# [  5      5      5      �� 5   
   -   5        $��Add Task��5      $
��Left=�6$   $	��Top=�6?   $��80��6W   $��30��6b   $��10q�6n   6z   5      5      