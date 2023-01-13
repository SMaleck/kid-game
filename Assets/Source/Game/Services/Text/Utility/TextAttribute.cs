using System;

namespace Game.Services.Text.Utility
{
    public class TextAttribute : Attribute
    {
        public string Value { get; }

        public TextAttribute(string value)
        {
            Value = value;
        }
    }

    public static class TextValueEnumExtensions
    {
        public static string GetText(this TextKeys textKey)
        {
            string output = null;
            var type = textKey.GetType();

            var fi = type.GetField(textKey.ToString());
            var attrs = fi.GetCustomAttributes(typeof(TextAttribute), false) as TextAttribute[];
            if (attrs != null && attrs.Length > 0)
            {
                output = attrs[0].Value;
            }
            else if (attrs == null)
            {
                throw new Exception($"Cannot get TextValue for {nameof(TextKeys)}.{textKey}. Are you missing the {nameof(TextKeys)} attribute?");
            }

            return output;
        }
    }
}
