Imports DevExpress.Xpf.Bars
Imports System.Windows
Imports DevExpress.Xpf.Scheduling

Namespace PopUpMenuShowingEvent

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Private myMenuItem As BarButtonItem

        Public Sub New()
            Me.InitializeComponent()
        End Sub

#Region "#PopUpMenuShowing"
        Private Sub scheduler_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs)
            'Customize the cell context menu:
            If e.MenuType = ContextMenuType.CellContextMenu Then
                Dim menu As PopupMenu = CType(e.Menu, PopupMenu)
                'Change the "New All Day Event" item's caption to "Create All-Day Appointment":
                For i As Integer = 0 To menu.Items.Count - 1
                    Dim menuItem As BarItem = TryCast(menu.Items(i), BarItem)
                    If menuItem IsNot Nothing Then
                        If menuItem IsNot Nothing AndAlso Equals(menuItem.Content.ToString(), "New All Day Event") Then
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

#End Region  ' #PopUpMenuShowing
#Region "#NewMenuItem"
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
#End Region  ' #NewMenuItem
    End Class
End Namespace
