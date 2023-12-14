using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Security;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class HelperObj
{
    public bool spawned_byte = false;
    public int byte_lane = 0;

    public bool spanwed_kilo = false;
    public int kilo_lane = 0;

    public bool spanwed_mega = false;
    public int mega_lane = 0;

    public bool spanwed_giga = false;
    public int giga_lane = 0;

}
public class AI : MonoBehaviour
{

    public GameObject[] lanes; //being initialized in GenerateMaps
    private float byteTimer;
    private float kiloTimer;
    private float megaTimer;
    private float gigaTimer;

    public HelperObj player_spawned = new HelperObj();


    void Start()
    {
        byteTimer = 0;
        kiloTimer = 0;
        megaTimer = 0;
        gigaTimer = 0;

    }

    IEnumerator Wait()
    {
        player_spawned.spawned_byte = false;
        yield return new WaitForSeconds((float)0.25);
    }

    // Update is called once per frame
    void Update()
    {

        //byte
        if (byteTimer <= -2)
        {
            SpawnByte(UnityEngine.Random.Range(0, lanes.Length));
        }

        if (byteTimer <= 0 && player_spawned.spawned_byte)
        {
            player_spawned.spawned_byte = false;

            SpawnByte(player_spawned.byte_lane);
        }

        //kilo
        if (kiloTimer <= 0 && player_spawned.spanwed_kilo)
        {
            player_spawned.spanwed_kilo = false;

            SpawnKilobyte(player_spawned.kilo_lane);
        }
        if (kiloTimer <= -4)
        {
            SpawnKilobyte(UnityEngine.Random.Range(0, lanes.Length));
        }

        //mega
        if (megaTimer <= 0 && player_spawned.spanwed_mega)
        {
            player_spawned.spanwed_mega = false;

            SpawnMegabyte(player_spawned.mega_lane);
        }
        if (megaTimer <= -7)
        {
            SpawnMegabyte(UnityEngine.Random.Range(0, lanes.Length));
        }

        //giga
        if (gigaTimer <= 0 && player_spawned.spanwed_giga)
        {
            player_spawned.spanwed_giga = false;

            SpawnGigabyte(player_spawned.giga_lane);
        }
        if (gigaTimer < 0)
        {
            SpawnGigabyte(UnityEngine.Random.Range(0, lanes.Length));
        }

        // Timers

        byteTimer -= Time.deltaTime;
        kiloTimer -= Time.deltaTime;
        megaTimer -= Time.deltaTime;
        gigaTimer -= Time.deltaTime;


    }

    public void SpawnByte(int lane)
    {
        byteTimer = 2; //nerfing the spawn rate lol
        StartCoroutine(Wait());
        lanes[lane].transform.GetChild(1).gameObject.GetComponent<SpawnPacket>().spawn(3, "EnemyPacket");

    }
    public void SpawnKilobyte(int lane)
    {
        lanes[lane].transform.GetChild(1).gameObject.GetComponent<SpawnPacket>().spawn(5, "EnemyPacket");
        StartCoroutine(Wait());
        kiloTimer = 8;

    }
    public void SpawnMegabyte(int lane)
    {
        lanes[lane].transform.GetChild(1).gameObject.GetComponent<SpawnPacket>().spawn(7, "EnemyPacket");
        StartCoroutine(Wait());
        megaTimer = 15;

    }
    public void SpawnGigabyte(int lane)
    {
        lanes[lane].transform.GetChild(1).gameObject.GetComponent<SpawnPacket>().spawn(9, "EnemyPacket");
        StartCoroutine(Wait());
        gigaTimer = 30;

    }
}
