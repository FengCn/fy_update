namespace Microsoft
{
    /// <summary>
    /// �����жϷ������Դ�Ƿ��Ѿ��ͷŵ����Խӿ�.
    /// Copyright (c) JajaSoft
    /// </summary>
    public interface IDisposeState
    {
        /// <summary>
        /// �������Դ�Ƿ������ͷ�
        /// </summary>
        bool Disposing
        {
            get;
        }

        /// <summary>
        /// �������Դ�Ƿ��Ѿ��ͷ�
        /// </summary>
        bool IsDisposed
        {
            get;
        }

        /// <summary>
        /// ����Ƿ����ͷ���Դ,������ͷ���Դ���׳��쳣
        /// </summary>
        void CheckDisposed();
    }
}
