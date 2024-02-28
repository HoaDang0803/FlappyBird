using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce=7f;
    
    private int Score = 0;
    [SerializeField] private Text ScoreText;

    private bool isEndGame;
    private bool isStartFirst;
    [SerializeField] private GameObject panelEnd;
    [SerializeField] private Text EndScore;
    private Button TryAgain;
    
    private Animator anim;
    private enum MovementState { Jumping, Falling }
    
    [SerializeField] private AudioSource deathSound;
    private void Start()
    {
        isEndGame = false;
        Time.timeScale = 0;
        panelEnd.SetActive(false);
        isStartFirst = true;
        
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }

        if (isEndGame)
        {
            if(Input.GetMouseButtonDown(0)&& isStartFirst)
                StartGame();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
                Time.timeScale = 1;
        }
        
        UpdateAnimationState();
    }
    
    private void UpdateAnimationState()
    {
        MovementState state=0;

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        anim.SetInteger("state", (int)state);
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
    }


    public void ReStart()
    {
        StartGame();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        deathSound.Play();
        
        isEndGame = true;
        Time.timeScale = 0;
        isStartFirst = false;
        panelEnd.SetActive(true);
        EndScore.text = "SCORE: " + Score.ToString();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Score++;
            Debug.Log("SCORE:" + Score);
            ScoreText.text = "SCORE:" + Score;
        }
    }
}
