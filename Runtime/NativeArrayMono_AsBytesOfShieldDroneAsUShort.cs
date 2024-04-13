using UnityEngine;

public class NativeArrayMono_AsBytesOfShieldDroneAsUShort: MonoBehaviour
{
    public NativeArray_AsBytesOfShieldDroneAsUShort m_droneAsNativeBytes= new NativeArray_AsBytesOfShieldDroneAsUShort();

    public void Awake()
    {
        m_droneAsNativeBytes.Create();
    }
    public void OnDestroy()
    {
        m_droneAsNativeBytes.Destroy();
    }
}
