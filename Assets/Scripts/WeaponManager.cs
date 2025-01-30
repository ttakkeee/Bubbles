using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    // Références aux éléments UI dans Unity
    public TMP_Text weaponText;
    public Button upgradeButton; // Référence au bouton d'upgrade

    private int currentNotoriety = 0;
    private int currentLevel = 0;
    private int money = 0;

    // Index des armes
    private int weaponIndex = 0;

    // Liste des armes et leurs caractéristiques
    private string[] weapons = { "Clic sans amélioration", "Sarbacane", "Arbalète", "Magnum", "Mitraillette" };
    private int[] weaponCosts = { 250, 2500, 10000, 25000 };  // Coût pour chaque arme
    private int[] notorietyPerClick = { 1, 3, 8, 15, 25 };  // Gain de notoriété par clic pour chaque arme

    void Start()
    {
        UpdateUI();
        StartCoroutine(GainMoneyOverTime());  // Démarre la coroutine pour gagner de l'argent

        // Lier le bouton au script (avec un listener)
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(UpgradeWeapon);  // Quand on clique, on améliore l'arme
        }
        else
        {
            Debug.LogWarning("Le bouton d'upgrade n'est pas assigné.");
        }
    }

    // Méthode appelée lors du clic du bouton d'achat
    public void UpgradeWeapon()
    {
        // Vérifier si l'arme peut être améliorée
        if (weaponIndex < weapons.Length - 1)  // Si ce n'est pas la dernière arme
        {
            int cost = weaponCosts[weaponIndex];  // Coût de l'arme suivante
            if (money >= cost)  // Si le joueur a assez d'argent
            {
                money -= cost;  // Déduire l'argent du joueur
                weaponIndex++;  // Passer à l'arme suivante
                UpdateUI();  // Mettre à jour l'UI pour afficher la nouvelle arme
                Debug.Log("Arme améliorée à: " + weapons[weaponIndex]);
            }
            else
            {
                Debug.LogWarning("Pas assez d'argent pour acheter cette arme.");
            }
        }
        else
        {
            Debug.Log("Vous avez déjà l'arme la plus puissante.");
        }
    }

    // Méthode qui gère l'augmentation de la notoriété quand le joueur clique sur une bulle
    public void BubbleClicked()
    {
        // Ajouter de la notoriété en fonction de l'arme actuelle
        currentNotoriety += notorietyPerClick[weaponIndex];
        CheckLevelUp();
        UpdateUI();
    }

    // Vérification du niveau de notoriété
    private void CheckLevelUp()
    {
        if (currentNotoriety >= (currentLevel + 1) * 10)  // Exemple simple de progression de niveau
        {
            currentLevel++;
        }
    }

    // Mise à jour de l'UI
    private void UpdateUI()
    {
        weaponText.text = "Arme: " + weapons[weaponIndex]; // Affichage de l'arme actuelle
    }

    // Gagner de l'argent toutes les 2 secondes
    private IEnumerator GainMoneyOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);  // Attendre 2 secondes
            money += 5;  // Ajouter 5 d'argent
            UpdateUI();  // Mettre à jour l'UI pour afficher l'argent
            Debug.Log("Gagner de l'argent, argent actuel: " + money);
        }
    }
}