using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

	// Use this for initialization
	void Awake () {

        // initialize screen utils
        ScreenUtils.Initialize();

        // initialize audio manager
        // this seems ugly because we can't add components to the audio manager
		// STUDENTS: uncomment the code below in Step 3 of Project Increment 5
        //AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        //AudioManager.Initialize(audioSource);
    }
}
