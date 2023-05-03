using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;

        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;

            fill.color = gradient.Evaluate(1f);
        }

        public void SetHealth(int health)
        {
            slider.value = health;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}