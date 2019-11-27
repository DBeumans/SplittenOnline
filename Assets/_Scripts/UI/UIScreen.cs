using System;
using UnityEngine;
using UnityEngine.UI;
using Splitten.Extensions;
    
namespace Splitten.UI
{
    public class UIScreen : Singleton<UIScreen>
    {
        [SerializeField]protected Canvas screenCanvas;

        protected UIController UIController;

        private void Awake()
        {
            if(this.screenCanvas == null)
                Debug.Log($"{this} has no screen assigned");
            
            this.UIController = UIController.Instance;
            this.DisableScreen();
        }

        public virtual void Setup(Vector2 screenResolution)
        {
            CanvasScaler canvasScalar = this.screenCanvas.GetComponent<CanvasScaler>();
            canvasScalar.referenceResolution = screenResolution;
            canvasScalar.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

            Debug.Log($"SCREENRESOLUTION: {screenResolution}");
        }

        public virtual void EnableScreen()
        {
            this.screenCanvas.gameObject.SetActive(true);
            //Debug.Log($"ENABLED {this} ");
        }

        public virtual void DisableScreen()
        {
            this.screenCanvas.gameObject.SetActive(false);
            //Debug.Log($"DISABLED {this} ");
        }
    }
}