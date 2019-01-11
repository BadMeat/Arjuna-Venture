using UnityEngine;
using System.Collections;

public class DownTrap : MonoBehaviour {
	
	public float speed;
	public float radius;
	public Transform playerDetector;
	public LayerMask playerLayer;

	private Rigidbody2D body;
	private bool onSign;

	void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){
		onSign = Physics2D.OverlapCircle(playerDetector.position,radius,playerLayer);
	}

	void Update () {
		if(onSign){
			body.gravityScale = 10f;
			Destroy(gameObject,2f);
		}
	}
}
