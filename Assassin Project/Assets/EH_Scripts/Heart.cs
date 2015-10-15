using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Heart : MonoBehaviour {
    public Sprite full;
    public Sprite three_fourths;
    public Sprite half;
    public Sprite one_fourth;
    public Sprite empty;
    Sprite[] heartArray = new Sprite[5];
    Image image;
    

    void Awake()
    {
        heartArray[0] = empty;
        heartArray[1] = one_fourth;
        heartArray[2] = half;
        heartArray[3] = three_fourths;
        heartArray[4] = full;
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.sprite = heartArray[Player.health];   
    }
}
