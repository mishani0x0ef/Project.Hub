using System.Collections.Generic;
using Project.Hub.Config.Entities;
using Project.Hub.Config.Interfaces;

namespace Project.Hub.Config.Providers
{
    public class StaticConfigurationProvider : IConfigurationProvider
    {
        private readonly Configuration _config;

        public StaticConfigurationProvider()
        {
            _config = new Configuration
            {
                SystemLinks = new List<SiteLink>
                {
                    new SiteLink("Google Test", "https://www.google.com", "Link to Google. Just for testing.")
                },
                Environments = new List<EnvironmentConfig>
                {
                    new EnvironmentConfig("Testing", "Testing environment.")
                    {
                        Sites = new List<SiteLink>
                        {
                            new SiteLink("Google", "https://www.google.com", "Link to Google. Just for testing."),
                        },
                        Downloads = new List<DownloadLink>
                        {
                            new DownloadLink("File from Web", "File for testing")
                            {
                                Mode = DownloadMode.Dirrect,
                                DownloadPath = "http://che.org.il/wp-content/uploads/2016/12/pdf-sample.pdf"
                            },
                            new DownloadLink("File from local system", "File for testing")
                            {
                                Mode = DownloadMode.FileSystem,
                                DownloadPath = "C://temp/test.txt"
                            }
                        }
                    },
                    new EnvironmentConfig("Production", "Production environment.")
                    {
                        Sites = new List<SiteLink>
                        {
                            new SiteLink("Google", "https://www.google.com", "Link to Google. Just for testing."),
                        },
                        Downloads = new List<DownloadLink>
                        {
                            new DownloadLink("File from Web", "File for testing")
                            {
                                Mode = DownloadMode.Dirrect,
                                DownloadPath = "http://che.org.il/wp-content/uploads/2016/12/pdf-sample.pdf"
                            },
                            new DownloadLink("File from local system", "File for testing")
                            {
                                Mode = DownloadMode.FileSystem,
                                DownloadPath = "C://temp/test.txt"
                            }
                        }
                    }
                }
            };
        }

        public Configuration GetConfig()
        {
            return _config;
        }
    }
}
