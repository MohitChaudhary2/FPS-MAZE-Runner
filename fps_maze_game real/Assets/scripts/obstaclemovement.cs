using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class obstaclemovement : MonoBehaviour
{
    [SerializeField] Vector3 MovementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    float movementfactor;
    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period == 0f) { return; }
        float cycles = Time.time / period;
        const float Tou = Mathf.PI * 2f;
        float rawsinewave = Mathf.Sin(cycles*Tou);//-1 to 1
        movementfactor = rawsinewave / 2f + 0.5f;
        Vector3 displacement = movementfactor * MovementVector;
        transform.position = startingPos + displacement;
        
    }
}
