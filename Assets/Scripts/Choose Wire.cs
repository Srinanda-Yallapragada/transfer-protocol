using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWire : MonoBehaviour
{
    public GameObject top;
    public GameObject mid;
    public GameObject bot;
	public Material outline;
	public Material noOutline;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                string go = hit.transform.gameObject;
                if (go.equals(top)) {
                    Debug.Log("Test");
                }
                
            }
        }
    }
}
