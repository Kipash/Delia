using UnityEngine;
using System.Collections;

namespace Skyrise
{
    public class SwitchElement : MonoBehaviour
    {
        public SwitchManager Manager;
        public void Active()
        {
            Manager.Interact(this);
        }
    }
}