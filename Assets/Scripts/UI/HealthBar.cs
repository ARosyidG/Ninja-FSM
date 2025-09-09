using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void setHealth(float health)
    {
        slider.value = health;
    }
    public void setMaxHealth(float health)
    {
        Debug.Log($"Max health: {health}");
        slider.maxValue = health;
        slider.value = health;
    }
}
