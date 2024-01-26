using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerIconChanger : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] faces;


    private void OnEnable()
    {
        ChildHungerManager.OnHungerChange += ChangeIcon;
    }

    private void OnDisable()
    {
        ChildHungerManager.OnHungerChange -= ChangeIcon;
    }

    private void ChangeIcon()
    {
        image.sprite = faces[FindObjectOfType<ChildHungerManager>().GetHungerIndex()];
    }
}
