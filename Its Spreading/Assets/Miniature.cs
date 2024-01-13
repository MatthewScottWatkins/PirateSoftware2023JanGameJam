using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Miniature", menuName = "ScriptableObjects/MiniatureScriptableObject", order = 1)]
public class Miniature : ScriptableObject
{
    public DistrictType type;

    public District district;

    public ResourceType output;

    public ResourceType secondaryOutput;
}
