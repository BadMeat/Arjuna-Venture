using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public static CheckPoint cp;
	public int thisCheckpoint;
	public GameObject[] thisCp;

	private Vector3[] thisPosition;

	void Awake () {
		if(cp == null){
			cp = this;
		}else{
			//nothing;
		}
	}

	void Update(){

	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			PlayerPrefs.SetFloat("savePosition",thisCheckpoint);
		}
	}

	/*public Vector3 GetPosition(){
		for(int a=0;a<thisCp.Length;a++){
			thisPosition[a] = new Vector3(thisCp[a].transform.position.x,thisCp[a].transform.position.y,thisCp[a].transform.position.z);
			return thisPosition[a];
		}
	}*/
}
