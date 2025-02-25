using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar; // Référence à l'image de la barre de vie
    public float maxHealth = 100f; // Vie maximale du joueur
    private float currentHealth; // Vie actuelle du joueur

    // Gradient pour la couleur de la barre de vie
    public Gradient healthGradient;

    void Start()
    {
        currentHealth = maxHealth; // Initialise la vie actuelle à la vie maximale
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Réduit la vie actuelle
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Assure que la vie reste entre 0 et maxHealth
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float healthRatio = currentHealth / maxHealth; // Calcule le ratio de vie
        healthBar.fillAmount = healthRatio; // Met à jour le remplissage de la barre de vie

        // Change la couleur de la barre de vie en fonction du gradient
        healthBar.color = healthGradient.Evaluate(healthRatio);
    }
}