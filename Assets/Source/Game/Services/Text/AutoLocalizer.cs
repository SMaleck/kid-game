using Game.Services.Text.Utility;
using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

namespace Game.Services.Text
{
    [RequireComponent(typeof(TMP_Text))]
    public class AutoLocalizer : MonoBehaviour
    {
        [SerializeField][HideInInspector] private TMP_Text _textField;
        [SerializeField][HideInInspector] private string _stringTextKey;

        private TMP_Text TextField => _textField ??= GetComponent<TMP_Text>();
        public string StringTextKey => _stringTextKey;

        private void Start()
        {
            Localize();
        }

        private void OnValidate()
        {
            Localize();
        }

        private void Localize()
        {
            if (!Enum.TryParse<TextKeys>(_stringTextKey, true, out var key))
            {
                return;
            }

            if (UnityEngine.Application.isPlaying)
            {
                TextField.text = TextService.Get(key);
            }
            else if (UnityEngine.Application.isEditor)
            {
                TextField.text = key.GetText();
            }
        }

        //------------------------------------ EDITOR
        [Conditional("UNITY_EDITOR")]
        public void SetKey(string key)
        {
            _stringTextKey = key;
            Localize();
        }
    }
}
