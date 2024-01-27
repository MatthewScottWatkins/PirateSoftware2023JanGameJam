using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MamaFaceSwap : MonoBehaviour
{
    CooldownManager coolDownManager;

    public Image image;
    public Sprite[] faces;

    public Image Slider;


    // Start is called before the first frame update
    void Awake()
    {
        coolDownManager= FindObjectOfType<CooldownManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Slider.fillAmount += Time.deltaTime;
    }

    public void UpdatePortrait()
    {
        if (Slider.fillAmount >= 0 && Slider.fillAmount < 0.337f)
        {
            image.sprite = faces[0];
        }
        else if (Slider.fillAmount >= 0.337f && Slider.fillAmount < 0.667f)
        {
            image.sprite = faces[1];
        }
        else if (Slider.fillAmount >= 0.667f && Slider.fillAmount < 1)
        {
            image.sprite = faces[2];
        }
    }
}
