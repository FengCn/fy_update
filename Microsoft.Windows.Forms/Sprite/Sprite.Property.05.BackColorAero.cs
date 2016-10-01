using System.Drawing;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private AeroStyle m_BackColorAeroStyle = AeroStyle.None;
        /// <summary>
        /// ��Ч���Ʒ�ʽ
        /// </summary>
        public AeroStyle BackColorAeroStyle
        {
            get
            {
                return this.m_BackColorAeroStyle;
            }
            set
            {
                if (value != this.m_BackColorAeroStyle)
                {
                    this.m_BackColorAeroStyle = value;
                    this.Feedback();
                }
            }
        }

        private float m_BackColorAeroPos = 0.45f;
        /// <summary>
        /// ��Ч�ָ�λ��
        /// </summary>
        public float BackColorAeroPos
        {
            get
            {
                return this.m_BackColorAeroPos;
            }
            set
            {
                if (value != this.m_BackColorAeroPos)
                {
                    this.m_BackColorAeroPos = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorAeroBlurColor = DefaultTheme.BlurColor;
        /// <summary>
        /// ģ����Ч��ɫ
        /// </summary>
        public Color BackColorAeroBlurColor
        {
            get
            {
                return this.m_BackColorAeroBlurColor;
            }
            set
            {
                if (value != this.m_BackColorAeroBlurColor)
                {
                    this.m_BackColorAeroBlurColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorAeroGlassCenterColor = DefaultTheme.GlassCenterColor;
        /// <summary>
        /// ������Ч������ɫ
        /// </summary>
        public Color BackColorAeroGlassCenterColor
        {
            get
            {
                return this.m_BackColorAeroGlassCenterColor;
            }
            set
            {
                if (value != this.m_BackColorAeroGlassCenterColor)
                {
                    this.m_BackColorAeroGlassCenterColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorAeroGlassSurroundColor = DefaultTheme.GlassSurroundColor;
        /// <summary>
        /// ������Ч������ɫ
        /// </summary>
        public Color BackColorAeroGlassSurroundColor
        {
            get
            {
                return this.m_BackColorAeroGlassSurroundColor;
            }
            set
            {
                if (value != this.m_BackColorAeroGlassSurroundColor)
                {
                    this.m_BackColorAeroGlassSurroundColor = value;
                    this.Feedback();
                }
            }
        }
    }
}
