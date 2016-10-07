using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        //��ǰ״̬�ı���ɫ
        private Color? m_CurrentBackColor;
        /// <summary>
        /// ��ǰ״̬�ı���ɫ
        /// </summary>
        internal Color CurrentBackColor
        {
            get
            {
                if (this.m_CurrentBackColor == null)
                {
                    switch (this.m_State)
                    {
                        case State.Normal:
                            this.m_CurrentBackColor = this.m_BackColor;
                            break;

                        case State.Hovered:
                        case State.HoveredFocused:
                            this.m_CurrentBackColor = this.m_BackColorHovered;
                            break;

                        case State.Pressed:
                        case State.PressedFocused:
                            this.m_CurrentBackColor = this.m_BackColorPressed;
                            break;

                        case State.NormalFocused:
                            this.m_CurrentBackColor = this.m_BackColorFocused;
                            break;

                        case State.Disabled:
                            this.m_CurrentBackColor = this.m_BackColorDisabled;
                            break;

                        case State.Hidden:
                            this.m_CurrentBackColor = Color.Empty;
                            break;

                        case State.Highlight:
                            this.m_CurrentBackColor = this.m_BackColorHighlight;
                            break;

                        default:
                            this.m_CurrentBackColor = this.m_BackColor;
                            break;
                    }
                }
                return this.m_CurrentBackColor.Value;
            }
        }

        //����ɫ�Ƿ������
        private bool? m_CurrentBackColorReverse;
        /// <summary>
        /// ����ɫ�Ƿ������
        /// </summary>
        internal bool CurrentBackColorReverse
        {
            get
            {
                if (this.m_CurrentBackColorReverse == null)
                {
                    this.m_CurrentBackColorReverse = (this.m_BackColorAlign == TabAlignment.Right || this.m_BackColorAlign == TabAlignment.Bottom);
                }
                return this.m_CurrentBackColorReverse.Value;
            }
        }

        //����ɫ����ģʽ
        private LinearGradientMode? m_CurrentBackColorMode;
        /// <summary>
        /// ����ɫ����ģʽ
        /// </summary>
        internal LinearGradientMode CurrentBackColorMode
        {
            get
            {
                if (this.m_CurrentBackColorMode == null)
                {
                    this.m_CurrentBackColorMode = (this.m_BackColorAlign == TabAlignment.Left || this.m_BackColorAlign == TabAlignment.Right) ? LinearGradientMode.Horizontal : LinearGradientMode.Vertical;
                }
                return this.m_CurrentBackColorMode.Value;
            }
        }

        //����ɫ��������ľ���
        private Rectangle? m_CurrentBackColorPathRect;
        /// <summary>
        /// ����ɫ��������ľ���
        /// </summary>
        internal Rectangle CurrentBackColorPathRect
        {
            get
            {
                if (this.m_CurrentBackColorPathRect == null)
                {
                    Rectangle rect = this.m_BackColorRect;
                    //���
                    if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Left) != 0)
                    {
                        rect.X += 2;
                        rect.Width -= 2;
                    }
                    else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Left) != 0)
                    {
                        rect.X += 1;
                        rect.Width -= 1;
                    }

                    //�ϱ�
                    if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Top) != 0)
                    {
                        rect.Y += 2;
                        rect.Height -= 2;
                    }
                    else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Top) != 0)
                    {
                        rect.Y += 1;
                        rect.Height -= 1;
                    }

                    //�ұ�
                    if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Right) != 0)
                    {
                        rect.Width -= 2;
                    }
                    else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Right) != 0)
                    {
                        rect.Width -= 1;
                    }

                    //�±�
                    if ((this.m_InnerBorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
                    {
                        rect.Height -= 2;
                    }
                    else if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
                    {
                        rect.Height -= 1;
                    }
                    RectangleEx.MakeNotEmpty(ref rect);
                    this.m_CurrentBackColorPathRect = rect;
                    this.m_Graphics.SetClip(this.m_CurrentBackColorPathRect.Value, CombineMode.Intersect);//���ü�����
                }
                return this.m_CurrentBackColorPathRect.Value;
            }
        }

        //����ɫ��������ľ���(ҪFill��Path)
        private GraphicsPath m_CurrentBackColorPath;
        /// <summary>
        /// ����ɫ��������ľ���(ҪFill��Path)
        /// </summary>
        internal GraphicsPath CurrentBackColorPath
        {
            get
            {
                if (this.IsDisposed)
                    throw new ObjectDisposedException(base.GetType().ToString());

                if (this.m_CurrentBackColorPath == null)
                {
                    this.m_CurrentBackColorPath = RenderEngine.CreateGraphicsPath(this.CurrentBackColorPathRect, this.m_RoundCornerStyle, this.m_RoundStyle, this.m_RoundRadius, false);
                }
                return this.m_CurrentBackColorPath;
            }
        }

        //����ɫ��ˢ����
        private Rectangle? m_CurrentBackColorBrushRect;
        /// <summary>
        /// ����ɫ��ˢ����
        /// </summary>
        internal Rectangle CurrentBackColorBrushRect
        {
            get
            {
                if (this.m_CurrentBackColorBrushRect == null)
                {
                    Rectangle rect = RectangleEx.Inflate(this.CurrentBackColorPathRect, this.m_BackColorAlign, 1, 1);
                    RectangleEx.MakeNotEmpty(ref rect);
                    this.m_CurrentBackColorBrushRect = rect;
                }
                return this.m_CurrentBackColorBrushRect.Value;
            }
        }


        //��ǰ����ͼ
        private Image m_CurrentBackgroundImage;
        /// <summary>
        /// ��ǰ����ͼ
        /// </summary>
        internal Image CurrentBackgroundImage
        {
            get
            {
                if (this.m_CurrentBackgroundImage == null)
                {
                    switch (this.m_State)
                    {
                        case State.Normal:
                            this.m_CurrentBackgroundImage = this.m_BackgroundImage;
                            break;

                        case State.Hovered:
                        case State.HoveredFocused:
                            this.m_CurrentBackgroundImage = this.m_BackgroundImageHovered ?? this.m_BackgroundImage;
                            break;

                        case State.Pressed:
                        case State.PressedFocused:
                            this.m_CurrentBackgroundImage = this.m_BackgroundImagePressed ?? this.m_BackgroundImage;
                            break;

                        case State.NormalFocused:
                            this.m_CurrentBackgroundImage = this.m_BackgroundImageFocused ?? this.m_BackgroundImage;
                            break;

                        case State.Disabled:
                            this.m_CurrentBackgroundImage = this.m_BackgroundImageDisabled ?? this.m_BackgroundImage;
                            break;

                        case State.Hidden:
                            this.m_CurrentBackgroundImage = null;
                            break;

                        case State.Highlight:
                            this.m_CurrentBackgroundImage = this.m_BackgroundImageHighlight ?? this.m_BackgroundImage;
                            break;

                        default:
                            this.m_CurrentBackgroundImage = this.m_BackgroundImage;
                            break;
                    }
                }
                return this.m_CurrentBackgroundImage;
            }
        }

        //����ͼ���ƾ���
        private Rectangle? m_CurrentBackgroundImageRect;
        /// <summary>
        /// ����ͼ���ƾ���
        /// </summary>
        internal Rectangle CurrentBackgroundImageRect
        {
            get
            {
                if (this.m_CurrentBackgroundImageRect == null)
                {
                    Rectangle rect = this.m_BackgroundImageRect;
                    RectangleEx.MakeNotEmpty(ref rect);
                    this.m_CurrentBackgroundImageRect = rect;
                }
                return this.m_CurrentBackgroundImageRect.Value;
            }
        }


        //��ǰ�Ź��񱳾�ͼ
        private Image m_CurrentBackgroundImage9;
        /// <summary>
        /// ��ǰ�Ź��񱳾�ͼ
        /// </summary>
        internal Image CurrentBackgroundImage9
        {
            get
            {
                if (this.m_CurrentBackgroundImage9 == null)
                {
                    switch (this.m_State)
                    {
                        case State.Normal:
                            this.m_CurrentBackgroundImage9 = this.m_BackgroundImage9;
                            break;

                        case State.Hovered:
                        case State.HoveredFocused:
                            this.m_CurrentBackgroundImage9 = this.m_BackgroundImage9Hovered ?? this.m_BackgroundImage9;
                            break;

                        case State.Pressed:
                        case State.PressedFocused:
                            this.m_CurrentBackgroundImage9 = this.m_BackgroundImage9Pressed ?? this.m_BackgroundImage9;
                            break;

                        case State.NormalFocused:
                            this.m_CurrentBackgroundImage9 = this.m_BackgroundImage9Focused ?? this.m_BackgroundImage9;
                            break;

                        case State.Disabled:
                            this.m_CurrentBackgroundImage9 = this.m_BackgroundImage9Disabled ?? this.m_BackgroundImage9;
                            break;

                        case State.Hidden:
                            this.m_CurrentBackgroundImage9 = null;
                            break;

                        case State.Highlight:
                            this.m_CurrentBackgroundImage9 = this.m_BackgroundImage9Highlight ?? this.m_BackgroundImage9;
                            break;

                        default:
                            this.m_CurrentBackgroundImage9 = this.m_BackgroundImage9;
                            break;
                    }
                }
                return this.m_CurrentBackgroundImage9;
            }
        }

        //�Ź��񱳾�ͼ���ƾ���
        private Rectangle? m_CurrentBackgroundImage9Rect;
        /// <summary>
        /// �Ź��񱳾�ͼ���ƾ���
        /// </summary>
        internal Rectangle CurrentBackgroundImage9Rect
        {
            get
            {
                if (this.m_CurrentBackgroundImage9Rect == null)
                {
                    Rectangle rect = this.m_BackgroundImage9Rect;
                    RectangleEx.MakeNotEmpty(ref rect);
                    this.m_CurrentBackgroundImage9Rect = rect;
                }
                return this.m_CurrentBackgroundImage9Rect.Value;
            }
        }


        //��ǰ�߿���ɫ
        private Color? m_CurrentBorderColor;
        /// <summary>
        /// ��ǰ�߿���ɫ
        /// </summary>
        internal Color CurrentBorderColor
        {
            get
            {
                if (this.m_CurrentBorderColor == null)
                {
                    switch (this.m_State)
                    {
                        case State.Normal:
                            this.m_CurrentBorderColor = this.m_BorderColor;
                            break;

                        case State.Hovered:
                        case State.HoveredFocused:
                            this.m_CurrentBorderColor = this.m_BorderColorHovered;
                            break;

                        case State.Pressed:
                        case State.PressedFocused:
                            this.m_CurrentBorderColor = this.m_BorderColorPressed;
                            break;

                        case State.NormalFocused:
                            this.m_CurrentBorderColor = this.m_BorderColorFocused;
                            break;

                        case State.Disabled:
                            this.m_CurrentBorderColor = this.m_BorderColorDisabled;
                            break;

                        case State.Hidden:
                            this.m_CurrentBorderColor = Color.Empty;
                            break;

                        case State.Highlight:
                            this.m_CurrentBorderColor = this.m_BorderColorHighlight;
                            break;

                        default:
                            this.m_CurrentBorderColor = this.m_BorderColor;
                            break;
                    }
                }
                return this.m_CurrentBorderColor.Value;
            }
        }

        //�߿�·������
        private Rectangle? m_CurrentBorderPathRect;
        /// <summary>
        /// �߿�·������
        /// </summary>
        internal Rectangle CurrentBorderPathRect
        {
            get
            {
                if (this.m_CurrentBorderPathRect == null)
                {
                    Rectangle rect = this.m_BorderColorRect;
                    rect.Width--;
                    rect.Height--;
                    this.m_CurrentBorderPathRect = rect;
                }
                return this.m_CurrentBorderPathRect.Value;
            }
        }

        //�߿�ˢ����
        private Rectangle? m_CurrentBorderBrushRect;
        /// <summary>
        /// �߿�ˢ����
        /// </summary>
        internal Rectangle CurrentBorderBrushRect
        {
            get
            {
                if (this.m_CurrentBorderBrushRect == null)
                {
                    this.m_CurrentBorderBrushRect = RectangleEx.Inflate(this.CurrentBorderPathRect, this.m_BackColorAlign, 1, 1);
                }
                return this.m_CurrentBorderBrushRect.Value;
            }
        }

        //��ǰ�ڱ߿���ɫ
        private Color? m_CurrentInnerBorderColor;
        /// <summary>
        /// ��ǰ�ڱ߿���ɫ
        /// </summary>
        internal Color CurrentInnerBorderColor
        {
            get
            {
                if (this.m_CurrentInnerBorderColor == null)
                {
                    switch (this.m_State)
                    {
                        case State.Normal:
                            this.m_CurrentInnerBorderColor = this.m_InnerBorderColor;
                            break;

                        case State.Hovered:
                        case State.HoveredFocused:
                            this.m_CurrentInnerBorderColor = this.m_InnerBorderColorHovered;
                            break;

                        case State.Pressed:
                        case State.PressedFocused:
                            this.m_CurrentInnerBorderColor = this.m_InnerBorderColorPressed;
                            break;

                        case State.NormalFocused:
                            this.m_CurrentInnerBorderColor = this.m_InnerBorderColorFocused;
                            break;

                        case State.Disabled:
                            this.m_CurrentInnerBorderColor = this.m_InnerBorderColorDisabled;
                            break;

                        case State.Hidden:
                            this.m_CurrentInnerBorderColor = Color.Empty;
                            break;

                        case State.Highlight:
                            this.m_CurrentInnerBorderColor = this.m_InnerBorderColorHighlight;
                            break;

                        default:
                            this.m_CurrentInnerBorderColor = this.m_InnerBorderColor;
                            break;
                    }
                }
                return this.m_CurrentInnerBorderColor.Value;
            }
        }

        //�ڱ߿�·������
        private Rectangle? m_CurrentInnerBorderPathRect;
        /// <summary>
        /// �ڱ߿�·������
        /// </summary>
        internal Rectangle CurrentInnerBorderPathRect
        {
            get
            {
                if (this.m_CurrentInnerBorderPathRect == null)
                {
                    Rectangle rect = this.CurrentBorderPathRect;
                    if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Left) != 0)
                    {
                        rect.X++;
                        rect.Width--;
                    }
                    if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Top) != 0)
                    {
                        rect.Y++;
                        rect.Height--;
                    }
                    if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Right) != 0)
                    {
                        rect.Width--;
                    }
                    if ((this.m_BorderVisibleStyle & BorderVisibleStyle.Bottom) != 0)
                    {
                        rect.Height--;
                    }
                    this.m_CurrentInnerBorderPathRect = rect;
                }
                return this.m_CurrentInnerBorderPathRect.Value;
            }
        }

        //�ڱ߿�ˢ����
        private Rectangle? m_CurrentInnerBorderBrushRect;
        /// <summary>
        /// �ڱ߿�ˢ����
        /// </summary>
        internal Rectangle CurrentInnerBorderBrushRect
        {
            get
            {
                if (this.m_CurrentInnerBorderBrushRect == null)
                {
                    this.m_CurrentInnerBorderBrushRect = RectangleEx.Inflate(this.CurrentInnerBorderPathRect, this.m_BackColorAlign, 1, 1);
                }
                return this.m_CurrentInnerBorderBrushRect.Value;
            }
        }


        //�ַ��������������,���ݽ�����ֵ
        private Rectangle? m_CurrentStringClientRect;
        /// <summary>
        /// �ַ��������������,���ݽ�����ֵ
        /// </summary>
        internal Rectangle CurrentStringClientRect
        {
            get
            {
                if (this.m_CurrentStringClientRect == null)
                {
                    this.m_CurrentStringClientRect = this.m_StringRect;
                }
                return this.m_CurrentStringClientRect.Value;
            }
        }

        //�ַ���ʵ�ʻ����������,��ȥ�߾ಢƫ��
        private Rectangle? m_CurrentStringRect;
        /// <summary>
        /// �ַ���ʵ�ʻ����������,��ȥ�߾ಢƫ��
        /// </summary>
        internal Rectangle CurrentStringRect
        {
            get
            {
                if (this.m_CurrentStringRect == null)
                {
                    Rectangle rect = RectangleEx.Subtract(this.CurrentStringClientRect, this.m_Padding);
                    rect.Offset(this.m_TextOffset);
                    this.m_CurrentStringRect = rect;
                }
                return this.m_CurrentStringRect.Value;
            }
        }

        //�ַ���·���ľ���
        private Rectangle? m_CurrentStringPathRect;
        /// <summary>
        /// �ַ���·���ľ���
        /// </summary>
        internal Rectangle CurrentStringPathRect
        {
            get
            {
                if (this.m_CurrentStringPathRect == null)
                {
                    return Rectangle.Empty;
                }
                return this.m_CurrentStringPathRect.Value;
            }
        }

        //�ַ�����С
        private Size? m_CurrentStringSize;
        /// <summary>
        /// �ַ�����С
        /// </summary>
        internal Size CurrentStringSize
        {
            get
            {
                if (this.m_CurrentStringSize == null)
                {
                    return Size.Empty;
                }
                return this.m_CurrentStringSize.Value;
            }
        }


        //�ı�ͼƬ�����������,���ݽ�����ֵ
        private Rectangle? m_CurrentTextImageClientRect;
        /// <summary>
        /// �ı�ͼƬ�����������,���ݽ�����ֵ
        /// </summary>
        internal Rectangle CurrentTextImageClientRect
        {
            get
            {
                if (this.m_CurrentTextImageClientRect == null)
                {
                    this.m_CurrentTextImageClientRect = this.m_TextImageRect;
                }
                return this.m_CurrentTextImageClientRect.Value;
            }
        }

        //���������ı�ͼƬ�ľ�������
        private Rectangle? m_CurrentTextImagePreferredRect;
        /// <summary>
        /// ���������ı�ͼƬ�ľ�������
        /// </summary>
        internal Rectangle CurrentTextImagePreferredRect
        {
            get
            {
                if (this.m_CurrentTextImagePreferredRect == null)
                {
                    Rectangle imageRect = this.CurrentImagePreferredRect;
                    Rectangle textRect = this.CurrentTextPreferredRect;

                    if (imageRect.Width == 0 || imageRect.Height == 0)
                        this.m_CurrentTextImagePreferredRect = textRect;
                    else if (textRect.Width == 0 || textRect.Height == 0)
                        this.m_CurrentTextImagePreferredRect = imageRect;
                    else
                        this.m_CurrentTextImagePreferredRect = Rectangle.Union(imageRect, textRect);

                }
                return this.m_CurrentTextImagePreferredRect.Value;
            }
        }

        //���������ı��ľ�������
        private Rectangle? m_CurrentTextPreferredRect;
        /// <summary>
        /// ���������ı��ľ�������
        /// </summary>
        internal Rectangle CurrentTextPreferredRect
        {
            get
            {
                if (this.m_CurrentTextPreferredRect == null)
                {
                    this.m_CurrentTextPreferredRect = Rectangle.Empty;
                }
                return this.m_CurrentTextPreferredRect.Value;
            }

            private set
            {
                switch (this.m_State)
                {
                    case State.Normal:
                        this.m_CurrentTextPreferredRect = value;
                        break;

                    case State.Hovered:
                    case State.HoveredFocused:
                        this.m_CurrentTextPreferredRect = RectangleEx.Offset(value, this.TextOffsetHovered);
                        break;

                    case State.Pressed:
                    case State.PressedFocused:
                        this.m_CurrentTextPreferredRect = RectangleEx.Offset(value, this.TextOffsetPressed);
                        break;

                    case State.NormalFocused:
                        this.m_CurrentTextPreferredRect = RectangleEx.Offset(value, this.TextOffsetFocused);
                        break;

                    case State.Disabled:
                        this.m_CurrentTextPreferredRect = RectangleEx.Offset(value, this.TextOffsetDisabled);
                        break;

                    case State.Hidden:
                        this.m_CurrentTextPreferredRect = value;
                        break;

                    case State.Highlight:
                        this.m_CurrentTextPreferredRect = RectangleEx.Offset(value, this.TextOffsetHighlight);
                        break;

                    default:
                        this.m_CurrentTextPreferredRect = value;
                        break;
                }
            }
        }

        //��ǰǰ��ɫ
        private Color? m_CurrentForeColor;
        /// <summary>
        /// ��ǰǰ��ɫ
        /// </summary>
        internal Color CurrentForeColor
        {
            get
            {
                if (this.m_CurrentForeColor == null)
                {
                    switch (this.m_State)
                    {
                        case State.Normal:
                            this.m_CurrentForeColor = this.m_ForeColor;
                            break;

                        case State.Hovered:
                        case State.HoveredFocused:
                            this.m_CurrentForeColor = this.m_ForeColorHovered;
                            break;

                        case State.Pressed:
                        case State.PressedFocused:
                            this.m_CurrentForeColor = this.m_ForeColorPressed;
                            break;

                        case State.NormalFocused:
                            this.m_CurrentForeColor = this.m_ForeColorFocused;
                            break;

                        case State.Disabled:
                            this.m_CurrentForeColor = (this.m_TextGrayOnDisabled ? RenderEngine.GetGrayColor(this.CurrentBackColor) : this.m_ForeColorDisabled);
                            break;

                        case State.Hidden:
                            this.m_CurrentForeColor = Color.Empty;
                            break;

                        case State.Highlight:
                            this.m_CurrentForeColor = this.m_ForeColorHighlight;
                            break;

                        default:
                            this.m_CurrentForeColor = this.m_ForeColor;
                            break;
                    }
                }
                return this.m_CurrentForeColor.Value;
            }
        }

        //��������ͼƬ�ľ�������
        private Rectangle? m_CurrentImagePreferredRect;
        /// <summary>
        /// ��������ͼƬ�ľ�������
        /// </summary>
        internal Rectangle CurrentImagePreferredRect
        {
            get
            {
                if (this.m_CurrentImagePreferredRect == null)
                {
                    this.m_CurrentImagePreferredRect = Rectangle.Empty;
                }
                return this.m_CurrentImagePreferredRect.Value;
            }

            private set
            {

                switch (this.m_State)
                {
                    case State.Normal:
                        this.m_CurrentImagePreferredRect = value;
                        break;

                    case State.Hovered:
                    case State.HoveredFocused:
                        this.m_CurrentImagePreferredRect = RectangleEx.Offset(value, this.ImageOffsetHovered);
                        break;

                    case State.Pressed:
                    case State.PressedFocused:
                        this.m_CurrentImagePreferredRect = RectangleEx.Offset(value, this.ImageOffsetPressed);
                        break;

                    case State.NormalFocused:
                        this.m_CurrentImagePreferredRect = RectangleEx.Offset(value, this.ImageOffsetFocused);
                        break;

                    case State.Disabled:
                        this.m_CurrentImagePreferredRect = RectangleEx.Offset(value, this.ImageOffsetDisabled);
                        break;

                    case State.Hidden:
                        this.m_CurrentImagePreferredRect = value;
                        break;

                    case State.Highlight:
                        this.m_CurrentImagePreferredRect = RectangleEx.Offset(value, this.ImageOffsetHighlight);
                        break;

                    default:
                        this.m_CurrentImagePreferredRect = value;
                        break;
                }
            }
        }

        //��ǰͼƬ
        private Image m_CurrentImage;
        /// <summary>
        /// ��ǰͼƬ
        /// </summary>
        internal Image CurrentImage
        {
            get
            {
                if (this.m_CurrentImage == null)
                {
                    switch (this.m_State)
                    {
                        case State.Normal:
                            this.m_CurrentImage = this.m_Image;
                            break;

                        case State.Hovered:
                        case State.HoveredFocused:
                            this.m_CurrentImage = this.m_ImageHovered ?? this.m_Image;
                            break;

                        case State.Pressed:
                        case State.PressedFocused:
                            this.m_CurrentImage = this.m_ImagePressed ?? this.m_Image;
                            break;

                        case State.NormalFocused:
                            this.m_CurrentImage = this.m_ImageFocused ?? this.m_Image;
                            break;

                        case State.Disabled:
                            this.m_CurrentImage = this.m_ImageDisabled ?? this.m_Image;
                            break;

                        case State.Hidden:
                            this.m_CurrentImage = null;
                            break;

                        case State.Highlight:
                            this.m_CurrentImage = this.m_ImageHighlight ?? this.m_Image;
                            break;

                        default:
                            this.m_CurrentImage = this.m_Image;
                            break;
                    }
                }
                return this.m_CurrentImage;
            }
        }


        //��ǰֱ����ɫ
        private Color? m_CurrentLineColor;
        /// <summary>
        /// ��ǰֱ����ɫ
        /// </summary>
        internal Color CurrentLineColor
        {
            get
            {
                if (this.m_CurrentLineColor == null)
                {
                    switch (this.m_State)
                    {
                        case State.Normal:
                            this.m_CurrentLineColor = this.m_LineColor;
                            break;

                        case State.Hovered:
                        case State.HoveredFocused:
                            this.m_CurrentLineColor = this.m_LineColorHovered;
                            break;

                        case State.Pressed:
                        case State.PressedFocused:
                            this.m_CurrentLineColor = this.m_LineColorPressed;
                            break;

                        case State.NormalFocused:
                            this.m_CurrentLineColor = this.m_LineColorFocused;
                            break;

                        case State.Disabled:
                            this.m_CurrentLineColor = this.m_LineColorDisabled;
                            break;

                        case State.Hidden:
                            this.m_CurrentLineColor = Color.Empty;
                            break;

                        case State.Highlight:
                            this.m_CurrentLineColor = this.m_LineColorHighlight;
                            break;

                        default:
                            this.m_CurrentLineColor = this.m_LineColor;
                            break;
                    }
                }
                return this.m_CurrentLineColor.Value;
            }
        }
    }
}
