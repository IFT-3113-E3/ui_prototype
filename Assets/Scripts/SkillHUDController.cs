using UnityEngine;
using UnityEngine.UI;

public class SkillHUDController : MonoBehaviour
{
    [Header("Références Stacks")]
    public Image[] stackFills; // Remplissages des stacks

    public void Initialize(int maxStacks)
    {
        // Initialiser l'UI avec le bon nombre de stacks
        foreach (var fill in stackFills)
        {
            if (fill != null) fill.fillAmount = 0f;
        }
    }

    public void UpdateStackFill(int stackIndex, float fillAmount)
    {
        if (stackIndex >= 0 && stackIndex < stackFills.Length && stackFills[stackIndex] != null)
        {
            stackFills[stackIndex].fillAmount = fillAmount;
        }
    }

    public void UpdateAvailableStacks(int available)
    {
        for (int i = 0; i < stackFills.Length; i++)
        {
            if (stackFills[i] != null)
            {
                stackFills[i].color = i < available ? Color.green : Color.gray;
            }
        }
    }
}