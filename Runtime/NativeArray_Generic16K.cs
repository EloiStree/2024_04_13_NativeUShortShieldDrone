using Unity.Collections;

namespace DroneIMMO {

    public class NativeGeneric16KUtility {

        public static int ARRAY_MAX_SIZE = 128 * 128;
    }
    public class NativeArray_Generic16K<T>   where T: struct 
    {
        public static int ARRAY_MAX_SIZE = 128 * 128;
        public NativeArray<T> m_indexToValue;

        public void Create()
        {
            m_indexToValue = new NativeArray<T>(ARRAY_MAX_SIZE, Allocator.Persistent);
        }

        public void Get(int index, out T valueInArray)
        {
            valueInArray = m_indexToValue[index];
        }
        public void Set(int index, T valueInArray)
        {
            m_indexToValue[index] = valueInArray;
        }
        public void Destroy()
        {
            if(m_indexToValue!=null)
                m_indexToValue.Dispose();
        }
    }
}