using UnityEngine;
using System.Collections;

public class MovingTiles : MonoBehaviour {

	public enum Direction{
		moveUp,
		moveRight
	}

	public float unitMoveY;
	public float unitMoveX;
	public float speed;
	public Direction direction = Direction.moveUp;

	private float currentPositionY;
	private float currentPositionX;
	private bool toUP;
	private bool toRight;

	private Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D>();
		currentPositionY = transform.position.y;
		currentPositionX = transform.position.x;
		unitMoveY = transform.position.y + unitMoveY;
		unitMoveX = transform.position.x + unitMoveX;

	}

	void Update () {
		if(direction == Direction.moveUp){
			if(toUP){
				body.velocity = new Vector2(body.velocity.x,speed);
			}
			else if(!toUP){
				body.velocity = new Vector2(body.velocity.x,-speed);
			}
			if(transform.position.y >= unitMoveY){
				toUP = false;
			}
			else if(transform.position.y <= currentPositionY){
				toUP = true;
			}
			transform.position = new Vector3(currentPositionX,transform.position.y,transform.position.z);                                                                                                                                                 
		}
		if(direction == Direction.moveRight){
			if(toRight){
				body.velocity = new Vector2(speed,body.velocity.y);
			}
			else if(!toRight){
				body.velocity = new Vector2(-speed,body.velocity.y);
			}
			if(transform.position.x >= unitMoveX){
				toRight = false;
			}
			else if(transform.position.x <= currentPositionX){
				toRight = true;
			}
			transform.position = new Vector3(transform.position.x,currentPositionY,transform.position.z);
		}
	}
}
