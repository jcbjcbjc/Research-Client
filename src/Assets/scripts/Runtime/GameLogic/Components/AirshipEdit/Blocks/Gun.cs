using System.Collections;
using UnityEngine;

namespace GameLogic {
    public class Gun : Block
    {
        protected GameObject barrel;
        protected float angle = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            barrel = transform.Find("Barrel").gameObject;
            barrel.transform.rotation = Quaternion.identity;
        }

        // Update is called once per frame
        void Update()
        {

        }

        // [UnityEditor.MenuItem("Custom/Foo")]
        // static void Foo(){
        //     UnityEditor.EditorApplication.Beep();
        // }

        // ScrollBar
        public void SetAngle(float value){
            barrel.transform.rotation = Quaternion.AngleAxis(Mathf.Lerp(-90.0f, 90.0f, value), Vector3.forward);
        }
    }
}
