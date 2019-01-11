using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour {

	public void ChangeExp(Image expBar, float currentExp, float maxExp){
		float exp = currentExp / maxExp;
		expBar.fillAmount = exp;
	}

}
