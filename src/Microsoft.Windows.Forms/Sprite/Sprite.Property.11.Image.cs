using System.Drawing;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private Image m_Image = null;
        /// <summary>
        /// ����״̬��ͼƬ
        /// </summary>
        public Image Image
        {
            get
            {
                return this.m_Image;
            }
            set
            {
                if (value != this.m_Image)
                {
                    this.m_Image = value;
                    this.Feedback();
                }
            }
        }

        private Image m_ImageHovered = null;
        /// <summary>
        /// �������ͼƬ
        /// </summary>
        public Image ImageHovered
        {
            get
            {
                return this.m_ImageHovered;
            }
            set
            {
                if (value != this.m_ImageHovered)
                {
                    this.m_ImageHovered = value;
                    this.Feedback();
                }
            }
        }

        private Image m_ImagePressed = null;
        /// <summary>
        /// ��갴��ͼƬ
        /// </summary>
        public Image ImagePressed
        {
            get
            {
                return this.m_ImagePressed;
            }
            set
            {
                if (value != this.m_ImagePressed)
                {
                    this.m_ImagePressed = value;
                    this.Feedback();
                }
            }
        }

        private Image m_ImageFocused = null;
        /// <summary>
        /// ӵ�н���ͼƬ
        /// </summary>
        public Image ImageFocused
        {
            get
            {
                return this.m_ImageFocused;
            }
            set
            {
                if (value != this.m_ImageFocused)
                {
                    this.m_ImageFocused = value;
                    this.Feedback();
                }
            }
        }

        private Image m_ImageDisabled = null;
        /// <summary>
        /// ״̬����ͼƬ
        /// </summary>
        public Image ImageDisabled
        {
            get
            {
                return this.m_ImageDisabled;
            }
            set
            {
                if (value != this.m_ImageDisabled)
                {
                    this.m_ImageDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Image m_ImageHighlight = null;
        /// <summary>
        /// ����ͼƬ
        /// </summary>
        public Image ImageHighlight
        {
            get
            {
                return this.m_ImageHighlight;
            }
            set
            {
                if (value != this.m_ImageHighlight)
                {
                    this.m_ImageHighlight = value;
                    this.Feedback();
                }
            }
        }

        private Point m_ImageOffset = Point.Empty;
        /// <summary>
        /// ͼƬƫ��
        /// </summary>
        public Point ImageOffset
        {
            get
            {
                return this.m_ImageOffset;
            }
            set
            {
                if (value != this.m_ImageOffset)
                {
                    this.m_ImageOffset = value;
                    this.Feedback();
                }
            }
        }

        private Point m_ImageOffsetHovered = Point.Empty;
        /// <summary>
        /// �������ʱ��ImageOffset���ٴ�ƫ��
        /// </summary>
        public Point ImageOffsetHovered
        {
            get
            {
                return this.m_ImageOffsetHovered;
            }
            set
            {
                if (value != this.m_ImageOffsetHovered)
                {
                    this.m_ImageOffsetHovered = value;
                    this.Feedback();
                }
            }
        }

        private Point m_ImageOffsetPressed = Point.Empty;
        /// <summary>
        /// ��갴��ʱ��ImageOffset���ٴ�ƫ��
        /// </summary>
        public Point ImageOffsetPressed
        {
            get
            {
                return this.m_ImageOffsetPressed;
            }
            set
            {
                if (value != this.m_ImageOffsetPressed)
                {
                    this.m_ImageOffsetPressed = value;
                    this.Feedback();
                }
            }
        }

        private Point m_ImageOffsetFocused = Point.Empty;
        /// <summary>
        /// ��ȡ����ʱ��ImageOffset���ٴ�ƫ��
        /// </summary>
        public Point ImageOffsetFocused
        {
            get
            {
                return this.m_ImageOffsetFocused;
            }
            set
            {
                if (value != this.m_ImageOffsetFocused)
                {
                    this.m_ImageOffsetFocused = value;
                    this.Feedback();
                }
            }
        }

        private Point m_ImageOffsetDisabled = Point.Empty;
        /// <summary>
        /// ����ʱ��ImageOffset���ٴ�ƫ��
        /// </summary>
        public Point ImageOffsetDisabled
        {
            get
            {
                return this.m_ImageOffsetDisabled;
            }
            set
            {
                if (value != this.m_ImageOffsetDisabled)
                {
                    this.m_ImageOffsetDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Point m_ImageOffsetHighlight = Point.Empty;
        /// <summary>
        /// ����ʱ��ImageOffset���ٴ�ƫ��
        /// </summary>
        public Point ImageOffsetHighlight
        {
            get
            {
                return this.m_ImageOffsetHighlight;
            }
            set
            {
                if (value != this.m_ImageOffsetHighlight)
                {
                    this.m_ImageOffsetHighlight = value;
                    this.Feedback();
                }
            }
        }

        private Size m_ImageSize = new Size(32, 32);
        /// <summary>
        /// ͼƬ��С
        /// </summary>
        public Size ImageSize
        {
            get
            {
                return this.m_ImageSize;
            }
            set
            {
                if (value != this.m_ImageSize)
                {
                    this.m_ImageSize = value;
                    this.Feedback();
                }
            }
        }

        private ContentAlignment m_ImageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// ͼƬ���뷽ʽ
        /// </summary>
        public ContentAlignment ImageAlign
        {
            get
            {
                return this.m_ImageAlign;
            }
            set
            {
                if (value != this.m_ImageAlign)
                {
                    this.m_ImageAlign = value;
                    this.Feedback();
                }
            }
        }

        private float m_ImageRotateAngle = 0f;
        /// <summary>
        /// ͼƬ��ת�Ƕ�
        /// </summary>
        public float ImageRotateAngle
        {
            get
            {
                return this.m_ImageRotateAngle;
            }
            set
            {
                if (value != this.m_ImageRotateAngle)
                {
                    this.m_ImageRotateAngle = value;
                    this.Feedback();
                }
            }
        }

        private bool m_ImageGrayOnDisabled = true;
        /// <summary>
        /// ͼƬ״̬�����Ƿ���
        /// </summary>
        public bool ImageGrayOnDisabled
        {
            get
            {
                return this.m_ImageGrayOnDisabled;
            }
            set
            {
                if (value != this.m_ImageGrayOnDisabled)
                {
                    this.m_ImageGrayOnDisabled = value;
                    this.Feedback();
                }
            }
        }
    }
}
