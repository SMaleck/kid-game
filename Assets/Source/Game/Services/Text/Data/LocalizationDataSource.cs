using Game.Data;
using Game.Data.Tables;
using Game.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Services.Text.Data
{
    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(LocalizationDataSource), fileName = nameof(LocalizationDataSource))]
    public class LocalizationDataSource : ScriptableObjectDataSource
    {
        [SerializeField] private LocalizationTable _table;

        private Dictionary<TextKeys, LocalizationTable.Row> _rows;

        public void Initialize()
        {
            _rows = _table.Rows.ToDictionary(e => Enum.Parse<TextKeys>(e.Key));
        }

        public string Get(Language language, Language fallbackLanguage, TextKeys key)
        {
            var row = _rows[key];
            string text = GetEntryFor(row, language);

            return string.IsNullOrWhiteSpace(text)
                ? GetEntryFor(row, fallbackLanguage)
                : text;
        }

        private string GetEntryFor(LocalizationTable.Row row, Language language)
        {
            switch (language)
            {
                case Language.English:
                    return row.English;

                case Language.German:
                    return row.German;

                case Language.Polish:
                    return row.Polish;

                default:
                    GameLog.Error($"Cannot handle Language: {language}");
                    return "MISSING";
            }
        }
    }
}
