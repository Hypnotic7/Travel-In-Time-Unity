using UnityEngine;

namespace Interactables
{
    public class DoorScript : Interactable
    {

        public bool ContainsKey;
        public bool OpenClose;
        public bool IsTriggered;
        public int counter;


        // Use this for initialization
        void Start ()
        {
            IsTriggered = false;
            ContainsKey = false;
            counter = 0;
        }

        public bool CheckForKey()
        {
            var inv = GameObject.Find("Inventory").GetComponent<Inventory>();
            foreach (var item in inv.items)
            {
                if (item.ID == 2)
                {
                    ContainsKey = true;
                    return ContainsKey;
                }
            }
            return ContainsKey;
        }

        void Update()
        {
           
        }
        

        public override void Interact()
        {
            Debug.Log("Doors were clicked");
            IsTriggered = true;

            if (CheckForKey())
            {
                if (IsTriggered)
                {
                    if (ContainsKey)
                    {
                        if (OpenClose && counter != 0)
                        {
                            Debug.Log("Doors Open: " + OpenClose);
                            var door = GameObject.Find("DoorRoom2").transform;
                            transform.Rotate(0, -90, 0, Space.Self);
                            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                            //door.localRotation = newRotation;
                            OpenClose = !OpenClose;
                            IsTriggered = false;

                        }
                        else if (!OpenClose)
                        {
                            Debug.Log("Doors Closed: " + OpenClose);
                            var door = GameObject.Find("DoorRoom2").transform;
                            transform.Rotate(0, 90, 0, Space.Self);
                            transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);
                            //door.localRotation = newRotation;
                            OpenClose = !OpenClose;
                            IsTriggered = false;

                        }
                        counter++;
                    }
                }

            }
        }
    }
           
    }

