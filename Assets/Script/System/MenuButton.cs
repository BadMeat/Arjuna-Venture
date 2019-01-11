using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public Texture2D[] weapon;
	public Sprite[] weaponSpirte;
	public float[] weaponPrice;
	public GUISkin skinButton;
	public string[] weaponStat;

	private float widthButton;
	private float heightButton;
	private bool onPause;
	private float[] rangeButtonY;
	private string[] menuName;
	private bool[] menuFunction;
	private bool onQuit;

	void Start () {

		widthButton = Screen.width / 10;
		heightButton = Screen.height /8;

		menuFunction = new bool[3];
		rangeButtonY = new float[3];
		menuName = new string[3];
		rangeButtonY[0] = 10f;
		for(int b=1;b<rangeButtonY.Length;b++){
			rangeButtonY[b] = rangeButtonY[b-1] + heightButton + 10f; 
		}

		menuName[0] = "Pause";
		menuName[1] = "Shop";
		menuName[2] = "Exit";

	}

	void Update () {
		if(onPause){
			Time.timeScale = 0;
		}
		else{
			Time.timeScale = 1;
		}
	}

	private void OnGUI(){
		GUI.skin = skinButton;
		if(GUI.Button(new Rect(Screen.width - widthButton - 10f, rangeButtonY[0],widthButton,heightButton),menuName[0])){
			menuFunction[0] = !menuFunction[0];
			menuFunction[1] = false;
			menuFunction[2] = false;
		}
		if(GUI.Button(new Rect(Screen.width - widthButton - 10f, rangeButtonY[1],widthButton,heightButton),menuName[1])){
			menuFunction[0] = false;
			menuFunction[1] = !menuFunction[1];
			menuFunction[2] = false;
		}
		if(GUI.Button(new Rect(Screen.width - widthButton - 10f, rangeButtonY[2],widthButton,heightButton),menuName[2])){
			menuFunction[0] = false;
			menuFunction[1] = false;
			menuFunction[2] = !menuFunction[2];
		}

		if(menuFunction[0]){
			onPause = !onPause;
			onQuit = false;
		}

		if(menuFunction[1]){
			if(GUI.Button(new Rect(Screen.width - widthButton*2 - 10f*2, rangeButtonY[0], widthButton,heightButton),new GUIContent(""+weaponPrice[0],weapon[0]))){
				if(PlayerPrefs.GetFloat("gold") >= weaponPrice[0] && PlayerPrefs.GetFloat(weaponStat[0]) <=0f){
					PlayerPrefs.SetFloat("gold",PlayerPrefs.GetFloat("gold") - weaponPrice[0]);
					ChangeWeapon.changeWeapon.ChangingWeapon(weaponSpirte[0]);
					PlayerPrefs.SetFloat(weaponStat[0],1);
					GameManager.gm.playerStatus.SetDamage(10f);
				}
				else if(PlayerPrefs.GetFloat(weaponStat[0]) >0f){
					ChangeWeapon.changeWeapon.ChangingWeapon(weaponSpirte[0]);
				}
				else{
					Debug.Log("Duit mu Kurang Weapon1");
				}
			}
			if(GUI.Button(new Rect(Screen.width - widthButton*2 - 10f*2, rangeButtonY[1], widthButton,heightButton),new GUIContent(""+weaponPrice[1],weapon[1]))){
				if(PlayerPrefs.GetFloat("gold") >= weaponPrice[1] && PlayerPrefs.GetFloat(weaponStat[1]) <=0f){
					PlayerPrefs.SetFloat("gold",PlayerPrefs.GetFloat("gold") - weaponPrice[1]);
					ChangeWeapon.changeWeapon.ChangingWeapon(weaponSpirte[1]);
					PlayerPrefs.SetFloat(weaponStat[1],1);
					GameManager.gm.playerStatus.SetDamage(1000f);
				}
				else if(PlayerPrefs.GetFloat(weaponStat[1]) >0f){
					ChangeWeapon.changeWeapon.ChangingWeapon(weaponSpirte[1]);
				}
				else{
					Debug.Log("Duit mu Kurang Weapon2");
				}
			}
			if(GUI.Button(new Rect(Screen.width - widthButton*2 - 10f*2, rangeButtonY[2], widthButton,heightButton),new GUIContent(""+weaponPrice[2],weapon[2]))){
				
			}
			onQuit = false;
		}
		if(menuFunction[2]){
			onQuit = !onQuit;
		}

		if(onQuit){
			if(GUI.Button(new Rect(Screen.width/2 - widthButton - 10f,Screen.height/2 - heightButton,widthButton,heightButton),"Yes")){
				GameManager.gm.playerStatus.SaveState();
				//Application.LoadLevel("MainMenu");
			}
			if(GUI.Button(new Rect(Screen.width/2 +10f , Screen.height/2 - heightButton,widthButton,heightButton),"No")){
				onQuit = false;
			}
		}
	}
}
