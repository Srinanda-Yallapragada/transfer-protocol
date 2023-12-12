using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWire : MonoBehaviour
{
    public GameObject[] lanes;
	public Material outline;
	public Material noOutline;

    bool[] isLaneOutlined;
    int prevIndex = -1;
    int currIndex = -1;

    void Start()
    {
        isLaneOutlined = new bool[lanes.Length];
        isLaneOutlined[0] = true;
        currIndex = 0;
        Select(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                string tag = hit.transform.gameObject.tag;
                if (tag == "Node")
                {
                    GameObject child = hit.transform.gameObject;
                    GameObject pole = child.transform.parent.gameObject;
                    string name = pole.transform.parent.gameObject.name;
                    switch (name)
                    {
                        case "Lane 0":
                            Select(0);
                            break;
                        case "Lane 1":
                            Select(1);
                            break;
                        case "Lane 2":
                            Select(2);
                            break;
                        case "Lane 3":
                            Select(3);
                            break;
                        case "Lane 4":
                            Select(4);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    void Select(int index)
    {
        // turns off current selected
        if (prevIndex != -1)
        {
            isLaneOutlined[prevIndex] = false;
            // Pole
            lanes[prevIndex].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = noOutline;
            lanes[prevIndex].transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = noOutline;
            // Pole End
            lanes[prevIndex].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = noOutline;
            lanes[prevIndex].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = noOutline;
            // Cylandar
            lanes[prevIndex].transform.GetChild(3).gameObject.GetComponent<Renderer>().material = noOutline;
        }
        prevIndex = index;

        // turns on selected
        isLaneOutlined[index] = true;
        // Home Side
        lanes[index].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = outline;
        lanes[index].transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = outline;
        // Enemy Side
        lanes[index].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = outline;
        lanes[index].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = outline;
        // Wire
        lanes[index].transform.GetChild(3).gameObject.GetComponent<Renderer>().material = outline;
        currIndex = index;
    }

    public void SpawnByte()
    {
        lanes[currIndex].transform.GetChild(0).gameObject.GetComponent<SpawnPacket>().spawn(3);
    }
    public void SpawnKilobyte()
    {
        lanes[currIndex].transform.GetChild(0).gameObject.GetComponent<SpawnPacket>().spawn(5);
    }
    public void SpawnMegabyte()
    {
        lanes[currIndex].transform.GetChild(0).gameObject.GetComponent<SpawnPacket>().spawn(7);
    }
    public void SpawnGigabyte()
    {
        lanes[currIndex].transform.GetChild(0).gameObject.GetComponent<SpawnPacket>().spawn(9);
    }
}
