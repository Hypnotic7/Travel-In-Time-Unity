using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LitJson;
using UnityEngine;

namespace Assets.Scripts.DataAccess.Repository.JsonRepository
{
    public abstract class JsonRepository
    {
        private JsonData data;

        public JsonRepository OpenFileAndReadData(string path)
        {
            data = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + path));
            return this;
        }

        public JsonData GetCollection()
        {
            if (data == null)
                Debug.Log("Local Data Not Found");
            return data;
        }

    }
}
