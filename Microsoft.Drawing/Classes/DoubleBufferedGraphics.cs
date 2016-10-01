using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Microsoft.Drawing
{
    /// <summary>
    /// ˫������
    /// </summary>
    public class DoubleBufferedGraphics : Disposable
    {
        private bool m_IsCreating;                      //�Ƿ����ڴ���������
        private IWin32Window m_Owner;                   //ӵ�иû������Ĵ���
        private BufferedGraphics m_BufferedGraphics;    //������


        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="owner">ӵ����</param>
        public DoubleBufferedGraphics(IWin32Window owner)
        {
            this.m_Owner = owner;
        }

        #endregion


        #region �ֶ�����

        private CompositingMode m_CompositingMode = CompositingMode.SourceOver;
        /// <summary>
        /// ��ȡһ��ֵ����ֵָ����ν��ϳ�ͼ����Ƶ��� System.Drawing.Graphics��
        /// </summary>
        public CompositingMode CompositingMode
        {
            get
            {
                return this.m_CompositingMode;
            }
            set
            {
                if (value != this.m_CompositingMode)
                {
                    this.m_CompositingMode = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.CompositingMode = value;
                }
            }
        }

        private CompositingQuality m_CompositingQuality = CompositingQuality.Default;
        /// <summary>
        /// ��ȡ�����û��Ƶ��� System.Drawing.Graphics �ĺϳ�ͼ��ĳ���������
        /// </summary>
        public CompositingQuality CompositingQuality
        {
            get
            {
                return this.m_CompositingQuality;
            }
            set
            {
                if (value != this.m_CompositingQuality)
                {
                    this.m_CompositingQuality = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.CompositingQuality = value;
                }
            }
        }

        private InterpolationMode m_InterpolationMode = InterpolationMode.Bilinear;
        /// <summary>
        /// ��ȡ��������� System.Drawing.Graphics �����Ĳ岹ģʽ��
        /// </summary>
        public InterpolationMode InterpolationMode
        {
            get
            {
                return this.m_InterpolationMode;
            }
            set
            {
                if (value != this.m_InterpolationMode)
                {
                    this.m_InterpolationMode = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.InterpolationMode = value;
                }
            }
        }

        private PixelOffsetMode m_PixelOffsetMode = PixelOffsetMode.Default;
        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָ���ڳ��ִ� System.Drawing.Graphics �Ĺ������������ƫ�ơ�
        /// </summary>
        public PixelOffsetMode PixelOffsetMode
        {
            get
            {
                return this.m_PixelOffsetMode;
            }
            set
            {
                if (value != this.m_PixelOffsetMode)
                {
                    this.m_PixelOffsetMode = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.PixelOffsetMode = value;
                }
            }
        }

        private SmoothingMode m_SmoothingMode = SmoothingMode.None;
        /// <summary>
        /// ��ȡ�����ô� System.Drawing.Graphics �ĳ���������
        /// </summary>
        public SmoothingMode SmoothingMode
        {
            get
            {
                return this.m_SmoothingMode;
            }
            set
            {
                if (value != this.m_SmoothingMode)
                {
                    this.m_SmoothingMode = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.SmoothingMode = value;
                }
            }
        }

        private int m_TextContrast = 4;
        /// <summary>
        /// ��ȡ�����ó����ı��ĻҶ�У��ֵ��
        /// </summary>
        public int TextContrast
        {
            get
            {
                return this.m_TextContrast;
            }
            set
            {
                if (value != this.m_TextContrast)
                {
                    this.m_TextContrast = value;
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.TextContrast = value;
                }
            }
        }

        private TextRenderingHint m_TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        /// <summary>
        /// ��ȡ��������� System.Drawing.Graphics �������ı��ĳ���ģʽ��
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
                    if (this.m_BufferedGraphics != null)
                        this.m_BufferedGraphics.Graphics.TextRenderingHint = value;
                }
            }
        }

        /// <summary>
        /// ��������ͼ����
        /// </summary>
        public Graphics Graphics
        {
            get
            {
                return this.m_BufferedGraphics.Graphics;
            }
        }

        private Size m_Size = Size.Empty;
        /// <summary>
        /// ��ȡ�����������⻭����С��
        /// </summary>
        public Size Size
        {
            get
            {
                return this.m_Size;
            }
        }

        #endregion


        #region ˽�з���

        /// <summary>
        /// ���´���������
        /// </summary>
        /// <returns>�����ɹ�����true,���ڴ�����ʧ�ܷ���false</returns>
        private bool RecreateBuffer()
        {
            //����״̬
            if (this.m_IsCreating)
                return false;
            this.m_IsCreating = true;

            //�����Դ
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            //�����С���
            Rectangle wndRect = new Rectangle(Point.Empty, Util.GetSize(this.m_Owner.Handle));
            if (wndRect.Width <= 0 || wndRect.Height <= 0)
            {
                this.m_IsCreating = false;
                return false;
            }

            //����������
            BufferedGraphicsContext bufferedGraphicsContext = BufferedGraphicsManager.Current;
            bufferedGraphicsContext.MaximumBuffer = wndRect.Size;

            //����
            if (this.m_BufferedGraphics != null)
                this.m_BufferedGraphics.Dispose();
            this.m_BufferedGraphics = bufferedGraphicsContext.Allocate(Graphics.FromHwndInternal(this.m_Owner.Handle), wndRect);

            //��ʼ����ͼ����
            this.InitGraphics(this.m_BufferedGraphics.Graphics);
            this.m_Size = wndRect.Size;

            //������
            this.m_IsCreating = false;
            return true;
        }

        /// <summary>
        /// ��ʼ����ͼ����
        /// </summary>
        /// <param name="g">��ͼ����</param>
        private void InitGraphics(Graphics g)
        {
            g.CompositingMode = this.m_CompositingMode;
            g.CompositingQuality = this.m_CompositingQuality;
            g.InterpolationMode = this.m_InterpolationMode;
            g.PixelOffsetMode = this.m_PixelOffsetMode;
            g.SmoothingMode = this.m_SmoothingMode;
            g.TextContrast = this.m_TextContrast;
            g.TextRenderingHint = this.m_TextRenderingHint;
        }

        #endregion


        #region ��������

        /// <summary>
        /// ��ʼ��Ⱦ
        /// </summary>
        /// <returns>�ɹ�����true,���򷵻�false</returns>
        public bool Prepare()
        {
            return (!this.IsDisposed) && (this.m_BufferedGraphics != null && this.m_Size == Util.GetSize(this.m_Owner.Handle) || this.RecreateBuffer());
        }

        /// <summary>
        /// ��Ŀ���豸�ϻ����Ⱦ
        /// </summary>
        /// <param name="g">Ŀ���豸��Ⱦ����</param>
        /// <returns>�ɹ�����true,���򷵻�false</returns>
        public void BlendRender(Graphics g)
        {
            BufferedGraphicsEx.BlendRender(this.m_BufferedGraphics, g);
        }

        /// <summary>
        /// ��Ŀ���豸�ϻ����Ⱦ
        /// </summary>
        /// <param name="e">Ŀ���豸��Ⱦ����</param>
        /// <returns>�ɹ�����true,���򷵻�false</returns>
        public void BlendRender(PaintEventArgs e)
        {
            BufferedGraphicsEx.BlendRender(this.m_BufferedGraphics, e.Graphics, e.ClipRectangle);
        }

        /// <summary>
        /// ��Ŀ���豸�ϸ�����Ⱦ
        /// </summary>
        /// <param name="g">Ŀ���豸��Ⱦ����</param>
        /// <returns>�ɹ�����true,���򷵻�false</returns>
        public void Render(Graphics g)
        {
            this.m_BufferedGraphics.Render(g);
        }

        /// <summary>
        /// ��Ŀ���豸�ϸ�����Ⱦ
        /// </summary>
        /// <param name="e">Ŀ���豸��Ⱦ����</param>
        /// <returns>�ɹ�����true,���򷵻�false</returns>
        public void Render(PaintEventArgs e)
        {
            BufferedGraphicsEx.Render(this.m_BufferedGraphics, e.Graphics, e.ClipRectangle);
        }

        #endregion


        #region �ͷ���Դ

        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        /// <param name="disposing">�ͷ��й���ԴΪtrue,����Ϊfalse</param>
        protected override void Dispose(bool disposing)
        {
            this.m_Owner = null;//ȡ������
            if (this.m_BufferedGraphics != null)
            {
                this.m_BufferedGraphics.Dispose();
                this.m_BufferedGraphics = null;
            }
        }

        #endregion
    }
}
