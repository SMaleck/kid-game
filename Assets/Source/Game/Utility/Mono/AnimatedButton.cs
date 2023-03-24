using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Utility.Mono
{
    public class CustomButton : Button, IPointerDownHandler
    {
        [field: SerializeField] public Button Button { get; private set; }



        private void Start()
        {
        }

        private void OnPointerUp()
        {

        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
        }
    }
}
