using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float unitMove;
	public float speed;

	public enum EnemyType{
		range,
		melee
	}

	public EnemyType enemyType;

	private float currentPositionX;
	private float currentScaleX;
	private bool moveRight;


	[System.Serializable]
	public class CatchPlayer{
		public float radius;
		public LayerMask player;
		public Transform playerDetector;
	}

	[System.Serializable]
	public class GroundCheck{
		public float groundRadius;
		public LayerMask groundLayer;
		public Transform groundDetector;
	}

	public CatchPlayer catchPlayer;
	public GroundCheck groundCheck;
	
	private Animator anim;
	private bool onSign;
	private bool onGround;
	private Vector3 playerPosition;
	private bool onAttack;
	private bool backPosition;
	private bool backRightPosition;
	private bool backLeftPosition;

	void Start () {
		anim = GetComponent<Animator>();
		moveRight = true;
		currentPositionX = transform.position.x;
		currentScaleX = transform.localScale.x;
		unitMove = currentPositionX + unitMove;
	}

	void FixedUpdate(){
		playerPosition = new Vector3(GameManager.gm.playerStatus.transform.position.x,transform.position.y,transform.position.z);
		onSign = Physics2D.OverlapCircle(catchPlayer.playerDetector.position, catchPlayer.radius,catchPlayer.player);
		onGround = Physics2D.OverlapCircle(groundCheck.groundDetector.position,groundCheck.groundRadius,groundCheck.groundLayer);
	}

	void Update () {
		HandleAnimation();
		if(onSign && enemyType == EnemyType.melee && onGround && !backPosition){
			transform.position = Vector3.MoveTowards(transform.position,playerPosition,speed * Time.deltaTime);
			if(GameManager.gm.playerStatus.transform.position.x >= transform.position.x ){
				transform.localScale = new Vector3(currentScaleX,transform.localScale.y,transform.localScale.z);
			}
			else if(GameManager.gm.playerStatus.transform.position.x < transform.position.x ){
				transform.localScale = new Vector3(-currentScaleX,transform.localScale.y,transform.localScale.z);
			}
		}
		else if(!onGround || backPosition){
			backPosition = true;
			if(GameManager.gm.playerStatus.transform.position.x <= transform.position.x){
				backRightPosition = true;
			}
			else if(GameManager.gm.playerStatus.transform.position.x > transform.position.x){
				backLeftPosition = true;
			}
			BackPosition();
		}
		else{
			Patrol();
		}
	}

	private void BackPosition(){
		if(backLeftPosition){
			transform.Translate(Vector3.left * speed * Time.deltaTime);
			transform.localScale = new Vector3(-currentScaleX,transform.localScale.y,transform.localScale.z);
			if(transform.position.x < currentPositionX){
				backPosition = false;
			}
		}
		if(backRightPosition){
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.localScale = new Vector3(currentScaleX,transform.localScale.y,transform.localScale.z);
			if(transform.position.x > unitMove){
				backPosition = false;
			}
		}
	}

	private void Patrol(){
		if(transform.position.x > unitMove){
			moveRight = false;
		}
		if(transform.position.x < currentPositionX){
			moveRight = true;
		}

		if(moveRight){
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.localScale = new Vector3(currentScaleX,transform.localScale.y,transform.localScale.z);
		}
		else if(!moveRight){
			transform.Translate(Vector3.left * speed * Time.deltaTime);
			transform.localScale = new Vector3(-currentScaleX,transform.localScale.y,transform.localScale.z);
		}
	}

	private void OnDrawGizmosSelected(){
		Gizmos.DrawSphere(catchPlayer.playerDetector.position,catchPlayer.radius);
		Gizmos.DrawSphere(groundCheck.groundDetector.position,groundCheck.groundRadius);
	}
	private void HandleAnimation(){
		anim.SetFloat("speed",Mathf.Abs(speed));
		anim.SetBool("onAttack",onAttack);
	}

	private void OnTriggerStay2D(Collider2D other){
		if(other.tag == "Player"){
			onAttack = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player"){
			onAttack = false;
		}
	}
}
