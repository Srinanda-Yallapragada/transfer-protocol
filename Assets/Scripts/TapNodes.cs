using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNodes : MonoBehaviour
{
	public Material outline;
	public Material noOutline;

    private bool isOutlined = false;
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                string tag = hit.transform.gameObject.tag;
                if (tag == "Node") {
                    hit.transform.gameObject.GetComponent<Renderer>().material = isOutlined? noOutline : outline;
                    isOutlined = !isOutlined;
                }
            }
        }
    }
}
