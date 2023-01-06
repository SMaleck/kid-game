namespace Savegames.Serialization
{
    public interface ISerializer
    {
        string Serialize(object savegame);
        T Deserialize<T>(string savegameJson) where T : class;
    }
}