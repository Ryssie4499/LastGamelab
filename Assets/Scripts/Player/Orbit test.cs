using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbittest : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        transform.Translate(transform.right.normalized);
    }
}
