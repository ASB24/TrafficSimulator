using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopLight : MonoBehaviour
{
    public Orientation orientation;
    public Sprite[] SpriteArray; //0: Red, 1: Yellow, 2: Green
    SpriteRenderer sr;
    public bool isGreen = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        switch (gameObject.name)
        {
            case "stoplight_up":
                orientation = Orientation.Up;
                break;
            case "stoplight_down":
                orientation = Orientation.Down;
                break;
            case "stoplight_left":
                orientation = Orientation.Left;
                break;
            case "stoplight_right":
                orientation = Orientation.Up;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRed()
    {
        this.sr.sprite = SpriteArray[0];
        isGreen = false;
    }
    public void setYellow()
    {
        this.sr.sprite = SpriteArray[1];
    }
    public void setGreen()
    {
        this.sr.sprite = SpriteArray[2];
        isGreen = true;
    }
}
