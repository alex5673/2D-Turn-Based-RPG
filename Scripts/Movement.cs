using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    Animator animator;

    private int speed = 8;
    private float timer = 0;
    private bool buttonPressed = false;
    private int stepCount = 0;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (buttonPressed == true)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 1)
        {
            animator.SetBool("up", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("down", false);
            timer = 0;
            buttonPressed = false;
        } 
    }

    public void MoveUP()
    {
        animator.SetBool("up", true);
        animator.SetBool("right", false);
        animator.SetBool("left", false);
        animator.SetBool("down", false);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        buttonPressed = true;
        Step();
    }

    public void MoveRight()
    {
        animator.SetBool("up", false);
        animator.SetBool("right", true);
        animator.SetBool("left", false);
        animator.SetBool("down", false);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        buttonPressed = true;
        Step();
    }

    public void MoveLeft()
    {
        animator.SetBool("up", false);
        animator.SetBool("right", false);
        animator.SetBool("left", true);
        animator.SetBool("down", false);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        buttonPressed = true;
        Step();
    }

    public void MoveDown()
    {
        animator.SetBool("up", false);
        animator.SetBool("right", false);
        animator.SetBool("left", false);
        animator.SetBool("down", true);
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        buttonPressed = true;
        Step();
    }

    public void Step()
    {
        stepCount++;
        if(stepCount == 5)
        {
            SceneManager.LoadScene("GrassBattleScreen");
            stepCount = 0;
        }
    }
}