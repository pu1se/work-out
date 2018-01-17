using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YourWorkOut.Services
{
    public abstract class BaseService<T> where T : class 
    {
        private readonly string ServiceKey;
        public BaseService()
        {
            ServiceKey = this.GetType().Name;
        }

        protected void SaveData(T settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            App.Current.Properties[ServiceKey] = json;
            App.Current.SavePropertiesAsync();
        }

        protected T GetData()
        {
            //todo: maybe use CrossSettings.Current instead?

            if (App.Current.Properties.ContainsKey(ServiceKey) == false)
                return null;

            var json = App.Current.Properties[ServiceKey] as string;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
