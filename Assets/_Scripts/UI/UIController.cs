using UnityEngine;
using System;
using System.Collections.Generic;
using Splitten.Extensions;

namespace Splitten.UI
{
    public class UIController : Singleton<UIController>
    {
        [SerializeField]private UIScreen activeScreen;

        [SerializeField]private List<UIScreen> screens = new List<UIScreen>();
        
        private Vector2 screenResolution = default;
        private void Awake()
	    {
            this.screenResolution = new Vector2(Screen.width, Screen.height);
            Debug.Log($"SCREENRESOLUTION: {this.screenResolution}");


            this.FetchScreens();
            this.activeScreen = this.screens[0];
            this.activeScreen.EnableScreen();
        }

        /// <summary>
        /// Change from UI Screen
        /// </summary>
        /// <param name="OnScreenChanged">Callback when screen has been changed, returning the newly changed screen</param>
        /// <typeparam name="T">UIScreen class to change to</typeparam>
        public void GoToScreen<T>(Action<UIScreen> OnScreenChanged = null)
        {
            this.GoToScreen(typeof(T), OnScreenChanged);
        }

        /// <summary>
        /// Change from UI Screen
        /// </summary>
        /// <param name="type">UIScreen class to change to</param>
        /// <param name="OnScreenChanged">Callback when screen has been changed, returning the newly changed screen</param>
        public void GoToScreen(System.Type type, Action<UIScreen> OnScreenChanged = null)
        {
            this.activeScreen.DisableScreen();

            int screensLength = this.screens.Count;
            for(int i = 0; i < screensLength; i++)
            {
                UIScreen currentScreen = this.screens[i];
                if(!type.Equals(currentScreen.GetType()))
                    continue;
                
                this.activeScreen = currentScreen;
            }

            this.activeScreen.EnableScreen();
            OnScreenChanged?.Invoke(this.activeScreen);
        }
        
    	/// <summary>
        /// Fetching all the UIScreens inside the UIController GameObject.
        /// </summary>
        private void FetchScreens()
        {
            UIScreen[] uiScreens = this.GetComponents<UIScreen>();

            int screensLength = uiScreens.Length;
            for (int i = 0; i < screensLength; i++)
            {
                this.screens.Add(uiScreens[i]);
                uiScreens[i].Setup(this.screenResolution);
            }
        }

        private void Update()
        {

        }
    }
}