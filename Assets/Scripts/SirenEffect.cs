using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenEffect : MonoBehaviour {

	public Light redLight;
    public Light blueLight;
    public int speed;

	private Vector3 redTemp;
	private Vector3 blueTemp;
	
	// Update is called once per frame
	void Update () {
		redTemp.y += speed * Time.deltaTime;
		blueTemp.y -= speed * Time.deltaTime;

        redLight.transform.eulerAngles = redTemp;
		blueLight.transform.eulerAngles = blueTemp;
	}
}
