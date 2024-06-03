using UnityEngine;
using UnityEngine.UI;

namespace scripts.items {
    public class Items {
        public static class Totems {
            public static Item SpeedTotem1 = new Item(
            "Speed Totem I",
            "Gives the player a small speed boost",
            Resources.Load<Image>("Sprites/Items/Totems/SpeedTotem"),
            ItemEffect.SPEED,
            1.1f
            );
        }

        public static class Amulets {
            
        }

        public static class Boots {

        }
    }
}