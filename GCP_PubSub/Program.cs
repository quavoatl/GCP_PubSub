using System;

namespace GCP_PubSub
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GoogleCloudStorage gcs = new GoogleCloudStorage();
            gcs.InitializeBucket();
            gcs.UploadFile();
        }
        
        
    }
}