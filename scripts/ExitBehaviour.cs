using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehaviour : MonoBehaviour
{
    public static ExitBehaviour instance;
    [SerializeField] private Transform teleport;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }

    public bool CheckExit() 
    {
        float distance = Vector3.Distance(teleport.position, transform.position);
        return distance < 6;
    }

}
