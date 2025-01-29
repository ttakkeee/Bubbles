using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class NotorieteManager : MonoBehaviour
{
    private struct NotorietyLevel
    {
        public int requiredNotoriety;
        public int moneyGain;

        public NotorietyLevel(int notoriety, int money)
        {
            requiredNotoriety = notoriety;
            moneyGain = money;
        }
    }

    private NotorietyLevel[] notorietyLevels = new NotorietyLevel[]
    {
        new NotorietyLevel(5, 5),
        new NotorietyLevel(15, 10),
        new NotorietyLevel(30, 15),
        new NotorietyLevel(50, 20),
        new NotorietyLevel(75, 25),
        new NotorietyLevel(105, 30),
        new NotorietyLevel(140, 35),
        new NotorietyLevel(180, 40),
        new NotorietyLevel(225, 45),
        new NotorietyLevel(275, 50),
    };

    public TMP_Text notorietyText;
    public TMP_Text moneyText;

    private int currentNotoriety = 0;
    private int currentLevel = 0;
    public int money = 0;

    void Start()
    {
        UpdateUI();
        StartCoroutine(GainMoneyOverTime());
    }

    public void BubbleClicked()
    {
        currentNotoriety += 1;
        CheckLevelUp();
        UpdateUI();
    }

    public void BubbleAutoDestroyed()
    {
        currentNotoriety += 1; // No half points (float not used)
        CheckLevelUp();
        UpdateUI();
    }

    private void CheckLevelUp()
    {
        for (int i = notorietyLevels.Length - 1; i >= 0; i--)
        {
            if (currentNotoriety >= notorietyLevels[i].requiredNotoriety)
            {
                currentLevel = i;
                break;
            }
        }
    }

    private IEnumerator GainMoneyOverTime()
    {
        while (true)
        {
            // Check if notoriety level is within the correct range (1 to 10)
            if (currentLevel >= 0 && currentLevel < notorietyLevels.Length)
            {
                // Get the money gain based on the notoriety level (starting from level 1)
                int moneyGain = notorietyLevels[currentLevel].moneyGain;
                money += moneyGain;
                UpdateUI(); // Update the UI with new money value
            }

            yield return new WaitForSeconds(1f); 
        }
    }
    private void UpdateUI()
    {
        notorietyText.text = "Niveau de Notoriété: " + currentLevel;
        moneyText.text = "Argent: " + money;
    }
}