using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Audio;
using Assets.Scripts.Interactables.Lever;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Interactables.Piano
{
    public class Piano : Interactable, IAudio
    {
        public AudioClip MusicClip;
        public AudioSource MusicSource;
        public InteractableManager InteractableManager;
        public bool isPlaying;
        private bool isActive;

        private Color startcolor;

        void OnMouseEnter()
        {

            startcolor = transform.GetChild(0).GetComponent<Renderer>().material.color;
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.magenta;

        }
        void OnMouseExit()
        {
            transform.GetChild(0).GetComponent<Renderer>().material.color = startcolor;
        }


        void Start()
        {
            if (GameObject.Find("Audio(Clone)") == null)
            {
                MusicSource.clip = MusicClip;
            }
            
            isActive = false;
            isPlaying = false;
        }

        public override void Interact()
        {
            Debug.Log("Interacted");
            
            if (PlayerPrefs.GetString("CurrentTime").StartsWith("Past") && !isPlaying)
            {
                isActive = GameObject.Find("Lever_Right").GetComponent<LeverRight>().activated;

                if(isActive)
                    Play();
            }
            else
            {
                InteractableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
                InteractableManager.pianoInteraction = this.gameObject;
                if (GameObject.Find("Piano"))
                    InteractableManager.Activate("Piano");
            }
        }

        public void Clean()
        {
            
        }

        public void Play()
        {
            isPlaying = true;
            MusicSource.Play();
            isPlaying = false;
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }
    }
}
