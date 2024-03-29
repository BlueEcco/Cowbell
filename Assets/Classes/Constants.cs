﻿// Static class for all constants and pre-defs (partial).

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace MySpace
{
    public static partial class Constants
    {
        // Grid definitions
        public static readonly int GridSizeX = 16;
        public static readonly int GridSizeY = 12;
        public static readonly int GridSizeZ = 2;
        public static readonly int GridSurfaceY = 8; // First row of 'AboveSurface'. Here, 0..7 = below, 8..11 is above

        public static readonly float GridElementWidth = 2.5f;  // X-Size
        public static readonly float GridElementHeight = 4.0f; // Y-Size
        public static readonly float GridElementDepth = 5.0f;  // Z-Size

        // Selection definitions
        public static readonly float MouseDragInvokeDownTime = 0.5f;

        // Avatar movements
        public static readonly float GridPositionWalkZOffset = 1.4f; // Z-Offset for the 'walking lane' in rooms
        public static readonly float ManRunSpeed = 2.0f;
        public static readonly float ManWalkSpeed = 1.0f;
        public static readonly float ManWalkLaneZOffset = 1.5f;

        // In/Out fixed movement paths. Overdoing it here a bit, trying to follow Microsoft's design rule for constant arrays
        private static readonly Vector3[] _NewManIncomingPath = { new Vector3(-18f,  (GridSurfaceY + 0.5f) * GridElementHeight - 0.2f, 6.0f),
                                                                  new Vector3(-5.5f, (GridSurfaceY + 0.5f) * GridElementHeight - 0.2f, 6.0f),
                                                                  new Vector3(-3.0f, (GridSurfaceY + 0.5f) * GridElementHeight - 0.2f, 4.5f),
                                                                  new Vector3(-3.5f, (GridSurfaceY + 0.5f) * GridElementHeight - 0.2f, 1.5f) };
        public static readonly ReadOnlyCollection<Vector3> NewManIncomingPath = new ReadOnlyCollection<Vector3>(_NewManIncomingPath);

        private static readonly Vector3[] _NewManOutgoingPath = { new Vector3(-2.5f, (GridSurfaceY + 0.5f) * GridElementHeight - 0.2f, 1.5f),
                                                                  new Vector3(-3.0f, (GridSurfaceY + 0.5f) * GridElementHeight - 0.2f, 4.5f),
                                                                  new Vector3(-5.5f, (GridSurfaceY + 0.5f) * GridElementHeight - 0.2f, 6.0f),
                                                                  new Vector3(-18f,  (GridSurfaceY + 0.5f) * GridElementHeight - 0.2f, 6.0f) };
        public static readonly ReadOnlyCollection<Vector3> NewManOutgoingPath = new ReadOnlyCollection<Vector3>(_NewManOutgoingPath);

        // Camera definitions
        public static readonly float CameraKeyMovementSpeed = 4.0f;
        public static readonly float CameraZoomMovementSpeed = 5.0f;
        public static readonly float CameraDragMovementSpeed = 0.1f;
        public static readonly int CameraDragThreshold = 6;  // Pixel threshold to detect/invoke camera drag
        public static readonly Vector2 CameraxZPositionLimits = new Vector2(-180.0f, -10.0f);
        public static readonly Vector2 CameraxXPositionLimitsLeft = new Vector2(18.0f, -21.0f); // At min/max Zoomfactor
        public static readonly Vector2 CameraxXPositionLimitsRight = new Vector2(18.0f, 58.0f); // At min/max Zoomfactor
        public static readonly Vector2 CameraxYPositionLimitsDown = new Vector2(18.0f, -12.0f); // At min/max Zoomfactor
        public static readonly Vector2 CameraxYPositionLimitsUp = new Vector2(48.0f, 67.0f); // At min/max Zoomfactor

        // Selector definitions
        public static readonly Dictionary<Enums.RoomSizes, string> RoomBuildSelectorModels = new Dictionary<Enums.RoomSizes, string>
        {
            { Enums.RoomSizes.Size1, "RoomSelectors/BuildPosSelector_Size1" },
            { Enums.RoomSizes.Size2, "RoomSelectors/BuildPosSelector_Size2" },
            { Enums.RoomSizes.Size4, "RoomSelectors/BuildPosSelector_Size4" },
            { Enums.RoomSizes.Size6, "RoomSelectors/BuildPosSelector_Size6" }
        };

        // Man avatar definitions
        public static readonly string ManSelectedMaterial = "Avatars/UnlitRedMaterial";
        public static readonly string ManGhostMaterial = "Avatars/UnlitGreyMaterial";

        public static readonly ManDefData[] ManDefinitions = new ManDefData[]
        {
            new ManDefData ("StandardMan", "Avatars/Man_pref", Enums.ManTypes.StandardMan)
        };
    }
}