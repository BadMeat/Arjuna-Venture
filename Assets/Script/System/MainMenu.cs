using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private bool newStart;

	public GameObject yesButton;
	public GameObject noButton;
	public GameObject boxButton;
	public Image loadButton;
	public string[] weaponStat;

	public void StartGame(){
		if(PlayerPrefs.GetInt("startGame") <= 0){
			SetStatus();
		}
		else if(PlayerPrefs.GetInt("startGame") > 0){
			newStart = !newStart;
		}
		else{
			newStart = !newStart;
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.P)){
			PlayerPrefs.DeleteAll();
		}

		//if(PlayerPrefs.GetFloat("startGame") < 1){
		//	newStart = true;
		//}

		if(newStart){
			yesButton.SetActive(true);
			noButton.SetActive(true);
			boxButton.SetActive(true);
		}else{
			yesButton.SetActive(false);
			noButton.SetActive(false);
			boxButton.SetActive(false);
		}

		if(PlayerPrefs.GetInt("startGame") <1){
			loadButton.color = new Color(loadButton.color.r,loadButton.color.g,loadButton.color.b,0.5f);
		}
	}

	public void ExitGame(){
		Application.Quit();
	}

	public void LoadGame(){
		if(PlayerPrefs.GetInt("startGame") <1){
			loadButton.color = new Color(loadButton.color.r,loadButton.color.g,loadButton.color.b,0.5f);
		}else{
			//Application.LoadLevel("Forest");
			SceneManager.LoadScene("Forest");
		}
	}

	public void YesButton(){
		SetStatus();
	}

	public void NoButton(){
		newStart = !newStart;
	}

	private void SetStatus(){
		PlayerPrefs.SetFloat("currentHealth",10f);
		PlayerPrefs.SetFloat("maxHealth",10f);
		PlayerPrefs.SetFloat("gold",0);
		PlayerPrefs.SetFloat("currentExp",0);
		PlayerPrefs.SetFloat("maxExp",10f);
		PlayerPrefs.SetInt("startGame",1);
		PlayerPrefs.SetInt("level",1);
		PlayerPrefs.SetFloat("damage",5);
		PlayerPrefs.SetFloat("weaponUse",0);
		for(int a=0;a<weaponStat.Length;a++){
			PlayerPrefs.SetFloat(weaponStat[a],0);
		}
		//Application.LoadLevel("Forest");
		SceneManager.LoadScene("Forest");
	}
}
