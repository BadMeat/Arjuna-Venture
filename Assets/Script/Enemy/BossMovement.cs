using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {

	public enum BossStage{
		bos1,
		bos2,
		bos3
	}

	public Transform deteckPlayerTransform;
	public float deteckPlayerRadius;
	public LayerMask deteckPlayerLayer;
	public float speed;	
	public BossStage bossStage;
	public Transform[] fireBallOut;
	public GameObject fireBall;
	public float delay;

	private Camera mainCam;
	private Vector3 maxCamera;
	private Vector3 minCamera;
	private bool moveLeft;
	private bool onTarget;
	private bool stopMove;
	private float time;
	private float currentSpeed;

	private Rigidbody2D body;
	private Animator anim;


	void Start () {
		mainCam = Camera.main;	
		currentSpeed = speed;
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		time = 4f;
	}
	
	void FixedUpdate(){
		onTarget = Physics2D.OverlapCircle(deteckPlayerTransform.position,deteckPlayerRadius,deteckPlayerLayer);
	}

	void Update () {
		Movement();
		DeteckPlayer();
	}

	private void Movement(){
		
		maxCamera = mainCam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,1f));
		minCamera = mainCam.ScreenToWorldPoint(new Vector3(0f,0f,1f));
		if(bossStage == BossStage.bos1){
			if(transform.position.x >= maxCamera.x){
				moveLeft = true;
			}
			else if(transform.position.x <= minCamera.x){
				moveLeft = false;
			}

			if(moveLeft){
				body.velocity = new Vector2(-speed,body.velocity.y);
			}
			if(!moveLeft){
				body.velocity = new Vector2(speed,body.velocity.y);
			}

			if(stopMove){
				speed = 0f;
			}else{
				speed = currentSpeed;
			}
		}
	}

	private void DeteckPlayer(){
		if(Time.timeSinceLevelLoad > time){
			anim.SetBool("onAttack",true);
			for(int a=0;a<fireBallOut.Length;a++){
				Instantiate(fireBall,fireBallOut[a].position,Quaternion.identity);
			}
			StartCoroutine("StopMoving");
			time = Time.timeSinceLevelLoad + delay;
		}

	}

	private IEnumerator StopMoving(){
		stopMove = true;
		yield return new WaitForSeconds(1f);
		stopMove = false;
		anim.SetBool("onAttack",false);
	}
}
