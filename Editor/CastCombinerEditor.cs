using UnityEditor;
using CastSystem2D;

namespace CastSystem2D.Editors
{
    [CustomEditor(typeof(CastCombiner))]
    public class CastCombinerEditor : Editor
    {
        SerializedProperty _actionByNull;
        SerializedProperty _onlyFirstCollected;
        SerializedProperty _action;

        private void OnEnable()
        {
            _actionByNull = serializedObject.FindProperty("_actionByNull");
            _onlyFirstCollected = serializedObject.FindProperty("_onlyFirstCollected");
            _action = serializedObject.FindProperty("_action");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_actionByNull);

            EditorGUILayout.PropertyField(_onlyFirstCollected);

            EditorGUILayout.Space(5);

            EditorGUILayout.PropertyField(_action);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
