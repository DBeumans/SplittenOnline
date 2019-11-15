using System;
using UnityEngine;
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

            this.DisableScreen();
            
            this.UIController = UIController.Instance;
        }

        public virtual void EnableScreen()
        {
            this.screenCanvas.gameObject.SetActive(true);
            Debug.Log($"ENABLED {this} ");
        }

        public virtual void DisableScreen()
        {
            this.screenCanvas.gameObject.SetActive(false);
            Debug.Log($"DISABLED {this} ");
        }
    }
}