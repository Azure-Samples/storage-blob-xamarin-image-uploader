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
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace XamarinImageUploader.Droid
{
    [Activity(Label = "ListImagesActivity")]
    public class ListImagesActivity : ListActivity
    {
        string[] images;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            images = await ImageManager.ListImages();
            
            var adapter = new ArrayAdapter<string>(this, Resource.Layout.TextViewItem, images);

            ListAdapter = adapter;
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            this.Intent = new Intent(this, typeof(ImageActivity));
            this.Intent.PutExtra("image", images[position]);

            StartActivity(this.Intent);
        }
    }
}