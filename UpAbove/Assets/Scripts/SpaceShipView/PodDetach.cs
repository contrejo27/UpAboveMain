using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodDetach : MonoBehaviour
{
    public Light keyLight;
    public Light bounceLight;
    public Material podInside;
    public float fadeRate;
    public CanvasGroup screenEffect;
    public SpaceShipManager shipManager;

    IEnumerator StartFadeOut()
    {
        if (keyLight)
        {
            while (keyLight.intensity <= 15.0f)
            {
                yield return new WaitForSeconds(.01f);
                keyLight.intensity += fadeRate;
                RenderSettings.ambientIntensity += fadeRate*2.0f;
                screenEffect.alpha += fadeRate*.1f;
                bounceLight.intensity += fadeRate * .1f;
            }
            shipManager.LoadPlanet("Mars");
        }
    }

}
