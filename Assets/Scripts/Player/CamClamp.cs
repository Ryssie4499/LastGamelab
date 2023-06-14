using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamClamp : MonoBehaviour
{
    [SerializeField] Transform minCorner;

    [SerializeField] Transform maxCorner;

    [SerializeField] Transform player;

    private void Start()
    {
        transform.position = player.position;
    }
    private void Update()
    {
        if (player.position.x < maxCorner.position.x && player.position.x > minCorner.position.x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y,transform.position.z);
        }

        if (player.position.z < maxCorner.position.z && player.position.z > minCorner.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
        }
    }
}
