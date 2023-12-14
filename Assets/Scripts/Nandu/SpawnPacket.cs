using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpawnPacket : MonoBehaviour
{

    public GameObject packet_prefab;
    public Vector3 target;


    public void spawn(int radius, string tag)
    {
        GameObject packet = Instantiate(packet_prefab);
        packet.transform.position = this.transform.GetChild(1).gameObject.transform.position;
        packet.SendMessage("SetTarget", target);
        packet.SendMessage("SetRadius", radius);
        packet.tag = tag;
    }

}

