using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DroneIMMO;
using Unity.Collections;
using Unity.Jobs;

public class DrawLogMono_LineOfShieldDrone16K : MonoBehaviour
{
    public NativeArrayMono_ShieldDrone16K m_drones;
    public NativeArrayMono_DebugDrawLine m_linesDuoPoints;
    public float m_lineDistance = 1.0f;
    private JobHandle m_jobHandle;
    public long m_timePerUpdateJobTick = 1000;
    public long m_timePerUpdateDrawTick = 1000;
    public float m_timePerUpdateJob = 0.0f;
    public float m_timePerUpdateDraw = 0.0f;
    private void Update()
    {
        long time_start = 0;

        time_start = System.DateTime.Now.Ticks;

        DrawPoints();
        m_timePerUpdateJobTick = (System.DateTime.Now.Ticks - time_start);

        time_start = System.DateTime.Now.Ticks;

        for (int i = 0; i < NativeGeneric16KUtility.ARRAY_MAX_SIZE; i++)
        {
            Debug.DrawLine(m_linesDuoPoints.m_nativeArray.m_indexToValue[i].m_pointA,
                m_linesDuoPoints.m_nativeArray.m_indexToValue[i].m_pointB,
                Color.green, Time.deltaTime * 10);
            
        }
        m_timePerUpdateDrawTick = (System.DateTime.Now.Ticks - time_start);
        m_timePerUpdateJob = m_timePerUpdateJobTick * 0.0001f;
        m_timePerUpdateDraw = m_timePerUpdateDrawTick * 0.0001f;
    }

    private void DrawPoints()
    {

        var setRandomPointsJob = new SetDrawingPointsPositionJob
        {
            m_points = m_linesDuoPoints.GetGenericNativeArray().m_indexToValue,
            m_drones = m_drones.GetGenericNativeArray().m_indexToValue,
            m_lineDistance = m_lineDistance
        };

        m_jobHandle = setRandomPointsJob.Schedule(NativeGeneric16KUtility.ARRAY_MAX_SIZE, 64);

        m_jobHandle.Complete();
    }

}

public struct DrawLineDuoPoint {

    public Vector3 m_pointA;
    public Vector3 m_pointB;

    
}


public struct SetDrawingPointsPositionJob : IJobParallelFor
{
    public NativeArray<ShieldDroneAsUShort> m_drones;
    public NativeArray<DrawLineDuoPoint> m_points;
    public float m_lineDistance;
    public void Execute(int index)
    {


        Vector3 pointA = m_points[index].m_pointA;
        Vector3 pointB = m_points[index].m_pointB;
        pointA.x = m_drones[index].m_quadrantRightX*0.0001f;
        pointA.y = m_drones[index].m_quadrantHeightY * 0.0001f;
        pointA.z = m_drones[index].m_quadrantDepthZ * 0.0001f;
        pointB.x = pointA.x;
        pointB.y = pointA.y+m_lineDistance;
        pointB.z = pointA.z;
        m_points[index] = new DrawLineDuoPoint
        {
            m_pointA = pointA,
            m_pointB = pointB
        };
    }
}



