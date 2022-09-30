using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Basic_spawner : MonoBehaviour
{
    public Image background;
    public Button backgroundButton { get; }
    public abstract List<GameObject> GetOrder();
    public abstract void setBackground();
    public Sprite sprite;
}
