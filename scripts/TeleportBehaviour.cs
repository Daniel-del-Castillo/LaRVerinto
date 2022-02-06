using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TeleportBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public AudioClip teleportClip;
    public AudioClip resetClip;
    public AudioClip sceneTransitionClip;
    public string[] teleportButtons = {"R2"};
    public string[] resetButtons = {"Circle"};
    private Rigidbody rigidBody;
    private GameObject player;
    new private GameObject camera;
    private AudioSource teleportSound;


    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        teleportSound = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main.gameObject;
    }
    
    void Update() {
        if (Array.Exists(teleportButtons, button => Input.GetButtonDown(button)))
        {
            if (ExitBehaviour.instance != null && ExitBehaviour.instance.CheckExit())
            {
                teleportSound.clip = sceneTransitionClip;
                teleportSound.Play();
                AudioManager.instance.FinalTransition();
                FadeController.instance.White(ExitScene);
            }
            else
            {
                teleportSound.clip = teleportClip;
                teleportSound.Play();
                FadeController.instance.Blink(TeleportPlayer);
            }
        }
        
        if (Array.Exists(resetButtons, button => Input.GetButtonDown(button)))
        {
            teleportSound.clip = resetClip;
            teleportSound.Play();
            Vector3 resetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.position = resetPosition;
        }

    }

    void FixedUpdate() {
        Vector3 forwardMovement = camera.transform.forward * Input.GetAxis(verticalAxis);
        Vector3 lateralMovement = camera.transform.right * Input.GetAxis(horizontalAxis);
        Vector3 movement = forwardMovement + lateralMovement;
        rigidBody.MovePosition(transform.position + movement * speed);
        rigidBody.velocity = Vector3.zero;
    }

    void TeleportPlayer()
    {
        Vector3 desiredPosition = transform.position;
        desiredPosition.y = 2.5f;
        player.transform.position = desiredPosition;
    }

    void ExitScene()
    {
        SceneManager.LoadScene(2);
    }
}
