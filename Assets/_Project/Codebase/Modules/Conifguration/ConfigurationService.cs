using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Conifguration
{
    public class ConfigurationService
    {
        private readonly IReadOnlyList<Configuration> _configs;
        private readonly Dictionary<Type, IConfiguration> _cachedConfigs = new();

        [Inject]
        public ConfigurationService(IReadOnlyList<Configuration> configs)
        {
            _configs = configs;
        }

        public TConfig GetConfiguration<TConfig>() where TConfig : IConfiguration
        {
            var type = typeof(TConfig);
            if (_cachedConfigs.TryGetValue(type, out IConfiguration cachedConfig))
            {
                return (TConfig)cachedConfig;
            }

            foreach (var config in _configs)
            {
                if(!config.GetType().IsAssignableFrom(type))
                    continue;

                cachedConfig = config;
                _cachedConfigs.TryAdd(type, config);

                return (TConfig)cachedConfig;
            }
            
            throw new Exception($"Configuration {type} not found.");
        }
    }

    public abstract class Configuration : ScriptableObject, IConfiguration{}
    public interface IConfiguration{}
}