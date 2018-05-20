using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

[Serializable]
public class AppUIManager
{
    public Text CurrentKeysText;
    [SerializeField] Text versionLabel;
    public void SetVersion(string v)
    {
        versionLabel.text = v;
    }
}
