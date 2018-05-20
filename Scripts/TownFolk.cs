using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using System.IO;

public class TownFolk : MonoBehaviour {

    Animator animator;

    public GameObject directionalButtons;
    public GameObject dialogueBox;
    public GameObject character;

    private string[] dialogue;
    private bool walkingLeft;
    private bool walkingRight;
    private string clipName;
    private AnimatorClipInfo[] currentClipInfo;

    private float speed;

    private string bossDefeated;

	// Use this for initialization
	void Start () {
        dialogue = new string[2];
        dialogue[0] = "The multi-headed serpent must be defeated to free the realm!";
        dialogue[1] = "Hooray! You defeated the serpent and freed us from it's reign of terror!";
        walkingLeft = false;
        walkingRight = false;
        animator = GetComponent<Animator>();
        animator.SetBool("IdleRight", false);
        animator.SetBool("IdleLeft", false);
        animator.SetBool("IdleDown", false);
        animator.SetBool("IdleUp", false);
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        dialogueBox.SetActive(false);
        character.GetComponent<Movement>().SetWorldMap(false);
        speed = 0.5f;
        bossDefeated = "";
        ReadBossEnemyFile();
	}
	
	// Update is called once per frame
	void Update () {
        currentClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        clipName = currentClipInfo[0].clip.name;
        if(clipName == "TownFolkMaleRight" || clipName == "TownFolkFemaleRight")
        {
            walkingLeft = true;
            walkingRight = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if(clipName == "TownFolkMaleIdleRight" || clipName == "TownFolkFemaleIdleRight")
        {
            if(walkingLeft == true)
            {
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
            }
        }
        else if(clipName == "TownFolkMaleIdleLeft" || clipName == "TownFolkFemaleIdleLeft")
        {
            if(walkingRight == true)
            {
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
            }
        }
        else if(clipName == "TownFolkMaleLeft" || clipName == "TownFolkFemaleLeft")
        {
            walkingLeft = false;
            walkingRight = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Entered");
        animator.SetBool("IdleRight", true);
        animator.SetBool("IdleLeft", true);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision occuring");
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if((character.GetComponent<Movement>().GetFacingRight() == true) && (character.GetComponent<Movement>().GetTransform().x < this.transform.position.x))
            {
                animator.SetBool("Idleleft", true);
                animator.SetBool("IdleRight", false);
                animator.SetBool("IdleDown", false);
                animator.SetBool("IdleUp", false);
            }
            else if((character.GetComponent<Movement>().GetFacingLeft() == true) && (character.GetComponent<Movement>().GetTransform().x > this.transform.position.x))
            {
                animator.SetBool("Idleleft", false);
                animator.SetBool("IdleRight", true);
                animator.SetBool("IdleDown", false);
                animator.SetBool("IdleUp", false);
            }
            else if((character.GetComponent<Movement>().GetFacingDown() == true) && (character.GetComponent<Movement>().GetTransform().y > this.transform.position.y))
            {
                animator.SetBool("Idleleft", false);
                animator.SetBool("IdleRight", false);
                animator.SetBool("IdleDown", false);
                animator.SetBool("IdleUp", true);
            }
            else if((character.GetComponent<Movement>().GetFacingUp() == true) && (character.GetComponent<Movement>().GetTransform().y < this.transform.position.y))
            {
                animator.SetBool("Idleleft", false);
                animator.SetBool("IdleRight", false);
                animator.SetBool("IdleDown", true);
                animator.SetBool("IdleUp", false);
            }
            directionalButtons.SetActive(false);
            dialogueBox.SetActive(true);

            if (bossDefeated == "true")
            {
                dialogueBox.GetComponent<Text>().text = dialogue[1];
            }
            else
            {
                dialogueBox.GetComponent<Text>().text = dialogue[0];
            }

            if((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                directionalButtons.SetActive(true);
                dialogueBox.SetActive(false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision ended");
        animator.SetBool("IdleRight", false);
        animator.SetBool("IdleLeft", false);
        animator.SetBool("IdleUp", false);
        animator.SetBool("IdleDown", false);
        directionalButtons.SetActive(true);
        dialogueBox.SetActive(false);
    }

    public void ReadBossEnemyFile()
    {
        string fileName = "BossEnemy.txt";

        StreamReader reader = new StreamReader(Application.persistentDataPath + "/" + fileName);

        try
        {
            bossDefeated = reader.ReadLine();
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            reader.Close();
        }
    }
}
