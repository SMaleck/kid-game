using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.Game.Services.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceProxy : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void Play(AudioClip audioClip, bool loop, float volume, Vector3 position)
        {

        }

        private void OnValidate()
        {
            _audioSource ??= GetComponent<AudioSource>();
        }
    }
}
