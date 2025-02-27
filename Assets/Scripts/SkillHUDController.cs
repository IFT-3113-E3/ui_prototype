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

    public void UpdateStacks(float totalProgress)
    {
        for (int i = 0; i < stackFills.Length; i++)
        {
            if (stackFills[i] != null)
            {
                // Calculer la progression pour chaque stack
                float stackProgress = Mathf.Clamp(totalProgress - i, 0f, 1f);
                stackFills[i].fillAmount = stackProgress;

                // Changer la couleur en fonction de la disponibilité
                stackFills[i].color = stackProgress > 0 ? Color.green : Color.gray;
            }
        }
    }
}