using UnityEngine;

namespace UI.Desc {
    // 护甲属性
    public class ArmorAttr : Attr {
        public enum Level {
            NONE,
            FIRST_LEVEL = NONE,
            PRIMARY,
            NORMAL,
            EXCELLENT,
            // 用于判断界限
            LAST_LEVEL = EXCELLENT
        }

        private static readonly Color[] colTable = new Color[]{
            new Color(1.0f, 1.0f, 1.0f, 0.390625f),
            Color.red,
            Color.green,
            Color.blue
        };

        public Level level;

        public Color color {
            get {
                return colTable[(int)level];
            }
        }
    }
}