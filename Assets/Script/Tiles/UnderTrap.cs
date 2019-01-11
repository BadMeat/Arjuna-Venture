using UnityEngine;
using System.Collections;

public class UnderTrap : MonoBehaviour {

	public float speed;
	public LayerMask playerLayer;
	public Transform playerDeteck;
	public float radius;
	public float unitMove;

	private bool onSign;
	private Vector3 targetMove;
	private Vector3 currentPosition;
	
	void Start () {
		currentPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		targetMove = new Vector3(transform.position.x,transform.position.y + unitMove ,transform.position.z);
	}

	void FixedUpdate(){
		onSign = Physics2D.OverlapCircle(playerDeteck.position,radius,playerLayer);
	}

	void Update () {
		if(onSign){
			transform.position = Vector3.MoveTowards(transform.position,targetMove, speed * Time.deltaTime);
		}else{
			transform.position = Vector3.MoveTowards(transform.position,currentPosition, speed * Time.deltaTime);
		}
	}
	 
	private void OnDrawGizmosSelected(){
		Gizmos.DrawSphere(playerDeteck.position,radius);
	}
}
