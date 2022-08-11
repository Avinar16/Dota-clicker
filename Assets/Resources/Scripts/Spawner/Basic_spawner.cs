using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Basic_spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract List<GameObject> GetOrder();
}
