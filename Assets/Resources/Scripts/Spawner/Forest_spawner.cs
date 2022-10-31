using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forest_spawner : Basic_spawner
{

    [SerializeField]
    private List<GameObject> Satyrs;

    [SerializeField]
    private List<GameObject> Centaurus;

    [SerializeField]
    private List<GameObject> Wolves;

    [SerializeField]
    private List<GameObject> Ogres;

    [SerializeField]
    private List<GameObject> Owls;

    [SerializeField]
    private List<GameObject> Ursas;

    [SerializeField]
    private List<GameObject> Trolls;





    public override List<GameObject> GetOrder()
    {
        // Массив всех списков крипов
        List<GameObject>[] All = {Satyrs, Centaurus, Wolves, Ogres, Owls, Ursas, Trolls};
        // Рандомный спавн крипов
        int index = Random.Range(0, All.Length);
        // Копия листа крипов из массива
        List<GameObject> order = All[index].GetRange(0, All[index].Count);
        setBackground();
        return order;
    }

    
    public override void setBackground()
    {
        background.sprite = sprite;
    }

}
