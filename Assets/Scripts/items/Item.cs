using UnityEngine;
using UnityEngine.UI;

namespace scripts.items {
    public class Item {
        public string name;
        public string description;

        public Image icon;

        public ItemEffect effect;

        public float effectModifier;

        public Item(string name, string description, Image icon, ItemEffect effect, float effectModifier) {
            this.name = name;
            this.description = description;
            this.icon = icon;
            this.effect = effect;
            this.effectModifier = effectModifier;
        }
    }
}