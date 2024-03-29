﻿// Container class for avatar/man data, stored in the room object script
using System;
using UnityEngine;

namespace MySpace
{
    [Serializable]
    public class RoomInstanceData
    {
        // Room Characterisation
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public Enums.RoomSizes RoomSize { get; set; }
        public Enums.RoomCategories RoomCategory { get; set; }
        public Enums.RoomTypes RoomType { get; set; }
        public Enums.RoomOverUnder RoomOverUnder{ get; set; }

        // Room Positioning
        public GridIndex[] CoveredIndizes { get; set; }

        // Avatar Management
        public int ManSlotCount { get; set; } // Number of avatars we can assign to this room   
        public Vector3[] ManSlotsPositions { get; set; } // World positions of the avatar slots
        public Quaternion[] ManSlotsRotations { get; set; } // World rotations of the avatar slots
        public Guid[] ManSlotsAssignments { get; set; } // Guids of avatars assigned to this room
        public Enums.ManStates[] ManWorkingStates { get; set; }

        public RoomInstanceData()
        {

        }

        public GridIndex GetLeftMostIndex()
        {
            return (CoveredIndizes[0]);
        }
    }
}
