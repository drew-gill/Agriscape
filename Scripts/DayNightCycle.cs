using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DayNightCycle : MonoBehaviour
{
    public Color dayBackground;
    public Color duskBackground;
    public Color nightBackground;
    public float dayLength;
    public float duskLength;
    public float nightLength;


    private Color currentBackground;
    private float timeInCycle;

    //Use Time.time instead (time since game has started in seconds)
    //private float time;

    // Start is called before the first frame update
    void Start()
    {
        SwitchTime(dayBackground);
        //Time.time starts at 0.
    }

    // Update is called once per frame
    void Update()
    {
        timeInCycle = (Time.time % (dayLength + duskLength + nightLength));


        if (timeInCycle < dayLength)
        {
            SwitchTime(dayBackground);
        } else if (timeInCycle < (dayLength + duskLength) && timeInCycle >= dayLength)
        {
            SwitchTime(duskBackground);
        } else if(timeInCycle < (dayLength + duskLength + nightLength) && timeInCycle >= (dayLength + duskLength))
        {
            SwitchTime(nightBackground);
        }
    }

    private void SwitchTime(Color newBackground)
    {
        this.transform.GetComponent<Tilemap>().color = newBackground;
        
    }

}
