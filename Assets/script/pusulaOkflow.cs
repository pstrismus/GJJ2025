using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusulaOkflow : MonoBehaviour
{
    [SerializeField] Transform player;

    private void Update()
    {
        Vector3 newRotation = transform.eulerAngles; 
        newRotation.z = -player.eulerAngles.y;       
        transform.eulerAngles = newRotation;       
    }
}
