using System;
using UnityEngine;

namespace UI {
    public class Airship : MonoBehaviour {
        public static readonly int SLOT_DELTA_X = 72;
        public static readonly int SLOT_DELTA_Y = 80;

        public GameObject slot;
        public int width;
        public int height;

        protected RectTransform rect;
        protected GameObject[,] slot_array;

        public Vector2 GetCoord(int x, int y){
            return new Vector2(
                x * SLOT_DELTA_X,
                ((x & 1) == 1 ? SLOT_DELTA_Y / 2 : 0) + y * SLOT_DELTA_Y
            );
        }

        // Start is called before the first frame update
        void Start(){
            rect = GetComponent<RectTransform>();

            slot_array = new GameObject[width, height];
            int x = -(width * SLOT_DELTA_X) / 2;
            int y_base = -(height * SLOT_DELTA_Y) / 2;

            for (int i = 0; i < width; i++, x += SLOT_DELTA_X){
                int y = (i & 1) == 1 ? y_base : y_base + SLOT_DELTA_Y / 2;
                for (int j = 0; j < height; j++, y += SLOT_DELTA_Y){
                    GameObject o = Instantiate(slot, transform);
                    slot_array[i, j] = o;
                    RectTransform r = o.GetComponent<RectTransform>();
                    r.localPosition = new Vector3(x, y, 0);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0)){
                Vector2 pos = new Vector2();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    rect, Input.mousePosition, Camera.main, out pos
                );
                Debug.Log(pos);
            }
        }
    }
}

