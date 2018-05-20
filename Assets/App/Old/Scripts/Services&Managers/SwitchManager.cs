using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Skyrise
{
    public class SwitchManager : MonoBehaviour
    {
        Dictionary<SwitchElement, SwitchElementTarget> Buttons = new Dictionary<SwitchElement, SwitchElementTarget>();
        List<SwitchElementTarget> Elements = new List<SwitchElementTarget>(); //All elements
        public List<Link> Links; //All Links

        public void AddLink(SwitchElement switcher, SwitchElementTarget target) //Register in to Dictionary
        {
            Buttons.Add(switcher, target);
            Elements.Add(target);
        }
        public SwitchElementTarget GetLinked(SwitchElement switcher) //Get SwtichElementTarget 
        {
            return Buttons[switcher];
        }
        public void Interact(SwitchElement switcher) // Main goal of SwitchMechanism
        {
            var toInteract = Elements.Where(x => x != GetLinked(switcher) && x.gameObject.active);
            foreach (var g in toInteract)
                g.gameObject.SetActive(false); //Activation of rest
            GetLinked(switcher).gameObject.SetActive(true); //TheElemnt what you are interacting
            //switcher.gameObject.SetActive(false);
        }

        public void DeselectAll()
        {
            foreach (var e in Elements.Where(x => x.gameObject.activeInHierarchy))
            {
                e.gameObject.SetActive(false);
            }

        }

        void Start() //Set Links
        {
            foreach (var x in Links)
            {
                AddLink(x.Switcher, x.Target);
            }
        }
    }

}