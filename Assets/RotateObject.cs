using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {



	
	// Update is called once per frame
	void Update () {
		transform.localRotation=Quaternion.Euler(120*Vector3.up*Time.time);
		transform.position+=transform.forward*Time.deltaTime*5;
		//transform.Rotate(360*Vector3.up*Time.deltaTime); 
	}
}
