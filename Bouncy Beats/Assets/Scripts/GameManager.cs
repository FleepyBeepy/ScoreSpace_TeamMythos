using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using LootLocker.Requests;
public class GameManager: MonoBehaviour
{
    // Start is called before the first frame update
    public Leaderboard leaderboard;
    public Transform[] asdfNotes;
    public static GameManager instance;
    public Transform player; 
    public int maxHealth = 100;
    public int health = 100;
    public int score = 0;
    public enum GameState 
    {
        Empty,
        Pause,
        Play,
        PlayerDead

    }

    public GameState gameState;
    private void Awake()
    {
        instance = this;
        gameState = GameState.Empty;
    }

    public void ChangeState(GameState newState) 
    {
        if (newState != gameState)
        {
            gameState = newState;
        }
    }

    private void Update()
    {
        switch (gameState) 
        {
            case GameState.Empty:
                break;
            case GameState.Pause:
                //Play pause sound
                //Show pause screen
                Time.timeScale = 0.0f;
                break;
            case GameState.Play:
                Time.timeScale = 1.0f;
                break;
            case GameState.PlayerDead:
                Time.timeScale = 0.0f;
                //Play death sound
                //Darken screen
                //Show Restart Screen
                break;
            default:
                break;

        }

        if (player != null && player.position.y < asdfNotes[0].position.y - .2f) 
        {
           // UpdateBeatsMeter();
        }
    }

    IEnumerator DieRoutine()
    {
        yield return leaderboard.SubmitScoreRoutine(score);
    }
}
