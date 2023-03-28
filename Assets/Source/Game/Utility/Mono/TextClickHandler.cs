using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Utility.Mono
{
    public class TextClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [field: SerializeField] public TMP_Text Text { get; private set; }

        public Action<PointerEventData> OnClick { get; set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(eventData);
        }

        private void OnValidate()
        {
            Text ??= GetComponent<TMP_Text>();
        }
    }
}
