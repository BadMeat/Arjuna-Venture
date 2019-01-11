using UnityEngine;
using System.Collections;

public class UnderPlayer : MonoBehaviour {

	private BoxCollider2D bc;

	void Start () {
		bc = GetComponent<BoxCollider2D>();
	}

	void Update () {
		AbovePlayer();
	}

	private void AbovePlayer(){
		if(GameManager.gm.playerStatus.transform.position.y < transform.position.y +1f){
			bc.isTrigger = true;
		}else{
			bc.isTrigger = false;
		}
	}
}
