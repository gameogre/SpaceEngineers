﻿using Sandbox.Game.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using VRage;
using VRage;
using VRageMath;

namespace Sandbox.Game.Components
{
    class MyFracturePiecePositionComponent : MyPositionComponent
    {
        public override void UpdateWorldVolume()
        {
            m_worldAABB.Min = m_worldMatrix.Translation;// -Vector3.One * m_localVolume.Radius;
            m_worldAABB.Max = m_worldMatrix.Translation;// +Vector3.One * m_localVolume.Radius;
            m_worldVolume.Center = m_worldMatrix.Translation;
            m_worldVolume.Radius = m_localVolume.Radius;
            Entity.Render.InvalidateRenderObjects();
        }

        protected override void UpdateChildren(object source)
        {
            return;
        }

        public override void OnWorldPositionChanged(object source)
        {
            Debug.Assert(source != this && (Entity == null || source != Entity), "Recursion detected!");
            ProfilerShort.Begin("FP.Volume+InvalidateRender");
            UpdateWorldVolume();
            //ProfilerShort.BeginNextBlock("FP.Prunning.Move");
            //MyGamePruningStructure.Move(Entity as MyEntity);
            ProfilerShort.End();
        }
    }
}
