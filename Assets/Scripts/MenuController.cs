using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [Header("Buttons")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button controlesButton;

    [Header("Inventory System")]
    public InventoryHandler inventory;

    private void Start()
    {
        inventory.curativoQuant = 0;
        inventory.sucoQuant = 0;
        inventory.frutaQuant = 0;
        inventory.brocheQuant = 0;
        inventory.oculosQuant = 0;
        inventory.jaquetaQuant = 0;
        inventory.cadernoQuant = 0;
        inventory.lapisQuant = 0;
        inventory.tesouraQuant = 0;
        inventory.hasAnyBuffs = false;
        inventory.attackBuff = false;
        inventory.healingBuff = false;
        inventory.empathyBuff = false;
        inventory.hp = 1;
        inventory.currentAttackItem1 = "";
        inventory.currentDefenseItem1 = "";
        inventory.currentEquippedBuff1 = "";
        inventory.currentAttackItem2 = "";
        inventory.currentDefenseItem2 = "";
        inventory.currentEquippedBuff2 = "";
        //reseta o spawn tmb dps
    }
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ControlesButton()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
