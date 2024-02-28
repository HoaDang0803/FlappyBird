using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallMoving : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    void Update()
    {
        transform.Translate(new Vector3(-1*Time.deltaTime*moveSpeed,0,0));
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reset"))
            RandomWall();
    }

    private void RandomWall()
    {
            transform.position = new Vector3(transform.position.x + 4*6,Random.Range(minY,maxY + 1),0);
        }
    }
