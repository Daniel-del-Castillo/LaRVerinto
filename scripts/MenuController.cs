using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    private bool active;
    public string confirmButton = "X";

    private void Update()
    {
        if (active && Input.GetButtonDown(confirmButton))
        {
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(gameObject, pointer, ExecuteEvents.pointerClickHandler);
        }
    }

    public void OnPointerEnter()
    {
        active = true;
    }

    public void OnPointerExit()
    {
        active = false;
    }

    public void LoadLevel()
    {
        AudioManager.instance.WhooshTransition();
        FadeController.instance.Blink(() => SceneManager.LoadScene(1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        AudioManager.instance.WhooshTransition();
        FadeController.instance.Blink(() => SceneManager.LoadScene(0));
    }
}
