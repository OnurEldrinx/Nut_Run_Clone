using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float horizontalSpeed;
    public float forwardSpeed;
    public float xBorder;
    public float inputTolerance;
    private float _direction;
    private void Start()
    {
        DOTween.SetTweensCapacity(1250,500);
    }

    private void Update()
    {
        Transform t;
        (t = transform).Translate(Vector3.forward * (forwardSpeed * Time.deltaTime),Space.World);
        
        t.position += new Vector3(_direction * horizontalSpeed * Time.deltaTime, 0, 0);
        
        ClampPosition(t);
        
    }

    public void Stop()
    {

        horizontalSpeed = 0;
        forwardSpeed = 0;

    }
    
    private int GetSign(float number)
    {

        return number < 0 ? -1 : 1;

    }

    private void ClampPosition(Transform t)
    {
        var position = t.position;
        var c = Mathf.Clamp(position.x, -xBorder, xBorder);
        position = new Vector3(c, position.y, position.z);
        t.position = position;
    }
    
    #region INPUT

        public void OnMove(InputValue value)
        {
            var xVal = value.Get<Vector2>().x;
            _direction = xVal == 0 ? 0 : GetSign(xVal);
            /*if (Mathf.Abs(xVal) < inputTolerance) return;
            _direction = xVal;*/

        }

    #endregion

    
    
    
    
}
