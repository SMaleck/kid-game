using Game.Services.Text.Utility;
using TMPro;
using UnityEngine;

namespace Game.Services.Text
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(TMP_Text))]
    public class AutoLocalizer : MonoBehaviour
    {
        [SerializeField] private TextKeys _key;

        [SerializeField][HideInInspector] private TMP_Text _textField;
        private TMP_Text TextField => _textField ??= GetComponent<TMP_Text>();

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
            if (UnityEngine.Application.isPlaying)
            {
                TextField.text = TextService.Get(_key);
            }
            else if (UnityEngine.Application.isEditor)
            {
                TextField.text = _key.GetText();
            }
        }
    }
}
