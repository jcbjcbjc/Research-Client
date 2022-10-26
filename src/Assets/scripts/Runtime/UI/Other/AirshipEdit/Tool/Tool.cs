using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public abstract class Tool : MonoBehaviour
    {
        public Color enabledColor = Color.blue;
        public Color disabledColor = Color.white;

        protected Image image;
        protected Button button;
        private bool state = false;

        protected abstract void OnStateChanged(bool state);

        void OnClick(){
            state = !state;
            image.color = state ? enabledColor : disabledColor;
            OnStateChanged(state);
        }

        void Start(){
            image = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }
    }
}
