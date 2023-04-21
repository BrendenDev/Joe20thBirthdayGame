using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Settings
{   
    public class SensitivityUtility : EditorWindow
    {
        public int dpi;
        public float inchesPer360; 
        public float gameSens;

        [MenuItem("Tools/SensitivityUtility")]
        public static void Open()
        {
            EditorWindow.GetWindow<SensitivityUtility>();
        }

        private void OnGUI() 
        {
            inchesPer360 = EditorGUILayout.FloatField("Inches per 360", inchesPer360);
            gameSens = EditorGUILayout.FloatField("GameSens", gameSens);
            dpi = EditorGUILayout.IntField("DPI", dpi);

            var result = 360f / (inchesPer360 * dpi * gameSens);
            
            var style = EditorStyles.textField;
            EditorGUILayout.SelectableLabel(result.ToString(), style, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        }
    }
}
