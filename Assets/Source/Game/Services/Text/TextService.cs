using Game.Services.Text.Data;
using Game.Static.Locators;

namespace Game.Services.Text
{
    public static class TextService
    {
        private static LocalizationDataSource _locaData;

        private const Language DefaultLanguage = Language.English;
        public static Language CurrentLanguage { get; private set; }

        static TextService()
        {
            _locaData = DataLocator.Get<LocalizationDataSource>();
            _locaData.Initialize();

            CurrentLanguage = DefaultLanguage;
        }

        public static void SetLanguage(Language language)
        {
            CurrentLanguage = language;
        }

        public static string Get(TextKeys key, params object[] args)
        {
            var text = GetText(CurrentLanguage, key);
            return args?.Length > 0 ? string.Format(text, args) : text;
        }

        public static string Get(Language language, TextKeys key, params object[] args)
        {
            var text = GetText(language, key);
            return args?.Length > 0 ? string.Format(text, args) : text;
        }

        private static string GetText(Language language, TextKeys key)
        {
            return _locaData.Get(language, DefaultLanguage, key);
        }
    }
}
