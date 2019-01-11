using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {

	private SpriteRenderer render;
	private float fullColor = 1f;

	void Start () {
		render = GetComponent<SpriteRenderer>();
	}

	void Update(){
		render.color = new Color(render.color.r,render.color.g,render.color.b,fullColor -=0.5f*Time.deltaTime);
		if(fullColor <=0){
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			//transform.position = new Vector3(other.transform.position.x,other.transform.position.y,other.transform.position.z);
			transform.SetParent(other.transform);
		}
	}
}
