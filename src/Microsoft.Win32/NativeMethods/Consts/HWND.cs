using System;

namespace Microsoft.Win32
{
    //HWND����
    public static partial class NativeMethods
    {
        /// <summary>
        /// ���洰�ھ��  �μ�MapWindowPoints
        /// </summary>
        public static readonly IntPtr HWND_DESKTOP = IntPtr.Zero;

        /// <summary>
        /// ����������Z��Ķ����� �μ�SetWindowPos
        /// </summary>
        public static readonly IntPtr HWND_TOP = IntPtr.Zero;
        /// <summary>
        /// ����������Z��ĵײ����������hWnd��ʶ��һ�����㴰�ڣ��򴰿�ʧȥ����λ�ã����ұ������������ڵĵײ��� �μ�SetWindowPos
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        /// <summary>
        /// �������������зǶ��㴰��֮�ϡ���ʹ����δ�������Ҳ�����ֶ���λ�á� �μ�SetWindowPos
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        /// <summary>
        /// �������������зǶ��㴰��֮�ϣ��������ж��㴰��֮�󣩡���������Ѿ��ǷǶ��㴰����ñ�־�������á� �μ�SetWindowPos
        /// </summary>
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        /// <summary>
        /// ��Ϣ�����͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ� �����ǵĴ��ں͵���ʽ���ڡ���Ϣ�������͵��Ӵ���  �μ�PostMessage
        /// </summary>
        public static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);
        /// <summary>
        /// ���hwndParent��HWND_MESSAGE������������������Ϣ���ڡ� �μ�FindWindowEx
        /// </summary>
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);
    }
}
