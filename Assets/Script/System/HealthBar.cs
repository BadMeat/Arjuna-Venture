using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

	private Color minColor = Color.red;
	private Color maxColor = Color.green;
	private float minValue = 0f;
	private float maxValue = 1f;

	public void ChangeHealth(Image healthBar, float currentHealth, float maxHealth){
		float health = currentHealth / maxHealth;
		healthBar.color = Color.Lerp(minColor,maxColor,Mathf.Lerp(minValue,maxValue,health));
		healthBar.fillAmount = health;
	}
}
