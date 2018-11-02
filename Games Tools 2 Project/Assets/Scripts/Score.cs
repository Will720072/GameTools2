using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 4;
    private int scoreToNextLevel = 50;

    private bool isDead = false;

    public Text scoreText;
    public DeathMenu deathMenu;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isDead)
            return;

        if (score >= scoreToNextLevel)
            LevelUp();

        score += Input.GetAxis("Vertical")/10 * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMove>().SetSpeed(difficultyLevel);

        Debug.Log(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
    }
}
