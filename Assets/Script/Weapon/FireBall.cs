using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public float speed;
	public GameObject fireEffect;

	private Vector3 playerPosition;
	private Rigidbody2D body;


	void Start () {
		body = GetComponent<Rigidbody2D>();
		playerPosition = GameManager.gm.playerStatus.transform.position;
	}

	void Update(){
		if(transform.position.x >playerPosition.x){
			transform.Translate(-speed*2 * Time.deltaTime, - speed/2 * Time.deltaTime, 0f);
		}else{
			transform.Translate(speed*2 * Time.deltaTime, - speed/2 * Time.deltaTime, 0f);
		}
		//transform.position = Vector3.Lerp(transform.position,playerPosition,speed * Time.deltaTime);

	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Ground"){
			Instantiate(fireEffect,transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
