using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Image))]
    public class MenuItem : MonoBehaviour
    {
        protected Image image;

        public Color defaultColor = new Color(1.0f, 1.0f, 1.0f, 0.390625f);
        public Color selectedColor = new Color(0.0f, 0.0f, 1.0f, 0.390625f);

        // Start is called before the first frame update
        void Start()
        {
            image = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameLogic.Global.selectedItem == this){
                image.color = selectedColor;
            }else{
                image.color = defaultColor;
            }
        }

        public void OnClick(){
            GameLogic.Global.selectedItem = this;
        }

        public void PlaceOnSlot(Slot slot){
            Desc.ArmorAttr armor = slot.GetComponent<Desc.ArmorAttr>();
            if (armor == null){
                armor = slot.gameObject.AddComponent<Desc.ArmorAttr>();
            }
            if (armor.level < Desc.ArmorAttr.Level.LAST_LEVEL)
                armor.level++;
        }
    }
}

