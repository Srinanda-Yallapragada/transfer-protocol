using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * A simple implementation of animated power lines in Unity.
 * This script generates a certain number of segments between two empty GameObjects (start, end)
 * and animates the segments if desired.
 * See this for details: https://nerdhut.de/?p=11336
 * You are free to use this code in your personal and educational projects. Please do not use
 * it commercially. Do not redistribute the code.
 * If you want to use it commercially, please contact: https://nerdhut.de/contact/
 * 
 **/

public class DynamicWire : MonoBehaviour
{
	public GameObject start;
	public GameObject end;
	public Material segmentMaterial;

	[Space(10)]
	public int segments = 16;
	public float diameter = 0.1f;
	public float segmentMass = 0.1f;
	public float drag = 10f;

	// Private fields
	private float distance;
	private float segmentLength;

	void Start ()
	{
		GameObject previous = null;

		distance = Vector3.Distance(start.transform.position, end.transform.position);
		segmentLength = (distance / segments) / (2.0f);

		for (int i = 0; i < segments; i++) {
			GameObject wire = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			Renderer r = wire.GetComponent<Renderer>();

			wire.transform.localScale = new Vector3(diameter, segmentLength, diameter);
			wire.transform.position = start.transform.position + 
				(start.transform.forward * (segmentLength)) + 
				(start.transform.forward * (segmentLength * i * (2.0f)));
			wire.transform.Rotate(new Vector3(270f, 0f, 0f));
			// wire.transform.Rotate(Vector3.RotateTowards(transform.forward, end.transform.position));

			r.material = segmentMaterial;
			wire.name = "WireSegment_" + (i + 1);

			Rigidbody rb = wire.AddComponent(typeof(Rigidbody)) as Rigidbody;
			HingeJoint conn = wire.AddComponent(typeof(HingeJoint)) as HingeJoint;
			
			rb.mass = (i % 2 != 0) ? segmentMass : segmentMass * 2f;
			rb.drag = rb.angularDrag = drag;

			if (i == 0)
				conn.connectedBody = start.GetComponent<Rigidbody>();
			else
				conn.connectedBody = previous.GetComponent<Rigidbody>();

			previous = wire;
		}

		end.GetComponent<HingeJoint>().connectedBody = previous.GetComponent<Rigidbody>();
	}
}