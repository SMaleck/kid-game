using Game.Services.Text;

namespace Game.Static.Settings
{
    public static class AppSettings
    {
        private static readonly AppSettingsStorage Storage = new AppSettingsStorage();

        public static Language Language
        {
            get => (Language)Storage.GetInt(AppSettingsKeys.Language);
            set => Storage.Set(AppSettingsKeys.Language, (int)value);
        }

        public static bool IsLanguageSet => Storage.TryGetInt(AppSettingsKeys.Language, out var _);
    }
}
