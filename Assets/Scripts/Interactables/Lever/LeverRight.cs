using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interactables.Lever
{
    public class LeverRight : Interactable, ILever
    {
        private GameObject leverRightObj;
        private GameObject leverRightHandleObj;
        private const string leverObjName = "LeverRight";
        private const string leverHandleObjName = "HandleRight";
        private GameObject PointLightOne;
        private GameObject PointLightTwo;
        public bool activated;
        private float timeStamp;
        private const int ActivatedInSeconds = 15;
        private Color startcolor;

        void OnMouseEnter()
        {

            startcolor = this.GetComponent<Renderer>().material.color;
            this.GetComponent<Renderer>().material.color = Color.magenta;
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.magenta;

        }
        void OnMouseExit()
        {
            this.GetComponent<Renderer>().material.color = startcolor;
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = startcolor;

        }

        void Start()
        {
            leverRightHandleObj = GameObject.Find(leverHandleObjName);
            PointLightOne = GameObject.Find("Brazier_East_One").transform.GetChild(0).gameObject;
            PointLightTwo = GameObject.Find("Brazier_East_Two").transform.GetChild(0).gameObject;
            activated = false;
        }

        public override void Interact()
        {
            activated = !activated ? Activate(leverObjName) : Deactivate(leverObjName);
            Debug.Log("Activated?" + activated);
        }

        public bool Activate(string leverPulled)
        {
            activated = true;
            PullDown(leverPulled);
            return activated;
        }

        public bool Deactivate(string leverPulled)
        {
            activated = false;
            PullUp(leverPulled);
            return activated;
        }

        public void PullDown(string lever)
        {
            var handleTransform = leverRightHandleObj.GetComponent<Transform>();
            handleTransform.Rotate(90f, 0, 0, Space.Self);
            timeStamp = Time.time + ActivatedInSeconds;
            PointLightOne.SetActive(activated);
            PointLightTwo.SetActive(activated);
        }

        public void PullUp(string lever)
        {
            var handleTransform = leverRightHandleObj.transform;
            handleTransform.Rotate(-90f, 0, 0, Space.Self);
            PointLightOne.SetActive(activated);
            PointLightTwo.SetActive(activated);
        }

        void Update()
        {
            if (activated)
            {
                if (timeStamp <= Time.time)
                {
                    Deactivate(leverObjName);
                }
            }
        }
    }
}
