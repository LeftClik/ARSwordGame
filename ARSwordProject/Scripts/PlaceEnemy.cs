using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceEnemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates hoop prefab on a plane at the touch location.")]
    GameObject m_EnemyPrefab;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedEnemy
    {
        get { return m_EnemyPrefab; }
        set { m_EnemyPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedEnemy { get; private set; }


    [SerializeField]
    [Tooltip("Instantiates ball prefab on a plane at the touch location.")]
    GameObject m_SwordPrefab;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedSword
    {
        get { return m_SwordPrefab; }
        set { m_SwordPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedSword { get; private set; }

    /// <summary>
    /// Invoked whenever an object is placed in on a plane.
    /// </summary>
    public static event Action onPlacedObject;

    private bool isPlaced = false;

    ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (isPlaced)
            return;


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;

                    spawnedEnemy = Instantiate(m_EnemyPrefab, hitPose.position, Quaternion.AngleAxis(180, Vector3.up));
                    spawnedEnemy.transform.parent = transform.parent;

                    isPlaced = true;

                    spawnedSword = Instantiate(m_SwordPrefab);
                    spawnedSword.transform.parent = m_RaycastManager.transform.Find("AR Camera").gameObject.transform;
                    if (onPlacedObject != null)
                    {
                        onPlacedObject();
                    }
                }
            }
        }
    }
}
