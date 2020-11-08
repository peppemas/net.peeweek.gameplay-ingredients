using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameplayIngredients.Editor
{
    [CustomEditor(typeof(CallableFlow))]
    public class CallableFlowEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if(GUILayout.Button("Open Flow Window"))
            {
                CallableFlowEditorWindow wnd = EditorWindow.GetWindow<CallableFlowEditorWindow>();
                wnd.OpenCallableFlow(serializedObject.targetObject as CallableFlow);
            }

        }


    }
}


