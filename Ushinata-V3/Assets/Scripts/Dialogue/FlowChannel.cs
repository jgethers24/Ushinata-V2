using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flow", menuName = "Flow/Flow Channel")]
public class FlowChannel : ScriptableObject
{
    public delegate void FlowStateCallback(FlowState state);
    public FlowStateCallback OnFlowStateRequested;
    public FlowStateCallback OnFlowStateChanged;

    public void RaiseFlowStateRequest(FlowState state)
    {
        OnFlowStateRequested?.Invoke(state);
    }

    public void RaiseFlowStateChanged(FlowState state)
    {
        OnFlowStateChanged?.Invoke(state);
    }
}