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
        protected GameObject[,] slotArray;

        public Vector2 GetCoord(int x, int y){
            return new Vector2(
                x * SLOT_DELTA_X,
                // 注意，奇数行下移
                ((x & 1) == 1 ? -SLOT_DELTA_Y / 2 : 0) + y * SLOT_DELTA_Y
            );
        }

        // Start is called before the first frame update
        void Start(){
            rect = GetComponent<RectTransform>();

            slotArray = new GameObject[width, height];

            int xBeg = -(width >> 1);
            int yBeg = -(height >> 1);

            for (int i = 0; i < width; i++){
                for (int j = 0; j < height; j++){
                    Vector2 pos = GetCoord(xBeg + i, yBeg + j);
                    GameObject o = Instantiate(slot, transform);
                    slotArray[i, j] = o;
                    RectTransform r = o.GetComponent<RectTransform>();
                    r.localPosition = new Vector3(pos.x, pos.y, 0);
                }
            }
        }

        bool IsClickSlot(){
            GameObject o = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            if (o == null)
                return false;
            return o.GetComponent<Slot>() != null;
        }

        protected bool lineEnabled = false;
        protected Vector2Int prevIdx;

        // Update is called once per frame
        void Update(){
            if (GameLogic.Global.lineMode &&
                Input.GetMouseButtonDown(0) && IsClickSlot()){
                lineEnabled = true;
                prevIdx = new Vector2Int(int.MaxValue, int.MaxValue);
            }
            if (lineEnabled){
                if (Input.GetMouseButton(0)){
                    Vector2 pos = new Vector2();
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(
                        rect, Input.mousePosition, null, out pos
                    );
                    EmitSlotEvent(pos);
                }else{
                    lineEnabled = false;
                }
            }
        }

        private static readonly float mathSqrt3 = Mathf.Sqrt(3.0f);
        private static readonly int halfSideLen = SLOT_DELTA_X / 3;
        private static readonly int sideLen = (SLOT_DELTA_X / 3) * 2;

        //指定坐标是否在六边形内
        bool PosInGrid(Vector2 pos, Vector2 center) {
            float dx = Mathf.Abs(center.x - pos.x);
            float dy = Mathf.Abs(center.y - pos.y);
            if (dx <= halfSideLen){
                return dy <= halfSideLen * mathSqrt3;
            }else{
                int maxY = Mathf.FloorToInt(-mathSqrt3 * (dx - halfSideLen) + halfSideLen * mathSqrt3);
                return dy < maxY;
            }
        }

        // 正六边形算法
        Vector2Int GetHexagonIndex(Vector2 pos){
            // (0, 0) 为 (0, 0) 正六边形中心

            // 坐标在六边形之中的大致区域
            // 从左到右
            int divX = Mathf.FloorToInt((pos.x / (float)SLOT_DELTA_X) * 4.0f) + 2;
            // 从下到上
            int divY = Mathf.FloorToInt(pos.y / (sideLen * mathSqrt3) * 2.0f) + 1;

            int gridX = divX >> 2;
            int odd = (gridX & 1);
            // 奇数列下移
            divY += odd;
            int gridY = divY >> 1;

            divX &= 3;
            divY &= 1;

            if (divX == 1 || divX == 2)
                return new Vector2Int(gridX, gridY);
            
            Vector2Int auth = new Vector2Int(gridX + (divX == 0 ? -1 : 1), gridY + divY - odd);
            if (PosInGrid(pos, GetCoord(auth.x, auth.y)))
                return auth;
            return new Vector2Int(gridX, gridY);
        }

        void EmitSlotEvent(Vector2 pos){
            Vector2Int rawIdx = GetHexagonIndex(pos);
            Vector2Int idx = new Vector2Int(rawIdx.x + (width >> 1), rawIdx.y + (height >> 1));
            if (idx == prevIdx)
                return;
            prevIdx = idx;
            if (idx.x >= 0 && idx.x <= width && idx.y >= 0 && idx.y <= height){
                slotArray[idx.x, idx.y].GetComponent<Slot>().OnClick();
            }
        }
    }
}

