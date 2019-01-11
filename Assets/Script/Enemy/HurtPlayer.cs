using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	public float damage;

	private float time;
	public float delayAttack;

	void Start () {

	}

	void Update () {
	
	}

	/*private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			GameManager.gm.playerStatus.GetHitted(damage);
			Debug.Log("Normal Attack");
		}
	}*/

	private void OnTriggerStay2D(Collider2D other){
		if(other.tag == "Player"){
			if(Time.time > time){
				GameManager.gm.playerStatus.GetHitted(damage);
				time = Time.time + delayAttack;
			}
		}
	}
}
