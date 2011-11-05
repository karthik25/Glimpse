using Glimpse.Core2.Extensibility;
using Newtonsoft.Json;

namespace Glimpse.Core2
{
    public class JsonNetSerializer:IGlimpseSerializer
    {
        private JsonSerializerSettings Settings { get; set; }

        public JsonNetSerializer()
        {
            Settings = new JsonSerializerSettings();
                           
            Settings.Error += (obj, args) =>
                                  {
                                      //Ignore errors
                                      //TODO: add logging here (args.ErrorContext.Error)
                                      args.ErrorContext.Handled = true;
                                  };
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, Settings);
        }
    }
}