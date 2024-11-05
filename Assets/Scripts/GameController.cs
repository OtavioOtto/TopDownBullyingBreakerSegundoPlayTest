using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("People")]
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemyAura;

    [Header("Health Bar")]
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Slider enemyHealth;

    [Header("Character Selection")]
    [SerializeField] private GameObject player1Selection;
    [SerializeField] private GameObject player2Selection;
    [SerializeField] private GameObject enemySelection;

    [Header("End Screens")]
    [SerializeField] private GameObject enemyDefeated;
    [SerializeField] private GameObject enemyConverted;
    [SerializeField] private GameObject enemyWon;

    [Header("Player Actions")]
    [SerializeField] private float playerAttackValue = .75f;
    [SerializeField] private float playerEmpathyValue = .5f;

    [Header("Action Buttons")]
    [SerializeField] private Button attackButton;
    [SerializeField] private Button empathyButton;
    [SerializeField] private Button itemButton;

    [Header("Action Buttons Text")]
    [SerializeField] private GameObject attackButtonTxt;
    [SerializeField] private GameObject empathyButtonTxt;
    [SerializeField] private GameObject itemButtonTxt;

    [Header("GameObject Buttons")]
    [SerializeField] private GameObject attackButtonGM;
    [SerializeField] private GameObject empathyButtonGM;
    [SerializeField] private GameObject itemButtonGM;
    [SerializeField] private GameObject nextSceneEnemyDefeatedGM;
    [SerializeField] private GameObject nextSceneEnemyConvertedGM;
    [SerializeField] private GameObject resetSceneGM;

    [Header("Buttons Attack")]
    [SerializeField] private Button firstAttackButton;
    [SerializeField] private GameObject firstAttackButtonTxt;
    [SerializeField] private Button secondAttackButton;
    [SerializeField] private GameObject secondAttackButtonTxt;

    [Header("Buttons Empathy")]
    [SerializeField] private Button firstEmpathyButton;
    [SerializeField] private GameObject firstEmpathyButtonTxt;
    [SerializeField] private Button secondEmpathyButton;
    [SerializeField] private GameObject secondEmpathyButtonTxt;

    [Header("Buttons Items")]
    [SerializeField] private Button firstItemButton;
    [SerializeField] private GameObject firstItemButtonTxt;
    [SerializeField] private Button secondItemButton;
    [SerializeField] private GameObject secondItemButtonTxt;
    [SerializeField] private Button thirdItemButton;
    [SerializeField] private GameObject thirdItemButtonTxt;

    [Header("Buttons Groups")]
    [SerializeField] private GameObject itemOptions;
    [SerializeField] private GameObject empathyOptions;
    [SerializeField] private GameObject attackOptions;
    [SerializeField] private GameObject defaultOptions;

    [Header("Enemy Stats")]
    [SerializeField] private float enemyAttackValue = 0.25f;
    [SerializeField] private float enemyHealthValue = 1.0f;

    [Header("Player Stats")]
    [SerializeField] private float battlePoints = 0.25f;
    [SerializeField] private TMP_Text battlePointsTxt;

    [Header("Items")]
    [SerializeField] private float itemHealValue = 0.10f;

    private List<GameObject> turnOrder;
    private int currentTurnIndex;
    private float menu;
    private float weaponAttackValue;
    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // dps muda isso
        weaponAttackValue = playerController.GetWeaponDamage();
        InitializeGame();
    }
    private void Update()
    {
        menu = Input.GetAxis("MENU");
        Menu();
        SetButtonTexts();
        ReturnToDefaultButtons();

    }

    private void InitializeGame()
    {
        turnOrder = new List<GameObject> { player1, player2, enemy };
        currentTurnIndex = 0;
        enemyHealth.maxValue = enemyHealthValue;
        enemyHealth.value = enemyHealthValue;
        UpdateTurn();
    }

    private void UpdateTurn()
    {
        DeactivateSelections();
        DisableActionButtons();

        if (turnOrder[currentTurnIndex] == player1)
        {
            battlePoints += 4;
            ActivatePlayer1Turn();
            EventSystem.current.SetSelectedGameObject(attackButtonGM);
        }
        else if (turnOrder[currentTurnIndex] == player2)
        {
            ActivatePlayer2Turn();
            EventSystem.current.SetSelectedGameObject(attackButtonGM);
        }
        else if (turnOrder[currentTurnIndex] == enemy)
        {
            ActivateEnemyTurn();
        }
    }

    private void DeactivateSelections()
    {
        player1Selection.SetActive(false);
        player2Selection.SetActive(false);
        enemySelection.SetActive(false);
    }

    private void DisableActionButtons()
    {
        attackButton.interactable = false;
        empathyButton.interactable = false;
        itemButton.interactable = false;
    }

    private void ActivatePlayer1Turn()
    {
        player1Selection.SetActive(true);
        EnableActionButtons();
    }

    private void ActivatePlayer2Turn()
    {
        player2Selection.SetActive(true);
        EnableActionButtons();
    }

    private void ActivateEnemyTurn()
    {
        enemySelection.SetActive(true);
        StartCoroutine(EnemyAttackRoutine());
    }

    private void EnableActionButtons()
    {
        attackButton.interactable = true;
        empathyButton.interactable = true;
        itemButton.interactable = true;
    }

    private IEnumerator EnemyAttackRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        playerHealth.value -= playerHealth.maxValue * enemyAttackValue;

        if (playerHealth.value <= 0)
        {
            enemyWon.SetActive(true);
            EventSystem.current.SetSelectedGameObject(resetSceneGM);
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            NextTurn();
        }
    }

    public void EmpathyOptions()
    {

        if (battlePoints > 15)
        {
            attackOptions.SetActive(true);
            defaultOptions.SetActive(false);
            firstAttackButton.Select();
        }


        else
        {
            attackOptions.SetActive(true);
            defaultOptions.SetActive(false);
            firstAttackButton.Select();
            secondAttackButton.interactable = false;
        }
        
    }

    public void EmpathyButton(GameObject chonsenButton) {

        AdjustEnemyAura(chonsenButton);

        if (enemyAura.GetComponent<Image>().color.a == 0)
        {
            enemyConverted.SetActive(true);
            EventSystem.current.SetSelectedGameObject(nextSceneEnemyConvertedGM);
        }
        else
        {
            NextTurn();
        }

    }

    private void AdjustEnemyAura(GameObject buttonOBJ)
    {
        if (buttonOBJ == firstEmpathyButton)
        {
            Color auraColor = enemyAura.GetComponent<Image>().color;

            auraColor.a = Mathf.Max(0, auraColor.a - playerEmpathyValue);
            enemyAura.GetComponent<Image>().color = auraColor;
        }

        else if (buttonOBJ == secondEmpathyButton)
        {
            Color auraColor = enemyAura.GetComponent<Image>().color;

            auraColor.a = Mathf.Max(0, auraColor.a - playerEmpathyValue * 2);
            enemyAura.GetComponent<Image>().color = auraColor;
        }


    }

    public void AttackOptions()
    {
        if (battlePoints > 10 && playerController.currentWeapon != null)
        {
            attackOptions.SetActive(true);
            defaultOptions.SetActive(false);
            firstAttackButton.Select();
        }


        else
        {
            attackOptions.SetActive(true);
            defaultOptions.SetActive(false);
            firstAttackButton.Select();
            secondAttackButton.interactable = false;
        }

    }

    public void AttackButton(GameObject chosenButton)
    {
            AdjustEnemyHealth(chosenButton);

        if (enemyHealth.value == 0)
        {
            enemyDefeated.SetActive(true);
            EventSystem.current.SetSelectedGameObject(nextSceneEnemyDefeatedGM);

        }
        else
        {
            NextTurn();
        }
    }

    private void ReturnToDefaultButtons() {

        if (attackOptions.activeSelf && Input.GetButtonDown("BRANCO0")) {

            attackOptions.SetActive(false);
            defaultOptions.SetActive(true);
            attackButton.Select();
        
        }

        else if (empathyOptions.activeSelf && Input.GetButtonDown("BRANCO0"))
        {

            empathyOptions.SetActive(false);
            defaultOptions.SetActive(true);
            empathyButton.Select();

        }

        else if (itemOptions.activeSelf && Input.GetButtonDown("BRANCO0"))
        {

            itemOptions.SetActive(false);
            defaultOptions.SetActive(true);
            itemButton.Select();

        }

    }

    private void AdjustEnemyHealth(GameObject buttonOBJ)
    {
        if (buttonOBJ == firstAttackButton)
        {
            enemyHealth.value -= enemyHealth.maxValue * playerAttackValue;
        }

        else if(buttonOBJ == secondAttackButton)
        {
            enemyHealth.value -= enemyHealth.maxValue * playerAttackValue * weaponAttackValue;
        }
    }

    public void ItemOptions()
    {
        if (playerController.curativoQuant > 0 && playerController.sucoQuant < 0 && playerController.frutaQuant < 0) 
        {
            itemOptions.SetActive(true);
            defaultOptions.SetActive(false);
            firstItemButton.Select();
            secondItemButton.interactable = false;
            thirdItemButton.interactable = false;
        }

        else if (playerController.curativoQuant > 0 && playerController.sucoQuant > 0 && playerController.frutaQuant < 0)
        {
            itemOptions.SetActive(true);
            defaultOptions.SetActive(false);
            firstItemButton.Select();
            thirdItemButton.interactable = false;
        }

        else if (playerController.curativoQuant > 0 && playerController.sucoQuant > 0 && playerController.frutaQuant > 0)
        {
            itemOptions.SetActive(true);
            defaultOptions.SetActive(false);
            firstItemButton.Select();
        }

        else if (playerController.curativoQuant < 0 && playerController.sucoQuant > 0 && playerController.frutaQuant < 0)
        {
            itemOptions.SetActive(true);
            defaultOptions.SetActive(false);
            secondItemButton.Select();
            firstItemButton.interactable = false;
            thirdItemButton.interactable = false;
        }

        else if (playerController.curativoQuant < 0 && playerController.sucoQuant > 0 && playerController.frutaQuant > 0)
        {
            itemOptions.SetActive(true);
            defaultOptions.SetActive(false);
            secondItemButton.Select();
            firstItemButton.interactable = false;
        }

        else if (playerController.curativoQuant > 0 && playerController.sucoQuant < 0 && playerController.frutaQuant > 0)
        {
            itemOptions.SetActive(true);
            defaultOptions.SetActive(false);
            firstItemButton.Select();
            secondItemButton.interactable = false;
        }

        else if (playerController.curativoQuant < 0 && playerController.sucoQuant < 0 && playerController.frutaQuant > 0)
        {
            itemOptions.SetActive(true);
            defaultOptions.SetActive(false);
            thirdItemButton.Select();
            secondItemButton.interactable = false;
            firstItemButton.interactable = false;
        }
    }
    public void ItemButton(string itemName) 
    {
        AdjustPlayerHealth(itemName);
        NextTurn();
    }

    private void AdjustPlayerHealth(string item) {

        if (item == "curativo") {

            playerHealth.value += playerHealth.maxValue * (itemHealValue * 0.1f);

        }

        if (item == "suco")
        {

            playerHealth.value += playerHealth.maxValue * (itemHealValue * 0.15f);

        }

        if (item == "fruta")
        {

            playerHealth.value += playerHealth.maxValue * (itemHealValue * 0.25f);

        }

    }


    private void NextTurn()
    {
        currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;
        UpdateTurn();

        
    }

    public void ResetSceneButton()
    {
        SceneManager.LoadScene("TopDownLuzDaEsperanca");
    }

    public void NextSceneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Menu()
    {

        if (menu > 0.0f)
            SceneManager.LoadScene(0);

    }
    private void SetButtonTexts() 
    {
        if (defaultOptions.activeSelf)
        {
            if (EventSystem.current.currentSelectedGameObject == attackButtonGM)
            {
                attackButtonTxt.SetActive(true);
                empathyButtonTxt.SetActive(false);
                itemButtonTxt.SetActive(false);

            }

            if (EventSystem.current.currentSelectedGameObject == empathyButtonGM)
            {
                attackButtonTxt.SetActive(false);
                empathyButtonTxt.SetActive(true);
                itemButtonTxt.SetActive(false);

            }

            if (EventSystem.current.currentSelectedGameObject == itemButtonGM)
            {
                attackButtonTxt.SetActive(false);
                empathyButtonTxt.SetActive(false);
                itemButtonTxt.SetActive(true);

            }
        }

        if (attackOptions.activeSelf)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == firstAttackButton)
            {
                firstAttackButtonTxt.SetActive(true);
                secondAttackButtonTxt.SetActive(false);

            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == secondAttackButton)
            {
                firstAttackButtonTxt.SetActive(false);
                secondAttackButtonTxt.SetActive(true);

            }
        }

        if (empathyOptions.activeSelf)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == firstEmpathyButton)
            {
                firstEmpathyButtonTxt.SetActive(true);
                secondEmpathyButtonTxt.SetActive(false);

            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == secondEmpathyButton)
            {
                firstEmpathyButtonTxt.SetActive(false);
                secondEmpathyButtonTxt.SetActive(true);

            }
        }

        if (itemOptions.activeSelf)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == firstItemButton)
            {
                firstItemButtonTxt.SetActive(true);
                secondItemButtonTxt.SetActive(false);
                thirdItemButtonTxt.SetActive(false);

            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == secondItemButton)
            {
                firstItemButtonTxt.SetActive(false);
                secondItemButtonTxt.SetActive(true);
                thirdItemButtonTxt.SetActive(false);

            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == thirdItemButton)
            {
                firstItemButtonTxt.SetActive(false);
                secondItemButtonTxt.SetActive(false);
                thirdItemButtonTxt.SetActive(true);

            }
        }

    }

    private void UpdateBattlePoints()
    {

        battlePointsTxt.text = "" + battlePoints;

    }
}
