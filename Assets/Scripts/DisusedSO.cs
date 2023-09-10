using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !!! DISUSED !!!

public enum VictimType
{
    CARDIAC, UNCONSCIOUS, ASLEEP, CHOKING, DROWNED
}

[CreateAssetMenu]
public class DisusedSO : ScriptableObject
{
    public Transform prefab;
    public VictimType type;
    public bool isAlive = true;

}
