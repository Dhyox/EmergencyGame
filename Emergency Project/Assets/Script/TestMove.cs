using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float chaseRange = 5f;
    public Transform playerTransform;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < chaseRange)
        {
            // Enemy chases player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Time.deltaTime);
        }
    }
}