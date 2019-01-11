using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public GameObject shopMenu;
	public GameObject exitMenu;
	public Image playMenu;
	public Sprite[] pauseMenu;
	public GameObject needGold;
	public Image[] equipt;
	public Sprite[] equiptSprite;
	public Sprite[] equippedSprite;
	public float[] weaponPrice;
	public Sprite[] weaponSprite;
	public string[] weaponStat;

	private bool shopMenuActive;
	private bool exitMenuActive;
	private bool onPause;

	void Start(){
		/*for(int c=0;c<3;c++){
			if(PlayerPrefs.GetFloat(weaponStat[c])>0){
				equipt[c].sprite = equiptSprite[c];
			}
		}*/
	}

	void Update () {

		ChangeEquppedSprite();
		if(onPause){
			playMenu.sprite = pauseMenu[0];
			Time.timeScale = 0;
		}
		else if(!onPause){
			playMenu.sprite = pauseMenu[1];
			Time.timeScale = 1f;
		}
		if(shopMenuActive){
			shopMenu.SetActive(true);
		}
		else if(!shopMenuActive){
			shopMenu.SetActive(false);
		}
		if(exitMenuActive){
			exitMenu.SetActive(true);
		}
		else if(!exitMenuActive){
			exitMenu.SetActive(false);
		}
	}

	public void ShopButton(){
		shopMenuActive = !shopMenuActive;
		exitMenuActive = false; 
	}

	public void ExitButton(){
		exitMenuActive = !exitMenuActive;
		shopMenuActive = false;
	}

	public void NoExitButton(){
		exitMenuActive = false;
	}

	public void PauseButton(){
		onPause = !onPause;
	}

	public void BuyWeapon1(){
		if(PlayerPrefs.GetFloat("gold") >= weaponPrice[0] && PlayerPrefs.GetFloat(weaponStat[0]) <=0f){
			//PlayerPrefs.SetFloat("gold",PlayerPrefs.GetFloat("gold") - weaponPrice[0]);
			GameManager.gm.playerStatus.SetGold(weaponPrice[0]);
			ChangeWeapon.changeWeapon.ChangingWeapon(weaponSprite[0]);
			PlayerPrefs.SetFloat(weaponStat[0],1);
			GameManager.gm.playerStatus.SetDamage(10f);
			PlayerPrefs.SetFloat("damage",10f);
			//equipt[0].sprite = equiptSprite[0];
			PlayerPrefs.SetFloat("weaponUse",1);
		}
		else if(PlayerPrefs.GetFloat(weaponStat[0]) >0f){
			ChangeWeapon.changeWeapon.ChangingWeapon(weaponSprite[0]);
			PlayerPrefs.SetFloat("weaponUse",1);
			GameManager.gm.playerStatus.SetDamage(10f);
			PlayerPrefs.SetFloat("damage",10f);
		}
		else{
			StartCoroutine("Remove");
		}
	}

	public void BuyWeapon2(){
		if(PlayerPrefs.GetFloat("gold") >= weaponPrice[1] && PlayerPrefs.GetFloat(weaponStat[1]) <=0f){
			//PlayerPrefs.SetFloat("gold",PlayerPrefs.GetFloat("gold") - weaponPrice[1]);
			GameManager.gm.playerStatus.SetGold(weaponPrice[1]);
			ChangeWeapon.changeWeapon.ChangingWeapon(weaponSprite[1]);
			PlayerPrefs.SetFloat(weaponStat[1],1);
			GameManager.gm.playerStatus.SetDamage(30f);
			PlayerPrefs.SetFloat("damage",30f);
			//equipt[1].sprite = equiptSprite[1];
			PlayerPrefs.SetFloat("weaponUse",2);
		}
		else if(PlayerPrefs.GetFloat(weaponStat[1]) >0f){
			ChangeWeapon.changeWeapon.ChangingWeapon(weaponSprite[1]);
			PlayerPrefs.SetFloat("weaponUse",2);
			GameManager.gm.playerStatus.SetDamage(30f);
			PlayerPrefs.SetFloat("damage",30f);
		}
		else{
			StartCoroutine("Remove");
		}
	}

	public void BuyWeapon3(){
		if(PlayerPrefs.GetFloat("gold") >= weaponPrice[2] && PlayerPrefs.GetFloat(weaponStat[2]) <=0f){
			//PlayerPrefs.SetFloat("gold",PlayerPrefs.GetFloat("gold") - weaponPrice[2]);
			GameManager.gm.playerStatus.SetGold(weaponPrice[2]);
			ChangeWeapon.changeWeapon.ChangingWeapon(weaponSprite[2]);
			PlayerPrefs.SetFloat(weaponStat[2],1);
			GameManager.gm.playerStatus.SetDamage(50f);
			PlayerPrefs.SetFloat("damage",50f);
			//equipt[2].sprite = equiptSprite[2];
			PlayerPrefs.SetFloat("weaponUse",3);
		}
		else if(PlayerPrefs.GetFloat(weaponStat[2]) >0f){
			ChangeWeapon.changeWeapon.ChangingWeapon(weaponSprite[2]);
			PlayerPrefs.SetFloat("weaponUse",3);
			GameManager.gm.playerStatus.SetDamage(50f);
			PlayerPrefs.SetFloat("damage",50f);
		}
		else{
			StartCoroutine("Remove");
		}
	}

	public void ExitGame(){
		GameManager.gm.playerStatus.SaveState ();
		//Application.LoadLevel("MainMenu");
		SceneManager.LoadScene("MainMenu");
	}

	private IEnumerator Remove(){
		needGold.SetActive(true);
		yield return new WaitForSeconds(1f);
		needGold.SetActive(false);
	}

	private void ChangeEquppedSprite(){
		if(PlayerPrefs.GetFloat("weaponUse") == 1){
			equipt[0].sprite = equippedSprite[0];
			if(PlayerPrefs.GetFloat(weaponStat[1]) > 0){
				equipt[1].sprite = equiptSprite[1];
			}
			if(PlayerPrefs.GetFloat(weaponStat[2]) > 0){
				equipt[2].sprite = equiptSprite[2];
			}
		}
		else if(PlayerPrefs.GetFloat("weaponUse") == 2){
			equipt[1].sprite = equippedSprite[1];
			if(PlayerPrefs.GetFloat(weaponStat[0]) > 0){
				equipt[0].sprite = equiptSprite[0];
			}
			if(PlayerPrefs.GetFloat(weaponStat[2]) > 0){
				equipt[2].sprite = equiptSprite[2];
			}
		}
		else if(PlayerPrefs.GetFloat("weaponUse") == 3){
			equipt[2].sprite = equippedSprite[2];
			if(PlayerPrefs.GetFloat(weaponStat[1]) > 0){
				equipt[1].sprite = equiptSprite[1];
			}
			if(PlayerPrefs.GetFloat(weaponStat[0]) > 0){
				equipt[0].sprite = equiptSprite[0];
			}
		}
	}

	public bool PauseMenu(){
		return onPause;
	}
}
