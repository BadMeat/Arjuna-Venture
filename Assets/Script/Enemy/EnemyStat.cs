using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour {

	public float maxHealth;
	public Image healthBar;
	public float goldDrop;
	public float expDrop;

	private float currentHealth;
	private float currentHealthScaleX; 	


	void Start () {
		currentHealth = maxHealth;
		currentHealthScaleX = healthBar.transform.localScale.x;
	}

	void Update () {
		GameManager.gm.health.ChangeHealth(healthBar,currentHealth,maxHealth);
		Death();
		Flip();
		if(Input.GetKeyDown(KeyCode.U)){
			PlayerPrefs.SetFloat("gold",10f);
		}
	}

	private void Death(){
		if(currentHealth <=0){
			GameManager.gm.playerStatus.GetDrop(goldDrop,expDrop);
			GameManager.gm.combatManager.CreateText(transform,goldDrop + "+ Gold",Color.yellow,3f);
			GameManager.gm.combatManager.CreateText(transform,expDrop + "+ Exp",Color.blue,4f);
			Destroy(gameObject);
		}
	}

	private void Flip(){
		if(transform.localScale.x >0){
			healthBar.transform.localScale = new Vector3(currentHealthScaleX,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
		}
		if(transform.localScale.x <0){
			healthBar.transform.localScale = new Vector3(-currentHealthScaleX,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
		}
	}

	public void GetHitted(float damage){
		currentHealth -= damage;
		GameManager.gm.combatManager.CreateText(transform,"- "+ damage + " HP",Color.green,2f);
	}

	
	private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Water"){
			currentHealth = 0;
		}
	}
	
}
