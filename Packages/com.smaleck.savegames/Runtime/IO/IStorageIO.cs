namespace Savegames.IO
{
    // ToDo Make storage targets ASYNC, to potentially support cloud storage
    public interface IStorageIO
    {
        bool Exists(string fileName);
        string Read(string fileName);
        void Write(string fileName, string serialized);
    }
}