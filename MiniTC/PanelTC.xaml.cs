using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTC
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public string LabelPathContent {
            get { return (string)GetValue(LabelPathContentProperty); }
            set { SetValue(LabelPathContentProperty, value); }
        }
        public static readonly DependencyProperty LabelPathContentProperty = DependencyProperty.Register(
            nameof(LabelPathContent), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public string TextBoxText {
            get { return (string)GetValue(TextBoxTextProperty); }
            set { SetValue(TextBoxTextProperty, value); }
        }
        public static DependencyProperty TextBoxTextProperty = DependencyProperty.Register(
            nameof(TextBoxText), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public string LabelDriveContent {
            get { return (string)GetValue(LabelDriveContentProperty); }
            set { SetValue(LabelDriveContentProperty, value); }
        }
        public static DependencyProperty LabelDriveContentProperty = DependencyProperty.Register(
            nameof(LabelDriveContent), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public int ComboBoxSelectedIndex {
            get { return (int)GetValue(ComboBoxSelectedIndexProperty); }
            set { SetValue(ComboBoxSelectedIndexProperty, value); }
        }
        public static DependencyProperty ComboBoxSelectedIndexProperty = DependencyProperty.Register(
            nameof(ComboBoxSelectedIndex), typeof(int), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public string[] ComboBoxItemsSource {
            get { return (string[])GetValue(ComboBoxItemsSourceProperty); }
            set { SetValue(ComboBoxItemsSourceProperty, value); }
        }
        public static DependencyProperty ComboBoxItemsSourceProperty = DependencyProperty.Register(
            nameof(ComboBoxItemsSource), typeof(string[]), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public string ComboBoxSelectedItem {
            get { return (string)GetValue(ComboBoxSelectedItemProperty); }
            set { SetValue(ComboBoxSelectedItemProperty, value); }
        }
        public static DependencyProperty ComboBoxSelectedItemProperty = DependencyProperty.Register(
            nameof(ComboBoxSelectedItem), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public static readonly RoutedEvent DropDownOpenedEvent = 
            EventManager.RegisterRoutedEvent(nameof(DropDownOpened), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelTC));
        public event RoutedEventHandler DropDownOpened
        {
            add { AddHandler(DropDownOpenedEvent, value); }
            remove { RemoveHandler(DropDownOpenedEvent, value); }
        }
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            ComboBoxItemsSource = Directory.GetLogicalDrives();
        }
        public ObservableCollection<string> ListBoxItemsSource {
            get { return (ObservableCollection<string>)GetValue(ListBoxItemsSourceProperty); }
            set { SetValue(ListBoxItemsSourceProperty, value); }
        }
        public static DependencyProperty ListBoxItemsSourceProperty = DependencyProperty.Register(
            nameof(ListBoxItemsSource), typeof(ObservableCollection<string>), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public int ListBoxSelectedIndex {
            get { return (int)GetValue(ListBoxSelectedIndexProperty); }
            set { SetValue(ListBoxSelectedIndexProperty, value); }
        }
        public static DependencyProperty ListBoxSelectedIndexProperty = DependencyProperty.Register(
            nameof(ListBoxSelectedIndex), typeof(int), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public string ListBoxSelectedItem {
            get { return (string)GetValue(ListBoxSelectedItemProperty); }
            set { SetValue(ListBoxSelectedItemProperty, value); }
        }
        public static DependencyProperty ListBoxSelectedItemProperty = DependencyProperty.Register(
            nameof(ListBoxSelectedItem), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null)
        );
        public PanelTC()
        {
            InitializeComponent();
        }
    }
}
