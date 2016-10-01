using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.Windows.Forms
{
    public partial class Sprite
    {
        private Image m_BackgroundImage = null;
        /// <summary>
        /// ����ͼ
        /// </summary>
        public Image BackgroundImage
        {
            get
            {
                return this.m_BackgroundImage;
            }
            set
            {
                if (value != this.m_BackgroundImage)
                {
                    this.m_BackgroundImage = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImageHovered = null;
        /// <summary>
        /// ������ϱ���ͼ
        /// </summary>
        public Image BackgroundImageHovered
        {
            get
            {
                return this.m_BackgroundImageHovered;
            }
            set
            {
                if (value != this.m_BackgroundImageHovered)
                {
                    this.m_BackgroundImageHovered = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImagePressed = null;
        /// <summary>
        /// ��갴�±���ͼ
        /// </summary>
        public Image BackgroundImagePressed
        {
            get
            {
                return this.m_BackgroundImagePressed;
            }
            set
            {
                if (value != this.m_BackgroundImagePressed)
                {
                    this.m_BackgroundImagePressed = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImageFocused = null;
        /// <summary>
        /// ��ȡ���㱳��ͼ
        /// </summary>
        public Image BackgroundImageFocused
        {
            get
            {
                return this.m_BackgroundImageFocused;
            }
            set
            {
                if (value != this.m_BackgroundImageFocused)
                {
                    this.m_BackgroundImageFocused = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImageDisabled = null;
        /// <summary>
        /// ״̬���ñ���ͼ
        /// </summary>
        public Image BackgroundImageDisabled
        {
            get
            {
                return this.m_BackgroundImageDisabled;
            }
            set
            {
                if (value != this.m_BackgroundImageDisabled)
                {
                    this.m_BackgroundImageDisabled = value;
                    this.Feedback();
                }
            }
        }

        private Image m_BackgroundImageHighlight = null;
        /// <summary>
        /// ��������ͼ
        /// </summary>
        public Image BackgroundImageHighlight
        {
            get
            {
                return this.m_BackgroundImageHighlight;
            }
            set
            {
                if (value != this.m_BackgroundImageHighlight)
                {
                    this.m_BackgroundImageHighlight = value;
                    this.Feedback();
                }
            }
        }

        private ImageLayout m_BackgroundImageLayout = ImageLayout.Tile;
        /// <summary>
        /// ����ͼ���ַ�ʽ
        /// </summary>
        public ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.m_BackgroundImageLayout;
            }
            set
            {
                if (value != this.m_BackgroundImageLayout)
                {
                    this.m_BackgroundImageLayout = value;
                    this.Feedback();
                }
            }
        }

        private bool m_BackgroundImageGrayOnDisabled = false;
        /// <summary>
        /// ״̬����ʱ����ͼ�Ƿ���
        /// </summary>
        public bool BackgroundImageGrayOnDisabled
        {
            get
            {
                return this.m_BackgroundImageGrayOnDisabled;
            }
            set
            {
                if (value != this.m_BackgroundImageGrayOnDisabled)
                {
                    this.m_BackgroundImageGrayOnDisabled = value;
                    this.Feedback();
                }
            }
        }
    }
}
