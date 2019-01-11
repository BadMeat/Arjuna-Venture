using UnityEngine;
using System.Collections;

public class ChangeWeapon : MonoBehaviour {

	public static ChangeWeapon changeWeapon;

	private SpriteRenderer render;

	void Awake(){
		if(changeWeapon == null){
			changeWeapon = this;
		}else{
			Debug.Log("Not Found");
		}
	}
	
	void Start(){
		render = GetComponent<SpriteRenderer>();
	}

	public void ChangingWeapon(Sprite weapon){
		if(render.sprite != weapon){
			render.sprite = weapon;
		}
	}
}
