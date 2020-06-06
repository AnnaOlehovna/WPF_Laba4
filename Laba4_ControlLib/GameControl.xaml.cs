using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Laba4_ControlLib
{
    /// <summary>
    /// Логика взаимодействия для GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
        public GameControl()
        {
            InitializeComponent();
            MyScene.Init();

        }

        public static readonly DependencyProperty SelectedObjectInfoProperty =
            DependencyProperty.Register("SelectedObjectInfo", typeof(string), typeof(GameControl),
                new UIPropertyMetadata(string.Empty));

        public string SelectedObjectInfo
        {
            get { return (string)this.GetValue(SelectedObjectInfoProperty); }
            set { this.SetValue(SelectedObjectInfoProperty, value); }
        }

        private void Start_CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !this.MyScene.IsBusy;
        }

        private void Start_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.MyScene.Start();
        }

        private void Pause_CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.MyScene.IsBusy;
        }

        private void Pause_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.MyScene.Pause();
        }

        private void Reset_CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Reset_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.MyScene.Init();
        }

        private void WhiteHorse_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.SetBinding(SelectedObjectInfoProperty, new Binding("WhitePosition") { Source = MyScene });
        }

        private void BlackHorse_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.SetBinding(SelectedObjectInfoProperty, new Binding("BlackPosition") { Source = MyScene });
        }

        private void BrownHorse_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.SetBinding(SelectedObjectInfoProperty, new Binding("BrownPosition") { Source = MyScene });
        }

        private void Element_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            object obj = (sender as FrameworkElement).DataContext;
            this.SetBinding(SelectedObjectInfoProperty, new Binding("Speed") { Source = obj });
        }

     
    }
}
