using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skyrise
{
    [Serializable]
    public class AppInput
    {
        public Dictionary<int, int[]> Keys = new Dictionary<int, int[]>();

        public bool Disable;

        public void Initialize()
        {
            //Log.Console.Add("bind", this, "EditBind");

            Add(Key.MoveUp, new KeyCode[] { KeyCode.UpArrow, KeyCode.W });
            Add(Key.MoveDown, new KeyCode[] { KeyCode.DownArrow, KeyCode.S });
            Add(Key.MoveLeft, new KeyCode[] { KeyCode.LeftArrow, KeyCode.A });
            Add(Key.MoveRight, new KeyCode[] { KeyCode.RightArrow, KeyCode.D });
        }

        int i;
        public void Add(Key k, KeyCode[] codes)
        {
            Keys.Add((int)k, codes.Cast<int>().ToArray());
        }

        public void EditBind(string rawKey, string rawKeyCode)
        {
            Key key = IsKey(rawKey);
            string keyCodeName = Enum.GetNames(typeof(KeyCode))
                                    .FirstOrDefault(x => x.ToLower() == rawKeyCode.ToLower());
            if(!string.IsNullOrWhiteSpace(keyCodeName))
            {
                KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), keyCodeName);

                var kCodes = Keys[(int)key].Cast<KeyCode>().ToArray();
                Keys.Remove((int)key);
                Add(key, (new KeyCode[] { keyCode }).Concat(kCodes).ToArray());
            }
        }
        Key IsKey(string rawKey)
        {
            Key key;
            string keyName = Enum.GetNames(typeof(Key))
                        .FirstOrDefault(x => x.ToLower() == rawKey.ToLower());
            if (!string.IsNullOrWhiteSpace(keyName))
            {
                return (Key)Enum.Parse(typeof(Key), keyName);
            }
            else
                Debug.LogError("No such key as " + rawKey + " is found!");

            return Key.none;
        }

        public bool GetKey(Key k, KeyState s)
        {
            if (Disable)
                return false;

            int[] keys = HaveBinding((int)k);
            for (int i = 0; i < keys.Length; i++)
            {
                
                switch (s)
                {
                    case KeyState.Initial:
                        if (Input.GetKeyDown((KeyCode)keys[i]))
                            return true;
                        break;
                    case KeyState.Press:
                        if (Input.GetKey((KeyCode)keys[i]))
                            return true;
                        break;
                    case KeyState.End:
                        if (Input.GetKeyUp((KeyCode)keys[i]))
                            return true;
                        break;
                    default:
                        UnityEngine.Debug.LogError("Keystate == none!");
                        break;
                }
            }
            return false;
        }

        private int[] HaveBinding(int pButton)
        {
            int[] keys;
            if (Keys.TryGetValue(pButton, out keys))
            {
                return keys;
            }
            UnityEngine.Debug.LogError(string.Format("Empty field of KeyCodes!"));
            return null;
        }
    }
}