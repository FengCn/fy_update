using System;
using System.Drawing.Imaging;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// ��Ⱦ����
    /// </summary>
    public static partial class RenderEngine
    {
        /// <summary>
        /// ��ɫͼ�����
        /// </summary>
        [ThreadStatic]
        private static ImageAttributes m_DisabledImageAttr;
    }
}
