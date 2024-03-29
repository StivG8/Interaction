﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaction.Redis.Data
{
    public class DataService
    {
        private RedisService cache { get; set; }

        public DataService()
        {
            cache = new RedisService();
        }

        public string Get()
        {
            try
            {
                var key = $"DataService_Get_{DateTime.Now:hhmm}";
                var data = cache.Get<WeatherForecast[]>(key);
                if (data == null)
                {
                    var wfs = new WeatherForecastService();
                    data = wfs.GetForecastAsync(DateTime.Now).GetAwaiter().GetResult();
                    cache.Put(key, data);
                }
                return System.Text.Json.JsonSerializer.Serialize(data);
            }
            catch (Exception ex)
            {
                throw new Exception($"Can`t get data {ex.Message}");
            }
        }
    }
}
