using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// �ı���Ӱ�����ʽ
    /// </summary>
    [Flags]
    public enum ShadowShapeStyle : int
    {
        /// <summary>
        /// ��
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// ��Ӱ
        /// </summary>
        Shadow = 0x0001,
        /// <summary>
        /// ��Ӱ���
        /// </summary>
        ShapeOfShadow = 0x0002,
        /// <summary>
        /// �ı����
        /// </summary>
        ShapeOfText = 0x0004,
        /// <summary>
        /// ȫ��
        /// </summary>
        All = 0x0007,
    }
}
