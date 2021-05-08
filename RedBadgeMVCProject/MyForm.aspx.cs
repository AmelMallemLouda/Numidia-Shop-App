using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace RedBadgeMVCProject
{
    public partial class MyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accountname = "numidiastorage1";
            string accessKey = "mol1tJWIXFa1X2rD2C7g9nblaG4eH11fQjuKbp0D6bERk5soM0VzR826HiYmozDlOZ8rmDWuGkIW1F26foSM1g==";

            try

            {
                
                StorageCredentials creden = new StorageCredentials(accountname, accessKey);

                CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);

                CloudBlobClient client = acc.CreateCloudBlobClient();

                CloudBlobContainer cont = client.GetContainerReference("mysample");

                cont.CreateIfNotExists();

                cont.SetPermissions(new BlobContainerPermissions



        {

                    PublicAccess = BlobContainerPublicAccessType.Blob


        });

                CloudBlockBlob cblob = cont.GetBlockBlobReference("Sampleblob.jpg");

                using (Stream file = System.IO.File.OpenRead(@"D:\amit\Nitin sir\Nitinpandit.jpg"))

                {

                    cblob.UploadFromStream(file);

                }

            }
            catch (Exception ex)

            {

            }
        }
    }
}