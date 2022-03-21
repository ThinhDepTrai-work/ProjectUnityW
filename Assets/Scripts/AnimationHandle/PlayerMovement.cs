using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator ani;
    public Joystick joystick;
    

    Vector2 vec;
    int direction;

    void Start()
    {
        direction = 1;
    }

    // Continues game
/*    private void Awake()
    {
        SaveData.current = (SaveData)SerializationManager.Load("Save");

        Vector3 position = Vector3.zero;

        /*if (SaveData.current.playerData == null)
        {
            position = Vector3.zero;
        }
        else
        {
            position = SaveData.current.playerData.Position;

        }

        transform.position = position;
    }*/

    // Update is called once per frame
    void Update()
    {
        vec.x = joystick.Horizontal ;
        vec.y = joystick.Vertical ;
        if (joystick.Horizontal > 0 )
        {
            if (joystick.Vertical >0 && joystick.Vertical > joystick.Horizontal)
            {
                ani.SetInteger("Direct", 1);
            }
            else if (joystick.Vertical < 0 && (joystick.Vertical * joystick.Vertical) > (joystick.Horizontal * joystick.Horizontal))
            {
                ani.SetInteger("Direct", 3);
            }
            else
            {
                ani.SetInteger("Direct", 2);
            }
        }
        else if (joystick.Horizontal < 0 )
        {
            if (joystick.Vertical > 0 && (joystick.Vertical * joystick.Vertical) > (joystick.Horizontal * joystick.Horizontal))
            {
                ani.SetInteger("Direct", 1);
            }
            else if (joystick.Vertical < 0 && joystick.Vertical < joystick.Horizontal)
            {
                ani.SetInteger("Direct", 3);
            }
            else
            {
                ani.SetInteger("Direct", 4);
            }
        }
        vec.Normalize();
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            ani.SetFloat("Speed", 0);
        }
        else
        {
            ani.SetFloat("Speed", vec.magnitude);
        }
        ani.SetFloat("Horizontal", vec.x);
        ani.SetFloat("Vertical", vec.y);


        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + vec * speed * Time.fixedDeltaTime);
    }


    // Load game
    public void OnLoad(string saveName)
    {
        SaveData.current = (SaveData)SerializationManager.Load("/saves/" + saveName);

        Vector3 position = Vector3.zero;

        //if (SaveData.current.playerData == null)
        //{
        //    position = Vector3.zero;
        //}
        //else
        //{
        //    position = SaveData.current.playerData.Position;

        //}

        transform.position = position;
    }


    // Save game
    public void SavePlayerProgress()
    {
        //SaveData.current.playerData = new PlayerData(this);
        SerializationManager.Save("Save", SaveData.current);

    }

    // Touch CheckPoint to Save game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPoint"))
        {
            SavePlayerProgress();
        }

    }
    public void OutStamina()
    {
        speed = 0.5f;
    }


}

