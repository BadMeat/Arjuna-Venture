using UnityEngine;
using System.Collections;

public class StickPlatform : MonoBehaviour {
	private void OnTriggerStay2D(Collider2D other){
		if(other.tag == "Platform"){
			transform.SetParent(other.transform);
		}
	}

	private void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Platform"){
			transform.SetParent(null);
		}
	}
}
