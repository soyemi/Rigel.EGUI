﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rigel.GUI.Collections;

namespace Rigel.GUI
{
    public static partial class GUI
    {

        private static GUIForm m_form = null;
        private static GUILayer m_layer = null;
        private static GUIRegion m_region = null;

        private static IGUIBuffer BufRect { get; set; }
        private static IGUIBuffer BufText { get; set; }

        private static int DepthBase;
        private static float DepthValue = 0;
        private static readonly float DepthStep = 0.0001f;

        internal static GUIFrame m_frame = new GUIFrame();
        private static GUIFrame Frame { get { return m_frame; } }

        internal static GUIAreaInfo CurArea;
        internal static GUILayoutInfo CurLayout;
        


        internal static void StartFrame(GUIForm form)
        {
            if (m_form != null) throw new Exception();
            m_form = form;

            m_frame = m_form.Frame;
            m_frame.Reset(m_form);
        }
        internal static void EndFrame(GUIForm form)
        {
            if (m_form != form) throw new Exception();
            m_form = null;


            if (!m_frame.EndFrame())
            {
                throw new Exception();
            }
            m_frame = null;
        }

        internal static void StartGUIRegion(GUIRegion region)
        {
            if (m_layer == null) throw new Exception();
            if (m_region != null) throw new Exception();

            m_region = region;

            DepthBase = m_layer.Order - m_region.Order;
            DepthValue = DepthBase;

            //Process Buffer and Offset
            BufRect = m_layer.GetBufferRect(m_region);
            BufText = m_layer.GetBufferText(m_region);


            region.BlockInfoRect.Start = BufRect.Count;
            //region.BlockInfoText.Start = BufText.Count;

            BeginArea(region.Rect);

        }
        internal static void EndGUIRegion(GUIRegion region)
        {
            EndArea();

            region.BlockInfoRect.Count = BufRect.Count - region.BlockInfoRect.Start;
            //region.BlockInfoText.Count = BufText.Count - region.BlockInfoText.Start;

            BufRect = null;
            BufText = null;

            if (m_region != region) throw new Exception();
            m_region = null;
        }

        internal static void StartGUILayer(GUILayer layer)
        {
            if (m_layer != null) throw new Exception();
            m_layer = layer;

        }
        internal static void EndGUILayer(GUILayer layer)
        {
            if (m_layer != layer) throw new Exception();
            m_layer = null;
        }
    }
}
