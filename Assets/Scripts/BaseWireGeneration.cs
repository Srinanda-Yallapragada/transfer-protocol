using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWireGeneration : MonoBehaviour
{
    public GameObject[] lanes;
    public bool isEnemy;
    GameObject baseSphere;

    // Start is called before the first frame update
    void Start()
    {
        baseSphere = this.transform.GetChild(0).transform.gameObject;
        int whichPole = isEnemy ? 1 : 0;

        foreach (GameObject g in lanes)
        {
            // Home / Enemy
            GameObject sphere = g.transform.GetChild(whichPole).gameObject.transform.GetChild(1).gameObject;

            Vector3 mid = Vector3.Lerp(baseSphere.transform.position, sphere.transform.position, 0.5f);
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            cylinder.name = isEnemy? "Enemy" : "Home";
            cylinder.transform.position = new Vector3(mid.x, baseSphere.transform.position.y, mid.z);
            cylinder.transform.parent = g.transform;
            Vector3 direction = sphere.transform.position - cylinder.transform.position;
            cylinder.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            float distance = Vector3.Distance(sphere.transform.position, baseSphere.transform.position) / 2f;
            cylinder.transform.localScale = new Vector3(1f, distance, 1f);
        }
    }
}
