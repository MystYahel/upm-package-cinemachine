﻿using Cinemachine.ECS;
using UnityEditor;
using Cinemachine.ECS_Hybrid;
using Unity.Entities;
using UnityEngine;

namespace Cinemachine.Editor.ECS_Hybrid
{
    [CustomEditor(typeof(CM_VcamTrackedDollyProxy))]
    internal class CM_VcamTrackedDollyEditor : BaseEditor<CM_VcamTrackedDollyProxy>
    {
        public override void OnInspectorGUI()
        {
            BeginInspector();
            DrawPropertyInInspector(FindProperty(x => x.path));

            float pathLength = 0;
            var m = World.Active?.EntityManager;
            if (m != null)
            {
                var pathEntity = Target.PathEntity;
                if (m.HasComponent<CM_PathState>(pathEntity))
                    pathLength = m.GetComponentData<CM_PathState>(pathEntity).PathLength;
            }
            EditorGUILayout.LabelField(new GUIContent("Path length"), new GUIContent(pathLength.ToString()));

            DrawRemainingPropertiesInInspector();
        }
    }
}
