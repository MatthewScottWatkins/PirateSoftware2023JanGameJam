using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ResourceObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject toolTip;


    private void Start()
    {
        
    }

    private void OnEnable()
    {
        //create event for setting resource
        //something.spendresource += SetText;
    }

    private void SetText()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.SetActive(false);
    }
}
