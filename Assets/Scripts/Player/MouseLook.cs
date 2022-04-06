using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    enum  Axis
    {
        
        Y,
        X
    }

    [SerializeField] private float _speedRotation = 100f;

    [SerializeField] private float _minValueVertRotation = -45f;
    [SerializeField] private float _maxValueVertRotation = 45f;

    [SerializeField] private Axis _axis;

    private float _vertRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (_axis)
        {
            case Axis.Y:
                transform.Rotate(new Vector3(
                    0,
                    Input.GetAxis("Mouse X") * _speedRotation * Time.deltaTime,
                    0));
                break;

            case Axis.X:
                _vertRotation -= Input.GetAxis("Mouse Y") * _speedRotation * Time.deltaTime;
                _vertRotation = Mathf.Clamp(_vertRotation, _minValueVertRotation, _maxValueVertRotation);

                transform.localEulerAngles = new Vector3(_vertRotation, 0, 0);

                break;
        }
    }
}
