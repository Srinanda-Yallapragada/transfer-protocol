using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class Packet : MonoBehaviour
{
    public AudioSource src;
    public AudioClip packetCollision;

    public Vector3 target;
    public int radius;

    GameObject gameManager;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        src = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        src.clip = packetCollision;

    }
    public void SetTarget(Vector3 t)
    {
        target = t;
    }


    public void SetRadius(int t)
    {
        radius = t;
        gameObject.transform.localScale = new Vector3(radius, radius, radius);

    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position == target)
        //check this.tage and decidte hitByte or byteDamage or hitPacket
        {
            switch (radius)
            {
                case 3:
                    if (this.CompareTag("PlayerPacket"))
                        gameManager.GetComponent<HpScript>().hitByte();
                    else
                    {
                        gameManager.GetComponent<HpScript>().byteDamage();
                    }
                    break;
                case 5:
                    if (this.CompareTag("PlayerPacket"))
                        gameManager.GetComponent<HpScript>().hitKilo();
                    else
                    {
                        gameManager.GetComponent<HpScript>().kiloDamage();
                    }
                    break;
                case 7:
                    if (this.CompareTag("PlayerPacket"))
                        gameManager.GetComponent<HpScript>().hitMega();
                    else
                    {
                        gameManager.GetComponent<HpScript>().megaDamage();
                    }
                    break;
                case 9:
                    if (this.CompareTag("PlayerPacket"))
                        gameManager.GetComponent<HpScript>().hitGiga();
                    else
                    {
                        gameManager.GetComponent<HpScript>().gigaDamage();
                    }
                    break;
                default:
                    break;
            }
            Destroy(gameObject); // here gameobject is the packet prefab clone object set by default
        }

        switch (radius)
        {
            case 1:
            case 2:
            case 3:
                speed = 10f;
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
            case 4:
            case 5:
                speed = 7.5f;
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
                break;
            case 6:
            case 7:
                speed = 5f;
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
            case 8:
            case 9:
                speed = 2.5f;
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;
            default:
                break;
        }

        Vector3 rotateDir = target - transform.position;
        Vector3 moveDir = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.SetPositionAndRotation(moveDir, Quaternion.FromToRotation(Vector3.up, rotateDir));
    }
    void OnTriggerEnter(Collider other)
    {

        if (this.CompareTag(other.tag))
        {
            return;
        }

        if (other.CompareTag("PlayerPacket"))
        {
            return;
        }

        Packet enemy_packet = other.GetComponent<Packet>();
        if (enemy_packet == null)
        {
            return;
        }


        if (this.radius > enemy_packet.radius)
        {
            this.radius -= enemy_packet.radius;
            this.gameObject.transform.localScale = new Vector3(this.radius, this.radius, this.radius);
            Destroy(other.gameObject);
        }
        else if (this.radius < enemy_packet.radius)
        {
            enemy_packet.radius -= this.radius;
            enemy_packet.gameObject.transform.localScale = new Vector3(enemy_packet.radius, enemy_packet.radius, enemy_packet.radius);
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