using Game.Services.Audio;
using Game.Static.Locators;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Utility.UI
{
    public class ButtonSoundHandler : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private AudioClip _audioClip;

        private AudioService _audioService;

        private void Start()
        {
            if (!_audioClip)
            {
                return;
            }

            _audioService = ServiceLocator.Get<AudioService>();
            _button.onClick.AddListener(() => _audioService.PlayUI(_audioClip));
        }

        private void OnValidate()
        {
            _button ??= GetComponent<Button>();
        }
    }
}
