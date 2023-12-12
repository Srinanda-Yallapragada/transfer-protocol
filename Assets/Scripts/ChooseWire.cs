using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWire : MonoBehaviour
{
    public GameObject[] lanes;
	public Material outline;
	public Material noOutline;
    bool[] isLaneOutlined;

    void Start()
    {
        isLaneOutlined = new bool[lanes.Length];
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
                            if (isLaneOutlined[0]) { Deselect(0); } else { Select(0); }
                            break;
                        case "Lane 1":
                            if (isLaneOutlined[1]) { Deselect(1); } else { Select(1); }
                            break;
                        case "Lane 2":
                            if (isLaneOutlined[2]) { Deselect(2); } else { Select(2); }
                            break;
                        case "Lane 3":
                            if (isLaneOutlined[3]) { Deselect(3); } else { Select(3); }
                            break;
                        case "Lane 4":
                            if (isLaneOutlined[4]) { Deselect(4); } else { Select(4); }
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
        for (int i = 0; i < lanes.Length; i++)
        {
            if (isLaneOutlined[i])
            {
                isLaneOutlined[i] = false;
                // Pole
                lanes[i].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = noOutline;
                lanes[i].transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = noOutline;
                // Pole End
                lanes[i].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = noOutline;
                lanes[i].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = noOutline;
                // Cylandar
                lanes[i].transform.GetChild(3).gameObject.GetComponent<Renderer>().material = noOutline;
            }
        }

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
    }

    void Deselect(int index)
    {
        isLaneOutlined[index] = false;
        // Home Side
        lanes[index].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = noOutline;
        lanes[index].transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = noOutline;
        // Enemy Side
        lanes[index].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = noOutline;
        lanes[index].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material = noOutline;
        // Wire
        lanes[index].transform.GetChild(3).gameObject.GetComponent<Renderer>().material = noOutline;
    }
}
