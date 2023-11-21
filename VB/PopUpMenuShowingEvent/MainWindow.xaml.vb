Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Scheduling
Imports System.Windows

Namespace PopUpMenuShowingEvent

    Public Partial Class MainWindow
        Inherits Window

        Private myMenuItem As BarButtonItem

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub scheduler_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs)
            'Customize the cell context menu:
            If e.MenuType = ContextMenuType.CellContextMenu Then
                Dim menu As PopupMenu = CType(e.Menu, PopupMenu)
                'Change the "New All Day Event" item's caption to "Create All-Day Appointment":
                For i As Integer = 0 To menu.Items.Count - 1
                    Dim menuItem As BarItem = TryCast(menu.Items(i), BarItem)
                    If menuItem IsNot Nothing Then
                        If menuItem IsNot Nothing AndAlso Equals(menuItem.Name, DefaultBarItemNames.ContextMenu_Items_Cell_Actions_NewAllDayEvent) Then
                            menuItem.Content = "Create All-Day Appointment"
                            Exit For
                        End If
                    End If
                Next

                'Add new menu item: 
                If Not menu.Items.Contains(myMenuItem) Then
                    CreateNewItem()
                    menu.Items.Add(myMenuItem)
                End If
            End If
        End Sub

        Private Sub CreateNewItem()
            'Create a new menu item: 
            myMenuItem = New BarButtonItem()
            myMenuItem.Name = "customItem"
            myMenuItem.Content = "Item Added at Runtime"
            AddHandler myMenuItem.ItemClick, New ItemClickEventHandler(AddressOf customItem_ItemClick)
        End Sub

        Private Sub customItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            ' Implement a custom action. 
            MessageBox.Show(String.Format("{0} is clicked", e.Item.Name))
        End Sub
    End Class
End Namespace
