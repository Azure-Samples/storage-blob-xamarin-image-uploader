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

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace XamarinImageUploader.Droid
{
	[Activity (Label = "XamarinImageUploader.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        public static readonly int PickImageId = 1000;
        private ImageView imageView;
        private Android.Net.Uri imageUri;
        private Button uploadButton;
        
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            SetContentView(Resource.Layout.Main);
            imageView = FindViewById<ImageView>(Resource.Id.RootImageView);
            Button selectButton = FindViewById<Button>(Resource.Id.Select);
            selectButton.Click += SelectButtonOnClick;

            uploadButton = FindViewById<Button>(Resource.Id.Upload);
            uploadButton.Click += UploadButtonOnClick;
            uploadButton.Enabled = false;

            Button showButton = FindViewById<Button>(Resource.Id.Show);
            showButton.Click += ShowButtonOnClick;
        }

        private async void UploadButtonOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                var inputStream = ContentResolver.OpenInputStream(imageUri);

                var imageName = await ImageManager.UploadImage(inputStream);

                new AlertDialog.Builder(this)
                    .SetMessage("Image uploaded successfully!. Image name: " + imageName)
                    .SetTitle("Image upload")
                    .Show();
            }
            catch(Exception ex)
            {
                new AlertDialog.Builder(this)
                    .SetMessage("The image could not be uploaded. Error " + ex.Message)
                    .SetTitle("Image upload")
                    .Show();
            }
        }

        private void SelectButtonOnClick(object sender, EventArgs eventArgs)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);

            uploadButton.Enabled = true;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                imageUri = data.Data;
                imageView.SetImageURI(imageUri);
            }
        }

        private void ShowButtonOnClick(object sender, EventArgs eventArgs)
        {
            Intent = new Intent(this, typeof(ListImagesActivity));
            StartActivity(Intent);
        }
    }
}


