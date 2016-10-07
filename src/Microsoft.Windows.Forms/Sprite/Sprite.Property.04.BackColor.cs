using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private BlendStyle m_BackColorBlendStyle = BlendStyle.Solid;
        /// <summary>
        /// ����ɫ�����ʽ
        /// </summary>
        public BlendStyle BackColorBlendStyle
        {
            get
            {
                return this.m_BackColorBlendStyle;
            }
            set
            {
                if (value != this.m_BackColorBlendStyle)
                {
                    this.m_BackColorBlendStyle = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColor = DefaultTheme.BackColor;
        /// <summary>
        /// ����ɫ
        /// </summary>
        public Color BackColor
        {
            get
            {
                return this.m_BackColor;
            }
            set
            {
                if (value != this.m_BackColor)
                {
                    this.m_BackColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorHovered = DefaultTheme.BackColor + DefaultTheme.BackColorHoveredVector;
        /// <summary>
        /// �������������ɫ����
        /// </summary>
        public Color BackColorHovered
        {
            get
            {
                return this.m_BackColorHovered;
            }
            set
            {
                if (value != this.m_BackColorHovered)
                {
                    this.m_BackColorHovered = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorPressed = DefaultTheme.BackColor + DefaultTheme.BackColorPressedVector;
        /// <summary>
        /// ������갴����ɫ����
        /// </summary>
        public Color BackColorPressed
        {
            get
            {
                return this.m_BackColorPressed;
            }
            set
            {
                if (value != this.m_BackColorPressed)
                {
                    this.m_BackColorPressed = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorFocused = DefaultTheme.BackColor + DefaultTheme.BackColorFocusedVector;
        /// <summary>
        /// ����ӵ�н�����ɫ����
        /// </summary>
        public Color BackColorFocused
        {
            get
            {
                return this.m_BackColorFocused;
            }
            set
            {
                if (value != this.m_BackColorFocused)
                {
                    this.m_BackColorFocused = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorDisabled = DefaultTheme.BackColor + DefaultTheme.BackColorDisabledVector;
        /// <summary>
        /// ����״̬������ɫ����
        /// </summary>
        public Color BackColorDisabled
        {
            get
            {
                return this.m_BackColorDisabled;
            }
            set
            {
                if (value != this.m_BackColorDisabled)
                {
                    this.m_BackColorDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Color m_BackColorHighlight = DefaultTheme.BackColor + DefaultTheme.BackColorHighlightVector;
        /// <summary>
        /// ����������ɫ����
        /// </summary>
        public Color BackColorHighlight
        {
            get
            {
                return this.m_BackColorHighlight;
            }
            set
            {
                if (value != this.m_BackColorHighlight)
                {
                    this.m_BackColorHighlight = value;
                    this.Feedback();
                }
            }
        }

        private float m_BackColorPos1 = 0.45f;
        /// <summary>
        /// ����ɫλ��1
        /// </summary>
        public float BackColorPos1
        {
            get
            {
                return this.m_BackColorPos1;
            }
            set
            {
                if (value != this.m_BackColorPos1)
                {
                    this.m_BackColorPos1 = value;
                    this.Feedback();
                }
            }
        }

        private float m_BackColorPos2 = 0.5f;
        /// <summary>
        /// ����ɫλ��2
        /// </summary>
        public float BackColorPos2
        {
            get
            {
                return this.m_BackColorPos2;
            }
            set
            {
                if (value != this.m_BackColorPos2)
                {
                    this.m_BackColorPos2 = value;
                    this.Feedback();
                }
            }
        }

        private TabAlignment m_BackColorAlign = TabAlignment.Top;
        /// <summary>
        /// ����ɫ,�������䷽��,��ת
        /// </summary>
        public TabAlignment BackColorAlign
        {
            get
            {
                return this.m_BackColorAlign;
            }
            set
            {
                if (value != this.m_BackColorAlign)
                {
                    this.m_BackColorAlign = value;
                    this.Feedback();
                }
            }
        }
    }
}
