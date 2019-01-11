using UnityEngine;
using System.Collections;

public class Bee : MonoBehaviour {

	public float speed;

	private int randomMove;
	private float time;
	private float delay;
	private float currentScaleX;

	private Rigidbody2D body;

	void Start () {
		currentScaleX = transform.localScale.x;
		body = GetComponent<Rigidbody2D>();
		delay = 4f;
		Randomize();
	}

	void Update () {
		if(Time.time > time){
			Randomize();
			time = Time.time + delay;
		}
		Movement();
	}

	private void Randomize(){
		randomMove = Random.Range(1,100);
	}

	private void Movement(){
		FlipPlayer();
		if(randomMove <= 25){
			body.velocity = new Vector2(speed,body.velocity.y);
			//transform.Translate(Vector3.right * speed * Time.deltaTime);
			//anim.Play("MoveRight");
		}
		if(randomMove >25 &&randomMove <=50){
			body.velocity = new Vector2(-speed,body.velocity.y);
			//transform.Translate(Vector3.left * speed * Time.deltaTime);
			//anim.Play("MoveLeft");
		}
		if(randomMove > 50 && randomMove <= 75){
			body.velocity = new Vector2(body.velocity.x,speed);
			//transform.Translate(Vector3.up * speed * Time.deltaTime);
		}
		if(randomMove >75 && randomMove <=100){
			body.velocity = new Vector2(body.velocity.x,-speed);
			//transform.Translate(Vector3.down * speed * Time.deltaTime);
		}
		if(transform.position.y <= -10.5f){
			randomMove = 60;
		}
		if(transform.position.x >= 265f){
			randomMove = 30;
		}
		if(transform.position.y >= 25f){
			randomMove = 90;
		}
		if(transform.position.x <=-6f){
			randomMove = 10;
		}
	}

	private void FlipPlayer(){
		if(body.velocity.x < 0){
			transform.localScale = new Vector3(currentScaleX,transform.localScale.y,transform.localScale.z);
		}
		if(body.velocity.x > 0){
			transform.localScale = new Vector3(-currentScaleX,transform.localScale.y,transform.localScale.z);
		}
	}
}
