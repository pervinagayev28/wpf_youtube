
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
using YouTube.ConnectionApi;

namespace YouTube
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<VideoInforms> videoss { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            videoss = new();
            DataContext = this;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void changed(object sender, TextChangedEventArgs e)
        {

        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            videoss = new(VideoDatabase.Serachvideo(textbox.Text.ToString()));
            PropertyChanged!.Invoke(this, new PropertyChangedEventArgs(nameof(videoss)));
        }




       

        private void cliked(object sender, MouseButtonEventArgs e)
        {
            var item = ((Image)sender).DataContext as VideoInforms;
            var link = $@"https://www.youtube.com/watch?v={item.VideoId}";
            webView.Visibility = Visibility.Visible;
            webView.Source = new Uri(link);
        }

        private void clikedwindow(object sender, MouseButtonEventArgs e)
        {
            webView.Visibility = Visibility.Hidden;
        }
    }
}
