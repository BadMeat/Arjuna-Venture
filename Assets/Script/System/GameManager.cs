using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager gm;

	public Status playerStatus;
	public Controller playerController;
	public Qeustion question;
	public HealthBar health;
	public ExpBar exp;
	public CombatManager combatManager;
	public Menu menuButton;

	void Start () {
		playerStatus = FindObjectOfType<Status>();
		playerController = FindObjectOfType<Controller>();
		question = FindObjectOfType<Qeustion>();
		health = FindObjectOfType<HealthBar>();
		exp = FindObjectOfType<ExpBar>();
		menuButton = FindObjectOfType<Menu>();
		combatManager = GetComponent<CombatManager>();
	}

	void Awake(){
		if(gm == null){
			gm = this;
		}else{
			Debug.Log("NotFound");
		}
	}
}
