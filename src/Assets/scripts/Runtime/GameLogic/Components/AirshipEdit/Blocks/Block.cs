using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic {
    public class Block : MonoBehaviour
    {
        public float health;

        // Start is called before the first frame update
        public virtual void OnRightClick(){}
    }
}
