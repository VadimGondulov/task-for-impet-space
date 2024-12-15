using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Scripts_Player>().transform;
    }
    
    private void Update()
    { 
        pos = player.position;
        pos.z = -15f;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
