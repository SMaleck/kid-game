using Game.Services.Scenes;
using Game.Static.Events;
using Game.Static.Locators;
using Gooey;
using UnityEngine;

namespace Game.Services.Gooey.Views
{
    public class ViewAutoInitializer : MonoBehaviour
    {
        [SerializeField] private View _view;

        private IGui _gui;

        private void OnValidate()
        {
            _view ??= GetComponent<View>();
        }

        private void Start()
        {
            _gui = ServiceLocator.Get<GuiBuilder>().Build(_view);
            EventBus.OnEvent<BeforeSceneUnloadEvent>(BeforeSceneUnload);
        }

        private void BeforeSceneUnload(object eventArgs)
        {
            var args = (BeforeSceneUnloadEvent)eventArgs;
            if (args.Scene != gameObject.scene.ToSceneId())
            {
                return;
            }

            ServiceLocator.Get<GuiServiceProxy>().Remove(_gui);
            EventBus.Unsubscribe(BeforeSceneUnload);
        }
    }
}
