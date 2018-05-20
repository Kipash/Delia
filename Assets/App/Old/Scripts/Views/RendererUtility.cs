using UnityEngine;
using UnityEngine.Events;

using System;
using System.Collections;

namespace Skyrise
{
    public class RendererUtility : MonoBehaviour
    {
        public BoolEvent visibility;

        void OnBecameVisible()
        {
            visibility.Invoke(true);
        }
        void OnBecameInvisible()
        {
            visibility.Invoke(false);
        }
    }

    [Serializable]
    public class BoolEvent : UnityEvent<bool> { }

}