using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facecamera : MonoBehaviour
{
    Camera m_camera;
    // Start is called before the first frame update
    void Awake()
    {
        m_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetvector = this.transform.position - m_camera.transform.position;
        transform.rotation = Quaternion.LookRotation(targetvector, m_camera.transform.rotation * Vector3.up);
    }
}
