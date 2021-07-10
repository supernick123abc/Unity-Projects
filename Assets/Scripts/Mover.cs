using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    public static float normalSpeed = 3.0f;
    public static float fastSpeed = normalSpeed * 2;

    public float jumpCooldown = 4f;
    private bool cooldown = false;

    public static float moveSpeed = normalSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
        ResetLevel();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("How to play:");
        Debug.Log("WASD or Arrow Keys to Move");
        Debug.Log("Don't hit obstacles or walls");
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }

    public void CooldownStart()
    {
        StartCoroutine(CooldownCoroutine());
    }

    IEnumerator CooldownCoroutine()
    {
        cooldown = true;
        yield return new WaitForSeconds(jumpCooldown);
        cooldown = false;
    }

    void JumpPlayer()
    {
        float jumpHeight = 400 * Time.deltaTime;
        
        if (cooldown == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                CooldownStart();
            }
            
        }
    }

    void ResetLevel()
    {
        if(Input.GetKeyDown("`"))
        {
            // get the current scene name 
        string sceneName = SceneManager.GetActiveScene().name;

        // load the same scene
        SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
        }
    }

}
