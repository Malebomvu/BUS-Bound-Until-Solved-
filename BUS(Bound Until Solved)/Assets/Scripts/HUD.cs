using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Header("Health")]
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    [Header("Objective")]
    public TextMeshProUGUI objectiveText;

    [Header("Interaction")]
    public GameObject interactionPanel;
    public TextMeshProUGUI interactionText;

    [Header("Inventory")]
    public GameObject inventoryPanel;
    public TextMeshProUGUI inventoryText;

    private string inventoryItems = "";

    void Start()
    {
        interactionPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        SetHealth(100, 100);
        SetObjective("Find the Phone.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void SetHealth(int currentHealth, int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        healthText.text = currentHealth + " / " + maxHealth;
    }

    public void SetObjective(string objective)
    {
        objectiveText.text = "Objective: " + objective;
    }

   
    public void ShowInteraction(string message)
    {
        interactionPanel.SetActive(true);
        interactionText.text = message;
    }

    public void HideInteraction()
    {
        interactionPanel.SetActive(false);
    }

    public void AddItem(string itemName)
    {
        inventoryItems += itemName + "\n";
        inventoryText.text = inventoryItems;
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}