using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PressAndHoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pointerDown;
    public UnityEvent onLongClick;
    public BoosterControl booster;

    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
        booster.Boost(gameObject.name);
        print("boosting " + gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }        
    // Update is called once per frame
    void Update()
    {

    }

    private void Reset()
    {
        booster.Boost("none");
        print("boosting none" );

    }
}
