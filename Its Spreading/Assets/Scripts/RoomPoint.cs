using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPoint : MonoBehaviour
{
    public float rotationSpeed;
    public float distance;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }



    private void Update()
    {
        transform.position = startPos + new Vector3(-Mathf.Cos(Time.time * rotationSpeed) * distance,
                                                            Mathf.Sin(Time.time * rotationSpeed) * distance, 0);
        
    }
}
