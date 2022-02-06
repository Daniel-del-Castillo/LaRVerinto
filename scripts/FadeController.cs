using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BlinkAction();

public class FadeController : MonoBehaviour
{
    static public FadeController instance;
    private Animator animator;
    private BlinkAction callback;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        animator = GetComponent<Animator>();
    }

    public void Blink(BlinkAction blinkAction)
    {
        callback = blinkAction;
        animator.SetTrigger("Blink");
    }
    
    public void White(BlinkAction blinkAction)
    {
        callback = blinkAction;
        animator.SetTrigger("White");
    }

    public void TriggerCallback()
    {
        callback();
    }
}
