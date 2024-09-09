using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(EnemyBehaviour)), CanEditMultipleObjects]
public class EnemyBehaviourEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Select all enemies"))
            {
                var allEnemyBehaviour = GameObject.FindObjectsOfType<EnemyBehaviour>();
                var allEnemyGameObjects = allEnemyBehaviour.Select(enemy => enemy.gameObject).ToArray();
                Selection.objects = allEnemyGameObjects;
            }

            if (GUILayout.Button("Clear selection"))
            {
                Selection.objects = new Object[] { (target as EnemyBehaviour).gameObject };
            }
            EditorGUILayout.EndHorizontal();

            var cachedColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Disable/Enable all enemy", GUILayout.Height(40)))
            {
                foreach (var enemy in GameObject.FindObjectsOfType<EnemyBehaviour>(true))
                    {
                    enemy.gameObject.SetActive(!enemy.gameObject.activeSelf);
                    }
            }
            GUI.backgroundColor = cachedColor;

            {
                EnemyBehaviour enemyBehaviour = (EnemyBehaviour)target;

                if (enemyBehaviour.cubeSize < 2)
                {
                    EditorGUILayout.HelpBox("Cube Size cannot be smaller than 2", MessageType.Warning);
                }

                if (enemyBehaviour.sphereRadius < 1)
                {
                    EditorGUILayout.HelpBox("Sphere Radius cannot be smaller than 2", MessageType.Warning);
                }

            }
        }
    }