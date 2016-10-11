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
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace XamarinImageUploader.iOS.iOS
{
	public partial class ViewController : UIViewController
	{
		UIImagePickerController imagePickerController;

		partial void SelectButton_TouchUpInside(UIButton sender)
		{
			imagePickerController = new UIImagePickerController();
			imagePickerController.Delegate = this;

			imagePickerController.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			imagePickerController.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

			//https://developer.xamarin.com/recipes/ios/media/video_and_photos/choose_a_photo_from_the_gallery/
			imagePickerController.FinishedPickingMedia += Handle_FinishedPickingMedia;
			imagePickerController.Canceled += Handle_Canceled;

			if (NavigationController != null)
			{
				this.PresentViewController(imagePickerController, true, null);
			}
		}

		//https://developer.xamarin.com/guides/cross-platform/advanced/async_support_overview/
		[Action("UploadButton_TouchUpInside:")]
		async void UploadButton_TouchUpInside(UIButton sender)
		{
			var imageStream = ImageView.Image.AsPNG().AsStream();

			var name = await ImageManager.UploadImage(imageStream);

			var alert = UIAlertController.Create(
				null,
				null,
				UIAlertControllerStyle.ActionSheet);
			alert.Title = "Image upload";
			alert.Message = "The image was uploaded successully. Image Name:" + name;
			alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (obj) => { }));
			this.NavigationController.PresentViewController(alert, true, null);
		}

		private void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			// determine what was selected, video or image
			bool isImage = false;
			switch (e.Info[UIImagePickerController.MediaType].ToString())
			{
				case "public.image":
					Console.WriteLine("Image selected");
					isImage = true;
					break;
				case "public.video":
					Console.WriteLine("Video selected");
					break;
			}

			// get common info (shared between images and video)
			NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
			if (referenceURL != null)
				Console.WriteLine("Url:" + referenceURL.ToString());

			// if it was an image, get the other image info
			if (isImage)
			{
				UploadButton.Enabled = true;

				// get the original image
				UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
				if (originalImage != null)
				{
					// do something with the image
					Console.WriteLine("got the original image");
					ImageView.Image = originalImage; // display
				}
			}

			// dismiss the picker
			imagePickerController.DismissViewController(true, null);
		}

		private void Handle_Canceled(object sender, EventArgs e)
		{
			imagePickerController.DismissViewController(true, null);
		}

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			UploadButton.Enabled = false;

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			switch (segue.Identifier) {
				case "listImages":
					var vc = (ImageListController)segue.DestinationViewController;
					vc.Title = "Images";
					break;
	
			}
		}
	}
}
