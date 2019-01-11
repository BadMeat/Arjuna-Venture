using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Qeustion : MonoBehaviour {

	public Text question;
	private int myAnswer;
	private int q1;
	private int q2;
	private int rightAnswer;

	void Start () {
		RandomQuestion();
	}

	void Update () {
		question.text = q1 +" + " + q2;
	}

	public bool TheQeustion(bool right){
		rightAnswer = q1 + q2;
		if(myAnswer == rightAnswer){ // kalo cek movement ditaro sini pas jalan gk manah tapi pas berhenti otomatis manah cuy
			if(GameManager.gm.playerController.CheckMovement(true)){
				right = true;
				RandomQuestion();
				myAnswer = 0;
			}else{
				myAnswer =0;
			}

		}
		else{
			right = false;
		}

		return right;
	}

	private void RandomQuestion(){
		q1 = Random.Range(1,5);
		q2 = Random.Range(1,5);
	}

	public void Button1(){
		myAnswer = 2;
	}

	public void Button2(){
		myAnswer = 3;
	}

	public void Button3(){
		myAnswer = 4;
	}

	public void Button4(){
		myAnswer = 5;
	}

	public void Button5(){
		myAnswer = 6;
	}

	public void Button6(){
		myAnswer = 7;
	}

	public void Button7(){
		myAnswer = 8;
	}

	public void Button8(){
		myAnswer = 9;
	}

	public void Button9(){
		myAnswer = 10;
	}
}
