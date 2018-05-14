using AutoMapper;
using System;
using System.Linq;

namespace KatlaSport.WebApi
{
    /// <summary>
    /// Represents a mapper configuration.
    /// </summary>
    public static class MapperConfig
    {
        /// <summary>
        /// Configures a mapper with static configuration.
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("KatlaSport")).ToArray();
                cfg.AddProfiles(assemblies);
            });
        }
    }
}
