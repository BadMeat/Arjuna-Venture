using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Status : MonoBehaviour {

	public string thisLevel;
	public Image healthBar;
	public Image expBar;
	public Text levelBar;
	public GameObject[] bodyPart;
	public GameObject deathAnimation;
	public Text goldText;
	public int[] cp;

	private float currentHealth;
	private float maxHealth;
	private float currentExp;
	private float maxExp;
	private int level;
	private float gold;
	private float damage;
	

	void Start () {
		if(PlayerPrefs.GetFloat("newDeath") >0){
			NewStart();
			for(int a=1;a<cp.Length;a++){
				if(PlayerPrefs.GetFloat("savePosition") == a){
					//transform.position = new Vector3(CheckPoint.cp.CheckPosition().x,CheckPoint.cp.CheckPosition().y,CheckPoint.cp.CheckPosition().z);
				}
			}
		}else{
			LoadState();
		}
	}

	void Update () {
		Death();
		LevelUp();
		levelBar.text = ""+level;
		goldText.text = "RP "+gold;
		GameManager.gm.health.ChangeHealth(healthBar,currentHealth,maxHealth);
		GameManager.gm.exp.ChangeExp(expBar,currentExp,maxExp);
		if(Input.GetKeyDown(KeyCode.H)){
			gold +=1000f;
			currentExp +=5f;
			PlayerPrefs.SetFloat("gold",gold);
		}
	}

	private void Death(){
		if(currentHealth <=0){
			PlayerPrefs.SetFloat("gold",gold);
			StartCoroutine("instanceDeath");
			gameObject.SetActive(false);
			Invoke("Deather",1f);
			if(currentExp >0){
				PlayerPrefs.SetFloat("currentExp",currentExp - 2f);
			}
		}
		if(transform.position.y <=-17f){
			currentHealth = 0f;
			if(currentExp >0){
				PlayerPrefs.SetFloat("currentExp",currentExp - 2f);
			}
		}
	}

	public void GetHitted(float damage){
		GameManager.gm.combatManager.CreateText(transform,"-" +damage +" HP",Color.red,2f);
		currentHealth -= damage;
		if(currentHealth > 0){
			StartCoroutine("Blink");
		}
	}

	public void GetDrop(float gold, float exp){
		this.gold += gold;
		this.currentExp += exp;
	}

	private void LoadState(){
		currentHealth = PlayerPrefs.GetFloat("currentHealth");
		maxHealth = PlayerPrefs.GetFloat("maxHealth");
		currentExp = PlayerPrefs.GetFloat("currentExp");
		maxExp = PlayerPrefs.GetFloat("maxExp");
		level = PlayerPrefs.GetInt("level");
		gold = PlayerPrefs.GetFloat("gold");
		damage = PlayerPrefs.GetFloat("damage");
		PlayerPrefs.DeleteKey("savePosition");
	}

	public void SaveState(){
		PlayerPrefs.SetFloat("currentHealth",currentHealth);
		PlayerPrefs.SetFloat("currentExp",currentExp);
		PlayerPrefs.SetInt("level",level);
		PlayerPrefs.SetFloat("gold",gold);
		PlayerPrefs.SetFloat("damage",damage);
	}

	public void LevelUp(){
		if(currentExp >= maxExp){
			GameManager.gm.combatManager.CreateText(transform,"Level UP",Color.yellow,1f);
			PlayerPrefs.SetFloat("maxHealth",maxHealth + 10);
			PlayerPrefs.SetFloat("maxExp",maxExp + 10);
			PlayerPrefs.SetInt("level",level + 1);
			maxHealth = PlayerPrefs.GetFloat("maxHealth");
			maxExp = PlayerPrefs.GetFloat("maxExp");
			level = PlayerPrefs.GetInt("level");
			currentHealth = maxHealth;
			currentExp = 0;
		}
	}

	private IEnumerator Blink(){
		for(int a=0;a<3;a++){
			for(int b=0;b<bodyPart.Length;b++){
				bodyPart[b].SetActive(false);
			}
			yield return new WaitForSeconds(0.2f);
			for(int b=0;b<bodyPart.Length;b++){
				bodyPart[b].SetActive(true);
			}
			yield return new WaitForSeconds(0.2f);
		}
	}

	private void Deather(){
		PlayerPrefs.SetFloat("newDeath",1);
		//Application.LoadLevel(thisLevel);
		SceneManager.LoadScene(thisLevel);
	}

	private IEnumerator instanceDeath(){
		Instantiate(deathAnimation,transform.position,Quaternion.identity);
		yield return new WaitForSeconds(1f);
	}

	public void SetDamage(float damage){
		this.damage = damage;
	}

	public float GetDamage(){
		return damage;
	}

	public void SetGold(float gold){
		this.gold -=gold;
	}

	public void NewStart(){
		maxHealth = PlayerPrefs.GetFloat("maxHealth");
		currentExp = PlayerPrefs.GetFloat("currentExp");
		maxExp = PlayerPrefs.GetFloat("maxExp");
		level = PlayerPrefs.GetInt("level");
		gold = PlayerPrefs.GetFloat("gold");
		damage = PlayerPrefs.GetFloat("damage");
		currentHealth = maxHealth;
		PlayerPrefs.SetInt("newDeath",0);
	}
}
