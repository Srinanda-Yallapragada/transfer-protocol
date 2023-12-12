using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpawnPacket : MonoBehaviour
{

    public GameObject packet_prefab;
    public Vector3 spawn_at;
    public Vector3 target;
    public string spawned_by;
    public float radius;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && spawned_by == "player")
        {
            GameObject packet = Instantiate(packet_prefab);
            packet.transform.position = spawn_at;
            packet.SendMessage("SetTarget", target);
            packet.SendMessage("SetRadius", radius);
            packet.tag = "PlayerPacket";
        }
        if (Input.GetMouseButtonDown(1) && spawned_by == "enemy")
        {
            GameObject packet = Instantiate(packet_prefab);
            packet.transform.position = spawn_at;
            packet.SendMessage("SetTarget", target);
            packet.SendMessage("SetRadius", radius);
            packet.tag = "EnemyPacket";
        }
    }
}

