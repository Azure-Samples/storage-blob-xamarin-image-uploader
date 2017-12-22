---
services: storage
platforms: xamarin
author: pcibraro
---

# Azure Storage Service - Photo Uploader Sample using Xamarin for Android, iOS and Windows.

This sample demostrates how to upload photo images from the gallery in Android, iOS and Windows Phone into a Block blob in Azure Storage with Xamarin. It shows a button "Select Image" to select 
an image from the gallery, a button "Upload Image" to upload it to the Azure Storage, a button "List images" to list all the uploaded images.
A Shared Asset Project is used for reusing all the common code for the platform specific projects.

Note: This sample uses the Windows Azure Storage client library for .NET available through a Nuget package.

If you don't have a Microsoft Azure subscription you can get a FREE trial account [here](http://go.microsoft.com/fwlink/?LinkId=330212).

## Running this sample in Windows with Visual Studio

This sample can be run using either the Azure Storage Emulator that installs as part of the Windows Azure SDK - or by updating the StorageConnectionString variable defined at Configuration.cs file in the Shared Native Library Project.

To run the sample using the Storage Emulator (Windows Azure SDK / Only on Windows):

1. Download and Install the Azure Storage Emulator [here](http://azure.microsoft.com/en-us/downloads/).
2. Start the Azure Storage Emulator (once only) by pressing the Start button or the Windows key and searching for it by typing "Azure Storage Emulator". Select it from the list of applications to start it.
3. Set breakpoints and run the project using F10.

To run the sample using the Storage Service

1. Open the Configuration.cs file in the Shared Native Library Project "XamarinImageUploader". Replace the StorageConnectionString variable (UseDevelopmentStorage=True) with the connection string for the storage service (AccountName=[]...)
2. Create a Storage Account through the Azure Portal and provide your [AccountName] and [AccountKey] in the StorageConnectionString variable.
3. Set breakpoints and run the project using F10.

<span style="color:red">some **This is Red Bold.** text</span>


Note: You can also run the sample with Xamarin Studio, but only the Android and iOS samples will be available. For the Windows Phone sample, you can only use Visual Studio.

## More information
- [What is a Storage Account](http://azure.microsoft.com/en-us/documentation/articles/storage-whatis-account/)
- [How to use Blob Storage from iOS](https://azure.microsoft.com/en-us/documentation/articles/storage-ios-how-to-use-blob-storage/)
- [Blob Service Concepts](http://msdn.microsoft.com/en-us/library/dd179376.aspx)
- [Blob Service REST API](http://msdn.microsoft.com/en-us/library/dd135733.aspx)
