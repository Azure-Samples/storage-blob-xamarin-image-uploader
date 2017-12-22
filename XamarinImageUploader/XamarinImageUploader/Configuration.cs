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
using System.Text;

namespace XamarinImageUploader
{
    public static class Configuration
    {
        /// <summary>
        /// Azure Storage Connection String. UseDevelopmentStorage=true points to the storage emulator.
        /// “Only use Shared Key authentication for testing purposes! Your account name and account key, which give full read/write access to the associated Storage account, 
        /// will be distributed to every person that downloads your app. This is not a good practice as you risk having your key compromised by untrusted clients. 
        /// Please consult following documents to understand and use Shared Access Signatures instead. 
        /// https://docs.microsoft.com/en-us/rest/api/storageservices/delegating-access-with-a-shared-access-signature
        /// https://docs.microsoft.com/en-us/azure/storage/common/storage-dotnet-shared-access-signature-part-1
        /// </summary>
        public const string StorageConnectionString = "UseDevelopmentStorage=true";
    }
}
