using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class Slot : MonoBehaviour
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
            
        }

        public void OnClick(){
            if (GameLogic.Global.selectedItem != null){
                GameLogic.Global.selectedItem.PlaceOnSlot(this);
            }

            Desc.ArmorAttr armor = GetComponent<Desc.ArmorAttr>();
            if (armor != null){
                image.color = armor.color;
            }
        }
    }
}
