﻿using Project.Hub.Config.Entities;
using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    public interface IConfigurationProvider
    {
        Task<Configuration> GetConfig();
    }
}
