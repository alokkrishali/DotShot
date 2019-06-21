using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum difficultyLevel { veryEasy = 0, easy, medium, extraMedium, difficult, veryDifficult };


public class GameController : MonoBehaviour {

    public static GameController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public difficultyLevel eGameDifficultyLevel = difficultyLevel.easy;

    void LateUpdate () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
