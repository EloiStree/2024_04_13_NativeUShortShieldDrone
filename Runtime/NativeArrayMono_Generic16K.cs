using UnityEngine;

public class NativeArrayMono_Generic16K<T>:MonoBehaviour where T : struct
{
    public T m_sample;
    public NativeArray_Generic16K<T> m_nativeArray = new NativeArray_Generic16K<T>();

    public void Awake()
    {
        m_nativeArray.Create();
    }

    public void Get(int index, out T shieldDroneAsUShort)
    {
        m_nativeArray.Get(index, out shieldDroneAsUShort);
    }
    public void Set(int index, T shieldDroneAsUShort)
    {
        Set(index, shieldDroneAsUShort);
    }
    public void OnDestroy()
    {
        m_nativeArray.Destroy();
    }
}
