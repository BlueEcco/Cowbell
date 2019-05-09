// This script is attached to the rooms

using MySpace;
using System;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    // Instance specific data. Kept separate for easier serialization
    public RoomInstanceData RoomData;

    // Internals
    public bool RoomIsActive { get; private set; } // True if at least one man working here


    private void Start()
    {
        AssignManSlotPositions();
        CheckReferences();
        SetRoomText();
    }

    private void CheckReferences()
    {
        Debug.Assert(RoomData != null);
        Debug.Assert(RoomData.ManSlotCount == RoomData.ManSlotsPositions.Length);
        Debug.Assert(RoomData.ManSlotCount == RoomData.ManSlotsRotations.Length);
        Debug.Assert(RoomData.ManSlotCount == RoomData.ManSlotsAssignments.Length);
    }

    private void AssignManSlotPositions() // Get men positions from model
    {
        Transform[] Children = GetComponentsInChildren<Transform>();

        for (int i = 0; i < Children.Length; i++)
        {
            string SlotName = "SlotPos" + (i + 1).ToString();
            foreach (Transform Child in Children)
            {
                if (Child.name == SlotName)
                {
                    RoomData.ManSlotsPositions[i] = Child.position;
                    RoomData.ManSlotsRotations[i] = Child.rotation;
                }
            }
        }
    }

    public bool RoomHasFreeManSlots()
    {
        foreach (Guid g in RoomData.ManSlotsAssignments)
        {
            if (g == Guid.Empty) return (true);
        }
        return (false);
    }

    public bool AllManSlotsAreEmpty()
    {
        foreach (Guid g in RoomData.ManSlotsAssignments)
        {
            if (g != Guid.Empty) return (false);
        }
        return (true);
    }

    public int GetFreeManSlotIndex()
    {
        for (int i = 0; i < RoomData.ManSlotCount; i++)
        {
            if (RoomData.ManSlotsAssignments[i] == Guid.Empty)
            {
                return (i);
            }
        }
        return (-1);
    }

    public bool RoomContainsMan(Guid manId)
    {
        foreach (Guid g in RoomData.ManSlotsAssignments)
        {
            if (g == manId) return (true);
        }
        return (false);
    }

    public int CountMen()
    {
        int Count = 0;
        foreach (Guid g in RoomData.ManSlotsAssignments)
        {
            if (g != Guid.Empty) Count++;
        }
        return (Count);
    }

    public void AssignManToRoomSlot(Guid manId, int slotIndex)
    {
        RoomData.ManSlotsAssignments[slotIndex] = manId;
        RoomIsActive = true; // General sign that there is a worker
    }

    public void RemoveManFromRoomSlot(Guid manId)
    {
        for (int i = 0; i < RoomData.ManSlotCount; i++)
        {
            if (RoomData.ManSlotsAssignments[i] == manId) RoomData.ManSlotsAssignments[i] = Guid.Empty;
        }

        if (AllManSlotsAreEmpty()) RoomIsActive = false;
    }

    private void SetRoomText()
    {
        Transform[] Children = GetComponentsInChildren<Transform>();

        foreach (Transform Child in Children)
        {
            if (Child.name == "TextPos")
            {
                GameObject RoomText = Instantiate(Resources.Load<GameObject>("RoomText"));
                //  RoomText.GetComponent<TextMesh>().text = RoomData.RoomType.ToString() + " " + RoomData.RoomSize.ToString();
                RoomText.GetComponent<TextMesh>().text = RoomData.RoomName.ToString();
                RoomText.transform.position = Child.transform.position;
                RoomText.transform.SetParent(transform);
                return;
            }
        }
    }
}        
