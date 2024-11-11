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

    [Header("Buffs")]
    public bool hasAnyBuffs = false;
    public bool attackBuff = false;
    public bool healingBuff = false;
    public bool empathyBuff = false;

    [Header("Itens Equipados Player 1")]
    public string currentAttackItem1;
    public string currentDefenseItem1;
    public string currentEquippedBuff1;

    [Header("Stats Players")]
    public float hp = 1;


    [Header("General")]
    public Transform spawnpoint;

    [Header("Itens Equipados Player 2")]
    public string currentAttackItem2;
    public string currentDefenseItem2;
    public string currentEquippedBuff2;

    [Header("Inimigos Recrutados")]
    public RecruitedEnemiesHadler enemies;

    public void ChangeItem(string newItem, string qualPlayer) {
        string[] itensDano = { "caderno", "lapis", "tesoura" };
        string[] itensDefesa = { "broche", "oculos", "jaqueta" };
        if (qualPlayer == "player1")
        {
            for (int i = 0; i < itensDano.Length; i++)
            {
                Debug.Log(newItem);
                if (newItem == itensDano[i])
                {
                    if (currentAttackItem1 != "")
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
                    if (currentDefenseItem1 != "")
                    {
                        if (currentDefenseItem1 == "broche")
                        {
                            brocheQuant++;
                            Debug.Log("certo");
                        }
                        else if (currentDefenseItem1 == "oculos")
                            oculosQuant++;
                        else if (currentDefenseItem1 == "jaqueta")
                            jaquetaQuant++;
                    }
                    if (newItem == "broche")
                        brocheQuant--;
                    else if (newItem == "oculos")
                    {
                        Debug.Log("certo tmb");
                        oculosQuant--;
                    }
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
                    if (currentAttackItem2 != "")
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
                    if (currentDefenseItem2 != "")
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
    public void HealPlayer(string item) {
        if (item == "curativo") {
            curativoQuant--;
            hp += 0.1f;
        }
        else if (item == "suco")
        {
            sucoQuant--;
            hp += 0.15f;
        }
        else if (item == "fruta")
        {
            frutaQuant--;
            hp += 0.2f;

        }
    }
    public void SetSpawnI(Transform newSpawn) {
        spawnpoint.position = newSpawn.position;
    }
    public void GotBuff()
    {
        if (enemies.normalBullies)
        {
            attackBuff = true;
        }
        else if (enemies.boss1)
        {
            empathyBuff = true;
        }
        else if (enemies.boss2) 
        {
            healingBuff = true;
        }
    }
    public void ChangeBuffs(string newBuff, string qualPlayer)
    {
        if (qualPlayer == "player1")
        {
            Debug.Log(newBuff);
            if (currentEquippedBuff1 != "")
            {
                if (currentEquippedBuff1 == "buffAtk" && currentEquippedBuff1 != newBuff)
                    attackBuff = true;
                else if (currentEquippedBuff1 == "buffHeal" && currentEquippedBuff1 != newBuff)
                    healingBuff = true;
                else if (currentEquippedBuff1 == "buffEmpathy" && currentEquippedBuff1 != newBuff)
                    empathyBuff = true;
            }
            if (newBuff == "buffAtk" && currentEquippedBuff1 != newBuff)
                attackBuff = false;
            else if (newBuff == "buffHeal" && currentEquippedBuff1 != newBuff)
                healingBuff = false;
            else if (newBuff == "buffEmpathy" && currentEquippedBuff1 != newBuff)
                empathyBuff = false;
            currentEquippedBuff1 = newBuff;
        }

        if (qualPlayer == "player2")
        {
            if (currentAttackItem1 != "")
            {
                if (currentEquippedBuff2 == "buffAtk" && currentEquippedBuff2 != newBuff)
                    attackBuff = true;
                else if (currentEquippedBuff2 == "buffHeal" && currentEquippedBuff2 != newBuff)
                    healingBuff = true;
                else if (currentEquippedBuff2 == "buffEmpathy" && currentEquippedBuff2 != newBuff)
                    empathyBuff = true;
            }
            if (newBuff == "buffAtk" && currentEquippedBuff2 != newBuff)
                attackBuff = false;
            else if (newBuff == "buffHeal" && currentEquippedBuff2 != newBuff)
                healingBuff = false;
            else if (newBuff == "buffEmpathy" && currentEquippedBuff2 != newBuff)
                empathyBuff = false;
            currentEquippedBuff2 = newBuff;
        }
    }
}
