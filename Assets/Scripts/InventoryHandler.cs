using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Inventory")]
public class InventoryHandler : ScriptableObject
{
    [Header("Quantidade Itens")]
    public int curativoQuant;
    public int sucoQuant;
    public int frutaQuant;
    public int brocheQuant;
    public int oculosQuant;
    public int jaquetaQuant;
    public int cadernoQuant;
    public int lapisQuant;
    public int tesouraQuant;

    [Header("Itens Equipados Player 1")]
    public string currentAttackItem1;
    public string currentDefenseItem1;
    public string currentEquippedBuff1;

    [Header("Stats Player 1")]
    public float hp1 = 1;

    [Header("Stats Player 2")]
    public float hp2 = 1;

    [Header("General")]
    public Transform spawnpoint;

    [Header("Itens Equipados Player 2")]
    public string currentAttackItem2;
    public string currentDefenseItem2;
    public string currentEquippedBuff2;

    public void ChangeItem(string newItem, string qualPlayer) {
        string[] itensDano = {"caderno", "lapis", "tesoura"};
        string[] itensDefesa = { "broche", "oculos", "jaqueta" };
        //string[] itensBuff = { "caderno", "lapis", "tesoura" }; preciso pensa nos buff e fazer a troca tmb
        if (qualPlayer == "player1")
        {
            for (int i = 0; i < itensDano.Length; i++)
            {
                if (newItem == itensDano[i])
                {
                    if (currentAttackItem1 != null)
                    {
                        if (currentAttackItem1 == "caderno")
                            cadernoQuant++;
                        else if (currentAttackItem1 == "lapis")
                            lapisQuant++;
                        else if (currentAttackItem1 == "tesoura")
                            tesouraQuant++;
                    }
                    if (newItem == "caderno")
                        cadernoQuant--;
                    else if (newItem == "lapis")
                        lapisQuant--;
                    else if (newItem == "tesoura")
                        tesouraQuant--;
                    currentAttackItem1 = newItem;
                }
            }
            for (int i = 0; i < itensDefesa.Length; i++)
            {
                if (newItem == itensDefesa[i])
                {
                    if (currentDefenseItem1 != null)
                    {
                        if (currentDefenseItem1 == "broche")
                            brocheQuant++;
                        else if (currentDefenseItem1 == "oculos")
                            oculosQuant++;
                        else if (currentDefenseItem1 == "jaqueta")
                            jaquetaQuant++;
                    }
                    if (newItem == "broche")
                        brocheQuant--;
                    else if (newItem == "oculos")
                        oculosQuant--;
                    else if (newItem == "jaqueta")
                        jaquetaQuant--;
                    currentDefenseItem1 = newItem;
                }
            }
        }
        else if (qualPlayer == "player2")
        {
            for (int i = 0; i < itensDano.Length; i++)
            {
                if (newItem == itensDano[i])
                {
                    if (currentAttackItem2 != null)
                    {
                        if (currentAttackItem2 == "caderno")
                            cadernoQuant++;
                        else if (currentAttackItem2 == "lapis")
                            lapisQuant++;
                        else if (currentAttackItem2 == "tesoura")
                            tesouraQuant++;
                    }
                    if (newItem == "caderno")
                        cadernoQuant--;
                    else if (newItem == "lapis")
                        lapisQuant--;
                    else if (newItem == "tesoura")
                        tesouraQuant--;
                    currentAttackItem2 = newItem;
                }
            }
            for (int i = 0; i < itensDefesa.Length; i++)
            {
                if (newItem == itensDefesa[i])
                {
                    if (currentDefenseItem2 != null)
                    {
                        if (currentDefenseItem2 == "broche")
                            brocheQuant++;
                        else if (currentDefenseItem2 == "oculos")
                            oculosQuant++;
                        else if (currentDefenseItem2 == "jaqueta")
                            jaquetaQuant++;
                    }
                    if (newItem == "broche")
                        brocheQuant--;
                    else if (newItem == "oculos")
                        oculosQuant--;
                    else if (newItem == "jaqueta")
                        jaquetaQuant--;
                    currentDefenseItem2 = newItem;
                }
            }
        }
    }
    public float ReturnDamageValue(string qualPlayer) {
        if (qualPlayer == "player1")
        {
            if (currentAttackItem1 != null)
            {
                if (currentAttackItem1 == "caderno")
                    return 2f;
                else if (currentAttackItem1 == "lapis")
                    return 3f;
                else if (currentAttackItem1 == "tesoura")
                    return 6f;
            }
        }
        else if (qualPlayer == "player2")
        {
            if (currentAttackItem2 != null)
            {
                if (currentAttackItem2 == "caderno")
                    return 2f;
                else if (currentAttackItem2 == "lapis")
                    return 3f;
                else if (currentAttackItem2 == "tesoura")
                    return 6f;
            }
        }
        return 0f;
    }
    public float ReturnDefenseValue(string qualPlayer)
    {
        if (qualPlayer == "player1")
        {
            if (currentDefenseItem1 != null)
            {
                if (currentDefenseItem1 == "broche")
                    return 3f;
                else if (currentDefenseItem1 == "oculos")
                    return 5f;
                else if (currentDefenseItem1 == "jaqueta")
                    return 9f;
            }
        }
        else if (qualPlayer == "player2")
        {
            if (currentDefenseItem2 != null)
            {
                if (currentDefenseItem2 == "broche")
                    return 3f;
                else if (currentDefenseItem2 == "oculos")
                    return 5f;
                else if (currentDefenseItem2 == "jaqueta")
                    return 9f;
            }
        }
        return 0f;
    }
    public string ReturnBuffName()
    {
        /*if (qualPlayer == "player1")
        {
            if (currentDefenseItem1 != null)
            {
                if (currentDefenseItem1 == "broche")
                    return 3f;
                else if (currentDefenseItem1 == "oculos")
                    return 5f;
                else if (currentDefenseItem1 == "jaqueta")
                    return 9f;
            }
        }
        else if (qualPlayer == "player2")
        {
            if (currentDefenseItem2 != null)
            {
                if (currentDefenseItem2 == "broche")
                    return 3f;
                else if (currentDefenseItem2 == "oculos")
                    return 5f;
                else if (currentDefenseItem2 == "jaqueta")
                    return 9f;
            }
        }*/
        //fzr dps q pensa nos buff
        return "";
    }
    public void GotItem(string name) {
        if (name == "curativo")
            curativoQuant++;

        else if (name == "suco")
            sucoQuant++;

        else if (name == "fruta")
            frutaQuant++;

        else if (name == "caderno")
            cadernoQuant++;

        else if (name == "lapis")
            lapisQuant++;

        else if (name == "tesoura")
            tesouraQuant++;

        else if (name == "broche")
            brocheQuant++;

        else if (name == "oculos")
            oculosQuant++;

        else if (name == "jaqueta")
            jaquetaQuant++;
    }
    public void HealPlayer(string item, string qualPlayer) {
        if (item == "curativo") {
            curativoQuant--;
            if (qualPlayer == "player1")
                hp1 += 0.1f;
            else if (qualPlayer == "player2")
                hp2 += 0.1f;
        }
        else if (item == "suco")
        {
            sucoQuant--;
            if (qualPlayer == "player1")
                hp1 += 0.15f;
            else if (qualPlayer == "player2")
                hp2 += 0.15f;
        }
        else if (item == "fruta")
        {
            frutaQuant--;
            if (qualPlayer == "player1")
                hp1 += 0.2f;
            else if (qualPlayer == "player2")
                hp2 += 0.2f;
        }
    }
    public void SetSpawnI(Transform newSpawn) {
        spawnpoint.position = newSpawn.position;
    }
}
