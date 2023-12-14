using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    //public int lane_count = 3;
    public GameObject polePrefab;
    public GameObject packetPrefab;

    void Awake()
    {
        // didnt wanna deal with mathing it out
        int lane_count = Random.Range(4, 6);
        int[] coors;
        switch (lane_count)
        {
            case 1:
                coors = new int[1] { 0 };
                break;
            case 2:
                coors = new int[2] { 22, -22 };
                break;
            case 3:
                coors = new int[3] { 0, 22, -22 };
                break;
            case 4:
                coors = new int[4] { 22, -22, 45, -45 };
                break;
            case 5:
                coors = new int[5] { 0, 22, -22, 45, -45 };
                break;
            default:
                coors = new int[5] { 0, 22, -22, 45, -45 };
                break;
        }

        int count = 0;
        GameObject[] objs = new GameObject[lane_count];
        foreach (int i in coors)
        {
            GameObject go = new GameObject("Lane " + count.ToString());
            float length = Random.Range(20f, 45f); // aka, Max 90, Min 40

            // Home
            GameObject pole = Instantiate(polePrefab, new Vector3(length, 16.84f, 0), Quaternion.identity);
            pole.name = "Home Side";
            pole.AddComponent<SpawnPacket>();
            pole.transform.parent = go.transform;

            // Enemy
            GameObject pole2 = Instantiate(polePrefab, new Vector3(-length, 16.84f, 0), Quaternion.identity);
            pole2.name = "Enemy Side";
            pole2.AddComponent<SpawnPacket>();
            pole2.transform.parent = go.transform;


            go.transform.position = new Vector3(0f, 0f, i);
            go.AddComponent<LaneWireGeneration>();
            objs[count++] = go;

            // Setting Spawn Packet Script Player
            pole.GetComponent<SpawnPacket>().target = pole2.transform.GetChild(1).gameObject.transform.position;
            pole.GetComponent<SpawnPacket>().packet_prefab = packetPrefab;

            // Setting Spawn Packet Script AI
            pole2.GetComponent<SpawnPacket>().target = pole.transform.GetChild(1).gameObject.transform.position;
            pole2.GetComponent<SpawnPacket>().packet_prefab = packetPrefab;
        }

        GameObject home = GameObject.FindGameObjectsWithTag("Home")[0];
        GameObject enemy = GameObject.FindGameObjectsWithTag("Enemy")[0];

        home.GetComponent<BaseWireGeneration>().lanes = objs;
        enemy.GetComponent<BaseWireGeneration>().lanes = objs;
        enemy.GetComponent<BaseWireGeneration>().isEnemy = true;

        this.GetComponent<ChooseWire>().lanes = objs;
        this.GetComponent<AI>().lanes = objs;

    }
}
