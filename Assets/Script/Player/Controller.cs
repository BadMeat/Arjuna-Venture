using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	public Transform groundCheck;
	public LayerMask layer;
	public float radius;
	public GameObject arrow;
	public Transform arrowOut;
	public AudioClip[] sound;

	[System.Serializable]
	public class BlockingCam{
		public float yMin;
		public float yMax;
		public float xMin;
		public float xMax;
		public float xCamDestination;
		public float yCamDestination;
	}
	public BlockingCam bk;

	private float currentScaleX;
	private bool onGround;
	private FollowingCamera fc;
	private Vector3 camDesti;
	private bool backFollowCam;

	private Rigidbody2D body;
	private Animator anim;
	private AudioSource source;

	void Start () {
		backFollowCam = true;
		source = GetComponent<AudioSource>();
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		fc = GetComponent<FollowingCamera>();

		currentScaleX = transform.localScale.x;
	}

	void FixedUpdate(){
		onGround = Physics2D.OverlapCircle(groundCheck.position,radius,layer);
	}

	void Update () {
		//HandleMovement();
		HandleAnimation();
		if(!GameManager.gm.menuButton.PauseMenu()){
			FlipPlayer();
		}
		BlockingCamera();
		if(GameManager.gm.question.TheQeustion(true) && body.velocity.x == 0f){
			if(body.velocity.y != 0){
				anim.SetBool("trueAnswer",GameManager.gm.question.TheQeustion(true));
				anim.Play("AttackJump");
			}else{
				anim.Play("Attack");
			}
			Attacking();
		}
	}

	private void HandleMovement(){
		body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.velocity.y);
		if(onGround && Input.GetKeyDown(KeyCode.Space)){
			body.velocity = new Vector2(body.velocity.x,jumpHeight);
		}
		FlipPlayer();
		HandleAnimation();
	}

	private void FlipPlayer(){
		if(body.velocity.x >0){
			transform.localScale = new Vector3(currentScaleX,transform.localScale.y,transform.localScale.z);
		}
		if(body.velocity.x <0){
			transform.localScale = new Vector3(-currentScaleX,transform.localScale.y,transform.localScale.z);
		}
	}

	private void HandleAnimation(){
		anim.SetFloat("speed",Mathf.Abs(body.velocity.x));
		anim.SetBool("onGround",onGround);
		anim.SetFloat("jumpHeight",body.velocity.y);
	}

	private void Attacking(){
		Instantiate(arrow,arrowOut.position,Quaternion.identity);
		AudioPlay(true,false);
	}
	
	private void Move(float direction){
		if(!GameManager.gm.menuButton.PauseMenu()){
			body.velocity = new Vector2(direction * speed, body.velocity.y);
		}
	}

	public void MoveLeft(){
		Move(-1);
	}

	public void MoveRight(){
		Move(1);
	}

	public void StopMove(){
		Move(0);
	}

	public void Jump(){
		if(onGround && !GameManager.gm.menuButton.PauseMenu()){
			body.velocity = new Vector2(body.velocity.x,jumpHeight);
		}
	}

	public bool CheckMovement(bool move){
		if(body.velocity.x == 0){
			move = true;
		}else{
			move = false;
		}
		return move;
	}

	private void HandleSound(){
		if(body.velocity.x !=0){
			AudioPlay(false,true);
		}
	}

	private void AudioPlay(bool fire, bool move){
		if(fire){
			source.PlayOneShot(sound[0]);
		}
		if(move){
			source.PlayOneShot(sound[1]);
		}
	}

	public void BlockingCamera(){
		camDesti = new Vector3(bk.xCamDestination,bk.yCamDestination,Camera.main.transform.position.z);
		if(transform.position.x <bk.xMax && transform.position.x > bk.xMin && transform.position.y >bk.yMin && transform.position.y <bk.yMax){
			backFollowCam = false;	
		}else{
			backFollowCam = true;
		}
		if(backFollowCam){
			fc.enabled = true;
		}
		else{
			fc.enabled = false;
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,camDesti,speed/2 * Time.deltaTime);
		}
	}
}
