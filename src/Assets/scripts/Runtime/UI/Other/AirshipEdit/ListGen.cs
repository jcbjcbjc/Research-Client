using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class ListGen : MonoBehaviour
    {
        [Serializable]
        public struct Item {
            public string name;
            public Sprite icon;
        }

        public GameObject templateItem;
        public Item[] listItems;

        // Start is called before the first frame update
        void Start()
        {
            Generate();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void Generate(){
            foreach (Item item in listItems){
                GameObject o = Instantiate(
                    templateItem,
                    transform
                );
                o.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;
                o.transform.Find("Name").GetComponent<Text>().text = item.name;
            }
        }
    }
}

