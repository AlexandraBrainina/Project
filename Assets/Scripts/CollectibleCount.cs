using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CollectibleCount : MonoBehaviour
    {
        private TMPro.TMP_Text _text;
        private int count;

        private void Awake()
        {
            _text = GetComponent<TMPro.TMP_Text>();
        }

        private void Start() => UpdateCount();

        private void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
        private void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

        void OnCollectibleCollected()
        {
            count++;
            UpdateCount();
        }

        void UpdateCount()
        {
            _text.text = $"{count} / {Collectible.total}";
        }
    }
}