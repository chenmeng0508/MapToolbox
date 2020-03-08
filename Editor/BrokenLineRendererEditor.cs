﻿#region License
/******************************************************************************
* Copyright 2019 The AutoCore Authors. All Rights Reserved.
* 
* Licensed under the GNU Lesser General Public License, Version 3.0 (the "License"); 
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
* 
* https://www.gnu.org/licenses/lgpl-3.0.html
* 
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*****************************************************************************/
#endregion


using UnityEditor;
using UnityEngine;
using static AutoCore.MapToolbox.Editor.Utils;

namespace AutoCore.MapToolbox.Editor
{
    class BrokenLineRendererEditor<T> : SiblingParentEditor where T : LineSegment<T>
    {
        new BrokenLineRenderer<T> Target => target as BrokenLineRenderer<T>;
        protected override void OnEnable()
        {
            base.OnEnable();
            Target.UpdateRenderer();
        }
        protected override void BeforeDefaultInspectorDraw()
        {
            base.BeforeDefaultInspectorDraw();
            Target.From = EditorGUILayout.Vector3Field(GetMemberName((BrokenLineRenderer<T> t) => t.From), Target.From);
            Target.To = EditorGUILayout.Vector3Field(GetMemberName((BrokenLineRenderer<T> t) => t.To), Target.To);
        }
        protected override void AfterDefaultInspectorDraw()
        {
            base.AfterDefaultInspectorDraw();
            GUI.color = Color.green;
            if (GUILayout.Button(GetMethodName(Target.Reverse)))
            {
                Target.Reverse();
            }
            GUI.color = Color.white;
        }
        protected virtual void OnSceneGUI()
        {
            Tools.current = Tool.None;
            Target.From = Handles.PositionHandle(Target.From, Quaternion.identity);
            Target.To = Handles.PositionHandle(Target.To, Quaternion.identity);
        }
    }
}