using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class Slot : MonoBehaviour
    {
        public enum Level {
            NONE,
            PRIMARY,
            NORMAL,
            EXCELLENT
        }

        protected Color[] colTable = new Color[]{
            new Color(1.0f, 1.0f, 1.0f, 0.390625f),
            Color.red,
            Color.green,
            Color.blue
        };
        protected Image image;

        public Level level = Level.NONE;

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
                image.color = colTable[(int)level];
            }
        }
    }
}
