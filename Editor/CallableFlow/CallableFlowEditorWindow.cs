using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

namespace GameplayIngredients.Editor
{
    public class CallableFlowEditorWindow : EditorWindow
    {
        CallableFlow m_CallableFlow;

        void OnEnable()
        {
            titleContent = new GUIContent("Callable Flow");
            Selection.selectionChanged += OnSelectionChanged;
        }

        private void OnDisable()
        {
            Selection.selectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged()
        {
            CallableFlow flow;
            if (Selection.activeObject != null && Selection.activeGameObject.TryGetComponent<CallableFlow>(out flow))
            {
                OpenCallableFlow(flow);
            }
        }

        public void OpenCallableFlow(CallableFlow flow)
        {
            m_CallableFlow = flow;
            Repaint();
        }

        private void OnGUI()
        {
            if(m_CallableFlow == null)
            {
                using(new GUILayout.HorizontalScope())
                {
                    GUILayout.FlexibleSpace();
                    using(new GUILayout.VerticalScope(GUILayout.Width(320)))
                    {
                        GUILayout.FlexibleSpace();
                        EditorGUILayout.HelpBox("No Object selected with Callable Flow, please select an object with a callable flow component.", MessageType.Info);
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.FlexibleSpace();
                }
                return;
            }

            using(new GUILayout.HorizontalScope(EditorStyles.toolbar))
            {
                GUILayout.Button("Refresh", EditorStyles.toolbarButton);
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(m_CallableFlow.gameObject.name, EditorStyles.toolbarButton))
                    EditorGUIUtility.PingObject(m_CallableFlow.gameObject);
            }
        }
    }
}  