using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
    
namespace Splitten.UI
{
    public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 buttonSize;
        private Rect buttonBounds;
        private RectTransform buttonRectTransform;
        [SerializeField] private bool interactable = true;

        [SerializeField] private ButtonState buttonState = ButtonState.RELEASED;

        private Vector2 clickPosition;

        private Image imageComponent;

        #region Color
        [SerializeField] private Color defaultColor = default;
        [SerializeField] private Color pressedColor = default;
        [SerializeField] private Color disabledColor = default;
        #endregion

        #region Actions
        public Action OnButtonDown;
        public Action OnButtonUp;
        public Action OnButtonClick;
        #endregion

        #region Methods
        private void Start()
        {
            this.CalculateButtonInformation();
            this.imageComponent = this.GetComponent<Image>();
            this.imageComponent.color = this.defaultColor;

        }

        #region IPointerMethods
        public void OnPointerDown(PointerEventData eventData)
        {
            if (this.interactable == false)
                return;

            //Checking if the player used the left mouse button to click. If not, no click will be detected.
            if (eventData.button != PointerEventData.InputButton.Left || this.enabled == false)
                return;

            //Saving the click position. Used to calculate if its a click press or not.
            this.clickPosition = eventData.position;

            this.buttonState = ButtonState.PRESSED;
            this.Transition();
            this.OnButtonDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (this.interactable == false)
                return;

            if (this.buttonState != ButtonState.PRESSED)
                return;

            //Checking if the player used the left mouse button to click. If not, no click will be detected.
            if (eventData.button != PointerEventData.InputButton.Left || this.enabled == false)
                return;

            if (this.buttonBounds.Contains(this.clickPosition))
            {
                this.OnClick();
                this.clickPosition = default;
            }

            this.buttonState = ButtonState.RELEASED;
            this.Transition();
            this.OnButtonUp?.Invoke();
        }
        #endregion

        /// <summary>
        /// Method called when button click is detected.
        /// </summary>
        private void OnClick()
        {
            Debug.Log($"{this.name} has been clicked");
            this.OnButtonClick?.Invoke();
        }

        private void Transition()
        {
            if (this.buttonState == ButtonState.PRESSED)
            {
                this.imageComponent.color = this.pressedColor;
                return;
            }
            if (this.buttonState == ButtonState.RELEASED)
            {
                this.imageComponent.color = this.defaultColor;
                return;
            }
        }

        /// <summary>
        /// Calculating the button bounds.
        /// </summary>
        private void CalculateButtonInformation()
        {
            float width = 0;
            float height = 0;
            float posX = 0;
            float posY = 0;

            this.buttonRectTransform = this.GetComponent<RectTransform>();

            width = this.buttonRectTransform.sizeDelta.x;
            height = this.buttonRectTransform.sizeDelta.y;
            this.buttonSize = new Vector2(width, height);

            posX = this.buttonRectTransform.position.x;
            posY = this.buttonRectTransform.position.y;

            this.buttonBounds = new Rect(posX - (width/2), posY - (height/2), width, height);
        }
        #endregion
    }
}