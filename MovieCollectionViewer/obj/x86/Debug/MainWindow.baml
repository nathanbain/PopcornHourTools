   M S B A M L   `   `   `  ����  MovieCollectionViewer&     MovieCollectionViewer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Movie Finder��5   	   $	��405��6   $	��721��6+   $��2q�67   ���	#FFE7E4E4 � Icon$< 6/MovieCollectionViewer;component/images/movie_icon.jpg��6b   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��72* �6   �� 5      $
��623* �6   .+�5
   
   �� -   5        $��refreshCollectionBtn��5
   h   $��Refresh Collection��6   $��23��6.   $
��Left=�6:   $��	23,31,0,0q�6U   $	��Top=�6�   $	��103��6�   $��2��6�   �� 5   
   -   5        $��statusImage��5   J   $��23��6   $
��Left=�6   $��	60,31,0,0q�67   $
��Fill=�6]   $	��Top=�6l   $��23��6�   $>��8/MovieCollectionViewer;component/images/circle-green.png��6�   $��1��6�   �� 5   
   -   5        $��resultsLabel��5   �   $;��5No movies found. Click refresh to search collection..��6   $��23��6P   $
��Left=�6\   $��	89,31,0,0q�6w   $	��Top=�6�   $	��328��6�   $��1��6�   �� 5   
   -   5        $��searchCriteriaTextBox��5   L   $��19��6   $
��Left=�6   $��	36,78,0,0q�69   $	��Top=�6i   $	��326��6�   $��2��6�   �� 5   
   -   5        $��searchMoviesBtn��5   ]   $��Search��6   $��19��6"   $
��Left=�6.   $��
296,78,0,0q�6I   $	��Top=�6t   $��74��6�    �� 	IsDefault . $��1��6�   �� 5   
   -   5        $��searchResultsTextBlock��5   N   $	��247��6   $
��Left=�6   $��
12,103,0,0q�6:   $$��Click Search to find results..��6l   $	��Top=�6�   $	��671��6�   
�������$��4q�6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�6�   $��2��6$  �� 5   
   -   5        $��border1��5   v   
�������$��1q�6&   $	��247��6:   $
��Left=�6G   $��
12,103,0,0q�6b   $	��Top=�6�   $	��671��6�   }�.   � UseLayoutRounding .  $��2��6�   5      5      