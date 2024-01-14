using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DistrictInformation : MonoBehaviour
{
    public Miniature miniature;

    public DistrictInformation[] adjacentDistricts;
    private List<DistrictInformation> activeAdjacentDistricts;

    private void Awake()
    {
        miniature = Instantiate(miniature);


        foreach (var district in adjacentDistricts)
        {
            if (!miniature.destroyed)
            {
                activeAdjacentDistricts.Add(district);
            }
        }
    }

}
