using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace scripts.events
{
    public class Events
    {
        public static NoArgsEvent OnRoomChange = new NoArgsEvent();
        public static OneArgEvent OnPlayerHit = new OneArgEvent();

        public static NoArgsEvent OnEnemiesDefeated = new NoArgsEvent();

        static Events()
        {
            OnRoomChange.AddListener(() => { Debug.Log("Room Change Event Invoked"); });
            OnPlayerHit.AddListener((obj) => { Debug.Log("Player Hit Event Invoked"); });
            OnEnemiesDefeated.AddListener(() => { Debug.Log("Enemies Defeated Event Invoked"); });
        }

        public static void clearActions() {
            OnRoomChange.RemoveAllListeners();
            OnPlayerHit.RemoveAllListeners();
            OnEnemiesDefeated.RemoveAllListeners();
        }
    }
}

