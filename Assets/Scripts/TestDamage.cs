using UnityEngine;

public class TestDamage : MonoBehaviour
{
    public HealthBar healthBar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Appuie sur Espace pour infliger des dégâts
        {
            healthBar.TakeDamage(10f); // Inflige 10 points de dégâts
        }
    }
}