using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Paramètres Généraux")]
    public int maxStacks = 3; // Nombre total de stacks disponibles
    public int attacksPerStack = 4; // Nombre d'attaques pour recharger 1 stack

    [Header("Coûts des Compétences")]
    public int skill1Cost = 1;
    public int skill2Cost = 2;

    [Header("Effets Visuels")]
    public ScreenFlashEffect flashEffect;

    [Header("Références UI")]
    public SkillHUDController hudController;

    private float totalProgress; // Progression totale (en stacks complets et partiels)
    private int attackCounter;

    private void Start()
    {
        totalProgress = 0f;
        attackCounter = 0;
        hudController.Initialize(maxStacks);
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // Attaque normale (remplissage progressif)
        if (Input.GetMouseButtonDown(0))
        {
            attackCounter++;
            UpdateStackProgress();
        }

        // Compétence 1 (Touche 1)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TryUseSkill(skill1Cost, Color.red);
        }

        // Compétence 2 (Touche 2)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TryUseSkill(skill2Cost, Color.blue);
        }
    }

    private void UpdateStackProgress()
    {
        if (totalProgress >= maxStacks) return;

        // Ajouter la progression actuelle
        totalProgress += 1f / attacksPerStack;
        attackCounter = 0;

        // Mettre à jour l'UI
        hudController.UpdateStacks(totalProgress);
    }

    private void TryUseSkill(int cost, Color color)
    {
        if (totalProgress >= cost)
        {
            totalProgress -= cost;
            hudController.UpdateStacks(totalProgress);
            TriggerSkillEffect(color);
        }
    }

    private void TriggerSkillEffect(Color color)
    {
        // Déclencher l'effet de flash
        if (flashEffect != null) flashEffect.TriggerFlash(color);
    }
}