using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interactables.Craft
{
    public interface ICraft<T>
    {
        bool CheckForIngrediants();
        void Reward();
    }
}
