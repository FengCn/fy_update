using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.Windows.Forms
{
    partial class Sprite
    {
        private Graphics m_Graphics;
        private Region m_GraphicsClip;

        /// <summary>
        /// ��ʼ��Ⱦ
        /// </summary>
        public void BeginRender(Graphics g)
        {
            this.DisposeReferences();
            this.m_Graphics = g;
            this.m_GraphicsClip = g.Clip;
            //���ڴ�ʱδ�� BackColorRect ��ֵ.���Բ������ü�����,������ m_CurrentBackColorPathRect ʱ���ü�����
        }

        /// <summary>
        /// ������Ⱦ
        /// </summary>
        public void EndRender()
        {
            this.m_Graphics.SetClip(this.m_GraphicsClip, CombineMode.Replace);
            this.m_GraphicsClip.Dispose();
            this.m_GraphicsClip = null;
        }
    }
}
