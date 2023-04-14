using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VictimType
{
    CARDIAC, UNCONSCIOUS, ASLEEP, CHOKING, DROWNED
}

[CreateAssetMenu]
public class VictimSO : ScriptableObject
{
    public Transform prefab;
    public VictimType type;
    public bool isAlive = true;

}
