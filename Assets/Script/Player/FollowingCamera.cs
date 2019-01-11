using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour {

	private Camera mainCamera;
	public float yOffset;

	public float maxX;
	public float minX;
	public float maxY;
	public float minY;

	void Start () {
		mainCamera = Camera.main;
	}

	void Update () {
		if(transform.position.y <= minY){
			mainCamera.transform.position = new Vector3(transform.position.x,minY, mainCamera.transform.position.z);
		}
		else if(transform.position.y >= maxY){
			mainCamera.transform.position = new Vector3(transform.position.x,maxY, mainCamera.transform.position.z);
		}
		else{
			mainCamera.transform.position = new Vector3(transform.position.x,transform.position.y + Camera.main.orthographicSize - yOffset, mainCamera.transform.position.z);
		}
		if(transform.position.x <= minX){
			mainCamera.transform.position = new Vector3(minX,transform.position.y + Camera.main.orthographicSize - yOffset, mainCamera.transform.position.z);
		}
		else if(transform.position.x >= maxX){
			mainCamera.transform.position = new Vector3(maxX,transform.position.y + Camera.main.orthographicSize - yOffset, mainCamera.transform.position.z);
		}
		else{
			mainCamera.transform.position = new Vector3(transform.position.x,transform.position.y + Camera.main.orthographicSize - yOffset, mainCamera.transform.position.z);
		}
	}
}
