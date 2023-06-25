using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupInteract : MonoBehaviour, INormalable
{
    [SerializeField] GameObject objectToEnable;

    public void NormalInteraction()
    {
        objectToEnable.SetActive(!objectToEnable.activeSelf);
    }
}
