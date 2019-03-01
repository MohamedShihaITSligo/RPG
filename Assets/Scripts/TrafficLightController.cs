using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TrafficLightState
{
    Red,Green
}
public class TrafficLightController : MonoBehaviour
{
    TrafficLightState state;
    public float lightSwitchTime = 5f;
    float elapsedTime = 0;
    SpriteRenderer LightConeSprite;
    // Use this for initialization
    void Start()
    {
        LightConeSprite = GetComponent<SpriteRenderer>();
        SetState(TrafficLightState.Red);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (elapsedTime < Time.time)
        {
            if(LightConeSprite.color == Color.red)
            SetState(TrafficLightState.Green);
            else SetState(TrafficLightState.Red);
            elapsedTime = Time.time+ lightSwitchTime;
        }
    }
    public void SetState(TrafficLightState newState)
    {
        if(newState == TrafficLightState.Green)
        LightConeSprite.color = Color.green;
        else LightConeSprite.color = Color.red;
    }
    public Color GetTrafgicLightState()
    {
        if (LightConeSprite.color == Color.red) return Color.red;
        else return Color.green;
    }
}