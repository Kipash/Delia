using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Skyrise
{
    public class Call
    {
        public Coroutine Corountine;
        public int ID;
    }

    public class StaticCoroutine : MonoBehaviour
    {
        Dictionary<int, Coroutine> coroutine = new Dictionary<int, Coroutine>();

        int instacesCrossScene;
        int instacesBasedScene;

        public void CallDelayed(Action a, float t, bool crossScene)
        {
            Register(new Call()
            {
                ID = crossScene ? instacesCrossScene-- : instacesBasedScene++,
                Corountine = StartCoroutine(Delay(a, t, crossScene ? instacesCrossScene : instacesBasedScene)),
            });
        }

        void Register(Call c)
        {
            coroutine.Add(c.ID, c.Corountine);
        }

        public void Kill(bool crossScene)
        {
            foreach(var c in coroutine.Keys)
            {
                if(crossScene)
                {
                           
                }
            }
        }
        void Kill(int id)
        {
            StopCoroutine(coroutine[id]);
            coroutine.Remove(id);
        }

        IEnumerator Delay(Action a, float t, int id)
        {
            yield return new WaitForSeconds(t);
            a();
            Kill(id);
        }

        IEnumerator Repeat(Action a, float period)
        {
            while (true)
            {
                yield return new WaitForSeconds(period);
                a();
            }
        }
    }
}