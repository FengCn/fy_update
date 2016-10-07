using System;

namespace Microsoft.Windows.Forms
{
    /// <summary>
    /// �߽�������ʽ��
    /// </summary>
    [Flags]
    public enum CornerStyle : int
    {
        /// <summary>
        /// Ĭ����ʽ
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// ���Ͻ�,���½����ڲ�����
        /// </summary>
        LeftIn = 0x0001,
        /// <summary>
        /// ���Ͻ�,���Ͻ����ڲ�����
        /// </summary>
        TopIn = 0x0002,
        /// <summary>
        /// ���Ͻ�,���½����ڲ�����
        /// </summary>
        RightIn = 0x0004,
        /// <summary>
        /// ���½�,���½����ڲ�����
        /// </summary>
        BottomIn = 0x0008,

        /// <summary>
        /// ���Ͻ�,���½����ⲿ����
        /// </summary>
        LeftOut = 0x0010,
        /// <summary>
        /// ���Ͻ�,���Ͻ����ⲿ����
        /// </summary>
        TopOut = 0x0020,
        /// <summary>
        /// ���Ͻ�,���½����ⲿ����
        /// </summary>
        RightOut = 0x0040,
        /// <summary>
        /// ���½�,���½����ⲿ����
        /// </summary>
        BottomOut = 0x0080,

        /// <summary>
        /// ˮƽ(LeftIn|RightIn|LeftOut|RightOut)
        /// </summary>
        Horizontal = 0x0055,
        /// <summary>
        /// ��ֱ(TopIn|BottomIn|TopOut|BottomOut)
        /// </summary>
        Vertical = 0x00AA,
    }
}
