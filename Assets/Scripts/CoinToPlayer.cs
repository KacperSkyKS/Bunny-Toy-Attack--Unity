using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToPlayer : MonoBehaviour
{
    Transform player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.position, 0.25f);
    }
}
