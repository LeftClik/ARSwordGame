/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Use this for initialization
    void Start()
    {
        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }

        if (this.gameObject.name == "sword")
        {
            BoxCollider bc = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
            bc.size = new Vector3(.5f, .5f, .5f);
            bc.isTrigger = true;
            Rigidbody rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            SwordControl sc = gameObject.AddComponent(typeof(SwordControl)) as SwordControl;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}