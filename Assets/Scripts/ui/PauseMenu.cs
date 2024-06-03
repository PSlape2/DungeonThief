using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject _uiCanvas;
    private Button resumeButton;
    private Button mainMenuButton;

    void Start()
    {
        _uiCanvas = transform.GetChild(0).GetChild(0).gameObject;
        resumeButton = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Button>();
        mainMenuButton = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Button>();

        _uiCanvas.SetActive(false);

        resumeButton.onClick.AddListener(CloseCanvas);
        mainMenuButton.onClick.AddListener(ReturnToMenu);
    }
    void Update()
    {
        if(Input.GetButton("Cancel")) {
            _uiCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        if(_uiCanvas.activeInHierarchy) {
            if(Input.GetButton("Submit")) {
                CloseCanvas();
            }
        }
    }

    void CloseCanvas() {
        Time.timeScale = 1;
        _uiCanvas.SetActive(false);
    }

    void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
