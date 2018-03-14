using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Wilberforce;

namespace Assets.Scripts.Items
{
    public class ItemData : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Item item;
        public int amount;
        public int slot;
        
        private Vector2 offset;
        private Inventory inv;
        private Tooltip tooltip;
        public string levelToLoad;
        public bool ChangedScenes;
        private float timeStamp;

        void Start()
        {
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();
            tooltip = inv.GetComponent<Tooltip>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log(item.ID);
            if (item.ID != -1)
            {
                offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
                this.transform.position = eventData.position - offset;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log(item.ID);
            if (item.ID != -1)
            {
                this.transform.position = eventData.position - offset;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(inv.slots[slot].transform);
            this.transform.position = inv.slots[slot].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.Activate(item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Deactivate();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
           

            if (!item.IsCoolingdown)
            {
            
                if (item.ID == 0)
                {
                    
                    GameObject go = GameObject.Find("GameManager");
                    if (go == null)
                    {
                        Debug.LogError("Failed to find an object named 'GameManager'");
                        this.enabled = false;
                        return;
                    }

                    if (PlayerPrefs.GetString("CurrentTime").Equals(string.Empty))
                    {
                        PlayerPrefs.SetString("CurrentTime","Past_Time_Test");
                    }

                    GameManager gm = go.GetComponent<GameManager>();
                    if (PlayerPrefs.GetString("CurrentTime") == "Present_Time_Test" || gm.currentTime == "Present_Time")
                    {
                       
                        item.IsCoolingdown = true;
                        timeStamp = Time.time + item.CooldownInSeconds;
                        transform.GetComponent<Image>().color = Color.white;
                        inv.slots[item.ID].GetComponent<Image>().color = Color.yellow;
                        gm.currentTime = "Past_Time_Test";
                        gm.LoadScene(gm.currentTime);
                    }
                    else if (PlayerPrefs.GetString("CurrentTime") == "Past_Time_Test" || gm.currentTime == "Past_Time")
                    {
                       
                        item.IsCoolingdown = true;
                        timeStamp = Time.time + item.CooldownInSeconds;
                        transform.GetComponent<Image>().color = Color.white;
                        inv.slots[item.ID].GetComponent<Image>().color = Color.yellow;
                        gm.currentTime = "Present_Time_Test";
                        gm.LoadScene(gm.currentTime);
                        

                    }
                    
                }else if (item.ID == 8)
                {
                    var colorBlind = GameObject.Find("Main Camera(Clone)").GetComponent<Colorblind>();
                    colorBlind.enabled = !colorBlind.enabled;
                }
            }


            }

        void Update()
        {
            if (item.IsCoolingdown)
            {
                if (timeStamp <= Time.time)
                {
                    transform.GetComponent<Image>().color = Color.white;
                    inv.slots[item.ID].GetComponent<Image>().color = Color.white;
                    item.IsCoolingdown = false;
                }
            }
        }
            


        }
    }

