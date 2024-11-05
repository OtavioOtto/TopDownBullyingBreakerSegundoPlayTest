using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteiraHandler : MonoBehaviour
{
    private readonly string[] itens = {"broche","oculos","jaqueta","caderno","lapis","tesoura","curativo","suco","fruta"};
    public string item;
    void Start()
    {
        int position = Random.Range(0,9);
        item = itens[position];
        transform.GetChild(0).name = item;
    }


}
