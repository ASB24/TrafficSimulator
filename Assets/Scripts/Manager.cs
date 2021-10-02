using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public stopLight stoplight_up;
    public stopLight stoplight_down;
    public stopLight stoplight_left;
    public stopLight stoplight_right;
    public UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(trafficFlow());
        setTimeScale();
    }

    // Update is called once per frame
    void Update()
    {
        setTimeScale();
    }

    IEnumerator trafficFlow()
    {
        while (true)
        {
            upDownGo();
            yield return new WaitForSeconds(5);

            trafficWarning();
            yield return new WaitForSeconds(3);

            leftRightGo();
            yield return new WaitForSeconds(4);

            trafficWarning();
            yield return new WaitForSeconds(3);
        }
    }

    //Estados de semaforos
    void upDownGo()
    {
        stoplight_up.GetComponent<stopLight>().setGreen();
        stoplight_up.GetComponent<stopLight>().isGreen = true;

        stoplight_down.GetComponent<stopLight>().setGreen();
        stoplight_down.GetComponent<stopLight>().isGreen = true;

        stoplight_left.GetComponent<stopLight>().setRed();
        stoplight_left.GetComponent<stopLight>().isGreen = false;

        stoplight_right.GetComponent<stopLight>().setRed();
        stoplight_right.GetComponent<stopLight>().isGreen = false;

    }
    void trafficWarning()
    {
        stoplight_up.GetComponent<stopLight>().setYellow();
        stoplight_down.GetComponent<stopLight>().setYellow();
        stoplight_left.GetComponent<stopLight>().setYellow();
        stoplight_right.GetComponent<stopLight>().setYellow();
    }
    void leftRightGo()
    {
        stoplight_up.GetComponent<stopLight>().setRed();
        stoplight_up.GetComponent<stopLight>().isGreen = false;

        stoplight_down.GetComponent<stopLight>().setRed();
        stoplight_down.GetComponent<stopLight>().isGreen = false;

        stoplight_left.GetComponent<stopLight>().setGreen();
        stoplight_left.GetComponent<stopLight>().isGreen = true;

        stoplight_right.GetComponent<stopLight>().setGreen();
        stoplight_right.GetComponent<stopLight>().isGreen = true;

    }

    public void setTimeScale()
    {
        Time.timeScale = slider.value;
    }

}
