using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public static Arrow arrow;
	public float speed;
	public float damage;
	public GameObject[] effect;
	public GameObject[] tail;
	private bool instance;

	private Rigidbody2D body;
	private SpriteRenderer render;
	private float currentScaleX;
	private float fullColor = 1f;

	void Start () {
		if(arrow == null){
			arrow = this;
		}
		render = GetComponent<SpriteRenderer>();
		currentScaleX = transform.localScale.x;
		body = GetComponent<Rigidbody2D>();
		if(GameManager.gm.playerStatus.transform.localScale.x <0){
			speed =-speed;
			transform.localScale = new Vector3(-currentScaleX,transform.localScale.y,transform.localScale.z);
		}
		for(int a=0;a<tail.Length;a++){
			if(PlayerPrefs.GetFloat("weaponUse") == a+1){
				tail[a].SetActive(true);
			}
		}


	}

	void Update () {
		Destroy(gameObject,2f);
		body.velocity = new Vector2(speed,body.velocity.y);
		if(fullColor<=0){
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			for(int a=0;a<tail.Length;a++){
				if(PlayerPrefs.GetFloat("weaponUse") == a+1){
					Destroy(tail[a]);
					if(!instance){
						Instantiate(effect[a],transform.position,Quaternion.identity);
						instance = true;
					}
				}
			}

			other.SendMessage("GetHitted",GameManager.gm.playerStatus.GetDamage());
			speed = 0f;
			transform.SetParent(other.transform);
			render.color = new Color(render.color.r,render.color.g,render.color.b,fullColor-= 0.5f*Time.deltaTime);

		}
	}

	public void SetDamage(float damage){
		this.damage = damage;
	}
}
