using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    
    public Transform camTransform;
    [SerializeField] CutterScript cutterscript;
    
    
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    public void Shaker()
    {
        if (cutterscript.getcollisioncontrol()==true)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            
        }
        else
        {
            camTransform.localPosition = originalPos;
        }
    }
}

