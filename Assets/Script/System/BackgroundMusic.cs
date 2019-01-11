using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour {

	private AudioSource sound;

	public AudioClip clip;

	void Start () {
		sound = GetComponent<AudioSource>();
		sound.clip = clip;
		sound.Play();
		//if(Application.loadedLevelName == "Forest"){
		//	sound.clip = clip[0];
		//}

		//if(Application.loadedLevelName == "ForestBoss"){
		//	sound.clip = clip[1];
		//}
	}

	void Update () {
		
		if(!sound.isPlaying){
			sound.Play();
		}else{

		}
	}
}
