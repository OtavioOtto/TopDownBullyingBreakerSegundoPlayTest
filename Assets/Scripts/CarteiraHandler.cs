using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteiraHandler : MonoBehaviour
{
    private readonly string[] itens = {"broche","caderno","curativo","suco","lapis","oculos","tesoura","jaqueta","fruta"};
    public string item;
    void Start()
    {
        int chance = Random.Range(0,101);
        if (chance <= 60)
        {
            int position = Random.Range(0, 3);
            item = itens[position];
            transform.GetChild(0).name = item;
        }

        else if (chance > 60 && chance < 90)
        {
            int position = Random.Range(3, 6);
            item = itens[position];
            transform.GetChild(0).name = item;
        }

        else {
            int position = Random.Range(6, 9);
            item = itens[position];
            transform.GetChild(0).name = item;
        }
    }


}
