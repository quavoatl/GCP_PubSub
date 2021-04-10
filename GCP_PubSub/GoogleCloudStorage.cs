using System;
using System.IO;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

namespace GCP_PubSub
{
    public class GoogleCloudStorage
    {
        private const string STORAGE_BUCKET = "issues_01138687-c741-4931-8dbc-d72c1356eadb";
        private const string Message = "Message";
        private StorageClient _storageClient; 
        private Bucket _bucket; 
        
        public GoogleCloudStorage()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"
                ,@"C:\Users\seantal\source\repos\GCP-Pub-Sub\GCP_PubSub\GCP_PubSub\abstract-frame-95216-d52c4732b93b.json");
            
            // GoogleCredential credential =
            //     GoogleCredential.FromStream(
            //         File.OpenRead(@"C:\Users\seantal\source\repos\GCP-Pub-Sub\GCP_PubSub\GCP_PubSub\client_secret_1055310617080-iv1o906g9sp0v3jj7uv60hecmcvrchtp.apps.googleusercontent.com.json"));
            //         
            
            _storageClient = StorageClient.Create();
        }

        public void InitializeBucket()
        {
            _bucket = _storageClient.GetBucket(STORAGE_BUCKET);
        }
        
        public void UploadFile(
            string bucketName = "STORAGE_BUCKET",
            string localPath = "Tracked_Issues/issues.txt",
            string objectName = "issues.txt")
        {
            using var fileStream = File.OpenWrite(localPath);
            byte[] bytes = Encoding.ASCII.GetBytes(Message); 
            fileStream.Write(bytes);
            _storageClient.UploadObject(bucketName, objectName, null, fileStream);
            Console.WriteLine($"Uploaded {objectName}.");
        }
        
    }
}