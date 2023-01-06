namespace Savegames.Middleware
{
    public enum ObjectMiddlewareStage
    {
        OnSave_BeforeSerialization,
        OnLoad_AfterDeserialization,
    }

    public enum SerializedMiddlewareStage
    {
        OnSave_AfterSerialization,
        OnLoad_BeforeDeserialization,
    }
}
