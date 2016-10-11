---
services: storage
platforms: xamarin
author: pcibraro
---

# Azure Storage Service - Photo Uploader Samples for iOS

This sample demostrates how to upload photo images from the gallery in Android, iOS and Windows Phone into a Block blob in Azure Storage with Xamarin. It shows a button "Select Image" to select 
an image from the gallery, a button "Upload Image" to upload it to the Azure Storage, a button "List images" to list all the uploaded images.

Note: This project uses a Shared Native Library for the common code for the platform specific projects. 

## Running this sample

1. Open the Configuration.cs file in the Shared Native Library Project "XamarinImageUploader" and change the "StorageConnectionString" to use the account and key provided in the Azure Portal. 

## More information
- [What is a Storage Account](http://azure.microsoft.com/en-us/documentation/articles/storage-whatis-account/)
- [How to use Blob Storage from iOS](https://azure.microsoft.com/en-us/documentation/articles/storage-ios-how-to-use-blob-storage/)
- [Blob Service Concepts](http://msdn.microsoft.com/en-us/library/dd179376.aspx)
- [Blob Service REST API](http://msdn.microsoft.com/en-us/library/dd135733.aspx)
