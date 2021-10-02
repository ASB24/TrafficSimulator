using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Orientation { Up, Down, Left, Right };

public class Vehicle : MonoBehaviour
{
    SpriteRenderer sr;
    public float speed;
    public bool hitGas = true;
    public Orientation orientation;
    public System.Random random = new System.Random();
    public GameObject frontLight;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        speed = 3;
        this.orientation = setOrientation(randOrientation());
        frontLight = setStopLight();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, frontLight.transform.position);
        if (frontLight.GetComponent<stopLight>().isGreen || distance < 2.3) speed = 3;
        else stop();

        transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }

    public void stop()
    {
        speed = 0;
    }

    public Orientation setOrientation(Orientation orientation)
    {
        if (orientation == Orientation.Up)
        {
            sr.transform.Rotate(new Vector3(0, 0, 0));
            sr.transform.position = new Vector2(0.61f, -6.10f);
        }
        else if (orientation == Orientation.Down)
        {
            sr.transform.Rotate(new Vector3(0, 0, 180));
            sr.transform.position = new Vector2(-0.54f, 6.19f);
        }
        else if (orientation == Orientation.Left)
        {
            sr.transform.Rotate(new Vector3(0, 0, 90));
            sr.transform.position = new Vector2(12.0f, 0.51f);
        }
        else //Right
        {
            sr.transform.Rotate(new Vector3(0, 0, -90));
            sr.transform.position = new Vector2(-11.92f, -0.53f);
        }
        return orientation;
    }
    public GameObject setStopLight()
    {
        if (this.orientation == Orientation.Up)
        {
            return GameObject.Find("stoplight_up");
        }
        else if (this.orientation == Orientation.Down)
        {
            return GameObject.Find("stoplight_down");
        }
        else if (this.orientation == Orientation.Left)
        {
            return GameObject.Find("stoplight_left");
        }
        else //Right
        {
            return GameObject.Find("stoplight_right");
        }
    }

    public Orientation randOrientation()
    {
        Array values = Enum.GetValues(typeof(Orientation));
        object value = values.GetValue(random.Next(values.Length));
        if ( (Orientation)value == Orientation.Up ) return Orientation.Up;
        else if ((Orientation)value == Orientation.Down) return Orientation.Down;
        else if ((Orientation)value == Orientation.Left) return Orientation.Left;
        else if ((Orientation)value == Orientation.Right) return Orientation.Right;
        return Orientation.Left;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Destroyer") Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vehicle")
        {
            stop();
            if(orientation == Orientation.Up) transform.Translate(new Vector2(0, -0.05f));
            else if(orientation == Orientation.Down) transform.Translate(new Vector2(0, 0.05f));
            else if(orientation == Orientation.Left) transform.Translate(new Vector2(-0.05f, 0));
            else if(orientation == Orientation.Right) transform.Translate(new Vector2(0.05f, 0));
        }
    }

}
