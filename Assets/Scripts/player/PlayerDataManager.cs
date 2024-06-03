using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using scripts.events;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace scripts.player {
    public class PlayerDataManager : MonoBehaviour // Also manages getting hit I guess
    {
        public TMP_Text healthText;
        public GameObject player;
        public Button menu;
        public GameObject gameOverPanel;
        
        public float Health { get; set; } = 3;

        // Start is called before the first frame update
        void Start()
        {
            Events.OnPlayerHit.AddListener(onHit);
            healthText.text = "Health: 10";

            gameOverPanel.SetActive(false);
            menu.onClick.AddListener(onMenu);
        }

        void onHit(GameObject incomingObject) {
            Health -= 1;
            Debug.Log("Player Health: " + Health);
            if(Health <= 0) {
                healthText.text = "";
                player.SetActive(false);
                gameOverPanel.SetActive(true);

            } else {
                healthText.text = "Health: " + Health;
            }
        }

        void onMenu() {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

