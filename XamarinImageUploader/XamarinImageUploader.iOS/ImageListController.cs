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

using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace XamarinImageUploader.iOS.iOS
{
    public partial class ImageListController : UITableViewController
    {
        public ImageListController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			string[] tableItems = ListImages();
			this.TableView.Source = new ImagesTableSource(this, tableItems);
		}

		private string[] ListImages()
		{
			return Task.Run(() => ImageManager.ListImages()).Result;
		}
    }

	// Serves both as Delegate and DataSource
	public class ImagesTableSource : UITableViewSource
	{

		UITableViewController _parent;
		string[] TableItems;
		string CellIdentifier = "ImageTableCell";

		public ImagesTableSource(UITableViewController parent, string[] items)
		{
			_parent = parent;
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var bytes = Task.Run(() => ImageManager.GetImage(TableItems[indexPath.Row])).Result;
			var data = NSData.FromArray(bytes);
			var uiimage = UIImage.LoadFromData(data);
			ShowFullScreenImage(uiimage);
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = TableItems[indexPath.Row];

			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = item;

			return cell;
		}

		private void ShowFullScreenImage(UIImage image)
		{
			_parent.NavigationController.SetNavigationBarHidden(
				_parent.NavigationController.NavigationBarHidden == false, true);


			var newImageView = new UIImageView(image);

			newImageView.Frame = _parent.View.Frame;

			newImageView.BackgroundColor = UIColor.Black;

			newImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

			newImageView.UserInteractionEnabled = true;

			var tap = new UITapGestureRecognizer((s) => {
				s.View.RemoveFromSuperview();
				_parent.NavigationController.SetNavigationBarHidden(
					_parent.NavigationController.NavigationBarHidden == false, true);
			});
			newImageView.AddGestureRecognizer(tap);

			_parent.View.AddSubview(newImageView);
		}

	}
}