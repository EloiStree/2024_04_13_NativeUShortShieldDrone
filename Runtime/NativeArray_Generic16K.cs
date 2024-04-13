using Unity.Collections;

public class NativeArray_Generic16K<T>   where T: struct 
{
    public NativeArray<T> m_indexToIndexInteger;

    public void Create()
    {
        m_indexToIndexInteger = new NativeArray<T>(128 * 128, Allocator.Persistent);
    }

    public void Get(int index, out T shieldDroneAsUShort)
    {
        shieldDroneAsUShort = m_indexToIndexInteger[index];
    }
    public void Set(int index, T shieldDroneAsUShort)
    {
        m_indexToIndexInteger[index] = shieldDroneAsUShort;
    }
    public void Destroy()
    {
        m_indexToIndexInteger.Dispose();
    }
}