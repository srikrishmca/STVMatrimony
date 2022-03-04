using System;

namespace STVMatrimonyAPI.Model
{
    public class APIConfiguration
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string STVEncryptionKey { get; set; }
        public string STVHost { get; set; }
    }
}
