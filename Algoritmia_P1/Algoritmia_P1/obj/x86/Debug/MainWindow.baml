   M S B A M L   `   `   `  ����  Algoritmia_P1    Algoritmia_P1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Algoritmia_P1��5   	   $	��385��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]   .��5      � .+�5   
   � -   5        $��grid1��5   J   $	��259��6   $
��Left=�6   $��	12,57,0,0q�67   $	��Top=�6W   $	��766��6o    � ColumnDefinitions 5      �� 5      $
��691* �6#   �� 5	      $	��75* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dtListas��5   q      AutoGenerateColumns .  $	��216��63   $��Stretch=�6@   $��	22,6,16,0q�6^   $��Stretch=�6�   $	��728��6�      CanUserResizeColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6�      CanUserDeleteRows .    CanUserResizeRows .  $��Stretch=�6,  $��Stretch=�6O  $��LeftToRight=�6t  $��2��6�  	 J� 	AllowDrop	 .  
 J� IsManipulationEnabled
 .     
IsReadOnly . ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width$ 30 65     5      $ Orden��6)   $ 95 68     5      $ Nº Elementos��6)   $	 105 6?     5      $ Nº Intercambios��6)   $	 105 6B     5      $ Nº Comparaciones��6)   $	 110 6C     5      $ Tiempo (ms)��6)   $ 80 6>   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Mostrar��6-   $ 55 6>      CellTemplate 5      �� 5      .R�5   "   � .+�5   &   �� -   5        $��20��5   E   $��20��6P   
������ 
������  � ToolTip$ Mostrar��6�   .��5   *   �� $9��3/Algoritmia_P1;component/Imágenes/search_lense.ico��60   6n   5   '   5   #   5      5        5      $ Ordenado��6)   $ 65 6;     5      $ Eliminar��6-   $ 55 6?    5       �� 5!      .R�5"   "   � .+�5#   &   �� -   5        $��20��5#   F   $��20��6Q   
������ 
������ $ Eliminar��6�   .��5$   *   �� $5��//Algoritmia_P1;component/Imágenes/delete_2.ico��60   6k   5%   '   5&   #   5'      5)      5+      5,      c� 5-   
   -   5        $��tlbBarra��5-   9   $��51��6   $
��Left=�6   $	��Top=�6I   $	��778��6a   .@�5.      �� -   5        $��btCrearLista��5.   >   $��40��6   $
��Left=�6"   $��Stretch=�6R   $��45��6n   $ Crear lista��6�   .��5/      �� $1��+/Algoritmia_P1;component/Imágenes/plus.ico��6   6N   51      �� 52      -   5        $��btCargar��52   >   $��40��6   $
��Left=�6"   $��Stretch=�6N   $��45��6j   $ Cargar��6u   .��53      �� $3��-/Algoritmia_P1;component/Imágenes/folder.ico��6   6P   54      �� 55      -	   5        $��	btGuardar��55   >   $��40��6   $
��Left=�6"   $��Stretch=�6O   $��45��6k   $ Guardar��6v   .��56      �� $4��./Algoritmia_P1;component/Imágenes/save_as.ico��6   6Q   57      �� 58      -
   5        $��lblOrdenacion��58   ]   $��	Algoritmo��6   $��35��6(   $��90��64   $��Center=�6?   $��Stretch=�6r   $��Center=�6�   $��Right=�6�   $
��Bold"�6�   $��Cambria)�6�   �� 59      -   5        $��cmbOrdenacion��59   ?   $��28��6   $
��Left=�6#   $��Stretch=�6T   $	��110��6p   $��Center=�6|    �� 
IsEditable .  $��5q�6�   
�������$ Selecciona algoritmo��6�   .@�5:      �� $��
Inserción��6   �� 5;      $��
Selección��6   �� 5<      $��	QuickSort��6   5=      �� 5>      -   5        $��lblOrden��5>   \   $��Criterio��6   $��35��6'   $��90��63   $��Center=�6>   $��Stretch=�6l   $��Center=�6�   $��Right=�6�   $
��Bold"�6�   $��Cambria)�6�   �� 5?      -   5        $��cmbCriterio��5?   ?   $��28��6   $
��Left=�6#   $��Stretch=�6R   $	��110��6n   $��Center=�6z    .  $��5q�6�   
�������$( "Selecciona criterio de ordenación��6�   .@�5@      �� $��
Ascendente��6   �� 5A      $��Descendente��6   5B      �� 5C      -   5        $��	btOrdenar��5C   >   $��40��6   $
��Left=�6"   $��Stretch=�6O   $��45��6k   $ Ordenar��6�   .��5D      �� $<��6/Algoritmia_P1;component/Imágenes/pie-chart_graph.ico��6   6Y   5E      �� 5F      -   5        $��	btDetener��5F   >   $��40��6   $
��Left=�6"   $��Stretch=�6O   $��45��6k   $ Detener��6v   .��5G      �� $;��5/Algoritmia_P1;component/Imágenes/close_delete_2.ico��6   6Y   5H      �� 5I      -   5        $��	btLimpiar��5I   >   $��40��6   $
��Left=�6"   $��Stretch=�6O   $��45��6k   $ Limpiar��6v   .��5J      �� $4��./Algoritmia_P1;component/Imágenes/refresh.ico��6   6Q   5K      �� 5L      -   5        $��btAyuda��5L   >   $��40��6   $
��Left=�6"   $��Stretch=�6M   $��45��6i   $ Ayuda��6t   .��5M      �� $;��5/Algoritmia_P1;component/Imágenes/help_ring-buoy.ico��6   6X   5N      5O      9� 5P   
   -   5        $��	expander1��5P   m   $��Visualizar elementos��6   $	��227��61   $
��Left=�6>   $��
16,322,0,0q�6Y   $	��Top=�6~   $	��766��6�    9� 
IsExpanded .  .��5Q      � .+�5R      �� -   5        $��
tbDesorden��5R   Z   $	��180��6   $
��Left=�6+   $��	17,24,0,0q�6F   $	��Top=�6l   " �� VerticalScrollBarVisibility$
 Auto=�6�   $	��360��6�   �� 5S      -   5        $��tbOrden��5S   Z   $	��180��6   $
��Left=�6+   $��
385,24,0,0q�6F   $	��Top=�6i   $
 Auto=�6�   $	��360��6�   �� 5T      -   5        $��lblDesordenL��5T   m   $��Lista desordenada��6   $��28��64   $
��Left=�6@   $��17,1,0,0q�6[   $	��Top=�6�   $	��135��6�   �� 5U      -   5        $��	lblOrdenL��5U   k   $��Lista ordenada��6   $��28��61   $
��Left=�6=   $��	385,1,0,0q�6X   $	��Top=�6|   $	��141��6�   5V      5W      5X      5Y      