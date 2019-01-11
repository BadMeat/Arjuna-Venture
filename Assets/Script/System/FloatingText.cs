using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

	private float speed;
	private Color tempColor;
	private float destroyTime;

	void Start () {
		tempColor = GetComponent<Text>().color;
		destroyTime = 1f;
		speed = 2f;
	}

	void Update () {
		MoveUp();
	}

	private void MoveUp(){
		destroyTime -= 0.5f * Time.deltaTime;
		transform.Translate(Vector3.up * speed * Time.deltaTime);
		gameObject.GetComponent<Text>().color = new Color(tempColor.r,tempColor.g,tempColor.b,destroyTime);
		if(destroyTime <=0){
			Destroy(gameObject);
		}
	}
}
