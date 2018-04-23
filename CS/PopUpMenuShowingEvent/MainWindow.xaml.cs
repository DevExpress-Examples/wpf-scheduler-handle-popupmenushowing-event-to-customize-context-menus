using DevExpress.Xpf.Bars;
using System.Windows;
using DevExpress.Xpf.Scheduling;
using System;
using System.Linq;

namespace PopUpMenuShowingEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BarButtonItem myMenuItem;
        public MainWindow()
        {
            InitializeComponent();
        }
        #region #PopUpMenuShowing
        private void scheduler_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            //Customize the cell context menu:
            if (e.MenuType == ContextMenuType.CellContextMenu)
            {
                PopupMenu menu = (PopupMenu)e.Menu;

                //Change the "New All Day Event" item's caption to "Create All-Day Appointment":
                for (int i = 0; i < menu.Items.Count; i++)
                {
                    BarItem menuItem = menu.Items[i] as BarItem;
                    if (menuItem != null)
                    {
                        if (menuItem != null && menuItem.Content.ToString() == "New All Day Event")
                        {
                            menuItem.Content = "Create All-Day Appointment";
                            break;
                        }
                    }
                }
                //Add new menu item: 
                if  (!menu.Items.Contains(myMenuItem))
                {
                    CreateNewItem();
                    menu.Items.Add(myMenuItem);
                }
            }
        }
        #endregion #PopUpMenuShowing


        #region #NewMenuItem
        private void CreateNewItem()
        {
            //Create a new menu item: 
            myMenuItem = new BarButtonItem();

            myMenuItem.Name = "customItem";
            myMenuItem.Content = "Item Added at Runtime";
            myMenuItem.ItemClick += new ItemClickEventHandler(customItem_ItemClick);
        }
        private void customItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Implement a custom action. 
            MessageBox.Show(String.Format("{0} is clicked", e.Item.Name));
        }
        #endregion #NewMenuItem
    }
}
