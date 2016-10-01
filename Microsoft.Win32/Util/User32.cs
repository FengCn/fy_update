using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Win32
{
    /// <summary>
    /// User32��չ
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// ��ʼ����,��ֹ�ؼ��ػ�
        /// </summary>
        /// <param name="hWnd">�ؼ����</param>
        public static void BeginUpdate(IntPtr hWnd)
        {
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_SETREDRAW, 0, 0);
        }
        /// <summary>
        /// ��ʼ����,����ؼ��ػ�
        /// </summary>
        /// <param name="hWnd">�ؼ����</param>
        public static void EndUpdate(IntPtr hWnd)
        {
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_SETREDRAW, 1, 0);
        }

        /// <summary>
        /// ��ʼ�϶�����
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        public static void BeginDrag(IntPtr hWnd)
        {
            UnsafeNativeMethods.ReleaseCapture();
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_SYSCOMMAND, NativeMethods.SC_MOVE | NativeMethods.HTCAPTION, 0);
        }

        /// <summary>
        /// ��ָ����������ڰ������,���ȴ���Ϣ���������������
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="pt">����ڴ��ڵĵ�</param>
        public static void PostMouseDown(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_MOUSEMOVE, IntPtr.Zero, lParam);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, lParam);
        }
        /// <summary>
        /// ��ָ����������ڵ������,���ȴ���Ϣ���������������
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="pt">����ڴ��ڵĵ�</param>
        public static void PostMouseUp(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
        }
        /// <summary>
        /// ��ָ����������ڵ������,���ȴ���Ϣ���������������
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="pt">����ڴ��ڵĵ�</param>
        public static void PostMouseClick(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_MOUSEMOVE, IntPtr.Zero, lParam);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, lParam);
            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
        }

        /// <summary>
        /// ��ָ����������ڰ������,�ȴ���Ϣ������ɺ��ٷ���
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="pt">����ڴ��ڵĵ�</param>
        public static void SendMouseDown(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_MOUSEMOVE, IntPtr.Zero, lParam);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, lParam);
        }
        /// <summary>
        /// ��ָ����������ڵ������,�ȴ���Ϣ������ɺ��ٷ���
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="pt">����ڴ��ڵĵ�</param>
        public static void SendMouseUp(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
        }
        /// <summary>
        /// ��ָ����������ڵ������,�ȴ���Ϣ������ɺ��ٷ���
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="pt">����ڴ��ڵĵ�</param>
        public static void SendMouseClick(IntPtr hWnd, Point pt)
        {
            IntPtr lParam = Util.MAKELPARAM(pt.X, pt.Y);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_MOUSEMOVE, IntPtr.Zero, lParam);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, lParam);
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
        }

        /// <summary>
        /// ���¼��̼�
        /// </summary>
        /// <param name="vKey">�������</param>
        public static void SendKeyDown(short vKey)
        {
            NativeMethods.INPUT[] input = new NativeMethods.INPUT[1];
            input[0].type = NativeMethods.INPUT_KEYBOARD;
            input[0].ki.wVk = vKey;
            input[0].ki.time = UnsafeNativeMethods.GetTickCount();

            if (UnsafeNativeMethods.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
            {
                //throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
        /// <summary>
        /// ������̼�
        /// </summary>
        /// <param name="vKey">�������</param>
        public static void SendKeyUp(short vKey)
        {
            NativeMethods.INPUT[] input = new NativeMethods.INPUT[1];
            input[0].type = NativeMethods.INPUT_KEYBOARD;
            input[0].ki.wVk = vKey;
            input[0].ki.dwFlags = NativeMethods.KEYEVENTF_KEYUP;
            input[0].ki.time = UnsafeNativeMethods.GetTickCount();

            if (UnsafeNativeMethods.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0])) < input.Length)
            {
                //throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
        /// <summary>
        /// ��һ�²�������̼�
        /// </summary>
        /// <param name="vKey">�������</param>
        public static void SendKeyClick(short vKey)
        {
            SendKeyDown(vKey);
            SendKeyUp(vKey);
        }

        /// <summary>
        /// ��ʾ�����ع��.
        /// </summary>
        /// <param name="visible">��ʾΪtrue,����Ϊfalse.</param>
        public static void ShowCursor(bool visible)
        {
            if (visible)
            {
                while (UnsafeNativeMethods.ShowCursor(true) < 0) { }
            }
            else
            {
                while (UnsafeNativeMethods.ShowCursor(false) >= 0) { }
            }
        }
        /// <summary>
        /// ��ȡ����Ƿ���ʾ.��ʾΪtrue,����Ϊfalse.
        /// </summary>
        public static bool GetCursorVisible()
        {
            UnsafeNativeMethods.ShowCursor(false);
            return UnsafeNativeMethods.ShowCursor(true) >= 0;
        }

        /// <summary>
        /// ��ȡָ�����ڵ������ߴ��ڡ�
        /// </summary>
        /// <param name="hWnd">ָ�����ڡ�</param>
        /// <returns>�����ߴ��ڡ�</returns>
        public static IntPtr GetOwner(IntPtr hWnd)
        {
            return UnsafeNativeMethods.GetWindow(hWnd, NativeMethods.GW_OWNER);
        }
        /// <summary>
        /// Ϊָ�����������µĵ������ߴ��ڡ�
        /// </summary>
        /// <param name="hWnd">ָ�����ڡ�</param>
        /// <param name="hWndNewOwner">�µ������ߴ��ڡ�</param>
        public static void SetOwner(IntPtr hWnd, IntPtr hWndNewOwner)
        {
            UnsafeNativeMethods.SetWindowLong(hWnd, NativeMethods.GWL_HWNDPARENT, (int)hWndNewOwner);
        }
        /// <summary>
        /// ��ȡָ�����ڵĸ����ڡ�
        /// </summary>
        /// <param name="hWnd">ָ�����ڡ�</param>
        /// <returns>�����ڡ�</returns>
        public static IntPtr GetParent(IntPtr hWnd)
        {
            return UnsafeNativeMethods.GetAncestor(hWnd, NativeMethods.GA_PARENT);
        }
        /// <summary>
        /// Ϊָ�����������µĸ����ڡ�
        /// </summary>
        /// <param name="hWnd">ָ�����ڡ�</param>
        /// <param name="hWndNewParent">�µĸ����ڡ�</param>
        public static void SetParent(IntPtr hWnd, IntPtr hWndNewParent)
        {
            UnsafeNativeMethods.SetParent(hWnd, hWndNewParent);
        }

        /// <summary>
        /// ��ȡָ�����ڰ����Ĺ�������
        /// </summary>
        /// <param name="hWnd">���ھ����</param>
        /// <returns>����ֵ�� System.Windows.Forms.ScrollBars ����</returns>
        public static int GetScrollBars(IntPtr hWnd)
        {
            int wndStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE);
            bool hsVisible = (wndStyle & NativeMethods.WS_HSCROLL) != 0;
            bool vsVisible = (wndStyle & NativeMethods.WS_VSCROLL) != 0;

            if (hsVisible)
                return vsVisible ? 3 : 1;
            else
                return vsVisible ? 2 : 0;
        }
        /// <summary>
        /// ��ȡָ�������Ƿ������������ʽ��
        /// </summary>
        /// <param name="hWnd">���ھ����</param>
        /// <returns>���������������ʽ���� true�����򷵻� false��</returns>
        public static bool GetLeftScrollBar(IntPtr hWnd)
        {
            int wndExStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_EXSTYLE);
            return (wndExStyle & NativeMethods.WS_EX_LEFTSCROLLBAR) != 0;
        }
        /// <summary>
        /// ��ȡָ�����ڱ߿��ȡ�
        /// </summary>
        /// <param name="hWnd">���ھ����</param>
        /// <returns>���ڱ߿��ȡ�</returns>
        public static int GetBorderWidth(IntPtr hWnd)
        {
            int wndExStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_EXSTYLE);
            if ((wndExStyle & NativeMethods.WS_EX_STATICEDGE) != 0)
                return 3;
            else if ((wndExStyle & NativeMethods.WS_EX_WINDOWEDGE) != 0)
                return 2;
            else if ((wndExStyle & NativeMethods.WS_EX_CLIENTEDGE) != 0)
                return 2;
            else if ((UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE) & NativeMethods.WS_BORDER) != 0)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// �� GDI+ Region ����һ�� GDI Region��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="region">System.Drawing.Region ����</param>
        /// <returns>GDI Region �����</returns>
        public static IntPtr GetHRgn(IntPtr hWnd, Region region)
        {
            using (Graphics g = Graphics.FromHwndInternal(hWnd))
            {
                return region.GetHrgn(g);
            }
        }
        /// <summary>
        /// ��ȡ���ڵĿͻ�������ڴ������Ͻǵľ���.(�ر�ע��:����зǿͻ������һ�㲻Ϊ0,0 ���û�зǿͻ�����ֵͬClientRectangle���).�ú����ǳ��ر�����Ҫ����,�ڷǿͻ�������ʱ����ʹ�õ�,������������ѯ��д��Ա. by Tim 2013.11.23
        /// </summary>
        /// <param name="hWnd">ָ�����ھ��</param>
        /// <returns>�ͻ�������ڴ�������ϵ������ʹ�С</returns>
        public static NativeMethods.RECT GetClientRect(IntPtr hWnd)
        {
            NativeMethods.RECT wndRect = new NativeMethods.RECT();//�����������Ļ������ʹ�С
            NativeMethods.RECT clientRect = new NativeMethods.RECT();//��0,0��ʼ�Ŀͻ�������ʹ�С

            UnsafeNativeMethods.GetWindowRect(hWnd, ref wndRect);//����
            UnsafeNativeMethods.GetClientRect(hWnd, ref clientRect);//�ͻ���
            UnsafeNativeMethods.MapWindowPoints(hWnd, NativeMethods.HWND_DESKTOP, ref clientRect, 2);//�ͻ���ӳ�䵽��Ļ

            //ƫ��
            clientRect.left -= wndRect.left;
            clientRect.top -= wndRect.top;
            clientRect.right -= wndRect.left;
            clientRect.bottom -= wndRect.top;

            //����
            return clientRect;
        }

        /// <summary>
        /// ��˸ָ�����ڡ�
        /// </summary>
        /// <param name="hWnd">ָ�����ھ����</param>
        /// <param name="count">��˸������</param>
        /// <returns>������˸ǰ�����Ƿ��ѱ����</returns>
        public static bool FlashWindow(IntPtr hWnd, int count)
        {
            NativeMethods.FLASHWINFO fwi = new NativeMethods.FLASHWINFO();
            fwi.cbSize = Marshal.SizeOf(fwi);
            fwi.hwnd = hWnd;
            fwi.dwFlags = NativeMethods.FLASHW_TRAY;
            fwi.uCount = count;
            fwi.dwTimeout = 0;
            return UnsafeNativeMethods.FlashWindowEx(ref fwi);
        }


        #region ��չ

        /// <summary>
        /// �������ö�
        /// </summary>
        /// <param name="lpClassName">��������</param>
        /// <param name="lpWindowName">���ڱ���</param>
        public static void BringToFront(string lpClassName, string lpWindowName)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(lpClassName, lpWindowName);
            if (hWnd != IntPtr.Zero)
                UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_TOP, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE);
        }

        /// <summary>
        /// �������õ�
        /// </summary>
        /// <param name="lpClassName">��������</param>
        /// <param name="lpWindowName">���ڱ���</param>
        public static void SendToBack(string lpClassName, string lpWindowName)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(lpClassName, lpWindowName);
            if (hWnd != IntPtr.Zero)
                UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_BOTTOM, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE);
        }

        /// <summary>
        /// �����,��ָ�����ڷ���WM_COPYDATA��Ϣ
        /// </summary>
        /// <param name="lpWindowName">���ڱ���</param>
        /// <param name="flag">���ֱ��</param>
        /// <param name="data">Ҫ���͵��ַ�������</param>
        public static void SendCopyData(string lpWindowName, int flag, string data)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            byte[] arr = Encoding.UTF8.GetBytes(data);
            NativeMethods.COPYDATASTRUCT cds = new NativeMethods.COPYDATASTRUCT();
            cds.dwData = flag;
            cds.cbData = arr.Length + 1;
            cds.lpData = data;
            UnsafeNativeMethods.SendMessage(hWnd, NativeMethods.WM_COPYDATA, IntPtr.Zero, ref cds);
        }

        /// <summary>
        /// ��ָ������Ĵ��ڷ���WM_CLOSE��Ϣ
        /// </summary>
        /// <param name="lpWindowName">���ڱ���</param>
        public static void CloseWindow(string lpWindowName)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, NativeMethods.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// ���ô�����ʾ״̬
        /// </summary>
        /// <param name="lpWindowName">���ڱ���</param>
        /// <param name="nCmdShow">��ʾָ��</param>
        public static void ShowWindow(string lpWindowName, int nCmdShow)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.ShowWindow(hWnd, nCmdShow);
        }

        /// <summary>
        /// ���ÿؼ�TopMost(ʹ���ڳ�Ϊ��TopMost�����͵Ĵ��ڣ��������͵Ĵ����������������ڵ�ǰ��)
        /// </summary>
        /// <param name="hWnd">Ҫ���õĴ���</param>
        public static void SetTopMost(IntPtr hWnd)
        {
            try
            {
                UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_TOPMOST, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOACTIVATE);
            }
            catch
            {
            }
        }

        /// <summary>
        /// ���ÿؼ�NoTopMost(�����ڷ������С�TopMost�����ʹ��ڵĺ���,�������ʹ��ڵ�ǰ��)
        /// </summary>
        /// <param name="hWnd">Ҫ���õĴ���</param>
        public static void SetNoTopMost(IntPtr hWnd)
        {
            try
            {
                UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_NOTOPMOST, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOACTIVATE);
            }
            catch
            {
            }
        }

        /// <summary>
        /// ���ô��ڵ�ӵ�д���,���Կ����
        /// </summary>
        /// <param name="child"></param>
        /// <param name="lpParentWindowName"></param>
        public static void SetOwner(Control child, string lpParentWindowName)
        {
            IntPtr hWndNewParent = UnsafeNativeMethods.FindWindow(null, lpParentWindowName);
            if (hWndNewParent != IntPtr.Zero)
                SetOwner(child.Handle, hWndNewParent);
        }

        /// <summary>
        /// ���ô��ڵ�ӵ�д���,���Կ����
        /// </summary>
        /// <param name="lpChildWindowName"></param>
        /// <param name="parent"></param>
        public static void SetOwner(string lpChildWindowName, Control parent)
        {
            IntPtr hWndChild = UnsafeNativeMethods.FindWindow(null, lpChildWindowName);
            if (hWndChild != IntPtr.Zero)
                SetOwner(hWndChild, parent.Handle);
        }

        /// <summary>
        /// �����,��ָ�����ڷ���ָ����Ϣ,��������
        /// </summary>
        /// <param name="lpWindowName">���ڱ���</param>
        /// <param name="msg">��Ϣ</param>
        /// <param name="lParam">lParam</param>
        public static void PostMessage(string lpWindowName, int msg, int lParam)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, msg, IntPtr.Zero, (IntPtr)lParam);
        }

        /// <summary>
        /// �����,��ָ�����ڷ���ָ����Ϣ,��������
        /// </summary>
        /// <param name="lpWindowName">���ڱ���</param>
        /// <param name="msg">��Ϣ</param>
        /// <param name="wParam">wParm</param>
        /// <param name="lParam">lParm</param>
        public static void PostMessage(string lpWindowName, int msg, int wParam, int lParam)
        {
            IntPtr hWnd = UnsafeNativeMethods.FindWindow(null, lpWindowName);
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, msg, (IntPtr)wParam, (IntPtr)lParam);
        }

        /// <summary>
        /// �����,��ָ�����ڷ���ָ����Ϣ,��������
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="msg">��Ϣ</param>
        /// <param name="lParam">lParam</param>
        public static void PostMessage(IntPtr hWnd, int msg, int lParam)
        {
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, msg, IntPtr.Zero, (IntPtr)lParam);
        }

        /// <summary>
        /// �����,��ָ�����ڷ���ָ����Ϣ,��������
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="msg">��Ϣ</param>
        /// <param name="wParam">wParam</param>
        /// <param name="lParam">lParam</param>
        public static void PostMessage(IntPtr hWnd, int msg, int wParam, int lParam)
        {
            if (hWnd == IntPtr.Zero)
                return;

            UnsafeNativeMethods.PostMessage(hWnd, msg, (IntPtr)wParam, (IntPtr)lParam);
        }

        #endregion


        #region ����

        /// <summary>
        /// �� lParam ��ȡ����
        /// </summary>
        /// <param name="lParam">��Ϣ�е� lParam ����</param>
        /// <returns>�����Դ�������</returns>
        public static Point GetMousePosition(IntPtr lParam)
        {
            return new Point(GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam));
        }
        /// <summary>
        /// ��ȡ�ÿؼ������½�����������������Ͻǵ����ꡣ
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>System.Drawing.Point������ʾ�ؼ������½�����������������Ͻǡ�</returns>
        public static Point GetBottomRight(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetWindowRect(hWnd, ref lpRect);
            NativeMethods.POINT pt = new NativeMethods.POINT(lpRect.bottom, lpRect.right);

            //�����ڲ�Ϊ��ת������
            IntPtr hWndParent = GetParent(hWnd);
            if (hWndParent != IntPtr.Zero)
                UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWndParent, ref pt, 1);

            return new Point(pt.x, pt.y);
        }
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�Ƿ񽫿ؼ���ʾΪ�������ڡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>���Ϊ true���򽫿ؼ���ʾΪ�������ڣ�����Ϊ false��</returns>
        public static bool GetTopLevel(IntPtr hWnd)
        {
            int dwStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE);
            return ((dwStyle & NativeMethods.WS_CHILD) == 0);
        }
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�ؼ��Ƿ������������ľ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>����Ѿ�Ϊ�ؼ������˾������Ϊ true������Ϊ false��</returns>
        public static bool GetIsHandleCreated(IntPtr hWnd)
        {
            return (hWnd != IntPtr.Zero);
        }
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�Ƿ���ʾ�ÿؼ��������и��ؼ���
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>�����ʾ�ÿؼ��������и��ؼ�����Ϊ true������Ϊ false��Ĭ��Ϊ true��</returns>
        public static bool GetVisible(IntPtr hWnd)
        {
            return UnsafeNativeMethods.IsWindowVisible(hWnd);
        }
        /// <summary>
        /// ����һ��ֵ����ֵָʾ�Ƿ���ʾ�ÿؼ��������и��ؼ���
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">�����ʾ�ÿؼ��������и��ؼ�����Ϊ true������Ϊ false��Ĭ��Ϊ true��</param>
        public static void SetVisible(IntPtr hWnd, bool value)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE | (value ? NativeMethods.SWP_SHOWWINDOW : NativeMethods.SWP_HIDEWINDOW));
        }
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�ؼ��Ƿ���Զ��û�����������Ӧ��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>����ؼ����Զ��û�����������Ӧ����Ϊ true������Ϊ false��Ĭ��Ϊ true��</returns>
        public static bool GetEnabled(IntPtr hWnd)
        {
            return UnsafeNativeMethods.IsWindowEnabled(hWnd);
        }
        /// <summary>
        /// ����һ��ֵ����ֵָʾ�ؼ��Ƿ���Զ��û�����������Ӧ��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">����ؼ����Զ��û�����������Ӧ����Ϊ true������Ϊ false��Ĭ��Ϊ true��</param>
        public static void SetEnabled(IntPtr hWnd, bool value)
        {
            UnsafeNativeMethods.EnableWindow(hWnd, value);
        }
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�ؼ��Ƿ������뽹�㡣
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>����ؼ��н��㣬��Ϊ true������Ϊ false��</returns>
        public static bool GetFocused(IntPtr hWnd)
        {
            return (GetIsHandleCreated(hWnd) && (UnsafeNativeMethods.GetFocus() == hWnd));
        }
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�ؼ��Ƿ���Խ��ս��㡣
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>����ؼ����Խ��ս��㣬��Ϊ true������Ϊ false��</returns>
        public static bool GetCanFocus(IntPtr hWnd)
        {
            if (!GetIsHandleCreated(hWnd))
                return false;

            return UnsafeNativeMethods.IsWindowVisible(hWnd) && UnsafeNativeMethods.IsWindowEnabled(hWnd);
        }
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�ؼ�������һ���ӿؼ���ǰ�Ƿ������뽹�㡣
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>����ؼ�������һ���ӿؼ���ǰ�Ѿ������뽹�㣬��Ϊ true������Ϊ false��</returns>
        public static bool GetContainsFocus(IntPtr hWnd)
        {
            if (!GetIsHandleCreated(hWnd))
                return false;

            IntPtr focus = UnsafeNativeMethods.GetFocus();
            if (focus == IntPtr.Zero)
                return false;

            return ((focus == hWnd) || UnsafeNativeMethods.IsChild(hWnd, focus));
        }
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�ؼ��Ƿ��Ѳ�����ꡣ
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>����ؼ��Ѳ�����꣬��Ϊ true������Ϊ false��</returns>
        public static bool GetCapture(IntPtr hWnd)
        {
            return (GetIsHandleCreated(hWnd) && (UnsafeNativeMethods.GetCapture() == hWnd));
        }
        /// <summary>
        /// ����һ��ֵ����ֵָʾ�ؼ��Ƿ��Ѳ�����ꡣ
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">����ؼ��Ѳ�����꣬��Ϊ true������Ϊ false��</param>
        public static void SetCapture(IntPtr hWnd, bool value)
        {
            if (value)
                UnsafeNativeMethods.SetCapture(hWnd);
            else
                UnsafeNativeMethods.ReleaseCapture();
        }
        /// <summary>
        /// ��ȡ�ÿؼ������Ͻ�����������������Ͻǵ����ꡣ
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>System.Drawing.Point������ʾ�ؼ������Ͻ�����������������Ͻǡ�</returns>
        public static Point GetLocation(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetWindowRect(hWnd, ref lpRect);
            NativeMethods.POINT pt = new NativeMethods.POINT(lpRect.left, lpRect.top);

            //�����ڲ�Ϊ��ת������
            IntPtr hWndParent = GetParent(hWnd);
            if (hWndParent != IntPtr.Zero)
                UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWndParent, ref pt, 1);

            return new Point(pt.x, pt.y);
        }
        /// <summary>
        /// ���øÿؼ������Ͻ�����������������Ͻǵ����ꡣ
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">System.Drawing.Point������ʾ�ؼ������Ͻ�����������������Ͻǡ�</param>
        public static void SetLocation(IntPtr hWnd, Point value)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, IntPtr.Zero, value.X, value.Y, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);
        }
        /// <summary>
        /// ��ȡ�ؼ��ĸ߶ȺͿ�ȡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>System.Drawing.Size����ʾ�ؼ��ĸ߶ȺͿ�ȣ�������Ϊ��λ����</returns>
        public static Size GetSize(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetWindowRect(hWnd, ref lpRect);
            return lpRect.Size;
        }
        /// <summary>
        /// ���ÿؼ��ĸ߶ȺͿ�ȡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">System.Drawing.Size����ʾ�ؼ��ĸ߶ȺͿ�ȣ�������Ϊ��λ����</param>
        public static void SetSize(IntPtr hWnd, Size value)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, value.Width, value.Height, NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);
        }
        /// <summary>
        /// ��ȡ�ؼ���������ǹ�����Ԫ�أ�������丸�ؼ��Ĵ�С��λ�ã�������Ϊ��λ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>����ڸ��ؼ��� System.Drawing.Rectangle����ʾ�ؼ���������ǹ�����Ԫ�أ��Ĵ�С��λ�ã�������Ϊ��λ����</returns>
        public static Rectangle GetBounds(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetWindowRect(hWnd, ref lpRect);

            //�����ڲ�Ϊ��ת������
            IntPtr hWndParent = GetParent(hWnd);
            if (hWndParent != IntPtr.Zero)
                UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWndParent, ref lpRect, 2);

            return lpRect.ToRectangle();
        }
        /// <summary>
        /// ���ÿؼ���������ǹ�����Ԫ�أ�������丸�ؼ��Ĵ�С��λ�ã�������Ϊ��λ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">����ڸ��ؼ��� System.Drawing.Rectangle����ʾ�ؼ���������ǹ�����Ԫ�أ��Ĵ�С��λ�ã�������Ϊ��λ����</param>
        public static void SetBounds(IntPtr hWnd, Rectangle value)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, IntPtr.Zero, value.X, value.Y, value.Width, value.Height, NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);
        }
        /// <summary>
        /// ��ȡ�ؼ����Ե���������Ĺ��������Ե֮��ľ��루������Ϊ��λ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>System.Int32 ��ʾ�ؼ����Ե���������Ĺ��������Ե֮��ľ��루������Ϊ��λ����</returns>
        public static int GetLeft(IntPtr hWnd)
        {
            return GetLocation(hWnd).X;
        }
        /// <summary>
        /// ���ÿؼ����Ե���������Ĺ��������Ե֮��ľ��루������Ϊ��λ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">System.Int32 ��ʾ�ؼ����Ե���������Ĺ��������Ե֮��ľ��루������Ϊ��λ����</param>
        public static void SetLeft(IntPtr hWnd, int value)
        {
            Point pt = GetLocation(hWnd);
            pt.X = value;
            SetLocation(hWnd, pt);
        }
        /// <summary>
        /// ��ȡ�ؼ��ϱ�Ե���������Ĺ������ϱ�Ե֮��ľ��루������Ϊ��λ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>System.Int32 ��ʾ�ؼ��±�Ե���������Ĺ������ϱ�Ե֮��ľ��루������Ϊ��λ����</returns>
        public static int GetTop(IntPtr hWnd)
        {
            return GetLocation(hWnd).Y;
        }
        /// <summary>
        /// ���ÿؼ��ϱ�Ե���������Ĺ������ϱ�Ե֮��ľ��루������Ϊ��λ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">System.Int32 ��ʾ�ؼ��ϱ�Ե���������Ĺ������ϱ�Ե֮��ľ��루������Ϊ��λ����</param>
        public static void SetTop(IntPtr hWnd, int value)
        {
            Point pt = GetLocation(hWnd);
            pt.Y = value;
            SetLocation(hWnd, pt);
        }
        /// <summary>
        /// ��ȡ�ؼ��ұ�Ե���������Ĺ��������Ե֮��ľ��루������Ϊ��λ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>System.Int32 ��ʾ�ؼ��ұ�Ե���������Ĺ��������Ե֮��ľ��루������Ϊ��λ����</returns>
        public static int GetRight(IntPtr hWnd)
        {
            return GetBottomRight(hWnd).X;
        }
        /// <summary>
        /// ��ȡ�ؼ��±�Ե���������Ĺ������ϱ�Ե֮��ľ��루������Ϊ��λ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>System.Int32 ��ʾ�ؼ��±�Ե���������Ĺ������ϱ�Ե֮��ľ��루������Ϊ��λ����</returns>
        public static int GetBottom(IntPtr hWnd)
        {
            return GetBottomRight(hWnd).Y;
        }
        /// <summary>
        /// ��ȡ�ؼ��Ŀ�ȡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>�ؼ��Ŀ�ȣ�������Ϊ��λ����</returns>
        public static int GetWidth(IntPtr hWnd)
        {
            return GetSize(hWnd).Width;
        }
        /// <summary>
        /// ���ÿؼ��Ŀ�ȡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">�ؼ��Ŀ�ȣ�������Ϊ��λ����</param>
        public static void SetWidth(IntPtr hWnd, int value)
        {
            Size sz = GetSize(hWnd);
            sz.Width = value;
            SetSize(hWnd, sz);
        }
        /// <summary>
        /// ��ȡ�ؼ��ĸ߶ȡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>�ؼ��ĸ߶ȣ�������Ϊ��λ����</returns>
        public static int GetHeight(IntPtr hWnd)
        {
            return GetSize(hWnd).Height;
        }
        /// <summary>
        /// ���ÿؼ��ĸ߶ȡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">�ؼ��ĸ߶ȣ�������Ϊ��λ����</param>
        public static void SetHeight(IntPtr hWnd, int value)
        {
            Size sz = GetSize(hWnd);
            sz.Height = value;
            SetSize(hWnd, sz);
        }
        /// <summary>
        /// ��ȡ�ؼ��Ĺ������ĸ߶ȺͿ�ȡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>һ�� System.Drawing.Size����ʾ�ؼ��Ĺ�������ά����</returns>
        public static Size GetClientSize(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetClientRect(hWnd, ref lpRect);
            return lpRect.Size;
        }
        /// <summary>
        /// ���ÿؼ��Ĺ������ĸ߶ȺͿ�ȡ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">һ�� System.Drawing.Size����ʾ�ؼ��Ĺ�������ά����</param>
        public static void SetClientSize(IntPtr hWnd, Size value)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT(0, 0, value.Width, value.Height);
            int dwStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE);
            int dwExStyle = UnsafeNativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_EXSTYLE);
            UnsafeNativeMethods.AdjustWindowRectEx(ref lpRect, dwStyle, false, dwExStyle);
            SetSize(hWnd, lpRect.Size);
        }
        /// <summary>
        /// ��ȡ��ʾ�ؼ��Ĺ������ľ��Ρ�
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>һ�� System.Drawing.Rectangle������ʾ�ؼ��Ĺ�������</returns>
        public static Rectangle GetClientRectangle(IntPtr hWnd)
        {
            NativeMethods.RECT lpRect = new NativeMethods.RECT();
            UnsafeNativeMethods.GetClientRect(hWnd, ref lpRect);
            return lpRect.ToRectangle();
        }
        /// <summary>
        /// ��ȡ��˿ؼ��������ı���
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>��ÿؼ��������ı���</returns>
        public static string GetText(IntPtr hWnd)
        {
            if (!GetIsHandleCreated(hWnd))
                return string.Empty;

            int windowTextLength = UnsafeNativeMethods.GetWindowTextLength(hWnd);
            if (UnsafeNativeMethods.GetSystemMetrics(NativeMethods.SM_DBCSENABLED) != 0)
                windowTextLength = (windowTextLength * 2) + 1;
            StringBuilder lpString = new StringBuilder(windowTextLength + 1);
            UnsafeNativeMethods.GetWindowText(hWnd, lpString, lpString.Capacity);
            return lpString.ToString();
        }
        /// <summary>
        /// ������˿ؼ��������ı���
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="value">��ÿؼ��������ı���</param>
        public static void SetText(IntPtr hWnd, string value)
        {
            if (GetIsHandleCreated(hWnd))
                return;

            UnsafeNativeMethods.SetWindowText(hWnd, value);
        }

        /// <summary>
        /// ����˿ؼ��������ı�����Ϊ��Ĭ��ֵ��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        public static void ResetText(IntPtr hWnd)
        {
            SetText(hWnd, string.Empty);
        }
        /// <summary>
        /// ���û���ʾ�ؼ���
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        public static void Show(IntPtr hWnd)
        {
            SetVisible(hWnd, true);
        }
        /// <summary>
        /// ���û����ؿؼ���
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        public static void Hide(IntPtr hWnd)
        {
            SetVisible(hWnd, false);
        }
        /// <summary>
        /// ���ؼ����� Z ˳���ǰ�档
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        public static void BringToFront(IntPtr hWnd)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_TOP, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE);
        }
        /// <summary>
        /// ���ؼ����͵� Z ˳��ĺ��档
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        public static void SendToBack(IntPtr hWnd)
        {
            UnsafeNativeMethods.SetWindowPos(hWnd, NativeMethods.HWND_BOTTOM, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOMOVE);
        }
        /// <summary>
        /// Ϊ�ؼ��������뽹�㡣
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>������뽹������ɹ�����Ϊ true������Ϊ false��</returns>
        public static bool Focus(IntPtr hWnd)
        {
            if (GetCanFocus(hWnd))
                UnsafeNativeMethods.SetFocus(hWnd);

            return GetFocused(hWnd);
        }
        /// <summary>
        /// Ϊ�ؼ����� System.Drawing.Graphics��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <returns>�ؼ��� System.Drawing.Graphics��</returns>
        public static Graphics CreateGraphics(IntPtr hWnd)
        {
            return Graphics.FromHwndInternal(hWnd);
        }
        /// <summary>
        /// ��ָ����Ļ���λ�ü���ɹ��������ꡣ
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="p">Ҫת������Ļ���� System.Drawing.Point��</param>
        /// <returns>һ�� System.Drawing.Point������ʾת����� System.Drawing.Point��p���Թ����������ʾ����</returns>
        public static Point PointToClient(IntPtr hWnd, Point p)
        {
            NativeMethods.POINT pt = new NativeMethods.POINT(p.X, p.Y);
            UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWnd, ref pt, 1);
            return new Point(pt.x, pt.y);
        }
        /// <summary>
        /// ��ָ�����������λ�ü������Ļ���ꡣ
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="p">Ҫת���Ĺ��������� System.Drawing.Point��</param>
        /// <returns>һ�� System.Drawing.Point������ʾת����� System.Drawing.Point��p������Ļ�����ʾ����</returns>
        public static Point PointToScreen(IntPtr hWnd, Point p)
        {
            NativeMethods.POINT pt = new NativeMethods.POINT(p.X, p.Y);
            UnsafeNativeMethods.MapWindowPoints(hWnd, NativeMethods.HWND_DESKTOP, ref pt, 1);
            return new Point(pt.x, pt.y);
        }
        /// <summary>
        /// ����ָ����Ļ���εĴ�С��λ�ã��Թ����������ʾ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="r">Ҫת������Ļ���� System.Drawing.Rectangle��</param>
        /// <returns>һ�� System.Drawing.Rectangle������ʾת����� System.Drawing.Rectangle��r���Թ����������ʾ����</returns>
        public static Rectangle RectangleToClient(IntPtr hWnd, Rectangle r)
        {
            NativeMethods.RECT rect = new NativeMethods.RECT(r);
            UnsafeNativeMethods.MapWindowPoints(NativeMethods.HWND_DESKTOP, hWnd, ref rect, 2);
            return rect.ToRectangle();
        }
        /// <summary>
        /// ����ָ�����������εĴ�С��λ�ã�����Ļ�����ʾ����
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="r">Ҫת���Ĺ��������� System.Drawing.Rectangle��</param>
        /// <returns>һ�� System.Drawing.Rectangle������ʾת����� System.Drawing.Rectangle��r������Ļ�����ʾ����</returns>
        public static Rectangle RectangleToScreen(IntPtr hWnd, Rectangle r)
        {
            NativeMethods.RECT rect = new NativeMethods.RECT(r);
            UnsafeNativeMethods.MapWindowPoints(hWnd, NativeMethods.HWND_DESKTOP, ref rect, 2);
            return rect.ToRectangle();
        }
        /// <summary>
        /// ʹ�ؼ�������ͼ����Ч�������ػ�ؼ���
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        public static void Invalidate(IntPtr hWnd)
        {
            Invalidate(hWnd, false);
        }
        /// <summary>
        /// ʹ�ؼ���ָ��������Ч��������ӵ��ؼ��ĸ��������´λ��Ʋ���ʱ�����»��Ƹ������򣩣�����ؼ����ͻ�����Ϣ��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="rc">һ�� System.Drawing.Rectangle����ʾҪʹ֮��Ч������</param>
        public static void Invalidate(IntPtr hWnd, Rectangle rc)
        {
            Invalidate(hWnd, rc, false);
        }
        /// <summary>
        /// ʹ�ؼ���ָ��������Ч��������ӵ��ؼ��ĸ��������´λ��Ʋ���ʱ�����»��Ƹ������򣩣�����ؼ����ͻ�����Ϣ��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="region">Ҫʹ֮��Ч�� System.Drawing.Region��</param>
        public static void Invalidate(IntPtr hWnd, Region region)
        {
            Invalidate(hWnd, region, false);
        }
        /// <summary>
        /// ʹ�ؼ����ض�������Ч����ؼ����ͻ�����Ϣ��������ʹ������ÿؼ����ӿؼ���Ч��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="invalidateChildren">��Ҫʹ�ؼ����ӿؼ���Ч����Ϊ true������Ϊ false��</param>
        public static void Invalidate(IntPtr hWnd, bool invalidateChildren)
        {
            if (GetIsHandleCreated(hWnd))
            {
                if (invalidateChildren)
                {
                    UnsafeNativeMethods.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, NativeMethods.RDW_ALLCHILDREN | NativeMethods.RDW_INVALIDATE);//.Net Framework :��NativeMethods.RDW_ERASE
                }
                else
                {
                    UnsafeNativeMethods.InvalidateRect(hWnd, IntPtr.Zero, false);//.Net Framework :֧��͸��Ϊtrue,����false
                }
            }
        }
        /// <summary>
        /// ʹ�ؼ���ָ��������Ч��������ӵ��ؼ��ĸ��������´λ��Ʋ���ʱ�����»��Ƹ������򣩣�����ؼ����ͻ�����Ϣ��������ʹ������ÿؼ����ӿؼ���Ч��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="rc">һ�� System.Drawing.Rectangle����ʾҪʹ֮��Ч������</param>
        /// <param name="invalidateChildren">��Ҫʹ�ؼ����ӿؼ���Ч����Ϊ true������Ϊ false��</param>
        public static void Invalidate(IntPtr hWnd, Rectangle rc, bool invalidateChildren)
        {
            if (rc.IsEmpty)
            {
                Invalidate(hWnd, invalidateChildren);
            }
            else if (GetIsHandleCreated(hWnd))
            {
                if (invalidateChildren)
                {
                    NativeMethods.RECT rcUpdate = NativeMethods.RECT.FromXYWH(rc.X, rc.Y, rc.Width, rc.Height);
                    UnsafeNativeMethods.RedrawWindow(hWnd, ref rcUpdate, IntPtr.Zero, NativeMethods.RDW_ALLCHILDREN | NativeMethods.RDW_INVALIDATE);//.Net Framework :��NativeMethods.RDW_ERASE
                }
                else
                {
                    NativeMethods.RECT rect = NativeMethods.RECT.FromXYWH(rc.X, rc.Y, rc.Width, rc.Height);
                    UnsafeNativeMethods.InvalidateRect(hWnd, ref rect, false);//.Net Framework :֧��͸��Ϊtrue,����false
                }
            }
        }
        /// <summary>
        /// ʹ�ؼ���ָ��������Ч��������ӵ��ؼ��ĸ��������´λ��Ʋ���ʱ�����»��Ƹ������򣩣�����ؼ����ͻ�����Ϣ��������ʹ������ÿؼ����ӿؼ���Ч��
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        /// <param name="region">Ҫʹ֮��Ч�� System.Drawing.Region��</param>
        /// <param name="invalidateChildren">��Ҫʹ�ؼ����ӿؼ���Ч����Ϊ true������Ϊ false��</param>
        public static void Invalidate(IntPtr hWnd, Region region, bool invalidateChildren)
        {
            if (region == null)
            {
                Invalidate(hWnd, invalidateChildren);
            }
            else if (GetIsHandleCreated(hWnd))
            {
                IntPtr hRgn = GetHRgn(hWnd, region);
                try
                {
                    if (invalidateChildren)
                    {
                        UnsafeNativeMethods.RedrawWindow(hWnd, IntPtr.Zero, hRgn, NativeMethods.RDW_ALLCHILDREN | NativeMethods.RDW_INVALIDATE);//.Net Framework :��NativeMethods.RDW_ERASE
                    }
                    else
                    {
                        UnsafeNativeMethods.InvalidateRgn(hWnd, hRgn, false);//.Net Framework :֧��͸��Ϊtrue,����false
                    }
                }
                finally
                {
                    UnsafeNativeMethods.DeleteObject(hRgn);
                }
            }
        }
        /// <summary>
        /// �õ�ǰ��С��λ�ø��¿ؼ��ı߽硣
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        public static void Update(IntPtr hWnd)
        {
            UnsafeNativeMethods.UpdateWindow(hWnd);
        }
        /// <summary>
        /// ǿ�ƿؼ�ʹ�乤������Ч�������ػ��Լ����κ��ӿؼ���
        /// </summary>
        /// <param name="hWnd">�ؼ������</param>
        public static void Refresh(IntPtr hWnd)
        {
            Invalidate(hWnd, true);
            Update(hWnd);
        }

        #endregion
    }
}
