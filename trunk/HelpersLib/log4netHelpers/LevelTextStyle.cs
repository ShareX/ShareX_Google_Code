using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using log4net.Util;

namespace HelpersLib
{
    public class LevelTextStyle : LevelMappingEntry
    {
        private Color textColor;
        private Color backColor;
        private FontStyle fontStyle = FontStyle.Regular;
        private float pointSize = 0.0f;
        private bool bold = false;
        private bool italic = false;
        private string fontFamilyName = null;
        private Font font = null;

        public bool Bold { get { return bold; } set { bold = value; } }
        public bool Italic { get { return italic; } set { italic = value; } }
        public float PointSize { get { return pointSize; } set { pointSize = value; } }

        /// <summary>
        /// Initialize the options for the object
        /// </summary>
        /// <remarks>Parse the properties</remarks>
        public override void ActivateOptions()
        {
            base.ActivateOptions();
            if (bold) fontStyle |= FontStyle.Bold;
            if (italic) fontStyle |= FontStyle.Italic;

            if (fontFamilyName != null)
            {
                float size = pointSize > 0.0f ? pointSize : 8.25f;
                try
                {
                    font = new Font(fontFamilyName, size, fontStyle);
                }
                catch (Exception)
                {
                    font = new Font("Arial", 8.25f, FontStyle.Regular);
                }
            }
        }

        public Color TextColor { get { return textColor; } set { textColor = value; } }
        public Color BackColor { get { return backColor; } set { backColor = value; } }
        public FontStyle FontStyle { get { return fontStyle; } set { fontStyle = value; } }
        public Font Font { get { return font; } set { font = value; } }
    }
}