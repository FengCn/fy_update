using System.Drawing;
using System.Drawing.Text;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private string m_Text = null;
        /// <summary>
        /// �ı�
        /// </summary>
        public string Text
        {
            get
            {
                return this.m_Text;
            }
            set
            {
                if (value != this.m_Text)
                {
                    this.m_Text = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffset = Point.Empty;
        /// <summary>
        /// �ı�ƫ��
        /// </summary>
        public Point TextOffset
        {
            get
            {
                return this.m_TextOffset;
            }
            set
            {
                if (value != this.m_TextOffset)
                {
                    this.m_TextOffset = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetHovered = Point.Empty;
        /// <summary>
        /// �������ʱ��TextOffset���ٴ�ƫ��
        /// </summary>
        public Point TextOffsetHovered
        {
            get
            {
                return this.m_TextOffsetHovered;
            }
            set
            {
                if (value != this.m_TextOffsetHovered)
                {
                    this.m_TextOffsetHovered = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetPressed = Point.Empty;
        /// <summary>
        /// ��갴��ʱ��TextOffset���ٴ�ƫ��
        /// </summary>
        public Point TextOffsetPressed
        {
            get
            {
                return this.m_TextOffsetPressed;
            }
            set
            {
                if (value != this.m_TextOffsetPressed)
                {
                    this.m_TextOffsetPressed = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetFocused = Point.Empty;
        /// <summary>
        /// ��ȡ����ʱ��TextOffset���ٴ�ƫ��
        /// </summary>
        public Point TextOffsetFocused
        {
            get
            {
                return this.m_TextOffsetFocused;
            }
            set
            {
                if (value != this.m_TextOffsetFocused)
                {
                    this.m_TextOffsetFocused = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetDisabled = Point.Empty;
        /// <summary>
        /// ����ʱ��TextOffset���ٴ�ƫ��
        /// </summary>
        public Point TextOffsetDisabled
        {
            get
            {
                return this.m_TextOffsetDisabled;
            }
            set
            {
                if (value != this.m_TextOffsetDisabled)
                {
                    this.m_TextOffsetDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextOffsetHighlight = Point.Empty;
        /// <summary>
        /// ����ʱ��TextOffset���ٴ�ƫ��
        /// </summary>
        public Point TextOffsetHighlight
        {
            get
            {
                return this.m_TextOffsetHighlight;
            }
            set
            {
                if (value != this.m_TextOffsetHighlight)
                {
                    this.m_TextOffsetHighlight = value;
                    this.Feedback();
                }
            }
        }

        private Font m_Font = DefaultTheme.Font;
        /// <summary>
        /// ����.������Ϊȫ�־�̬����,��Ҫ�ͷ�
        /// </summary>
        public Font Font
        {
            get
            {
                return this.m_Font;
            }
            set
            {
                if (value != this.m_Font)
                {
                    this.m_Font = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColor = DefaultTheme.ForeColor;
        /// <summary>
        /// ǰ��ɫ
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return this.m_ForeColor;
            }
            set
            {
                if (value != this.m_ForeColor)
                {
                    this.m_ForeColor = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorHovered = DefaultTheme.ForeColor + DefaultTheme.ForeColorHoveredVector;
        /// <summary>
        /// ǰ�����������ɫ����
        /// </summary>
        public Color ForeColorHovered
        {
            get
            {
                return this.m_ForeColorHovered;
            }
            set
            {
                if (value != this.m_ForeColorHovered)
                {
                    this.m_ForeColorHovered = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorPressed = DefaultTheme.ForeColor + DefaultTheme.ForeColorPressedVector;
        /// <summary>
        /// ǰ����갴����ɫ����
        /// </summary>
        public Color ForeColorPressed
        {
            get
            {
                return this.m_ForeColorPressed;
            }
            set
            {
                if (value != this.m_ForeColorPressed)
                {
                    this.m_ForeColorPressed = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorFocused = DefaultTheme.ForeColor + DefaultTheme.ForeColorFocusedVector;
        /// <summary>
        /// ǰ����ȡ������ɫ����
        /// </summary>
        public Color ForeColorFocused
        {
            get
            {
                return this.m_ForeColorFocused;
            }
            set
            {
                if (value != this.m_ForeColorFocused)
                {
                    this.m_ForeColorFocused = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorDisabled = DefaultTheme.ForeColor + DefaultTheme.ForeColorDisabledVector;
        /// <summary>
        /// ǰ��״̬������ɫ����
        /// </summary>
        public Color ForeColorDisabled
        {
            get
            {
                return this.m_ForeColorDisabled;
            }
            set
            {
                if (value != this.m_ForeColorDisabled)
                {
                    this.m_ForeColorDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Color m_ForeColorHighlight = DefaultTheme.ForeColor + DefaultTheme.ForeColorHighlightVector;
        /// <summary>
        /// ǰ��������ɫ����
        /// </summary>
        public Color ForeColorHighlight
        {
            get
            {
                return this.m_ForeColorHighlight;
            }
            set
            {
                if (value != this.m_ForeColorHighlight)
                {
                    this.m_ForeColorHighlight = value;
                    this.Feedback();
                }
            }
        }

        private TextRenderingHint m_TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        /// <summary>
        /// �ı���������
        /// </summary>
        public TextRenderingHint TextRenderingHint
        {
            get
            {
                return this.m_TextRenderingHint;
            }
            set
            {
                if (value != this.m_TextRenderingHint)
                {
                    this.m_TextRenderingHint = value;
                    this.Feedback();
                }
            }
        }

        private ContentAlignment m_TextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// �ı����뷽ʽ
        /// </summary>
        public ContentAlignment TextAlign
        {
            get
            {
                return this.m_TextAlign;
            }
            set
            {
                if (value != this.m_TextAlign)
                {
                    this.m_TextAlign = value;
                    this.Feedback();
                }
            }
        }

        private float m_TextRotateAngle = 0f;
        /// <summary>
        /// �ı���ת�Ƕ�
        /// </summary>
        public float TextRotateAngle
        {
            get
            {
                return this.m_TextRotateAngle;
            }
            set
            {
                if (value != this.m_TextRotateAngle)
                {
                    this.m_TextRotateAngle = value;
                    this.Feedback();
                }
            }
        }

        private bool m_TextGrayOnDisabled = true;
        /// <summary>
        /// ״̬����ʱ�ı��Ƿ���
        /// </summary>
        public bool TextGrayOnDisabled
        {
            get
            {
                return this.m_TextGrayOnDisabled;
            }
            set
            {
                if (value != this.m_TextGrayOnDisabled)
                {
                    this.m_TextGrayOnDisabled = value;
                    this.Feedback();
                }
            }
        }


        private ShadowShapeStyle m_TextShadowShapeStyle = ShadowShapeStyle.None;
        /// <summary>
        /// �ı���Ӱ�����ʽ
        /// </summary>
        public ShadowShapeStyle TextShadowShapeStyle
        {
            get
            {
                return this.m_TextShadowShapeStyle;
            }
            set
            {
                if (value != this.m_TextShadowShapeStyle)
                {
                    this.m_TextShadowShapeStyle = value;
                    this.Feedback();
                }
            }
        }

        private Color m_TextShadowColor = DefaultTheme.LightLightForeColor;
        /// <summary>
        /// ��Ӱ��ɫ
        /// </summary>
        public Color TextShadowColor
        {
            get
            {
                return this.m_TextShadowColor;
            }
            set
            {
                if (value != this.m_TextShadowColor)
                {
                    this.m_TextShadowColor = value;
                    this.Feedback();
                }
            }
        }

        private Point m_TextShadowMatrixOffset = Point.Empty;
        /// <summary>
        /// ��Ӱƫ����
        /// </summary>
        public Point TextShadowMatrixOffset
        {
            get
            {
                return this.m_TextShadowMatrixOffset;
            }
            set
            {
                if (value != this.m_TextShadowMatrixOffset)
                {
                    this.m_TextShadowMatrixOffset = value;
                    this.Feedback();
                }
            }
        }

        private Color m_TextShapeOfShadowColor = DefaultTheme.LightLightForeColor;
        /// <summary>
        /// ��Ӱ�����ɫ
        /// </summary>
        public Color TextShapeOfShadowColor
        {
            get
            {
                return this.m_TextShapeOfShadowColor;
            }
            set
            {
                if (value != this.m_TextShapeOfShadowColor)
                {
                    this.m_TextShapeOfShadowColor = value;
                    this.Feedback();
                }
            }
        }

        private float m_TextShapeOfShadowWidth = 0f;
        /// <summary>
        /// ��Ӱ��߿��
        /// </summary>
        public float TextShapeOfShadowWidth
        {
            get
            {
                return this.m_TextShapeOfShadowWidth;
            }
            set
            {
                if (value != this.m_TextShapeOfShadowWidth)
                {
                    this.m_TextShapeOfShadowWidth = value;
                    this.Feedback();
                }
            }
        }

        private Color m_TextShapeOfTextColor = DefaultTheme.LightLightForeColor;
        /// <summary>
        /// �ı������ɫ
        /// </summary>
        public Color TextShapeOfTextColor
        {
            get
            {
                return this.m_TextShapeOfTextColor;
            }
            set
            {
                if (value != this.m_TextShapeOfTextColor)
                {
                    this.m_TextShapeOfTextColor = value;
                    this.Feedback();
                }
            }
        }

        private float m_TextShapeOfTextWidth = 0f;
        /// <summary>
        /// �ı���߿��
        /// </summary>
        public float TextShapeOfTextWidth
        {
            get
            {
                return this.m_TextShapeOfTextWidth;
            }
            set
            {
                if (value != this.m_TextShapeOfTextWidth)
                {
                    this.m_TextShapeOfTextWidth = value;
                    this.Feedback();
                }
            }
        }
    }
}
