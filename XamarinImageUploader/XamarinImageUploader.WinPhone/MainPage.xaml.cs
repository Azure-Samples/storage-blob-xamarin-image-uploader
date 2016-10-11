/**----------------------------------------------------------------------------------
* Microsoft Developer & Platform Evangelism
*
* Copyright (c) Microsoft Corporation. All rights reserved.
*
* THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
* OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*----------------------------------------------------------------------------------
* The example companies, organizations, products, domain names,	
* e-mail addresses, logos, people, places, and events depicted
* herein are fictitious.  No association with any real company,
* organization, product, domain name, email address, logo, person,
* places, or events is intended or should be inferred.
*----------------------------------------------------------------------------------
**/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace XamarinImageUploader.WinPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StorageFile selectedImageFile;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            UploadButton.IsEnabled = false;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
            //Button.Click += delegate {
            //    var title = string.Format("{0} clicks!", count++);
            //    Button.Content = title;
            //};

           
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            CoreApplicationView view = CoreApplication.GetCurrentView();

            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;


            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");

            filePicker.PickSingleFileAndContinue();
            view.Activated += viewActivated;
        }

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var stream = await selectedImageFile.OpenReadAsync();
            
            var image = await ImageManager.UploadImage(stream.AsStreamForRead());

            MessageDialog dialog = new MessageDialog("The image was uploaded successfully!. Image name: " + image);
            await dialog.ShowAsync();
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ImagesPage));
        }

        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args)
        {
            FileOpenPickerContinuationEventArgs filePickerArgs = args as FileOpenPickerContinuationEventArgs;

            if (filePickerArgs != null)
            {
                if (filePickerArgs.Files.Count == 0) return;

                sender.Activated -= viewActivated;
                selectedImageFile = filePickerArgs.Files[0];

                var stream = await selectedImageFile.OpenReadAsync();

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(stream);

                ImageView.Source = bitmapImage;

                UploadButton.IsEnabled = true;
            }
        }
    }
}
