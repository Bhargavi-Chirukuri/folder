using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App58
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            

        }
        IReadOnlyList<StorageFile> fl;
        StorageFile sf;
        private async void clickbtn_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker fp = new FolderPicker();
            fp.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fp.ViewMode = PickerViewMode.Thumbnail;
            fp.FileTypeFilter.Add(".jpg");
            fp.FileTypeFilter.Add(".png");
            fp.FileTypeFilter.Add(".jpeg");
            var file = await fp.PickSingleFolderAsync();
            fl = await file.GetFilesAsync();
            if (file != null)
            {
                StorageFile sf = fl[0];
                foreach (StorageFile images in fl)
                {
                    IRandomAccessStream str = await images.OpenAsync(FileAccessMode.Read);
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.SetSource(str);

                    fp1.Items.Add(bitmapimage);
                 

                 
                }
        
            }

        }

        private async void fp1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           // StorageFile sf = fl[0];
            FlipView fp1 = sender as FlipView;
            fp1.SelectedItem = sender;

            
           // StorageFile sf 
            {
                ImageProperties ip = await sf.Properties.GetImagePropertiesAsync();
                tb1.Text = ip.DateTaken.ToString();
            }

        }
            }
            
        }


    

    

