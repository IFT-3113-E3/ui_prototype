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
    public ScreenFlashEffect flashEffect; // Remplace les particules par un effet de flash

    [Header("Références UI")]
    public SkillHUDController hudController;

    private int[] stackCharges; // Stocke la progression de chaque stack
    private int availableStacks; // Nombre de stacks complets
    private int attackCounter;

    private void Start()
    {
        stackCharges = new int[maxStacks];
        availableStacks = 0;
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
        if (availableStacks >= maxStacks) return;

        int stackIndex = availableStacks;
        stackCharges[stackIndex]++;
        hudController.UpdateStackFill(stackIndex, (float)stackCharges[stackIndex] / attacksPerStack);

        if (stackCharges[stackIndex] >= attacksPerStack)
        {
            availableStacks++;
            hudController.UpdateAvailableStacks(availableStacks);
            attackCounter = 0;
        }
    }

    private void TryUseSkill(int cost, Color color)
    {
        if (availableStacks >= cost)
        {
            availableStacks -= cost;
            ResetUsedStacks(cost);
            hudController.UpdateAvailableStacks(availableStacks);
            TriggerSkillEffect(color);
        }
    }

    private void ResetUsedStacks(int cost)
    {
        for (int i = 0; i < cost; i++)
        {
            int stackIndex = availableStacks + i;
            if (stackIndex < maxStacks)
            {
                stackCharges[stackIndex] = 0;
                hudController.UpdateStackFill(stackIndex, 0f);
            }
        }
    }

    private void TriggerSkillEffect(Color color)
    {
        // Déclencher l'effet de flash
        if (flashEffect != null) flashEffect.TriggerFlash(color);
    }
}