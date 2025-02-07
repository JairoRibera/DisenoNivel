using UnityEngine;
using System.Collections;

public class ControlRotCamera : MonoBehaviour {
	public float rot_Speed_Y = 2;
	//ROTACION X
	public  float rot_Speed_X = 1;
	public Transform piv_cam_X ;
	public float gradosX = 0;
	public float gradosMAX = 90;
	public float gradosMIN = - 90;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (0f, Input.GetAxis("Mouse X") * rot_Speed_Y, 0);

		gradosX += Input.GetAxis ("Mouse Y") * rot_Speed_X;

		gradosX = Mathf.Clamp (gradosX, gradosMIN, gradosMAX);

		piv_cam_X.localEulerAngles = new Vector3 (gradosX, 0, 0);
	}
}
