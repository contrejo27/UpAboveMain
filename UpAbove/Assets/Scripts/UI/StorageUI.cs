﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour
{
    Transform originalPos = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void HoldPosition()
    {
        originalPos = transform;
        transform.parent = null;
    }

    public void ReleasePosition()
    {
        originalPos = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (originalPos)
        {
            transform.position = originalPos.position;
            transform.rotation = originalPos.rotation;
        }
    }
}