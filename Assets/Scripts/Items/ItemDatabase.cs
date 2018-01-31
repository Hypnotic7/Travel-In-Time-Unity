using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Items;
using LitJson;
using UnityEngine;

namespace Items
{
    public class ItemDatabase : MonoBehaviour
    {

        private List<Item> database = new List<Item>();
        private JsonData itemData;

        void Start()
        {
            itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
            ConstructionDatabase();

            Debug.Log(database[1].Title);
        }

        public Item FetchItemByID(int id)
        {
            for (int i = 0; i < database.Count; i++)
                if (database[i].ID == id)
                    return database[i];
                return null;
            
            
        }

        public void ConstructionDatabase()
        {
            for (int index = 0; index < itemData.Count; index++)
            {
                database.Add(new Item((int)itemData[index]["id"], itemData[index]["title"].ToString(),
                                      (int)itemData[index]["value"],(bool)itemData[index]["stackable"],
                                      itemData[index]["slug"].ToString(),(int)itemData[index]["cooldown_in_seconds"]));
            }
        }
    }
}
