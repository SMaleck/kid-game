using System;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class MobileKeyboardHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
#if UNITY_WEBGL && !UNITY_EDITOR
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                inputField.textComponent.rectTransform,
                Input.mousePosition, inputField.textComponent.canvas.worldCamera,
                out pos);

            if (inputField.textComponent.rectTransform.rect.Contains(pos))
            {
                ShowMobileKeyboard();
            }
        }
    }

    [DllImport("__Internal")]
    private static extern void ShowMobileKeyboard();

    [AOT.MonoPInvokeCallback(typeof(Action<string>))]
    private static void MobileKeyboardCallback(string input)
    {
        FindObjectOfType<MobileKeyboardHandler>().inputField.text += input;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        Application.ExternalEval(@"
            window.MobileKeyboardCallback = function (ptr) {
                window.SendMessage('MobileKeyboardHandler', 'MobileKeyboardCallback', Pointer_stringify(ptr));
            };
        ");
    }
#endif
}