using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Image))]
    public class MenuItem : MonoBehaviour
    {
        protected Image image;

        // Start is called before the first frame update
        void Start()
        {
            image = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameLogic.Global.selectedItem == this){
                image.color = new Color(0.0f, 0.0f, 1.0f, 0.390625f);
            }else{
                image.color = new Color(1.0f, 1.0f, 1.0f, 0.390625f);
            }
        }

        public void OnClick(){
            GameLogic.Global.selectedItem = this;
        }

        public void PlaceOnSlot(Slot slot){
            slot.level = Slot.Level.PRIMARY;
        }
    }
}

