using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PodDetach : MonoBehaviour
{
    public Light keyLight;
    public Light bounceLight;
    public Material podInside;
    public float fadeRate;
    public CanvasGroup screenEffect;

    //fade to complete white and then switch scenes
    IEnumerator StartFadeOut()
    {
        if (keyLight)
        {
            while (keyLight.intensity <= 11.0f)
            {
                yield return new WaitForSeconds(.01f);
                keyLight.intensity += fadeRate;
                RenderSettings.ambientIntensity += fadeRate*2.0f;
                RenderSettings.fogDensity += fadeRate *.0005f;
                screenEffect.alpha += fadeRate*.1f;
                bounceLight.intensity += fadeRate * .1f;
            }
            GameManager.Instance.LoadPlanet("Mars");
        }
    }

}
