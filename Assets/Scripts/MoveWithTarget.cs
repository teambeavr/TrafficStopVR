using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTarget : MonoBehaviour {
	public GameObject target;

	public bool matchPositionX;
	public bool matchPositionY;
	public bool matchPositionZ;

	public bool matchRotationX;
	public bool matchRotationY;
	public bool matchRotationZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Get current position & rotation
		Vector3 position = gameObject.transform.position;
		Vector3 rotation = gameObject.transform.rotation.eulerAngles;

		Vector3 targetPos = target.transform.position;
		Vector3 targetRot = target.transform.rotation.eulerAngles;

		// Match target position/rotation
		if (matchPositionX)
			position.x = targetPos.x;
		if (matchPositionY)
			position.y = targetPos.y;
		if (matchPositionZ)
			position.z = targetPos.z;

		if (matchRotationX)
			rotation.x = targetRot.x;
		if (matchRotationY)
			rotation.y = targetRot.y;
		if (matchRotationZ)
			rotation.z = targetRot.z;

		// Apply transform
		gameObject.transform.SetPositionAndRotation(position, Quaternion.Euler(rotation));
	}
}
