using Newtonsoft.Json;

namespace Savegames.Serialization
{
    public class JsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings _serializationSettings;

        public JsonSerializer()
        {
            _serializationSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Error,
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
        }

        public string Serialize(object savegame)
        {
            return JsonConvert.SerializeObject(
                savegame,
                _serializationSettings);
        }

        public T Deserialize<T>(string savegameJson) where T : class
        {
            return JsonConvert.DeserializeObject<T>(
                savegameJson,
                _serializationSettings);
        }
    }
}
