using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

namespace Splitten.UI.Editor
{
    public class SplittenUIFactory : MonoBehaviour
    {
        [MenuItem("GameObject/Splitten/UI/Button/Default Button", false, 10)]
        public static void CreateUIButton(MenuCommand cmd)
        {
            GameObject btn = new GameObject("[BUTTON]Button");
            GameObjectUtility.SetParentAndAlign(btn, cmd.context as GameObject);
            Undo.RegisterCreatedObjectUndo(btn, $"Create {btn.name}");
            Selection.activeObject = btn;

            btn.AddComponent(typeof(Image));
            btn.AddComponent(typeof(Splitten.UI.UIButton));

            GameObject buttonLabel = new GameObject("[LABEL]Label text");
            buttonLabel.transform.SetParent(btn.transform, false);

            TextMeshProUGUI textComponent = buttonLabel.AddComponent<TextMeshProUGUI>();
            textComponent.alignment = TextAlignmentOptions.Midline;
            textComponent.rectTransform.anchorMax = new Vector2(1, 1);
            textComponent.rectTransform.anchorMin = new Vector2(0, 0);
            
            RectTransform textRecttransform = textComponent.GetComponent<RectTransform>();
            textRecttransform.sizeDelta = new Vector2(0, 0);

            textComponent.SetText("Splitten");
            textComponent.color = new Color32(34, 34, 34, 255);

        }

        [MenuItem("GameObject/Splitten/UI/Button/Card Button")]
        public static void CreateCardButton(MenuCommand cmd)
        {
            GameObject btn = new GameObject("[BUTTON]Button");
            GameObjectUtility.SetParentAndAlign(btn, cmd.context as GameObject);
            Undo.RegisterCreatedObjectUndo(btn, $"Create {btn.name}");
            Selection.activeObject = btn;

            btn.AddComponent(typeof(Image));
            btn.AddComponent(typeof(CardUIButton));

            GameObject buttonLabel = new GameObject("[LABEL]Label text");
            buttonLabel.transform.SetParent(btn.transform, false);

            TextMeshProUGUI textComponent = buttonLabel.AddComponent<TextMeshProUGUI>();
            textComponent.alignment = TextAlignmentOptions.Midline;
            textComponent.rectTransform.anchorMax = new Vector2(1, 1);
            textComponent.rectTransform.anchorMin = new Vector2(0, 0);

            RectTransform textRecttransform = textComponent.GetComponent<RectTransform>();
            textRecttransform.sizeDelta = new Vector2(0, 0);

            textComponent.SetText("Splitten");
            textComponent.color = new Color32(34, 34, 34, 255);
        }
    }

}
