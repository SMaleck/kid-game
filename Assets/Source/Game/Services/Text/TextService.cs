using Game.Services.Text.Data;
using Game.Static.Locators;
using Game.Static.Settings;
using Game.Utility;
using UnityEngine;

namespace Game.Services.Text
{
    public static class TextService
    {
        private static LocalizationDataSource _locaData;

        private const Language DefaultLanguage = Language.English;
        public static Language CurrentLanguage => AppSettings.Language;

        public static DateTimeTextFormatter TimeFormatter { get; } = new DateTimeTextFormatter();

        static TextService()
        {
            _locaData = DataLocator.Get<LocalizationDataSource>();
            _locaData.Initialize();

            if (!AppSettings.IsLanguageSet)
            {
                AppSettings.Language = GetSystemLanguage();
            }
        }

        private static Language GetSystemLanguage()
        {
            var systemLang = UnityEngine.Application.systemLanguage;

            switch (systemLang)
            {
                case SystemLanguage.English:
                    return Language.English;

                case SystemLanguage.German:
                    return Language.German;

                case SystemLanguage.Polish:
                    return Language.Polish;

                default:
                    GameLog.Warn($"{systemLang} is not supported, falling back to {DefaultLanguage}");
                    return DefaultLanguage;
            }
        }

        public static void SetLanguage(Language language)
        {
            AppSettings.Language = language;
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
