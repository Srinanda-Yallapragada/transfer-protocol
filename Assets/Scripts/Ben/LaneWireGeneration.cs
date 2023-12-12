using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaneWireGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerSphere;
    GameObject enemySphere;

    void Start()
    {
        GameObject parent = this.gameObject;
        // Get spheres
        playerSphere = parent.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        enemySphere = parent.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;

        // Wire
        Vector3 mid = Vector3.Lerp(enemySphere.transform.position, playerSphere.transform.position, 0.5f);
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        // Cyinder modifications
        cylinder.name = "Wire";
        cylinder.transform.position = new Vector3(mid.x, enemySphere.transform.position.y, mid.z);
        cylinder.transform.parent = parent.transform;
        Vector3 direction = playerSphere.transform.position - cylinder.transform.position;
        cylinder.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        float distance = Vector3.Distance(playerSphere.transform.position, enemySphere.transform.position) / 2f;
        cylinder.transform.localScale = new Vector3(1f, distance, 1f);
        cylinder.tag = "Node";
    }
}
