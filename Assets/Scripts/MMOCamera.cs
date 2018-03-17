using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class MMOCamera : MonoBehaviour
    {
        public Transform playerCam, character, centerPoint;
        public float mouseSensivity = 10f;

        private float moveFB, moveLR;
        public float moveSpeed = 2f;

        private float zoom;
        public float zoomSpeed = 2;

        public float zoomMin = -2f;
        public float zoomMax = -20f;
            
            void Start()
            {

                zoom = -3;

            }

        void Update()
        {
            zoom += Input.GetAxis("MouseScrollwheel") * zoomSpeed;
            if (zoom > zoomMin)
                zoom = zoomMin;

            if (zoom < zoomMax)
                zoom = zoomMax;

            playerCam.transform.position = new Vector3(0, 0, zoom);
        }
    }
}
