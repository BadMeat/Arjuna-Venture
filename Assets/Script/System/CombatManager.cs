using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

	public GameObject floatingText;
	public RectTransform canvas;

	public void CreateText(Transform trans, string text, Color color, float range){
		Vector3 outFloting = new Vector3(trans.position.x,trans.position.y + range,trans.position.z);
		GameObject texting = (GameObject)Instantiate(floatingText,outFloting,Quaternion.identity);
		texting.GetComponent<Text>().text = text;
		texting.GetComponent<Text>().color = color;
		texting.transform.SetParent(canvas);
		texting.transform.localScale = new Vector3(1f,1f,1f);
	}
}
