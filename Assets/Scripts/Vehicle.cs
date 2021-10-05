using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Orientation { Up, Down, Left, Right };

public class Vehicle : MonoBehaviour
{
    Rigidbody2D rb;
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
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        this.orientation = setOrientation(randOrientation());
        frontLight = setStopLight();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, frontLight.transform.position);
        if (frontLight.GetComponent<stopLight>().isGreen || isOverBoundary() ) speed = 3;
        else stop();

        rb.MovePosition(transform.position + getOrientationVector());
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

    private Vector3 getOrientationVector()
    {
        if (this.orientation == Orientation.Up) return new Vector3(0, speed * Time.deltaTime, 0);
        else if (this.orientation == Orientation.Down) return new Vector3(0, -speed * Time.deltaTime, 0);
        else if (this.orientation == Orientation.Right) return new Vector3(speed * Time.deltaTime, 0, 0);
        else if (this.orientation == Orientation.Left) return new Vector3(-speed * Time.deltaTime, 0, 0);
        return new Vector3(0,0,0);
    }

    private bool isOverBoundary()
    {
        switch (this.orientation)
        {
            case Orientation.Up:
                if (this.transform.position.y - frontLight.transform.position.y > -3) return true;
                return false;
            case Orientation.Down:
                if (this.transform.position.y - frontLight.transform.position.y < 3) return true;
                return false;
            case Orientation.Right:
                if (this.transform.position.x - frontLight.transform.position.x > -3) return true;
                return false;
            case Orientation.Left:
                if (this.transform.position.x - frontLight.transform.position.x < 3) return true;
                return false;
            default:
                print("hay bobo");
                break;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Destroyer") Destroy(this.gameObject);
        else if(collision.tag == "Vehicle") setOrientation(randOrientation());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Vehicle") setOrientation(randOrientation());
    }

}
