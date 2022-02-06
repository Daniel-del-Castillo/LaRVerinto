using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour
{
    private RaycastHit vision;
    public float interactDistance = 15f;
    public GameObject cross;
    public GameObject compass;
    private AudioSource spraySound;
    new private GameObject camera;
    public string[] markButtons = {"L2", "Square"};

    
    void Awake()
    {
        spraySound = GetComponent<AudioSource>();
        camera = GameObject.Find("Camera");
        Input.compass.enabled = true;
    }

    private void Update()
    {
        if (Array.Exists(markButtons, button => Input.GetButtonDown(button)))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out vision, interactDistance))
            {
                if (vision.collider.tag == "Wall")
                {
                    Vector3 offset = Vector3.zero;
                    offset.x = ((transform.position.x - vision.point.x) >= 0) ? 0.01f : -0.01f;
                    offset.z = ((transform.position.z - vision.point.z) >= 0) ? 0.01f : -0.01f;
                    GameObject crossShot = Instantiate(cross, 
                        vision.point + offset,
                        Quaternion.LookRotation(-vision.normal)) as GameObject;
                    spraySound.Play();
                } else if (vision.collider.tag == "Floor" && camera.transform.rotation.eulerAngles.x < 50.0f)
                {
                    float yRotation = camera.transform.rotation.eulerAngles.y - Input.compass.magneticHeading;
                    Quaternion compassRotation = Quaternion.Euler(0, yRotation, 0);
                    
                    Vector3 compassPosition = vision.point;
                    compassPosition.y += 0.01f;
                    GameObject crossShot = Instantiate(compass, 
                        compassPosition,
                        compassRotation) as GameObject;
                }
            }
        } else if (Input.GetButtonDown("ShareButton"))
        {
            transform.position = new Vector3(230, 2.5f, 230);
        }
    }
}
