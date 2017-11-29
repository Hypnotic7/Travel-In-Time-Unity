using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Items
{
    public class Item 
    {
        public int ID { get; private set; }
        public string Title { get; set; }
        public int Value { get; set; }
        public Sprite Sprite { get; set; }
        public string Slug { get; set; }

        public Item(int id, string title, int value,string slug)
        {
            this.ID = id;
            this.Title = title;
            this.Value = value;
            this.Slug = slug;
            this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug) as Sprite;

        }

        public Item()
        {
            ID = -1;
        }

    }
}
