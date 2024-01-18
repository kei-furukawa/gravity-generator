using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gravity.Sample
{
    public class GG_SampleObject : MonoBehaviour
    {
        [SerializeField] private float m_speed = 1.0f;

        private Rigidbody m_rigidbody = null;
        private Vector3 m_input = Vector3.zero;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                m_input.z = 1;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                m_input.z = 0;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                m_input.z = -1;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                m_input.z = 0;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                m_input.x = 1;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                m_input.x = 0;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_input.x = -1;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                m_input.x = 0;
            }
        }

        private void FixedUpdate()
        {
            m_rigidbody.AddForce(m_speed * (m_input.z * transform.forward + m_input.x * transform.right), ForceMode.VelocityChange);
        }
    }
}