using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using Packages.Rider.Editor.UnitTesting;

public class UIBanheiroHandler : MonoBehaviour
{
    [Header("Tela Recrutados")]
    [SerializeField] private GameObject recrutados;
    [SerializeField] private Button bully1Select;
    [SerializeField] private Button bully2Select;
    [SerializeField] private Button bully3Select;
    [SerializeField] private Button bully4Select;
    [SerializeField] private GameObject dadosBully1;
    [SerializeField] private GameObject dadosBully2;
    [SerializeField] private GameObject dadosBully3;
    [SerializeField] private GameObject dadosBully4;
    [SerializeField] private GameObject pencilBully1;
    [SerializeField] private GameObject pencilBully2;
    [SerializeField] private GameObject pencilBully3;
    [SerializeField] private GameObject pencilBully4;
    [Header("Tela Party")]
    [SerializeField] private GameObject party;
    [SerializeField] private Button jimmySelect;
    [SerializeField] private Button aliceSelect;
    [SerializeField] private Button itensSelect;
    [Header("Checks")]
    [SerializeField] private bool canChangeScreen = true;
    [SerializeField] private bool canUseGreen = true;
    [Header("Select")]
    [SerializeField] private GameObject pencilJimmy;
    [SerializeField] private GameObject pencilAlice;
    [SerializeField] private GameObject pencilItens;
    [Header("Tela Dados")]
    [SerializeField] private GameObject dadosJimmy;
    [SerializeField] private GameObject dadosAlice;
    [SerializeField] private GameObject dadosItens;
    [Header("Itens")]
    [SerializeField] private TMP_Text item1;
    [SerializeField] private TMP_Text item2;
    [SerializeField] private TMP_Text item3;
    [Header("Itens Game Object")]
    [SerializeField] private Button item1BTTN;
    [SerializeField] private Button item2BTTN;
    [SerializeField] private Button item3BTTN;
    [Header("Itens Texts")]
    [SerializeField] private TMP_Text item1Txt;
    [SerializeField] private TMP_Text item2Txt;
    [SerializeField] private TMP_Text item3Txt;
    [Header("Itens Select")]
    [SerializeField] private GameObject item1Select;
    [SerializeField] private GameObject item2Select;
    [SerializeField] private GameObject item3Select;
    [Header("Dados Alice")]
    [SerializeField] private GameObject ataqueAlicePencil;
    [SerializeField] private Button ataqueAliceSelect;
    [SerializeField] private GameObject defesaAlicePencil;
    [SerializeField] private Button defesaAliceSelect;
    [SerializeField] private GameObject buffAlicePencil;
    [SerializeField] private Button buffAliceSelect;
    [SerializeField] private TMP_Text itemAliceAtaque;
    [SerializeField] private TMP_Text itemAliceDefesa;
    [SerializeField] private TMP_Text aliceBuff;
    [Header("DadosJimmy")]
    [SerializeField] private GameObject ataqueJimmyPencil;
    [SerializeField] private Button ataqueJimmySelect;
    [SerializeField] private GameObject defesaJimmyPencil;
    [SerializeField] private Button defesaJimmySelect;
    [SerializeField] private GameObject buffJimmyPencil;
    [SerializeField] private Button buffJimmySelect;
    [SerializeField] private TMP_Text itemJimmyAtaque;
    [SerializeField] private TMP_Text itemJimmyDefesa;
    [SerializeField] private TMP_Text jimmyBuff;
    [Header("Health Bar")]
    [SerializeField] private Slider playerHealth;
    [Header("Inventory System")]
    public InventoryHandler inventory;
    

    [SerializeField] private float x0;
    string newItem = "";
    string newBuff = "";
    void Update()
    {
        x0 = Input.GetAxis("HORIZONTAL0");
        ChangeScreens();
        BullyAttributes();
        CharacterAttributes();
        CharacterAttributesScreen();
        ItemChange();
        BuffChange();
        HealItens();
        HealItensScreen();
        SetHealItemQuantities();
        ReturnButton();
        UpdatePlayerHealth();
    }
    private void ChangeScreens()
    {
        if (canChangeScreen)
        {
            if (Input.GetButtonDown("HORIZONTAL0"))
            {
                if (recrutados.activeSelf)
                {
                    recrutados.SetActive(false);
                    party.SetActive(true);
                    jimmySelect.Select();
                    pencilJimmy.SetActive(true);
                    pencilBully1.SetActive(false);
                }
                else if (party.activeSelf)
                {
                    party.SetActive(false);
                    recrutados.SetActive(true);
                    bully1Select.Select();
                    pencilBully1.SetActive(true);
                    pencilJimmy.SetActive(false);
                }
            }
        }
    }
    private void BullyAttributes()
    {

        if (recrutados.activeSelf && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == bully1Select)
        {
            pencilBully1.SetActive(true);
            dadosBully1.SetActive(true);
            pencilBully2.SetActive(false);
            dadosBully2.SetActive(false);
            pencilBully3.SetActive(false);
            dadosBully3.SetActive(false);
            pencilBully4.SetActive(false);
            dadosBully4.SetActive(false);
        }

        if (recrutados.activeSelf && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == bully2Select)
        {
            pencilBully2.SetActive(true);
            dadosBully2.SetActive(true);
            pencilBully1.SetActive(false);
            dadosBully1.SetActive(false);
            pencilBully3.SetActive(false);
            dadosBully3.SetActive(false);
            pencilBully4.SetActive(false);
            dadosBully4.SetActive(false);
        }

        if (recrutados.activeSelf && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == bully3Select)
        {
            pencilBully1.SetActive(false);
            dadosBully1.SetActive(false);
            pencilBully2.SetActive(false);
            dadosBully2.SetActive(false);
            pencilBully3.SetActive(true);
            dadosBully3.SetActive(true);
            pencilBully4.SetActive(false);
            dadosBully4.SetActive(false);
        }
        if (recrutados.activeSelf && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == bully4Select)
        {
            pencilBully1.SetActive(false);
            dadosBully1.SetActive(false);
            pencilBully2.SetActive(false);
            dadosBully2.SetActive(false);
            pencilBully3.SetActive(false);
            dadosBully3.SetActive(false);
            pencilBully4.SetActive(true);
            dadosBully4.SetActive(true);
        }

    }
    private void CharacterAttributes()
    {
        if (party.activeSelf && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == jimmySelect && !dadosJimmy.activeSelf)
        {

            pencilJimmy.SetActive(true);
            pencilAlice.SetActive(false);
            pencilItens.SetActive(false);
        }

        else if (party.activeSelf && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == aliceSelect && !dadosAlice.activeSelf)
        {
            pencilAlice.SetActive(true);
            pencilJimmy.SetActive(false);
            pencilItens.SetActive(false);

        }

    }
    private void HealItens()
    {

        if (party.activeSelf && EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == itensSelect && !dadosAlice.activeSelf)
        {
            pencilItens.SetActive(true);
            pencilAlice.SetActive(false);
            pencilJimmy.SetActive(false);
            if (Input.GetButtonDown("VERDE0"))
            {
                pencilItens.SetActive(false);
                dadosItens.SetActive(true);
                item1Select.SetActive(true);
                item1BTTN.Select();
                canChangeScreen = false;

            }
        }
    }
    private void CharacterAttributesScreen()
    {

        if (dadosJimmy.activeSelf == true)
        {

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == ataqueJimmySelect)
            {
                ataqueJimmyPencil.SetActive(true);
                defesaJimmyPencil.SetActive(false);
                buffJimmyPencil.SetActive(false);
            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == defesaJimmySelect)
            {
                ataqueJimmyPencil.SetActive(false);
                defesaJimmyPencil.SetActive(true);
                buffJimmyPencil.SetActive(false);
            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == buffJimmySelect)
            {
                ataqueJimmyPencil.SetActive(false);
                defesaJimmyPencil.SetActive(false);
                buffJimmyPencil.SetActive(true);
            }

        }

        if (dadosAlice.activeSelf == true)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == ataqueAliceSelect)
            {
                ataqueAlicePencil.SetActive(true);
                defesaAlicePencil.SetActive(false);
                buffAlicePencil.SetActive(false);
            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == defesaAliceSelect)
            {
                ataqueAlicePencil.SetActive(false);
                defesaAlicePencil.SetActive(true);
                buffAlicePencil.SetActive(false);
            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == buffAliceSelect)
            {
                ataqueAlicePencil.SetActive(false);
                defesaAlicePencil.SetActive(false);
                buffAlicePencil.SetActive(true);
            }

        }
    }
    private void HealItensScreen()
    {

        if (dadosItens.activeSelf == true)
        {

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == item1BTTN)
            {
                item1Select.SetActive(true);
                item2Select.SetActive(false);
                item3Select.SetActive(false);
            }

            else if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == item2BTTN)
            {
                item1Select.SetActive(false);
                item2Select.SetActive(true);
                item3Select.SetActive(false);
            }

            else if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == item3BTTN)
            {
                item1Select.SetActive(false);
                item2Select.SetActive(false);
                item3Select.SetActive(true);
            }
        }
    }
    private void ItemChange()
    {
        

        string caderno = "Caderno\n+2 Ataque";
        string lapis = "Lapis\n+3 Ataque";
        string tesoura = "Tesoura\n+6 Ataque";

        string broche = "Broche\n+3 Defesa";
        string oculos = "Oculos\n+5 Defesa";
        string jaqueta = "Jaqueta\n+9 Defesa";
        if (dadosJimmy.activeSelf == true)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == ataqueJimmySelect)
            {
                if (!canChangeScreen && Input.GetButtonDown("HORIZONTAL0") && itemJimmyAtaque.text == "")
                {
                    if (x0 > 0)
                    {
                        if (inventory.cadernoQuant > 0)
                        {
                            itemJimmyAtaque.text = caderno;
                            newItem = "caderno";
                        }
                        else if (inventory.lapisQuant > 0)
                        {
                            itemJimmyAtaque.text = lapis;
                            newItem = "lapis";
                        }
                        else if (inventory.tesouraQuant > 0)
                        {
                            itemJimmyAtaque.text = tesoura;
                            newItem = "tesoura";
                        }
                        else
                            itemJimmyAtaque.text = "Voce nao tem\nitens de ataque";
                    }
                    else if (x0 < 0)
                    {
                        if (inventory.tesouraQuant > 0)
                        {
                            itemJimmyAtaque.text = tesoura;
                            newItem = "tesoura";
                        }
                        else if (inventory.lapisQuant > 0)
                        {
                            itemJimmyAtaque.text = lapis;
                            newItem = "lapis";
                        }
                        else if (inventory.cadernoQuant > 0)
                        {
                            itemJimmyAtaque.text = caderno;
                            newItem = "caderno";
                        }
                        else
                            itemJimmyAtaque.text = "Voce nao tem\nitens de ataque";
                    }
                }

                else if (!canChangeScreen && ((Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && itemJimmyAtaque.text == caderno) || (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && itemJimmyAtaque.text == tesoura)))
                {
                    if (inventory.lapisQuant > 0)
                    {
                        itemJimmyAtaque.text = lapis;
                        newItem = "lapis";
                    }
                    else if (itemJimmyAtaque.text == caderno)
                    {
                        if (inventory.tesouraQuant > 0)
                        {
                            itemJimmyAtaque.text = tesoura;
                            newItem = "tesoura";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                    else if (itemJimmyAtaque.text == tesoura)
                    {
                        if (inventory.cadernoQuant > 0)
                        {
                            itemJimmyAtaque.text = caderno;
                            newItem = "caderno";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && !canChangeScreen && itemJimmyAtaque.text == lapis)
                {

                    if (inventory.cadernoQuant > 0)
                    {
                        itemJimmyAtaque.text = caderno;
                        newItem = "caderno";
                    }
                    else { }//n fzr nd pq ele n tem mais cadernos

                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && !canChangeScreen && itemJimmyAtaque.text == lapis)
                {

                    if (inventory.tesouraQuant > 0)
                    {
                        itemJimmyAtaque.text = tesoura;
                        newItem = "tesoura";
                    }
                    else { }//n fzr nd pq ele n tem mais tesouras

                }
                if (Input.GetButtonDown("VERDE0") && canUseGreen)
                {
                    inventory.ChangeItem(newItem, "player1");
                    dadosJimmy.SetActive(false);
                    pencilJimmy.SetActive(true);
                    jimmySelect.Select();
                    canChangeScreen = true;
                    canUseGreen = false;
                    StartCoroutine(GreenButtonCoolDown());
                }
            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == defesaJimmySelect)
            {
                if (!canChangeScreen && Input.GetButtonDown("HORIZONTAL0") && itemJimmyDefesa.text == "")
                {
                    if (x0 > 0)
                    {
                        if (inventory.brocheQuant > 0)
                        {
                            itemJimmyDefesa.text = broche;
                            newItem = "broche";
                        }
                        else if (inventory.oculosQuant > 0)
                        {
                            itemJimmyDefesa.text = oculos;
                            newItem = "oculos";
                        }
                        else if (inventory.jaquetaQuant > 0)
                        {
                            itemJimmyDefesa.text = jaqueta;
                            newItem = "jaqueta";
                        }
                        else
                            itemJimmyDefesa.text = "Voce nao tem\nitens de defesa";
                    }
                    else if (x0 < 0)
                    {
                        if (inventory.jaquetaQuant > 0)
                        {
                            itemJimmyDefesa.text = jaqueta;
                            newItem = "jaqueta";
                        }
                        else if (inventory.oculosQuant > 0)
                        {
                            itemJimmyDefesa.text = oculos;
                            newItem = "oculos";
                        }
                        else if (inventory.brocheQuant > 0)
                        {
                            itemJimmyDefesa.text = broche;
                            newItem = "broche";
                        }
                        else
                            itemJimmyDefesa.text = "Voce nao tem\nitens de defesa";
                    }
                }

                else if (!canChangeScreen && ((Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && itemJimmyDefesa.text == broche) || (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && itemJimmyDefesa.text == jaqueta)))
                {

                    if (inventory.oculosQuant > 0)
                    {
                        itemJimmyDefesa.text = oculos;
                        newItem = "oculos";
                    }
                    else if (itemJimmyDefesa.text == broche)
                    {
                        if (inventory.jaquetaQuant > 0)
                        {
                            itemJimmyDefesa.text = jaqueta;
                            newItem = "jaqueta";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                    else if (itemJimmyDefesa.text == jaqueta)
                    {
                        if (inventory.brocheQuant > 0)
                        {
                            itemJimmyDefesa.text = broche;
                            newItem = "broche";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }

                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && !canChangeScreen && itemJimmyDefesa.text == oculos)
                {

                    if (inventory.brocheQuant > 0)
                    {
                        itemJimmyDefesa.text = broche;
                        newItem = "broche";
                    }
                    else { }//n fzr nd pq ele n tem mais cadernos

                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && !canChangeScreen && itemJimmyDefesa.text == oculos)
                {

                    if (inventory.jaquetaQuant > 0)
                    {
                        itemJimmyDefesa.text = jaqueta;
                        newItem = "jaqueta";
                    }
                    else { }//n fzr nd pq ele n tem mais cadernos

                }
                if (Input.GetButtonDown("VERDE0") && canUseGreen)
                {
                    inventory.ChangeItem(newItem, "player1");
                    dadosJimmy.SetActive(false);
                    pencilJimmy.SetActive(true);
                    jimmySelect.Select();
                    canChangeScreen = true;
                    canUseGreen = false;
                    StartCoroutine(GreenButtonCoolDown());
                }
            }
        }
        if (dadosAlice.activeSelf == true)
        {

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == ataqueAliceSelect)
            {
                if (!canChangeScreen && Input.GetButtonDown("HORIZONTAL0") && itemAliceAtaque.text == "")
                {
                    if (x0 > 0)
                    {
                        if (inventory.cadernoQuant > 0)
                        {
                            itemAliceAtaque.text = caderno;
                            newItem = "caderno";
                        }
                        else if (inventory.lapisQuant > 0)
                        {
                            itemAliceAtaque.text = lapis;
                            newItem = "lapis";
                        }
                        else if (inventory.tesouraQuant > 0)
                        {
                            itemAliceAtaque.text = tesoura;
                            newItem = "tesoura";
                        }
                        else
                            itemAliceAtaque.text = "Voce nao tem\nitens de ataque";
                    }
                    else if (x0 < 0)
                    {
                        if (inventory.tesouraQuant > 0)
                        {
                            itemAliceAtaque.text = tesoura;
                            newItem = "tesoura";
                        }
                        else if (inventory.lapisQuant > 0)
                        {
                            itemAliceAtaque.text = lapis;
                            newItem = "lapis";
                        }
                        else if (inventory.cadernoQuant > 0)
                        {
                            itemAliceAtaque.text = caderno;
                            newItem = "caderno";
                        }
                        else
                            itemAliceAtaque.text = "Voce nao tem\nitens de ataque";
                    }
                }

                else if (!canChangeScreen && ((Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && itemAliceAtaque.text == caderno) || (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && itemAliceAtaque.text == tesoura)))
                {
                    if (inventory.lapisQuant > 0)
                    {
                        itemAliceAtaque.text = lapis;
                        newItem = "lapis";
                    }
                    else if (itemAliceAtaque.text == caderno)
                    {
                        if (inventory.tesouraQuant > 0)
                        {
                            itemAliceAtaque.text = tesoura;
                            newItem = "tesoura";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                    else if (itemAliceAtaque.text == tesoura)
                    {
                        if (inventory.cadernoQuant > 0)
                        {
                            itemAliceAtaque.text = caderno;
                            newItem = "caderno";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }


                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && !canChangeScreen && itemAliceAtaque.text == lapis)
                {
                    if (inventory.cadernoQuant > 0)
                    {
                        itemAliceAtaque.text = caderno;
                        newItem = "caderno";
                    }
                    else { }//n fzr nd pq ele n tem mais cadernos
                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && !canChangeScreen && itemAliceAtaque.text == lapis)
                {
                    if (inventory.tesouraQuant > 0)
                    {
                        itemAliceAtaque.text = tesoura;
                        newItem = "tesoura";
                    }
                    else { }//n fzr nd pq ele n tem mais tesouras
                }
                if (Input.GetButtonDown("VERDE0") && canUseGreen)
                {

                    inventory.ChangeItem(newItem, "player2");
                    dadosAlice.SetActive(false);
                    pencilAlice.SetActive(true);
                    aliceSelect.Select();
                    canChangeScreen = true;
                    canUseGreen = false;
                    StartCoroutine(GreenButtonCoolDown());
                }
            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == defesaAliceSelect)
            {
                if (!canChangeScreen && Input.GetButtonDown("HORIZONTAL0") && itemAliceDefesa.text == "")
                {
                    if (x0 > 0)
                    {
                        if (inventory.brocheQuant > 0)
                        {
                            itemAliceDefesa.text = broche;
                            newItem = "broche";
                        }
                        else if (inventory.oculosQuant > 0)
                        {
                            itemAliceDefesa.text = oculos;
                            newItem = "oculos";
                        }
                        else if (inventory.jaquetaQuant > 0)
                        {
                            itemAliceDefesa.text = jaqueta;
                            newItem = "jaqueta";
                        }
                        else
                            itemAliceDefesa.text = "Voce nao tem\nitens de defesa";
                    }
                    else if (x0 < 0)
                    {
                        if (inventory.jaquetaQuant > 0)
                        {
                            itemAliceDefesa.text = jaqueta;
                            newItem = "jaqueta";
                        }
                        else if (inventory.oculosQuant > 0)
                        {
                            itemAliceDefesa.text = oculos;
                            newItem = "oculos";
                        }
                        else if (inventory.brocheQuant > 0)
                        {
                            itemAliceDefesa.text = broche;
                            newItem = "broche";
                        }
                        else
                            itemAliceDefesa.text = "Voce nao tem\nitens de defesa";
                    }
                }

                else if (!canChangeScreen && ((Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && itemAliceDefesa.text == broche) || (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && itemAliceDefesa.text == jaqueta)))
                {

                    if (inventory.oculosQuant > 0)
                    {
                        itemAliceDefesa.text = oculos;
                        newItem = "oculos";
                    }
                    else if (itemAliceDefesa.text == broche)
                    {
                        if (inventory.jaquetaQuant > 0)
                        {
                            itemAliceDefesa.text = jaqueta;
                            newItem = "jaqueta";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                    else if (itemAliceDefesa.text == jaqueta)
                    {
                        if (inventory.brocheQuant > 0)
                        {
                            itemAliceAtaque.text = broche;
                            newItem = "broche";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }

                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && !canChangeScreen && itemAliceDefesa.text == oculos)
                {
                    Debug.Log("ok");
                    itemAliceDefesa.text = broche;
                    newItem = "broche";

                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && !canChangeScreen && itemAliceDefesa.text == oculos)
                {

                    itemAliceDefesa.text = jaqueta;
                    newItem = "jaqueta";

                }
                if (Input.GetButtonDown("VERDE0") && canUseGreen)
                {

                    inventory.ChangeItem(newItem, "player2");
                    dadosAlice.SetActive(false);
                    pencilAlice.SetActive(true);
                    aliceSelect.Select();
                    canChangeScreen = true;
                    canUseGreen = false;
                    StartCoroutine(GreenButtonCoolDown());
                }
            }
        }
    }
    private void BuffChange()
    {
        string buffAtk = "+10% de Ataque";
        string buffHeal = "+20 de Cura";
        string buffEmpathy = "+15% de Empatia";
        if (dadosJimmy.activeSelf == true)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == buffJimmySelect)
            {
                if (!canChangeScreen && Input.GetButtonDown("HORIZONTAL0") && jimmyBuff.text == "")
                {
                    if (x0 > 0)
                    {
                        if (inventory.attackBuff)
                        {
                            jimmyBuff.text = buffAtk;
                            newBuff = "buffAtk";
                        }
                        else if (inventory.healingBuff)
                        {
                            jimmyBuff.text = buffHeal;
                            newBuff = "buffHeal";
                        }
                        else if (inventory.empathyBuff)
                        {
                            jimmyBuff.text = buffEmpathy;
                            newBuff = "buffEmpathy";
                        }
                        else
                            jimmyBuff.text = "Voce nao tem\nBuffs";
                    }
                    else if (x0 < 0)
                    {
                        if (inventory.empathyBuff)
                        {
                            jimmyBuff.text = buffEmpathy;
                            newBuff = "buffEmpathy";
                        }
                        else if (inventory.healingBuff)
                        {
                            jimmyBuff.text = buffHeal;
                            newBuff = "buffHeal";
                        }
                        else if (inventory.attackBuff)
                        {
                            jimmyBuff.text = buffAtk;
                            newBuff = "buffAtk";
                        }
                        else
                            jimmyBuff.text = "Voce nao tem\nBuffs";
                    }
                }

                else if (!canChangeScreen && ((Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && jimmyBuff.text == buffAtk) || (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && jimmyBuff.text == buffEmpathy)))
                {
                    if (inventory.healingBuff)
                    {
                        jimmyBuff.text = buffHeal;
                        newBuff = "buffHeal";
                    }
                    else if (jimmyBuff.text == buffAtk)
                    {
                        if (inventory.empathyBuff)
                        {
                            jimmyBuff.text = buffEmpathy;
                            newBuff = "buffEmpathy";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                    else if (jimmyBuff.text == buffEmpathy)
                    {
                        if (inventory.attackBuff)
                        {
                            jimmyBuff.text = buffAtk;
                            newBuff = "buffAtk";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && !canChangeScreen && jimmyBuff.text == buffHeal)
                {

                    if (inventory.attackBuff)
                    {
                        jimmyBuff.text = buffAtk;
                        newBuff = "buffAtk";
                    }
                    else { }//n fzr nd pq ele n tem mais cadernos

                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && !canChangeScreen && jimmyBuff.text == buffHeal)
                {

                    if (inventory.empathyBuff)
                    {
                        jimmyBuff.text = buffEmpathy;
                        newBuff = "buffEmpathy";
                    }
                    else { }//n fzr nd pq ele n tem mais tesouras

                }
                if (Input.GetButtonDown("VERDE0") && canUseGreen)
                {

                    inventory.ChangeBuffs(newBuff, "player1");
                    dadosJimmy.SetActive(false);
                    pencilJimmy.SetActive(true);
                    jimmySelect.Select();
                    canChangeScreen = true;
                    canUseGreen = false;
                    StartCoroutine(GreenButtonCoolDown());
                }
            }
        }
        if (dadosAlice.activeSelf == true)
        {

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == buffAliceSelect)
            {
                if (!canChangeScreen && Input.GetButtonDown("HORIZONTAL0") && aliceBuff.text == "")
                {
                    if (x0 > 0)
                    {
                        if (inventory.attackBuff)
                        {
                            aliceBuff.text = buffAtk;
                            newBuff = "buffAtk";
                        }
                        else if (inventory.healingBuff)
                        {
                            aliceBuff.text = buffHeal;
                            newBuff = "buffHeal";
                        }
                        else if (inventory.empathyBuff)
                        {
                            aliceBuff.text = buffEmpathy;
                            newBuff = "buffEmpathy";
                        }
                        else
                            aliceBuff.text = "Voce nao tem\nBuffs";
                    }
                    else if (x0 < 0)
                    {
                        if (inventory.empathyBuff)
                        {
                            aliceBuff.text = buffEmpathy;
                            newBuff = "buffEmpathy";
                        }
                        else if (inventory.healingBuff)
                        {
                            aliceBuff.text = buffHeal;
                            newBuff = "buffHeal";
                        }
                        else if (inventory.attackBuff)
                        {
                            aliceBuff.text = buffAtk;
                            newBuff = "buffAtk";
                        }
                        else
                            aliceBuff.text = "Voce nao tem\nBuffs";
                    }
                }

                else if (!canChangeScreen && ((Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && aliceBuff.text == buffAtk) || (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && aliceBuff.text == buffEmpathy)))
                {
                    if (inventory.healingBuff)
                    {
                        aliceBuff.text = buffHeal;
                        newBuff = buffHeal;
                    }
                    else if (aliceBuff.text == buffAtk)
                    {
                        if (inventory.empathyBuff)
                        {
                            aliceBuff.text = buffEmpathy;
                            newBuff = "buffEmpathy";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                    else if (aliceBuff.text == buffEmpathy)
                    {
                        if (inventory.attackBuff)
                        {
                            aliceBuff.text = buffAtk;
                            newBuff = "buffAtk";
                        }
                        else { }//n fzr nd pq ele n tem mais itens
                    }
                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 < 0 && !canChangeScreen && aliceBuff.text == buffHeal)
                {

                    if (inventory.attackBuff)
                    {
                        aliceBuff.text = buffAtk;
                        newBuff = "buffAtk";
                    }
                    else { }//n fzr nd pq ele n tem mais cadernos

                }

                else if (Input.GetButtonDown("HORIZONTAL0") && x0 > 0 && !canChangeScreen && aliceBuff.text == buffHeal)
                {

                    if (inventory.empathyBuff)
                    {
                        aliceBuff.text = buffEmpathy;
                        newBuff = "buffEmpathy";
                    }
                    else { }//n fzr nd pq ele n tem mais tesouras

                }
                if (Input.GetButtonDown("VERDE0") && canUseGreen)
                {

                    inventory.ChangeBuffs(newBuff, "player2");
                    dadosAlice.SetActive(false);
                    pencilAlice.SetActive(true);
                    aliceSelect.Select();
                    canChangeScreen = true;
                    canUseGreen = false;
                    StartCoroutine(GreenButtonCoolDown());
                }
            }
        }
    }
    private void SetHealItemQuantities()
    {

        item1Txt.text = "Curativo - " + inventory.curativoQuant + "     +10 hp";
        item2Txt.text = "Suco - " + inventory.sucoQuant + "           +15 hp";
        item3Txt.text = "Fruta - " + inventory.frutaQuant + "         +20 hp";

    }
    public void JimmyAttributes() {
        if (inventory.currentAttackItem1 != "")
        {
            if (inventory.currentAttackItem1 == "caderno")
                itemJimmyAtaque.text = "Caderno\n+2 Ataque";
            else if (inventory.currentAttackItem1 == "lapis")
                itemJimmyAtaque.text = "Lapis\n+3 Ataque";
            else if (inventory.currentAttackItem1 == "tesoura")
                itemJimmyAtaque.text = "Tesoura\n+6 Ataque";
        }
        else
        {
            itemJimmyAtaque.text = "";
        }

        if (inventory.currentDefenseItem1 != "")
        {
            if (inventory.currentDefenseItem1 == "broche")
                itemJimmyDefesa.text = "Broche\n+3 Defesa";
            else if (inventory.currentDefenseItem1 == "oculos")
                itemJimmyDefesa.text = "Oculos\n+5 Defesa";
            else if (inventory.currentDefenseItem1 == "jaqueta")
                itemJimmyDefesa.text = "Jaqueta\n+9 Defesa";
        }
        else
        {
            itemJimmyDefesa.text = "";
        }

        if (inventory.currentEquippedBuff1 != "")
        {
            if (inventory.currentEquippedBuff1 == "buffAtk")
                jimmyBuff.text = "+10% de Ataque";
            else if (inventory.currentEquippedBuff1 == "buffHeal")
                jimmyBuff.text = "+20 de Cura";
            else if (inventory.currentEquippedBuff1 == "BuffEmpathy")
                jimmyBuff.text = "+15% de Empatia";
        }
        else
        {
            jimmyBuff.text = "";
        }
        dadosJimmy.SetActive(true);
        pencilJimmy.SetActive(false);
        defesaJimmyPencil.SetActive(true);
        defesaJimmySelect.Select();
        canChangeScreen = false;
        canUseGreen = false;
        StartCoroutine(GreenButtonCoolDown());
    }
    public void AliceAttributes() {
        if (inventory.currentAttackItem2 != "")
        {
            if (inventory.currentAttackItem2 == "caderno")
                itemAliceAtaque.text = "Caderno\n+2 Ataque";
            else if (inventory.currentAttackItem2 == "lapis")
                itemAliceAtaque.text = "Lapis\n+3 Ataque";
            else if (inventory.currentAttackItem2 == "tesoura")
                itemAliceAtaque.text = "Tesoura\n+6 Ataque";
        }
        else
        {
            itemAliceAtaque.text = "";
        }

        if (inventory.currentDefenseItem1 != "")
        {
            if (inventory.currentDefenseItem2 == "broche")
                itemAliceDefesa.text = "Broche\n+3 Defesa";
            else if (inventory.currentDefenseItem2 == "oculos")
                itemAliceDefesa.text = "Oculos\n+5 Defesa";
            else if (inventory.currentDefenseItem2 == "jaqueta")
                itemAliceDefesa.text = "Jaqueta\n+9 Defesa";
        }
        else
        {
            itemAliceDefesa.text = "";
        }

        if (inventory.currentEquippedBuff2 != "")
        {
            if (inventory.currentEquippedBuff2 == "buffAtk")
                aliceBuff.text = "+10% de Ataque";
            else if (inventory.currentEquippedBuff2 == "buffHeal")
                aliceBuff.text = "+20 de Cura";
            else if (inventory.currentEquippedBuff2 == "BuffEmpathy")
                aliceBuff.text = "+15% de Empatia";
        }
        else
        {
            aliceBuff.text = "";
        }
        pencilAlice.SetActive(false);
        dadosAlice.SetActive(true);
        defesaAlicePencil.SetActive(true);
        defesaAliceSelect.Select();
        canChangeScreen = false;
        canUseGreen = false;
        StartCoroutine(GreenButtonCoolDown());
    }
    public void ReturnButton() {
        if (Input.GetButtonDown("BRANCO0"))
        {
            if (!dadosItens.activeSelf && !dadosAlice.activeSelf && !dadosJimmy.activeSelf)
            {
                canChangeScreen = true;
                this.gameObject.SetActive(false);
            }
            else if (dadosAlice.activeSelf)
            {

                dadosAlice.SetActive(false);
                pencilAlice.SetActive(true);
                aliceSelect.Select();
                canChangeScreen = true;

            }

            else if (dadosJimmy.activeSelf)
            {

                dadosJimmy.SetActive(false);
                pencilJimmy.SetActive(true);
                jimmySelect.Select();
                canChangeScreen = true;

            }

            else if (dadosItens.activeSelf)
            {
                dadosItens.SetActive(false);
                pencilItens.SetActive(true);
                itensSelect.Select();
                canChangeScreen = true;

            }
        }

    }
    public void UseHealtem(string item)
    {
            if (item == "curativo" && inventory.curativoQuant > 0)
                inventory.HealPlayer(item);
            else if (item == "suco" && inventory.sucoQuant > 0)
                inventory.HealPlayer(item);
            else if (item == "fruta" && inventory.frutaQuant > 0)
                inventory.HealPlayer(item);        
    }
    public void UpdatePlayerHealth() {
        playerHealth.value = inventory.hp;
    }
    private IEnumerator GreenButtonCoolDown()
    {
        yield return new WaitForSeconds(0.25f);
        canUseGreen = true;
    }
}