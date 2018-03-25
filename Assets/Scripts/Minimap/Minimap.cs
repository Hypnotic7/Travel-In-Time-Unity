using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Minimap
{
    public class Minimap : MonoBehaviour
    {
        public Transform player;

        void LateUpdate()
        {
            player = GameObject.Find("Character(Clone)").transform;
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
    }
}
