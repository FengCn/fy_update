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
        /// �ƽ�ָ����
        /// </summary>
        private const float GOLDEN_RATIO = 0.618033988749895f;

        /// <summary>
        /// �����ɫ,Hue ��ʼֵ
        /// </summary>
        [ThreadStatic]
        private static float? RANDOM_COLOR_HUE;

        /// <summary>
        /// ��ɫͼ�����
        /// </summary>
        [ThreadStatic]
        private static ImageAttributes m_DisabledImageAttr;
    }
}
