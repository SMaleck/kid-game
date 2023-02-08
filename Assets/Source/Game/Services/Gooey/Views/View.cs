using System;
using UnityEngine;

namespace Game.Services.Gooey.Views
{
    public class View : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Canvas _rootCanvas;
        [field: SerializeField] public bool StartsVisible { get; private set; }

        public bool IsVisible
        {
            get => _root.activeSelf;
            protected set => _root.SetActive(value);
        }

        private void OnValidate()
        {
            if (_rootCanvas == null)
            {
                _rootCanvas = TryFindCanvas();
            }
            if (_root == null && _rootCanvas != null)
            {
                _root = _rootCanvas.gameObject;
            }
        }

        private Canvas TryFindCanvas()
        {
            var canvas = GetComponent<Canvas>();
            if (canvas)
            {
                return canvas;
            }
            return GetComponentInChildren<Canvas>();
        }

        public void SetIsVisible(bool value, bool instant, Action onComplete)
        {
            if (value)
            {
                ToVisible(instant, onComplete);
            }
            else
            {
                ToInvisible(instant, onComplete);
            }
        }

        protected virtual void ToVisible(bool instant, Action onCompleted)
        {
            IsVisible = true;
            onCompleted.Invoke();
        }

        protected virtual void ToInvisible(bool instant, Action onCompleted)
        {
            IsVisible = false;
            onCompleted.Invoke();
        }
    }
}
