using Game.Services.Scenes;
using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Static.Locators;
using Game.Utility;
using Gooey;
using UnityEngine;

namespace Game.Services.Gooey.Views
{
    [RequireComponent(typeof(View))]
    public class ViewAutoInitializer : MonoBehaviour
    {
        [SerializeField] private View _view;

        private IGui _gui;
        private bool _isRegistered = false;

        private void OnValidate()
        {
            _view ??= GetComponent<View>();
        }

        private void Start()
        {
            _isRegistered = true;
            _gui = ServiceLocator.Get<GuiBuilder>().Build(_view);
            EventBus.OnEvent<EndSceneEvent>(BeforeSceneUnload);
        }

        private void BeforeSceneUnload(object eventArgs)
        {
            EventBus.Unsubscribe(BeforeSceneUnload);

            if (!_isRegistered) { return; }
            _isRegistered = false;

            if (gameObject == null)
            {
                GameLog.Error($"Failed to remove GUI [{_gui.GetType()}]. GameObject already destroyed!");
                return;
            }

            var args = (EndSceneEvent)eventArgs;
            if (args.Scene != gameObject.scene.ToSceneId())
            {
                return;
            }

            ServiceLocator.Get<GuiServiceProxy>().Remove(_gui);
        }

        private void OnDestroy()
        {
            if (!_isRegistered) { return; }

            _isRegistered = false;
            EventBus.Unsubscribe(BeforeSceneUnload);
            ServiceLocator.Get<GuiServiceProxy>().Remove(_gui);
        }
    }
}
