using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Settings")]
    public int maxStacks = 2; // 2 stacks max
    public int attacksPerStack = 4; // 4 attaques normales pour recharger 1 stack
    public int stacksPerSkill = 1; // 1 stack par compétence

    [Header("Effects")]
    public ParticleSystem skill1Effect;
    public ParticleSystem skill2Effect;
    public AudioClip skillSound;

    [Header("UI Reference")]
    public SkillHUDController hudController;

    private int currentStacks;
    private int attackCounter; // Compteur d'attaques normales
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentStacks = maxStacks; // Pour tester, à remettre à 0 après
        attackCounter = 0;
        hudController.UpdateStacks(currentStacks);
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // Attaque normale (recharge)
        if (Input.GetMouseButtonDown(0))
        {
            attackCounter++;
            if (attackCounter >= attacksPerStack)
            {
                AddStacks(1);
                attackCounter = 0;
            }
        }

        // Compétence 1 (Bouton 1)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TryUseSkill(1);
        }

        // Compétence 2 (Bouton 2)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TryUseSkill(2);
        }
    }

    public void AddStacks(int amount)
    {
        currentStacks = Mathf.Min(currentStacks + amount, maxStacks);
        hudController.UpdateStacks(currentStacks);
    }

    private void TryUseSkill(int skillId)
    {
        if (currentStacks >= stacksPerSkill)
        {
            currentStacks -= stacksPerSkill;
            hudController.UpdateStacks(currentStacks);
            TriggerSkill(skillId);
        }
    }

    private void TriggerSkill(int skillId)
    {
        // Effet visuel et sonore
        switch(skillId)
        {
            case 1:
                skill1Effect.Play();
                break;
            case 2:
                skill2Effect.Play();
                break;
        }
        
        if (skillSound != null)
        {
            audioSource.PlayOneShot(skillSound);
        }
    }
}