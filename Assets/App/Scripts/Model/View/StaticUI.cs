using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Zenject;
public class StaticUI : MonoBehaviour, IInitializable
{
    [SerializeField] Text projectNameLabel;

    public void Initialize()
    {
        //temp TODO:better
        projectNameLabel.text = 
            $"{Application.productName} : " +
            $"{Application.version} (" +
            $"{Application.platform})";
    }
}
