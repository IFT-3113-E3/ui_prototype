using UnityEngine;
using UnityEngine.UI;

public class SkillHUDController : MonoBehaviour
{
    [Header("Skill 1")]
    public Button skill1Button;
    public Image[] skill1Stacks; // Tableau des rectangles (stacks) pour la compétence 1

    [Header("Skill 2")]
    public Button skill2Button;
    public Image[] skill2Stacks; // Tableau des rectangles (stacks) pour la compétence 2

    public void UpdateStacks(int currentStacks)
    {
        // Mettre à jour les stacks pour la compétence 1
        for (int i = 0; i < skill1Stacks.Length; i++)
        {
            skill1Stacks[i].gameObject.SetActive(i < currentStacks);
        }

        // Mettre à jour les stacks pour la compétence 2
        for (int i = 0; i < skill2Stacks.Length; i++)
        {
            skill2Stacks[i].gameObject.SetActive(i < currentStacks);
        }
    }
}