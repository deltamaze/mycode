using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using StockWatch.Data;

namespace StockWatch.Configuration
{
    public class TwitterSecretLoader : ISecretLoader
    {
        private SecretsDataModel secrets;
        private ILogger log;
        public TwitterSecretLoader(SecretsDataModel secrets, ILogger log)
        {
            this.secrets = secrets;
            this.log = log;
        }
        public void Load()
        {
            //this file is a gitignored folder, you'll have to make your own
            string secretFile = @".\secrets\twitter.json";
            if(File.Exists(secretFile)){
                string fileContent = File.ReadAllText(secretFile);
                this.secrets.TwitterConnData = JsonSerializer.Deserialize<TwitterConnData>(fileContent);
                return;
            }
            log.LogWarning("No twitter.json file found, unable to load Api Key/Secret");

        }
    }
    
}
