using System;

namespace Microsoft
{
    /// <summary>
    /// �������Դ�ͷ��¼��ӿ�
    /// </summary>
    public interface IDisposed
    {
        /// <summary>
        /// ��Դ�ͷ��¼�
        /// </summary>
        event EventHandler Disposed;
    }
}
