using System;

namespace Microsoft.Win32
{
    /// <summary>
    /// Util
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// ��ȡ�з��ŵ�16λ����
        /// </summary>
        /// <param name="lParam">���</param>
        /// <returns>�з��ŵ�16λ����</returns>
        public static int GET_X_LPARAM(IntPtr lParam)
        {
            return LOWORD(lParam);
        }
        /// <summary>
        /// ��ȡ�з��Ÿ�ʮ��λ����
        /// </summary>
        /// <param name="lParam">���</param>
        /// <returns>�з��Ÿ�ʮ��λ����</returns>
        public static int GET_Y_LPARAM(IntPtr lParam)
        {
            return HIWORD(lParam);
        }


        /// <summary>
        /// ��ȡ�޷��Ÿ�8λ����
        /// </summary>
        /// <param name="wValue">�޷���16λ����</param>
        /// <returns>�޷��Ÿ�8λ����</returns>
        public static byte HIBYTE(ushort wValue)
        {
            return (byte)((wValue >> 0x8) & 0xff);
        }
        /// <summary>
        /// ��ȡ�޷��ŵ�8λ����
        /// </summary>
        /// <param name="wValue">�޷���16λ����</param>
        /// <returns>�޷��ŵ�8λ����</returns>
        public static byte LOBYTE(ushort wValue)
        {
            return (byte)(wValue & 0xff);
        }
        /// <summary>
        /// ��ȡ�޷��Ÿ�16λ����
        /// </summary>
        /// <param name="dwValue">�޷���32λ����</param>
        /// <returns>�޷��Ÿ�16λ����</returns>
        public static ushort HIWORD(uint dwValue)
        {
            return (ushort)((dwValue >> 0x10) & 0xffff);
        }
        /// <summary>
        /// ��ȡ�޷��ŵ�16λ����
        /// </summary>
        /// <param name="dwValue">�޷���32λ����</param>
        /// <returns>�޷��ŵ�16λ����</returns>
        public static ushort LOWORD(uint dwValue)
        {
            return (ushort)(dwValue & 0xffff);
        }


        /// <summary>
        /// �������޷���8λ�����ϲ�Ϊһ���޷���16λ����
        /// </summary>
        /// <param name="bLow">�޷��ŵ�8λ����</param>
        /// <param name="bHigh">�޷��Ÿ�8λ����</param>
        /// <returns>�޷���16λ����</returns>
        public static ushort MAKEWORD(byte bLow, byte bHigh)
        {
            return (ushort)((((ushort)bHigh) << 0x8) | ((ushort)(bLow & 0xff)));
        }
        /// <summary>
        /// �������޷���16λ�����ϲ�Ϊһ���޷���32λ����
        /// </summary>
        /// <param name="wLow">�޷��ŵ�16λ����</param>
        /// <param name="wHigh">�޷��Ÿ�16λ����</param>
        /// <returns>�޷���32λ����</returns>
        public static uint MAKELONG(ushort wLow, ushort wHigh)
        {
            return ((((uint)wHigh) << 0x10) | ((uint)(wLow & 0xffff)));
        }
        /// <summary>
        /// �������޷���16λ�����ϲ�Ϊһ���з���32λ����
        /// </summary>
        /// <param name="wLow">�޷��ŵ�16λ����</param>
        /// <param name="wHigh">�޷��Ÿ�16λ����</param>
        /// <returns>�з���32λ����</returns>
        public static int MAKELPARAM(ushort wLow, ushort wHigh)
        {
            return (int)MAKELONG(wLow, wHigh);
        }
        /// <summary>
        /// �������޷���16λ�����ϲ�Ϊһ���з���32λ����
        /// </summary>
        /// <param name="wLow">�޷��ŵ�16λ����</param>
        /// <param name="wHigh">�޷��Ÿ�16λ����</param>
        /// <returns>�з���32λ����</returns>
        public static int MAKEWPARAM(ushort wLow, ushort wHigh)
        {
            return (int)MAKELONG(wLow, wHigh);
        }
        /// <summary>
        /// �������޷���16λ�����ϲ�Ϊһ���з��ž��
        /// </summary>
        /// <param name="wLow">�޷��ŵ�16λ����</param>
        /// <param name="wHigh">�޷��Ÿ�16λ����</param>
        /// <returns>�з��ž��</returns>
        public static IntPtr MAKELRESULT(ushort wLow, ushort wHigh)
        {
            return (IntPtr)MAKELONG(wLow, wHigh);
        }


        /// <summary>
        /// ��ȡ�޷��Ÿ�16λ����
        /// </summary>
        /// <param name="n">32λ�з�������</param>
        /// <returns>�޷��Ÿ�16λ����</returns>
        public static int HIWORD(int n)
        {
            return ((n >> 0x10) & 0xffff);
        }
        /// <summary>
        /// ��ȡ�޷��Ÿ�16λ����
        /// </summary>
        /// <param name="n">���</param>
        /// <returns>�޷��Ÿ�16λ����</returns>
        public static int HIWORD(IntPtr n)
        {
            return HIWORD((int)((long)n));
        }
        /// <summary>
        /// ��ȡ�޷��ŵ�16λ����
        /// </summary>
        /// <param name="n">32λ�з�������</param>
        /// <returns>�޷��ŵ�16λ����</returns>
        public static int LOWORD(int n)
        {
            return (n & 0xffff);
        }
        /// <summary>
        /// ��ȡ�޷��ŵ�16λ����
        /// </summary>
        /// <param name="n">���</param>
        /// <returns>�޷��ŵ�16λ����</returns>
        public static int LOWORD(IntPtr n)
        {
            return LOWORD((int)((long)n));
        }
        /// <summary>
        /// ��ȡ�з��Ÿ�16λ����
        /// </summary>
        /// <param name="n">32λ�з�������</param>
        /// <returns>�з��Ÿ�16λ����</returns>
        public static int SignedHIWORD(int n)
        {
            return (short)((n >> 0x10) & 0xffff);
        }
        /// <summary>
        /// ��ȡ�з��Ÿ�16λ����
        /// </summary>
        /// <param name="n">���</param>
        /// <returns>�з��Ÿ�16λ����</returns>
        public static int SignedHIWORD(IntPtr n)
        {
            return SignedHIWORD((int)((long)n));
        }
        /// <summary>
        /// ��ȡ�з��ŵ�16λ����
        /// </summary>
        /// <param name="n">32λ�з�������</param>
        /// <returns>�з��ŵ�16λ����</returns>
        public static int SignedLOWORD(int n)
        {
            return (short)(n & 0xffff);
        }
        /// <summary>
        /// ��ȡ�з��ŵ�16λ����
        /// </summary>
        /// <param name="n">���</param>
        /// <returns>�з��ŵ�16λ����</returns>
        public static int SignedLOWORD(IntPtr n)
        {
            return SignedLOWORD((int)((long)n));
        }


        /// <summary>
        /// ������16λ�����ϲ�Ϊһ��32λ����
        /// </summary>
        /// <param name="low">��16λ����</param>
        /// <param name="high">��16Ϊ����</param>
        /// <returns>32λ����</returns>
        public static int MAKELONG(int low, int high)
        {
            return ((high << 0x10) | (low & 0xffff));
        }
        /// <summary>
        /// ������16λ�����ϲ�Ϊ���
        /// </summary>
        /// <param name="low">��16λ����</param>
        /// <param name="high">��16Ϊ����</param>
        /// <returns>LParam</returns>
        public static IntPtr MAKELPARAM(int low, int high)
        {
            return (IntPtr)((high << 0x10) | (low & 0xffff));
        }
    }
}
