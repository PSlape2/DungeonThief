using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace scripts.ui {
    public class MainMenu : MonoBehaviour {
        private Button startButton;
        private Button exitButton;

        void Start() {
            Transform UICanvas = GameObject.Find("UI Container").transform.GetChild(0).transform;
            startButton = UICanvas.GetChild(0).GetComponent<Button>();
            exitButton = UICanvas.GetChild(1).GetComponent<Button>();

            startButton.onClick.AddListener(onStartButtonClick);
            exitButton.onClick.AddListener(onExitButtonClick);
        }

        void onStartButtonClick() {
            SceneManager.LoadScene("GameScene");
        }

        void onExitButtonClick() {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif

            Application.Quit();
        }
    }
}