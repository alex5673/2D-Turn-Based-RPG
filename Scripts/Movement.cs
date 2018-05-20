using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;
using System.IO;

public class Movement : MonoBehaviour {

    Animator animator;

    private int speed = 16;
    private float timer = 0;
    private bool buttonPressed = false;
    private int stepCount = 0;

    private bool facingRight;
    private bool facingLeft;
    private bool facingUp;
    private bool facingDown;

    private bool worldMap;

    private Scene scene;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        facingRight = false;
        facingLeft = false;
        facingUp = false;
        facingDown = false;
        worldMap = true;

        scene = SceneManager.GetActiveScene();

        if (scene.name == "Town")
        {
            animator.Play("IdleUp 0");
        }
        else
        {
            ReadCharacterPosFile();
        }
    }

    // Update is called once per frame
    void Update() {

        if(scene.name == "Town")
        {
            if(transform.position.x < -15.0f || transform.position.x > 15.0f || transform.position.y < -5.5f || transform.position.y > 5.5f)
            {
                SceneManager.LoadScene("WorldMap");
            }
        }

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
        facingRight = false;
        facingLeft = false;
        facingUp = true;
        facingDown = false;
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
        facingRight = true;
        facingLeft = false;
        facingUp = false;
        facingDown = false;
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
        facingRight = false;
        facingLeft = true;
        facingUp = false;
        facingDown = false;
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
        facingRight = false;
        facingLeft = false;
        facingUp = false;
        facingDown = true;
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
        
        
        if(stepCount == 10 && worldMap == true)
        {
            WriteToCharaterPosFile();
            SceneManager.LoadScene("GrassBattleScreen");
            stepCount = 0;
        }
        
    }

    public bool GetFacingRight()
    {
        return facingRight;
    }

    public bool GetFacingLeft()
    {
        return facingLeft;
    }

    public bool GetFacingUp()
    {
        return facingUp;
    }

    public bool GetFacingDown()
    {
        return facingDown;
    }

    public Vector3 GetTransform()
    {
        return this.transform.position;
    }

    public void SetWorldMap(bool worlMap)
    {
        worldMap = worlMap;
    }

    public void ReadCharacterPosFile()
    {
        Vector3 pos = new Vector3();

        string fileName = "PlayersMapPosition.txt";

        StreamReader reader = new StreamReader(Application.persistentDataPath + "/" + fileName);

        try
        {
            pos.x = float.Parse(reader.ReadLine());
            pos.y = float.Parse(reader.ReadLine());
            transform.position = pos;
        }
        catch(System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            reader.Close();
        }
    }

    public void WriteToCharaterPosFile()
    {
        string fileName = "PlayersMapPosition.txt";

        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + fileName, false);

        try
        {
            writer.WriteLine("" + transform.position.x);
            writer.WriteLine("" + transform.position.y);
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            writer.Close();
        }

        //AssetDatabase.Refresh();
    }
}