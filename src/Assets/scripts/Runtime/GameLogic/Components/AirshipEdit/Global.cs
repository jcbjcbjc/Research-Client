using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public static class Global
    {
        // 准备删除
        public static readonly LayerMask airshipLayer = LayerMask.GetMask("Airship");
        
        public static UI.MenuItem selectedItem = null;

        public static bool lineMode = false;
    }
}
