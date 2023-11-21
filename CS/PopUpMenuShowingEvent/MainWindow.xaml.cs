using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Scheduling;
using System;
using System.Windows;

namespace PopUpMenuShowingEvent {
    public partial class MainWindow : Window {
        private BarButtonItem myMenuItem;
        public MainWindow() {
            InitializeComponent();
        }
        private void scheduler_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e) {
            //Customize the cell context menu:
            if (e.MenuType == ContextMenuType.CellContextMenu) {
                PopupMenu menu = (PopupMenu)e.Menu;

                //Change the "New All Day Event" item's caption to "Create All-Day Appointment":
                for (int i = 0; i < menu.Items.Count; i++) {
                    BarItem menuItem = menu.Items[i] as BarItem;
                    if (menuItem != null) {
                        if (menuItem != null && menuItem.Name == DefaultBarItemNames.ContextMenu_Items_Cell_Actions_NewAllDayEvent) {
                            menuItem.Content = "Create All-Day Appointment";
                            break;
                        }
                    }
                }
                //Add new menu item: 
                if (!menu.Items.Contains(myMenuItem)) {
                    CreateNewItem();
                    menu.Items.Add(myMenuItem);
                }
            }
        }

        private void CreateNewItem() {
            //Create a new menu item: 
            myMenuItem = new BarButtonItem();

            myMenuItem.Name = "customItem";
            myMenuItem.Content = "Item Added at Runtime";
            myMenuItem.ItemClick += new ItemClickEventHandler(customItem_ItemClick);
        }
        private void customItem_ItemClick(object sender, ItemClickEventArgs e) {
            // Implement a custom action. 
            MessageBox.Show(String.Format("{0} is clicked", e.Item.Name));
        }
    }
}
