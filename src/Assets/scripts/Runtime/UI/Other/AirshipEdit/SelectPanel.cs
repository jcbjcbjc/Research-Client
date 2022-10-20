using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI {
    [RequireComponent(typeof(RectTransform))]
    public class SelectPanel : MonoBehaviour
    {
        [Serializable]
        public struct State {
            public float posX;
            public Sprite btnIcon;
        };

        public Button controlButton;

        public State state1;
        public State state2;

        public float animSpeed;
        public AnimationCurve animCurve;

        private RectTransform rect;
        private bool state = true;
        private float animCurrent = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            rect = GetComponent<RectTransform>();
            controlButton.onClick.AddListener(OnClick);
        }

        void Animate(){
            float pos = Mathf.Lerp(state1.posX, state2.posX, animCurve.Evaluate(animCurrent));
            Vector2 offset = rect.offsetMin;
            rect.offsetMin = new Vector2(pos, offset.y);
        }

        // Update is called once per frame
        void Update()
        {
            if (state){
                if (animCurrent < 1.0f){
                    animCurrent += Time.deltaTime * animSpeed;
                    if (animCurrent > 1.0f)
                        animCurrent = 1.0f;
                    Animate();
                }
            }else{
                if (animCurrent > 0.0f){
                    animCurrent -= Time.deltaTime * animSpeed;
                    if (animCurrent < 0.0f)
                        animCurrent = 0.0f;
                    Animate();
                }
            }
        }

        private void OnClick(){
            state = !state;
            controlButton.GetComponent<Image>().sprite
                = state ? state2.btnIcon : state1.btnIcon ;
        }
    }
}

