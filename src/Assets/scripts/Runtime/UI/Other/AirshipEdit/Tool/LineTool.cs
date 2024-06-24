using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class LineTool : Tool
    {
        public ScrollRect scrollRect;

        protected override void OnStateChanged(bool state){
            scrollRect.horizontal = !state;
            scrollRect.vertical = !state;
            GameLogic.Global.lineMode = state;
        }
    }
}
