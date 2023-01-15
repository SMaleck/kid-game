using Game.Services.Text;
using System.Linq;
using UnityEditor;
using UtilitiesGeneral.Utilities;

namespace Source.Editor.CustomInspectors
{
    [CustomEditor(typeof(AutoLocalizer))]
    public class AutoLocalizerEditor : UnityEditor.Editor
    {
        private AutoLocalizer Target => (AutoLocalizer)target;

        private int _index = 0;
        private int _lastIndex = 0;
        private string[] _keyNames;

        private void OnEnable()
        {
            _keyNames = EnumIterator<TextKeys>.Iterator
                .Select(e => e.ToString())
                .ToArray();

            for (var i = 0; i < _keyNames.Length; i++)
            {
                if (_keyNames[i] == Target.StringTextKey)
                {
                    _index = i;
                    _lastIndex = i;
                }
            }

            if (_index == 0)
            {
                SetKey(_index);
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.LabelField("Text Key:");
            _index = EditorGUILayout.Popup(_index, _keyNames);

            if (_index != _lastIndex)
            {
                SetKey(_index);
            }
        }

        private void SetKey(int index)
        {
            _lastIndex = _index;
            Target.SetKey(_keyNames[_index]);
            Save();
        }

        private void Save()
        {
            EditorUtility.SetDirty(target);
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }
    }
}