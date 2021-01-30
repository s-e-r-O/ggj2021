﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSpawner : NetworkBehaviour
{
    [SerializeField]
    GameObject npcPrefab;
    [SerializeField]
    int npcTotal;
    [SerializeField]
    float radius;

    public override void OnStartServer()
    {
        base.OnStartServer();
        for(int i = 0; i < npcTotal; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            Vector3 finalPosition;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) { 
                finalPosition = hit.position;
                var npc = Instantiate(npcPrefab, finalPosition, Quaternion.identity);
                NetworkServer.Spawn(npc);
            }
       
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}