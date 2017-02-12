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

namespace PublishSolution.Desktop
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("コピーを開始しますか？") == MessageBoxResult.OK)
            {

                try
                {
                    await Solution.CopyAsync(this.data);
                    MessageBox.Show("完了");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR " + ex.Message);
                }
            } // end if
        } // end sub

        private CopySolutionSettings data;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.data = new CopySolutionSettings { ToFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) };
            this.DataContext = this.data;
        }

        private void FromButton_Click(object sender, RoutedEventArgs e)
        {
            var d = new System.Windows.Forms.FolderBrowserDialog();
            d.SelectedPath = this.FromBox.Text;
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //this.FromBox.Text = d.SelectedPath;
                this.data.FromFolder = d.SelectedPath;
            } // end if
        } // end sub

        private void ToButton_Click(object sender, RoutedEventArgs e)
        {
            var d = new System.Windows.Forms.FolderBrowserDialog();
            d.SelectedPath = this.ToBox.Text;
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //this.ToBox.Text = d.SelectedPath;
                this.data.ToFolder = d.SelectedPath;
            } // end if
        } // end sub

    } // end class
} // end namespace
