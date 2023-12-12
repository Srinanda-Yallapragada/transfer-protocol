using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Sprites;
using UnityEngine;


public class Packet : MonoBehaviour
{

    public Vector3 target;
    public float radius;
    // takes values player, enemy

    // Start is called before the first frame update
    void Start()
    {
    }
    public void SetTarget(Vector3 t)
    {   // you can't use start. But this is just as good.
        target = t;
    }


    public void SetRadius(float t)
    {   // you can't use start. But this is just as good.
        radius = t;
        gameObject.transform.localScale = new Vector3(radius, radius, radius);

    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position == target)
        {
            Debug.Log("deduct lives here");
            Destroy(gameObject); // here gameobject is the packet prefab clone object set by default
        }

        float singleStep = 10f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target, singleStep, 0.0f);
        transform.SetPositionAndRotation(Vector3.MoveTowards(transform.position, target, 10f * Time.deltaTime), Quaternion.LookRotation(newDirection));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyPacket"))
        {
            return;
        }

        Packet player_packet = other.GetComponent<Packet>();
        if (player_packet == null)
        {
            return;
        }


        if (this.radius > player_packet.radius)
        {
            this.radius -= player_packet.radius;
            this.gameObject.transform.localScale = new Vector3(this.radius, this.radius, this.radius);
            Destroy(other.gameObject);
        }
        else if (this.radius < player_packet.radius)
        {
            player_packet.radius -= this.radius;
            player_packet.gameObject.transform.localScale = new Vector3(player_packet.radius, player_packet.radius, player_packet.radius);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}

// |
// Packet packet = other.GetComponent<Packet>();
//         Packet gameObj = this.GetComponent<Packet>();
//         if (packet != null)
//         {

//             if (gameObj.radius > packet.radius)
//             {
//                 gameObj.radius -= packet.radius;
//                 gameObj.transform.localScale = new Vector3(gameObj.radius, gameObj.radius, gameObj.radius);
//             }
//             else
//             {
//                 Destroy(other.transform.GameObject());
//             }

//         }
//     }


// Debug.Log(packet.tag);
//             //larger radius survives 
//             if (packet.radius > gameObj.radius)
//             {
//                 //if packet greater, destroy smaller
//                 float new_radius = packet.radius - gameObj.radius;
//                 packet.transform.localScale = new Vector3(new_radius, new_radius, new_radius);
//                 Destroy(gameObject);
//             }
//             else if (packet.radius < gameObj.radius)
//             {
//                 float new_radius = gameObj.radius - packet.radius;
//                 gameObj.transform.localScale = new Vector3(new_radius, new_radius, new_radius);
//                 Destroy(packet);
//             }