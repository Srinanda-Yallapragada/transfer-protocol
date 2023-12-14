using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ChooseWire : MonoBehaviour
{
    public GameObject[] lanes;
	public Material outline;
	public Material noOutline;

    public Button byteBtn;
    public Button kiloBtn;
    public Button megaBtn;
    public Button gigaBtn;

    public TextMeshProUGUI byteTxt;
    public TextMeshProUGUI kiloTxt;
    public TextMeshProUGUI megaTxt;
    public TextMeshProUGUI gigaTxt;

    public bool isPaused = false;

    private bool[] isLaneOutlined;
    private int prevIndex = -1;
    private int currIndex = -1;
    private float byteTimer;  
    private float kiloTimer;
    private float megaTimer;
    private float gigaTimer;

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

        // Timers
        if (Mathf.FloorToInt(byteTimer) > 0)
        {
            byteTimer -= Time.deltaTime;
            byteTxt.text = Mathf.FloorToInt(byteTimer) + "s";
        } 
        else if (Mathf.FloorToInt(byteTimer) <= 0)
        {
            byteTxt.text = "";
            byteBtn.interactable = true;
        }

        if (Mathf.FloorToInt(kiloTimer) > 0)
        {
            kiloTimer -= Time.deltaTime;
            kiloTxt.text = Mathf.FloorToInt(kiloTimer) + "s";
        }
        else if (Mathf.FloorToInt(kiloTimer) <= 0)
        {
            kiloTxt.text = "";
            kiloBtn.interactable = true;
        }

        if (Mathf.FloorToInt(megaTimer) > 0)
        {
            megaTimer -= Time.deltaTime;
            megaTxt.text = Mathf.FloorToInt(megaTimer) + "s";
        }
        else if (Mathf.FloorToInt(megaTimer) <= 0)
        {
            megaTxt.text = "";
            megaBtn.interactable = true;
        }

        if (Mathf.FloorToInt(gigaTimer) > 0)
        {
            gigaTimer -= Time.deltaTime;
            gigaTxt.text = Mathf.FloorToInt(gigaTimer) + "s";
        }
        else if (Mathf.FloorToInt(gigaTimer) <= 0)
        {
            gigaTxt.text = "";
            gigaBtn.interactable = true;
        }
    }

    void Select(int index)
    {
        if (isPaused) return;
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
        byteTimer = 2;
        byteBtn.interactable = false;
    }
    public void SpawnKilobyte()
    {
        lanes[currIndex].transform.GetChild(0).gameObject.GetComponent<SpawnPacket>().spawn(5);
        kiloTimer = 5;
        kiloBtn.interactable = false;
    }
    public void SpawnMegabyte()
    {
        lanes[currIndex].transform.GetChild(0).gameObject.GetComponent<SpawnPacket>().spawn(7);
        megaTimer = 10;
        megaBtn.interactable = false;
    }
    public void SpawnGigabyte()
    {
        lanes[currIndex].transform.GetChild(0).gameObject.GetComponent<SpawnPacket>().spawn(9);
        gigaTimer = 20;
        gigaBtn.interactable = false;
    }
}
