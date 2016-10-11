// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinImageUploader.iOS.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ListButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SelectButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton UploadButton { get; set; }

        [Action ("SelectButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SelectButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ImageView != null) {
                ImageView.Dispose ();
                ImageView = null;
            }

            if (ListButton != null) {
                ListButton.Dispose ();
                ListButton = null;
            }

            if (SelectButton != null) {
                SelectButton.Dispose ();
                SelectButton = null;
            }

            if (UploadButton != null) {
                UploadButton.Dispose ();
                UploadButton = null;
            }
        }
    }
}