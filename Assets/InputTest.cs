using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    private Gamepad controller = null;
    private Transform m_transform;

    [SerializeField] private Transform objectTransform;

    void Start()
    {
        this.controller = DS4.getConroller();
        // m_transform = this.transform;
        m_transform = objectTransform;
    }

    void Update()
    {
        if (controller == null)
        {
            try
            {
                controller = DS4.getConroller();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        else
        {
            // Press circle button to reset rotation
            if (controller.buttonEast.isPressed)
            {
                m_transform.rotation = Quaternion.identity;
            }
            m_transform.rotation *= DS4.getRotation(4000 * Time.deltaTime);
            m_transform.gameObject.GetComponent<Rigidbody>().AddForce(DS4.getAcceleration(Time.deltaTime), ForceMode.Acceleration); 
        }
    }
}