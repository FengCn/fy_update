using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Win32
{
    /// <summary>
    /// User32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        #region Window Functions                                    ���ں���

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������һ���ص�ʽ���ڡ�����ʽ���ڻ��Ӵ��ڡ�</para>
        /// <para>��ָ�������࣬���ڱ��⣬���ڷ���Լ����ڵĳ�ʼλ�ü���С����ѡ�ģ���</para>
        /// <para>����Ҳָ�ô��ڵĸ����ڻ��������ڣ�������ڵĻ����������ڵĲ˵���</para>
        /// <para>��Ҫʹ�ó�CreateWindow����֧�ֵķ�������չ�����ʹ��CreateWindowEx��������CreateWindow������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�ڷ���ǰ��CreateWindow�����ڹ��̷���һ��WM_CREATE��Ϣ��</para>
        /// <para>���ڲ��������ʽ���Ӵ��ڣ�CreateWindow�����ڷ���WM_CREATE��WM_GETMINMAXINFO��WM_NCCREATE��Ϣ��</para>
        /// <para>��ϢWM_CREATE��IParam��������һ��ָ��CREATESTRUCT�ṹ��ָ�롣</para>
        /// <para>���ָ����WS_VISIBLE���CreateWindow�򴰿ڷ���������Ҫ�������ʾ���ڵ���Ϣ��</para>
        /// </summary>
        /// <param name="lpClassName">ָ��һ���ս������ַ�����������atom������ò�����һ���������������ɴ�ǰ����theGlobalAddAtom����������ȫ���������С��0xC000��16λ��������lpClassName�����ֵĵ�16λ���ò����ĸ�λ������0�����lpClassName��һ���ַ�������ָ���˴��ڵ���������������������κ��ú���RegisterClassע��������������κ�Ԥ����Ŀ����������뿴˵�����ֵ��б�</param>
        /// <param name="lpWindowName">ָ��һ��ָ���������Ŀս������ַ���ָ�롣������ڷ��ָ���˱���������lpWindowNameָ��Ĵ��ڱ��⽫��ʾ�ڱ������ϡ���ʹ��Createwindow�����������������簴ť��ѡ���;�̬����ʱ����ʹ��lpWindowName��ָ�������ı���</param>
        /// <param name="dwStyle">ָ���������ڵķ�񡣸ò������������д��ڷ�������ټ���˵�����ֵĿ��Ʒ�񡣷�����壺WS</param>
        /// <param name="x">ָ�����ڵĳ�ʼˮƽλ�á���һ������򵯳�ʽ���ڣ�X��������Ļ����ϵ�Ĵ��ڵ����Ͻǵĳ�ʼX���ꡣ�����Ӵ��ڣ�x���Ӵ������Ͻ���Ը����ڿͻ������Ͻǵĳ�ʼX���ꡣ����ò�������ΪCW_USEDEFAULT��ϵͳΪ����ѡ��ȱʡ�����Ͻ����겢����Y������CW_USEDEFAULTֻ�Բ��������Ч�����Ϊ����ʽ���ڻ��Ӵ����趨����X��y��������Ϊ�㡣</param>
        /// <param name="y">ָ�����ڵĳ�ʼ��ֱλ�á���һ������򵯳�ʽ���ڣ�y��������Ļ����ϵ�Ĵ��ڵ����Ͻǵĳ�ʼy���ꡣ�����Ӵ��ڣ�y���Ӵ������Ͻ���Ը����ڿͻ������Ͻǵĳ�ʼy���ꡣ�����б��y���б��ͻ������Ͻ���Ը����ڿͻ������Ͻǵĳ�ʼy���ꡣ������������ʹ��WS_VISIBLE���λ�����Ĳ���X��������ΪCW_USEDEFAULT����ϵͳ������y������</param>
        /// <param name="nWidth">���豸��Ԫָ�����ڵĿ�ȡ����ڲ�����ڣ�nWidth������Ļ����Ĵ��ڿ�Ȼ���CW_USEDEFAULT����nWidth��CW_USEDEFAULT����ϵͳΪ����ѡ��һ��ȱʡ�ĸ߶ȺͿ�ȣ�ȱʡ���Ϊ�ӳ�ʼX���꿪ʼ����Ļ���ұ߽磬ȱʡ�߶�Ϊ�ӳ�ʼY���꿪ʼ��Ŀ������Ķ�����CW_USEDEFAULTֻ�Բ��������Ч�����Ϊ����ʽ���ں��Ӵ����趨CW_USEDEFAULT��־��nWidth��nHeight����Ϊ�㡣</param>
        /// <param name="nHeight">���豸��Ԫָ�����ڵĸ߶ȡ����ڲ�����ڣ�nHeight����Ļ����Ĵ��ڿ�ȡ���nWidth����ΪCW_USEDEFAULT����ϵͳ����nHeight������</param>
        /// <param name="hWndParent">ָ�򱻴������ڵĸ����ڻ������ߴ��ڵľ������Ҫ����һ���Ӵ��ڻ�һ���������ڣ����ṩһ����Ч�Ĵ��ھ������������Ե���ʽ�����ǿ�ѡ�ġ�Windows NT 5.0������һ����Ϣ���ڣ������ṩHWND_MESSAGE���ṩһ�������ڵ���Ϣ���ڵľ����</param>
        /// <param name="hMenu">�˵�����������ݴ��ڷ��ָ��һ���Ӵ��ڱ�ʶ�����ڲ���򵯳�ʽ���ڣ�hMenuָ������ʹ�õĲ˵������ʹ���˲˵��࣬��hMenu����ΪNULL�������Ӵ��ڣ�hMenuָ���˸��Ӵ��ڱ�ʶ��һ������������һ���Ի���ʹ���������ֵ���¼�֪ͨ���ࡣӦ�ó���ȷ���Ӵ��ڱ�ʶ�����ֵ������ͬ�����ڵ������Ӵ��ڱ�����Ψһ�ġ�</param>
        /// <param name="hInstance">�봰���������ģ��ʵ���ľ����</param>
        /// <param name="lpParam">ָ��һ��ֵ��ָ�룬��ֵ���ݸ�����WM_CREATE��Ϣ����ֵͨ����IParam�����е�CREATESTRUCT�ṹ���ݡ����Ӧ�ó������CreateWindow����һ��MDI�ͻ����ڣ���lpParam����ָ��һ��CLIENTCREATESTRUCT�ṹ��</param>
        /// <returns>��������ɹ�������ֵΪ�´��ڵľ�����������ʧ�ܣ�����ֵΪNULL�������ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindow(string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������һ��������չ���Ĳ��ʽ���ڡ�����ʽ���ڻ��Ӵ��ڣ�������CreateWindow������ͬ�����ڴ������ں��������������ݣ���ο�CreateWindow��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>:�μ�CreateWindow��</para>
        /// <para>�ٲ飺Windows NT��3.1���ϰ汾��Windows��95���ϰ汾��Windows CE��1.0���ϰ汾��ͷ�ļ���winuser.h�����ļ���USer32.lib;Unicode����Windows NT��ʵ��ΪUnicode��ANSI���ְ汾��</para>
        /// </summary>
        /// <param name="dwExStyle">ָ�����ڵ���չ��񡣸ò�������������ֵ��WS_EX</param>
        /// <param name="lpClassName">ָ��һ���ս������ַ�����������atom������ò�����һ���������������ɴ�ǰ����RegisterClass��RegisterClassEx�������ص�ֵ�����С��OxCOOO��16λ��������IpClassName�����ֵĵ�16λ���ò����ĸ�λ������O�����lpClassName��һ���ַ�������ָ���˴��ڵ���������������������κ��ú���RegisterClassExע��������������κ�Ԥ����Ŀ����������뿴˵�����ֵ��б�</param>
        /// <param name="lpWindowName">ָ��һ��ָ���������Ŀս������ַ���ָ�롣������ڷ��ָ���˱���������lpWindowNameָ��Ĵ��ڱ��⽫��ʾ�ڱ������ϡ���ʹ��CreateWindow�����������������簴ť��ѡ���;�̬����ʱ����ʹ��lpWindowName��ָ�������ı���</param>
        /// <param name="dwStyle">ָ���������ڵķ�񡣸ò������������д��ڷ�������ټ���˵�����ֵĿ��Ʒ��</param>
        /// <param name="x">ָ�����ڵĳ�ʼˮƽλ�á���һ������򵯳�ʽ���ڣ�X��������Ļ����ϵ�Ĵ��ڵ����Ͻǵĳ�ʼX���ꡣ�����Ӵ��ڣ�x���Ӵ������Ͻ���Ը����ڿͻ������Ͻǵĳ�ʼX���ꡣ����ò�������ΪCW_USEDEFAULT��ϵͳΪ����ѡ��ȱʡ�����Ͻ����겢����Y������CW_USEDEFAULTֻ�Բ��������Ч�����Ϊ����ʽ���ڻ��Ӵ����趨����X��y��������Ϊ�㡣</param>
        /// <param name="y">ָ�����ڵĳ�ʼ��ֱλ�á���һ������򵯳�ʽ���գ�y��������Ļ����ϵ�Ĵ��ڵ����Ͻǵĳ�ʼy���ꡣ�����Ӵ��ڣ�y���Ӵ������Ͻ���Ը����ڿͻ������Ͻǵĳ�ʼy���ꡣ�����б��y���б��ͻ������Ͻ���Ը����ڿͻ������Ͻǵĳ�ʼy���ꡣ������������ʹ��WS_VISIBLE���λ�����Ĳ���X��������ΪCW_USEDEFAULT����ϵͳ������y������</param>
        /// <param name="nWidth">���豸��Ԫָ�����ڵĿ�ȡ����ڲ�����ڣ�nWidth������Ļ����Ĵ��ڿ�Ȼ���CW_USEDEFAULT����nWidth��CW_USEDEFAULT����ϵͳΪ����ѡ��һ��ȱʡ�ĸ߶ȺͿ�ȣ�ȱʡ���Ϊ�ӳ�ʼX���꿪ʼ����Ļ���ұ߽磬ȱʡ�߶�Ϊ�ӳ�ʼX���꿪ʼ��Ŀ������Ķ�����CW_USEDEFAULTֻ�Բ��������Ч�����Ϊ����ʽ���ں��Ӵ����趨CW_USEDEFAULT��־��nWidth��nHeight����Ϊ�㡣</param>
        /// <param name="nHeight">���豸��Ԫָ�����ڵĸ߶ȡ����ڲ�����ڣ�nHeight����Ļ����Ĵ��ڿ�ȡ���nWidth����ΪCW_USEDEFAULT����ϵͳ����nHeight������</param>
        /// <param name="hWndParent">ָ�򱻴������ڵĸ����ڻ������ߴ��ڵľ������Ҫ����һ���Ӵ��ڻ�һ���������ڣ����ṩһ����Ч�Ĵ��ھ������������Ե���ʽ�����ǿ�ѡ�ġ�Windows NT 5.0������һ����Ϣ���ڣ������ṩHWND_MESSAGE���ṩһ�������ڵ���Ϣ���ڵľ����</param>
        /// <param name="hMenu">�˵�����������ݴ��ڷ��ָ��һ���Ӵ��ڱ�ʶ�����ڲ���򵯳�ʽ���ڣ�hMenuָ������ʹ�õĲ˵������ʹ���˲˵��࣬��hMenu����ΪNULL�������Ӵ��ڣ�hMenuָ���˸��Ӵ��ڱ�ʶ��һ������������һ���Ի���ʹ���������ֵ���¼�֪ͨ���ࡣӦ�ó���ȷ���Ӵ��ڱ�ʶ�����ֵ������ͬ�����ڵ������Ӵ��ڱ�����Ψһ�ġ�</param>
        /// <param name="hInstance">�봰���������ģ��ʵ���ľ����</param>
        /// <param name="lpParam">ָ��һ��ֵ��ָ�룬��ֵ���ݸ�����WM_CREATE��Ϣ����ֵͨ����IParam�����е�CREATESTRUCT�ṹ���ݡ����Ӧ�ó������CreateWindow����һ��MDI�ͻ����ڣ���lpParam����ָ��һ��CLIENTCREATESTRUCT�ṹ��</param>
        /// <returns>��������ɹ�������ֵΪ�´��ڵľ�����������ʧ�ܣ�����ֵΪNULL�������ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>����ָ���Ĵ��ڡ��������ͨ������WM_DESTROY ��Ϣ�� WM_NCDESTROY ��Ϣʹ������Ч���Ƴ�����̽��㡣������������ٴ��ڵĲ˵�������̵߳���Ϣ���У������봰�ڹ�����صĶ�ʱ����������ڶԼ������ӵ��Ȩ����ϼ��������Ĳ鿴����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>һ���̲߳���ʹ�ñ��������ٱ���̴߳����Ĵ��ڡ�������������һ��������WS_EX_NOPARENTNOTIFY ��ʽ���Ӵ��ڣ������ٴ���ʱ����WM_PARENTNOTIFY ��Ϣ���丸���ڡ�</para>
        /// <para>Windows CE: �������������� WM_NCDESTROY ��Ϣ.</para>
        /// </summary>
        /// <param name="hWnd">�������ٵĴ��ڵľ����</param>
        /// <returns>��������ɹ�������ֵΪ���㣺�������ʧ�ܣ�����ֵΪ�㡣�����ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����������洰�ڵľ�������洰�ڸ���������Ļ�����洰����һ��Ҫ�����ϻ������е�ͼ����������ڵ�����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// </summary>
        /// <returns>�����������洰�ڵľ����</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        /// <summary>
        /// FindWindow����������ָ���ַ�����ƥ��Ĵ��������򴰿�������㴰�ڵĴ��ھ�������������������Ӵ��ڡ�
        /// </summary>
        /// <param name="lpClassName">ָ��һ����null��β�ġ�����ָ���������ַ�����һ������ȷ�������ַ�����ԭ�ӡ�������������һ��ԭ�ӣ���ô��������һ���ڵ��ô˺���ǰ�Ѿ�ͨ��GlobalAddAtom���������õ�ȫ��ԭ�ӡ����ԭ�ӣ�һ��16bit��ֵ�������뱻������lpClassName�ĵ�λ�ֽ��У�lpClassName�ĸ�λ�ֽ����㡣</param>
        /// <param name="lpWindowName">ָ��һ����null��β�ġ�����ָ���������������ڱ��⣩���ַ���������˲���ΪNULL����ƥ�����д�������</param>
        /// <returns>�������ִ�гɹ����򷵻�ֵ��ӵ��ָ�����������򴰿����Ĵ��ڵľ�����������ִ��ʧ�ܣ��򷵻�ֵΪ NULL ������ͨ������GetLastError������ø�����ϸ�Ĵ�����Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ڴ����б���Ѱ����ָ����������ĵ�һ���Ӵ��� ��</para>
        /// <para>�ú������һ�����ڵľ�����ô��ڵ������ʹ�������������ַ�����ƥ�䡣</para>
        /// <para>������������Ӵ��ڣ������ڸ������Ӵ��ں������һ���Ӵ��ڿ�ʼ���ڲ���ʱ�����ִ�Сд��</para>
        /// </summary>
        /// <param name="hwndParent">Ҫ���ҵ��Ӵ������ڵĸ����ڵľ�������������hwndParent�����ʾ�����hwndParentָ��ĸ������������Ӵ��ڣ������hwndParentΪ 0 �����������洰��Ϊ�����ڣ��������洰�ڵ������Ӵ��ڡ�Windows NT5.0 and later�����hwndParent��HWND_MESSAGE������������������Ϣ���ڡ�</param>
        /// <param name="hwndChildAfter">�Ӵ��ھ�������Ҵ���Z���е���һ���Ӵ��ڿ�ʼ���Ӵ��ڱ���ΪhwndParent���ڵ�ֱ���Ӵ��ڶ��Ǻ�����ڡ����HwndChildAfterΪNULL�����Ҵ�hwndParent�ĵ�һ���Ӵ��ڿ�ʼ�����hwndParent �� hwndChildAfterͬʱΪNULL�������������еĶ��㴰�ڼ���Ϣ���ڡ�</param>
        /// <param name="lpszClass">ָ��һ��ָ���������Ŀս����ַ�������һ����ʶ�����ַ����ĳ�Ա��ָ�롣����ò���Ϊһ����Ա����������Ϊǰ�ε���theGlobaIAddAtom����������ȫ�ֳ�Ա���ó�ԱΪ16λ������λ��lpClassName�ĵ�16λ����λ����Ϊ0��</param>
        /// <param name="lpszWindow">ָ��һ��ָ���˴����������ڱ��⣩�Ŀս����ַ���������ò���Ϊ NULL����Ϊ���д���ȫƥ�䡣</param>
        /// <returns>Long���ҵ��Ĵ��ڵľ������δ�ҵ�������ڣ��򷵻��㡣������GetLastError��������ɹ�������ֵΪ����ָ�������ʹ������Ĵ��ھ�����������ʧ�ܣ�����ֵΪNULL�������ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ø������ڵĿ���״̬��</para>
        /// <para>.</para>
        /// <para>��ע��</para>
        /// <para>���ڵĿ���״̬��WS_VISIBLEλָʾ��</para>
        /// <para>��������WS_VISIBLEλ�����ھͿ���ʾ������ֻҪ���ھ���WS_VISIBLE����κλ��ڴ��ڵ���Ϣ��������ʾ��</para>
        /// <para>.</para>
        /// </summary>
        /// <param name="hWnd">�����Դ��ڵľ����</param>
        /// <returns>���ָ���Ĵ��ڼ��丸���ھ���WS_VISIBLE��񣬷���ֵΪ���㣻���ָ���Ĵ��ڼ��丸���ڲ�����WS_VISIBLE��񣬷���ֵΪ�㡣���ڷ���ֵ�����˴����Ƿ����Ws_VISIBLE�����ˣ���ʹ�ô��ڱ����������ڸǣ���������ֵҲΪ���㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        /// <summary>
        /// �ú����ı�һ���Ӵ��ڣ�����ʽ����ʽ���㴰�ڵĳߴ磬λ�ú�Z�� 
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="hWndInsertAfter">��z���е�λ�ڱ���λ�Ĵ���ǰ�Ĵ��ھ��.����Ϊ����ֵHWND_</param>
        /// <param name="x">�Կͻ�����ָ��������λ�õ���߽�</param>
        /// <param name="y">�Կͻ�����ָ��������λ�õĶ��߽�</param>
        /// <param name="cx">������ָ�����ڵ��µĿ��</param>
        /// <param name="cy">������ָ�����ڵ��µĸ߶�</param>
        /// <param name="uFlags">���ڳߴ�Ͷ�λ�ı�־���ò�������������ֵ�����.����Ϊ����ֵSWP_</param>
        /// <returns>��������ɹ�������ֵΪ���㣻�������ʧ�ܣ�����ֵΪ�㡣</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������ָ�����ڵı߿���εĳߴ硣�óߴ����������Ļ�������Ͻǵ���Ļ���������</para>
        /// </summary>
        /// <param name="hWnd">���ھ����</param>
        /// <param name="lpRect">ָ��һ��RECT�ṹ��ָ�룬�ýṹ���մ��ڵ����ϽǺ����½ǵ���Ļ���ꡣ</param>
        /// <returns>��������ɹ�������ֵΪ���㣺�������ʧ�ܣ�����ֵΪ�㡣�����ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref NativeMethods.RECT lpRect);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ȡ���ڿͻ��������ꡣ</para>
        /// <para>�ͻ�������ָ���ͻ��������ϽǺ����½ǡ�</para>
        /// <para>���ڿͻ�����������Դ��ڿͻ��������ϽǶ��Եģ�������Ͻ�����Ϊ��0��0��</para>
        /// </summary>
        /// <param name="hWnd">���򴰿ڵľ����</param>
        /// <param name="lpRect">ָ�룬ָ��һ��RECT���͵�rectangle�ṹ���ýṹ���ĸ�LONG�ֶ�,�ֱ�Ϊleft��top��right��bottom��GetClientRect�����ĸ��ֶ��趨Ϊ������ʾ����ĳߴ硣left��top�ֶ�ͨ���趨Ϊ0��right��bottom�ֶ��趨Ϊ��ʾ����Ŀ�Ⱥ͸߶ȣ����ص������� Ҳ������һ��CRect����ָ�롣CRect�����ж����������RECT�÷���ͬ�������������ܵ���˵���ǰѿͻ����Ĵ�Сд���ڶ���������ָ��Rect�ṹ���С�</param>
        /// <returns>��������ɹ�������һ������ֵ���������ʧ�ܣ������㡣Ҫ�õ�����Ĵ�����Ϣ����ʹ��GetLastError������</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, ref NativeMethods.RECT lpRect);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����������ͻ����εĴ�С��������Ҫ�Ĵ��ھ��εĴ�С��������Ĵ��ھ��������Դ��ݸ�CreateWindow���������ڴ���һ���ͻ��������С�Ĵ��ڡ�</para>
        /// <para>Ҫָ��һ����չ������ʽ��ʹ��AdjustWindowRectEx���ܡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�ͻ�������ָ��ȫ����һ���ͻ��������С���Σ����ھ�����ָ��ȫ����һ�����ڵ���С���Σ��ô��ڰ����ͻ�����ǿͻ�����</para>
        /// <para>��һ���˵������������л������ʱ��AdjustWindowRect���������Ӷ���Ŀռ䡣</para>
        /// </summary>
        /// <param name="lpRect">ָ��RECT�ṹ��ָ�룬�ýṹ��������ͻ���������ϽǺ����½ǵ����ꡣ��������ʱ���ýṹ��������ͻ�����Ĵ��ڵ����ϽǺ����½ǵ����ꡣ</param>
        /// <param name="dwStyle">ָ����������ߴ�Ĵ��ڵĴ��ڷ��</param>
        /// <param name="bMenu">ָʾ�����Ƿ��в˵���</param>
        /// <returns>��������ɹ�������ֵΪ���㣻�������ʧ�ܣ�����ֵΪ�㡣�����ø���Ĵ�����Ϣ������GetLastError������</returns>
        [DllImport("user32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustWindowRect(ref NativeMethods.RECT lpRect, int dwStyle, bool bMenu);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����������ͻ����δ�С��������Ҫ�Ĵ��ھ��εĴ�С��������Ĵ��ھ��������Դ��͸�CreateWindowEx���������ڴ���һ���ͻ��������С�Ĵ��ڡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�ͻ�������ָ��ȫ����һ���ͻ��������С���Σ����ھ�����ָ��ȫ����һ�����ڵ���С���Σ��ô��ڰ����ͻ�����ǿͻ�����</para>
        /// <para>��һ���˵������������л������ʱ��AdjustWindowRectEx���������Ӷ���Ŀռ䡣</para>
        /// <para>��AdjustWindowRectEx���ܲ���WS_VSCROLL��WS_HSCROLL���Ŀ��ǡ����ǵ�������������GetSystemMetrics��ʹ�ù���SM_CXVSCROLL��SM_CYHSCROLL��</para>
        /// </summary>
        /// <param name="lpRect">ָ��RECT�ṹ��ָ�룬�ýṹ��������ͻ���������ϽǺ����½ǵ����ꡣ��������ʱ���ýṹ������������ͻ�����Ĵ��ڵ����ϽǺ����½ǵ����ꡣ</param>
        /// <param name="dwStyle">ָ����������ߴ�Ĵ��ڵĴ��ڷ��</param>
        /// <param name="bMenu">ָʾ�����Ƿ��в˵���</param>
        /// <param name="dwExStyle">ָ����������ߴ�Ĵ��ڵ���չ���ڷ��</param>
        /// <returns>��������ɹ�������ֵΪ���㣻�������ʧ�ܣ�����ֵΪ�㡣�����ø��������Ϣ�������GetLastError����</returns>
        [DllImport("user32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustWindowRectEx(ref NativeMethods.RECT lpRect, int dwStyle, bool bMenu, int dwExStyle);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������һ�������Ƿ���ָ�������ڵ��Ӵ��ڻ������ڡ�����ø��������ڸ����ڵ����������Ӵ�����ָ�������ڵ�ֱ�Ӻ���������������ԭʼ������ڻ򵯳�����һֱ�������Ӵ��ڡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// </summary>
        /// <param name="hWndParent">�����ھ����</param>
        /// <param name="hWnd">�������ԵĴ��ھ����</param>
        /// <returns>���������ָ�����ڵ��Ӵ��ڻ������ڣ��򷵻�ֵΪ���㡣������ڲ���ָ�����ڵ��Ӵ��ڻ������ڣ��򷵻�ֵΪ�㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú������һ��ָ���Ӵ��ڵĸ����ھ����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>WindowsCE��Windows CE1.0�汾��֧�ֳ��˶Ի���֮��������Ӵ��ڡ�</para>
        /// <para>To obtain a window&apos;s owner window, instead of using GetParent, use GetWindow with the GW_OWNER flag.</para>
        /// <para>To obtain the parent window and not the owner, instead of using GetParent, use GetAncestor with the GA_PARENT flag.</para>
        /// </summary>
        /// <param name="hWnd">�Ӵ��ھ��������Ҫ��ø��Ӵ��ڵĸ����ھ����</param>
        /// <returns>��������ɹ�������ֵΪ�����ھ������������޸����ڣ���������NULL�������ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        /// <summary>
        /// Retrieves the handle to the ancestor of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose ancestor is to be retrieved. If this parameter is the desktop window, the function returns NULL.</param>
        /// <param name="gaFlags">The ancestor to be retrieved. This parameter can be one of the following values.</param>
        /// <returns>The return value is the handle to the ancestor window.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetAncestor(IntPtr hWnd, uint gaFlags);
        /// <summary>
        /// <para>����:</para>
        /// <para>Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>The EnumChildWindows function is more reliable than calling GetWindow in a loop.</para>
        /// <para>An application that calls GetWindow to perform this task risks being caught in an infinite loop or referencing a handle to a window that has been destroyed.</para>
        /// </summary>
        /// <param name="hWnd">A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter.</param>
        /// <param name="uCmd">The relationship between the specified window and the window whose handle is to be retrieved. This parameter can be one of the following values.</param>
        /// <returns>If the function succeeds, the return value is a window handle. If no window exists with the specified relationship to the specified window, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        /// <summary>
        /// <para>����:</para>
        /// <para>Changes the parent window of the specified child window.</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>An application can use the SetParent function to set the parent window of a pop-up, overlapped, or child window.</para>
        /// <para>If the window identified by the hWndChild parameter is visible, the system performs the appropriate redrawing and repainting.</para>
        /// <para>For compatibility reasons, SetParent does not modify the WS_CHILD or WS_POPUP window styles of the window whose parent is being changed. Therefore, if hWndNewParent is NULL, you should also clear the WS_CHILD bit and set the WS_POPUP style after calling SetParent. Conversely, if hWndNewParent is not NULL and the window was previously a child of the desktop, you should clear the WS_POPUP style and set the WS_CHILD style before calling SetParent.</para>
        /// <para>When you change the parent of a window, you should synchronize the UISTATE of both windows. For more information, see WM_CHANGEUISTATE and WM_UPDATEUISTATE.</para>
        /// </summary>
        /// <param name="hWndChild">A handle to the child window.</param>
        /// <param name="hWndNewParent">A handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window. If this parameter is HWND_MESSAGE, the child window becomes a message-only window.</param>
        /// <returns>If the function succeeds, the return value is a handle to the previous parent window.If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport("User32", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������ָ�����ڵı����ı���������ڣ����ַ����ȡ����ָ��������һ���ؼ������������ؿ������ı��ĳ��ȡ�����GetWindowTextLength�������ܷ���������Ӧ�ó����еĿ��Ƶ��ı����ȡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���Ŀ�괰�����ڵ�ǰ���̣�GetWindowTextLength������ָ���Ĵ��ڻ���Ʒ���WM_GETTEXT��Ϣ��</para>
        /// <para>��һ���������£�����GetWindowTextLength�ķ���ֵ���ܱ�ʵ�ʵ��ı����ȴ���������ANSI��Unlcode�Ļ��ʹ���Լ�ϵͳ����DBCS�ַ����ı��ڴ��ڵ�ԭ�򣬵��Ǻ�������ֵҪ�������ı���ʵ�ʳ�����ȣ���˿���������һ��ָ���������ķ��䡣��Ӧ�ó����ʹ��ANSI������ʹ��Unicode����ͨ�Ի���ʱ�ͻ��л����������⣻ͬ������Ӧ�ó�����һ��Unicode�Ĵ��ڹ�����ʹ����ANSI��GetWindowTextLength����������һ��ANSI�Ĵ��ڹ�����ʹ����Unicode��GetWindowTextLength������ʱ��Ҳ�л����������⡣�鿴ANSI��Vnicode�������ο�Wind32����prototypes��</para>
        /// <para>Ҫ����ı���ʵ�ʳ��ȣ�ʹ��WM_GETTEXT, LB_GETTEXT��CB_GETLBTBTEXT��Ϣ��GetWindowText������</para>
        /// </summary>
        /// <param name="hWnd">���ڵľ����</param>
        /// <returns>��������ɹ�������ֵΪ�ı����ַ����ȡ���һ���������£�����ֵ���ܱ�ʵ�ʵ��ı����ȴ���ο�˵��������������ı�������ֵΪ�㡣�����ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ�����ڵı������ı���������ڣ�������һ���������ڡ�</para>
        /// <para>���ָ���Ĵ�����һ���ؼ����򿽱��ؼ����ı������ǣ�GetWindowText���ܽ�������Ӧ�ó����пؼ����ı���</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���Ŀ�괰�����ڵ�ǰ���̣�GetWindowText������ָ���Ĵ��ڻ�ؼ�����WM_GETTEXT��Ϣ��</para>
        /// <para>���Ŀ�괰�������������̣�������һ�����ڱ��⣬��GetWindowTeXt���ش��ڵı����ı�����������ޱ��⣬�������ؿ��ַ�����</para>
        /// </summary>
        /// <param name="hWnd">���ı��Ĵ��ڻ�ؼ��ľ����</param>
        /// <param name="lpString">ָ������ı��Ļ�������ָ�롣</param>
        /// <param name="nMaxCount">ָ��Ҫ�����ڻ������ڵ��ַ��������������а���NULL�ַ�������ı��������ޣ����ͱ��ضϡ�</param>
        /// <returns>��������ɹ�������ֵ�ǿ������ַ������ַ��������������жϵĿ��ַ�����������ޱ��������ı����������Ϊ�գ��򴰿ڻ���Ƶľ����Ч���򷵻�ֵΪ�㡣�����ø��������Ϣ�������GetLastError�������������ܷ���������Ӧ�ó����еı༭�ؼ����ı���</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����ı�ָ�����ڵı��������ı����ݣ���������б���������</para>
        /// <para>���ָ��������һ���ؼ�����ı�ؼ����ı����ݡ�</para>
        /// <para>Ȼ����SetWindowText�������ı�����Ӧ�ó����еĿؼ����ı����ݡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���Ŀ�괰�����ڵ�ǰ���̣�SetWindowText������ʹWM_SETTEXT��Ϣ���͸�ָ���Ĵ��ڻ�ؼ���Ȼ��������ؼ�����WS_CAPTION��񴴽����б��ؼ���SetWindowText������Ϊ�ؼ������ı���������Ϊ�б��������ı���[1]</para>
        /// <para>SetWindowText��������չTab�ַ���ASCII����0��09����Tab�ַ����ַ���|������ʾ��</para>
        /// </summary>
        /// <param name="hWnd">Ҫ�ı��ı����ݵĴ��ڻ�ؼ��ľ����</param>
        /// <param name="lpString">ָ��һ���ս������ַ�����ָ�룬���ַ�������Ϊ���ڻ�ؼ������ı���</param>
        /// <returns>��������ɹ�������ֵΪ���㣻�������ʧ�ܣ�����ֵΪ�㡣�����ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        /// <summary>
        /// <para>����:�ú���������ʾ�����ش���ʱ�ܲ��������Ч�������������͵Ķ���Ч�������������ͻ���������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���Խ�AW_HOR_POSITIVE��AW_HOR_NEGTVE��AW_VER_POSITVE��AW_VER_NEGATIVE���������һ�����ڡ�</para>
        /// <para>.</para>
        /// <para>������Ҫ�ڸô��ڵĴ��ڹ��̺������Ӵ��ڵĴ��ڹ����д���WM_PRINT��WM_PRINTCLIENT��Ϣ���Ի��򣬿��ƣ������ÿ����Ѵ���WM_PRINTCLIENT��Ϣ��ȱʡ���ڹ���Ҳ�Ѵ���WM_PRINT��Ϣ��</para>
        /// </summary>
        /// <param name="hWnd">ָ�����������Ĵ��ڵľ��</param>
        /// <param name="dwTime">ָ������������ʱ�䣨��΢��ƣ������һ�������ı�׼ʱ��Ϊ200΢��</param>
        /// <param name="dwFlags">ָ���������͡��������������һ���������б�־����ϡ���־������</param>
        /// <summary>
        /// <para>AW_SLIDE��ʹ�û������͡�ȱʡ��Ϊ�����������͡���ʹ��AW_CENTER��־ʱ�������־�ͱ����ԡ�</para>
        /// <para>AW_ACTIVE������ڡ���ʹ����AW_HIDE��־��Ҫʹ�������־��</para>
        /// <para>AW_BLEND��ʹ�õ���Ч����ֻ�е�hWndΪ���㴰�ڵ�ʱ��ſ���ʹ�ô˱�־��</para>
        /// <para>AW_HIDE�����ش��ڣ�ȱʡ����ʾ���ڡ�</para>
        /// <para>AW_CENTER����ʹ����AW_HIDE��־����ʹ���������ص�����δʹ��AW_HIDE��־����ʹ����������չ��</para>
        /// <para>AW_HOR_POSITIVE������������ʾ���ڡ��ñ�־�����ڹ��������ͻ���������ʹ�á���ʹ��AW_CENTER��־ʱ���ñ�־�������ԡ�</para>
        /// <para>AW_VER_POSITIVE���Զ�������ʾ���ڡ��ñ�־�����ڹ��������ͻ���������ʹ�á���ʹ��AW_CENTER��־ʱ���ñ�־�������ԡ�</para>
        /// <para>AW_VER_NEGATIVE������������ʾ���ڡ��ñ�־�����ڹ��������ͻ���������ʹ�á���ʹ��AW_CENTER��־ʱ���ñ�־�������ԡ�</para>
        /// </summary>
        /// <returns>��������ɹ�������ֵΪ���㣻�������ʧ�ܣ�����ֵΪ�㡣����������º�����ʧ�ܣ�����ʹ���˴��ڱ߽磻�����Ѿ��ɼ���Ҫ��ʾ���ڣ������Ѿ�������Ҫ���ش��ڡ������ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        /// <summary>
        /// �ú�������ָ�����ڵ���ʾ״̬��
        /// </summary>
        /// <param name="hWnd">ָ���ھ����</param>
        /// <param name="nCmdShow">ָ�����������ʾ��</param>
        /// <returns>�������֮ǰ�ɼ����򷵻�ֵΪ���㡣�������֮ǰ�����أ��򷵻�ֵΪ�㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// <para>����:</para>
        /// <para>����һ���ֲ�Ĵ��ڵ�λ�ã���С����״�����ݺͰ�͸����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// <para>.</para>
        /// <para>���в����ɱ����õ�dwFlags:</para>
        /// <para>ULW_ALPHA��ʹ��pblendΪ��Ϲ���,�����ʾģʽΪ256ɫ����٣����ֵ��ULW_OPAQUEЧ����ͬ��</para>
        /// <para>ULW_COLORKEY��ʹ��crKeyֵΪ��ɫ��͸���ȡ�</para>
        /// <para>ULW_OPAQUE������һ����͸���ֲ㴰�ڡ�</para>
        /// <para>���hdcSrcΪNULL��dwFlagsӦΪ�㡣</para>
        /// </summary>
        /// <param name="hWnd">һ���ֲ�Ĵ��ھ��;һ���ֲ�Ĵ��ڵ���CreateWindowEx������������ʱָ��WS_EX_LAYERED��</param>
        /// <param name="hdcDst">��Ļ���豸������(DC)���;���ָ��Ϊ�գ���ô�����ں�������ʱ�Լ���á������ڵ��������ݸ���ʱ�����ɫ����ɫȥƥ��;���hdcDstָ��ΪNull����ʹ��Ĭ�ϵ�ɫ��;���hdcSrcΪNULL,hdcDst����NULL��</param>
        /// <param name="pptDst">һ��POINT�ṹ��ָ��(ָ���µķֲ㴰�ڵ���Ļλ��);���λ��û�иı䣬pptDst����ΪNULL��</param>
        /// <param name="psize">һ���ߴ�ṹ��ָ��(ָ���ֲ㴰���µĴ�С);������ı䴰�ڴ�С��psize����ΪNULL;���hdcSrcΪNULL��psize����ΪNULL��</param>
        /// <param name="hdcSrc">�����˵ķֲ㴰�ڻ�ͼ�����DC���;����������ͨ��CreateCompatibleDC�������;������ڵĿ��ӷ�Χ����״�������仯��hdcSrc����ΪNULL��</param>
        /// <param name="pptSrc">һ��POINT�ṹ��ָ��(ָ���˷ֲ㴰�����豸�����ĵ�λ��);���hdcSrcΪNULL��pptSrcӦ����NULL��</param>
        /// <param name="crKey">ָ��һ��COLORREFֵ(���ϳɷֲ㴰��ʱʹ��ָ����ɫ��ֵ)��Ҫ����COLORREF��ʹ��RGB�ꡣ</param>
        /// <param name="pblend">ָ��һ��BLENDFUNCTION�ṹ(���ϳɷֲ㴰��ʱʹ��ָ��͸����ֵ)��</param>
        /// <param name="dwFlags">��־������</param>
        /// <returns>��������ɹ�������ֵΪ����;�������ʧ�ܣ�����ֵΪ�㡣Ϊ�˻�ø���Ĵ�����Ϣ������GetLastError��</returns>
        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateLayeredWindow(IntPtr hWnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, uint crKey, [In] ref NativeMethods.BLENDFUNCTION pblend, uint dwFlags);

        #endregion


        #region Window Class Functions                              �����ຯ��

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú���������ָ��������ص�WNDCLASSEX�ṹ��ָ��32λֵ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>ͨ��ʹ�ú���RegisterClassEx���ṹWNDCLASSEX�е�cbCIsExtra��Ԫָ��Ϊһ����Oֵ������������Ĵ洢�ռ䡣</para>
        /// <para>Windows CE��nlndex������һ���ֽ�ƫ���������Ǳ���Ϊ 4�ı�����</para>
        /// <para>Windows CE��֧��unaligned access��nlndex������ֻ���趨ΪGCL_HICON��GCL_STYLE��</para>
        /// <para>���ʹ����Windows CE�� lconsurs����������֧�����ʵ���Ŀ��ƽ̨�ϵ���꣬Ҳ������nlndex��ʹ��GCL_HCURSOR��</para>
        /// <para>ע��֧������ Windows CE�汾���� Iconcurs�� Mcursor������ Icon�� Cursor�����</para>
        /// </summary>
        /// <param name="hWnd">���ھ����Ӹ����Ĵ����������ࡣ</param>
        /// <param name="nIndex">ָ��Ҫ�ָ���32λֵ���Ӷ������洢�ռ�ָ�һ��32λ��ֵ��ָ����һ�����ڵ���0�ı��ָ�ֵ��ƫ��������ЧֵΪ��0��ʼ��������洢�ռ��ֽ���һ4�����磬��ָ����12λ�����12λ�Ķ�����洢�ռ䣬��Ӧ��Ϊ������32λ����������λ8��Ҫ��WNDCLASSEX�ṹ�лָ��κ�ֵ����Ҫָ������ֵ֮һ����GCL</param>
        /// <returns>��������ɹ�������ֵ�������32λֵ���������ʧ�ܣ�����ֵΪ0�������ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public static extern int GetClassLong(IntPtr hWnd, int nIndex);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����滻�������洢�ռ���ָ��ƫ��������32λ������ֵ�����滻ָ�������������WNDCLASSEX�ṹ(Ӧ�����滻����ṹ����ֵ��û�аѽṹ������˰�)��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���ʹ��SetClassLong������GCL_WNDPROC����ֵ���滻���ڹ��̣��µĴ��ڹ��̱�����WindowProc�ص����������涨�Ĺ���һ�¡�</para>
        /// <para>�Դ�GCL_WNDPROC����ֵ��SetClassLong�����޸ĵ�һ��������ĵ����ཫ��Ӱ����������Ը��ഴ���Ĵ��ڡ�Ӧ�ó�����Դ���һ��ϵͳ������࣬���ǲ��ܴ������������̴�����������ࡣ</para>
        /// <para>ͨ��ʹ��RegisterClassEx������WNDCLASSEX�ṹ�е�cbWndExtra��Ԫָ��Ϊһ������ֵ����������ĵ���洢�ռ䡣</para>
        /// <para>ʹ��SetClassLong����ҪС�ġ����磬����ͨ��ʹ��SetClassLong���ı���ı�����ɫ���������ָı䲻��������Ч��ֱ�����ڸ���Ĵ����´��ػ棬����ʹ��UpdateWindow()ǿ�ȴ�����¡�</para>
        /// <para>Windows CE��nlndex������һ���ֽ�ƫ������������4�ı�����Unaligned��֧�֡�</para>
        /// <para>��֧����nlndex�����еı�׼��CGL_*ֵ��ֻ��һ�����⣬���Ŀ�����֧����꣬�������nlndex������ָ��CGL_HCURSOR��</para>
        /// <para>ע��֧������WindowsCE�汾����Iconcurs��Mcursor���������lcon��Cursor�����</para>
        /// </summary>
        /// <param name="hWnd">���ھ������Ӹ����Ĵ����������ࡣ</param>
        /// <param name="nIndex">ָ�������滻��32λֵ���ڶ�����洢�ռ�������32λֵ��Ӧָ��һ�����ڻ����0��ƫ��������Чֵ�ķ�Χ��0��������Ĵ洢�ռ���ֽ���һ4�����磬��ָ����12���ֽڻ����12���ֽڵĶ�����洢�ռ䣬������ֵΪ8ʱ����Ӧ���ǵ�����32λ����ֵ��Ҫ����WNDCLASSEX�ṹ�е��κ�ֵ��ָ����������֮һ����GCL</param>
        /// <param name="dwNewLong">ָ�����滻ֵ��</param>
        /// <returns>��������ɹ�������ֵ��ԭ����ṹ��32λ���������δ�����趨������ֵΪ0���������ʧ�ܣ�����ֵΪ0�������ø��������Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public static extern int SetClassLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������й�ָ�����ڵ���Ϣ������Ҳ����ڶ��ⴰ���ڴ���ָ��ƫ��λ��ַ��32λ������ֵ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>ͨ��ʹ�ú���RegisterClassEx���ṹWNDCLASSEX�е�cbWndExtra��Ԫָ��Ϊһ����0ֵ������������Ĵ洢�ռ䡣</para>
        /// <para>.</para>
        /// <para>Ҫ�����������ֵ��nIndexָ������ֵ֮һ��</para>
        /// <para>GWL_EXSTYLE�������չ���ڷ��</para>
        /// <para>GWL_STYLE����ô��ڷ��</para>
        /// <para>GWL_WNDPROC����ô��ڹ��̵ĵ�ַ��������ڹ��̵ĵ�ַ�ľ��������ʹ��CallWindowProc�������ô��ڹ��̡�</para>
        /// <para>GWL_HINSTANCE�����Ӧ�������ľ����</para>
        /// <para>GWL_HWNDPAAENT����������ڴ��ڣ���ø����ھ����</para>
        /// <para>GWL_ID:��ô��ڱ�ʶ��</para>
        /// <para>GWL_USERDATA������봰���йص�32λֵ��ÿһ�����ھ���һ���ɴ����ô��ڵ�Ӧ�ó���ʹ�õ�32λֵ��</para>
        /// <para>.</para>
        /// <para>��hWnd������ʶ��һ���Ի���ʱ��nIndexҲ��������ֵ��</para>
        /// <para>DWL_DLGPROC����öԻ�����̵ĵ�ַ����һ������Ի�����̵ĵ�ַ�ľ��������ʹ�ú���CallWindowProc�����öԻ�����̡�</para>
        /// <para>DWL_MSGRESULT������ڶԻ��������һ����Ϣ����ķ���ֵ��</para>
        /// <para>DWL_USER�����Ӧ�ó���˽�еĶ�����Ϣ������һ�������ָ�롣</para>
        /// </summary>
        /// <param name="hWnd">���ھ������Ӹ����Ĵ��������Ĵ����ࡣ</param>
        /// <param name="nIndex">ָ��Ҫ���ֵ�Ĵ��ڵ���0��ֵ��ƫ��������Чֵ�ķ�Χ��0�����ⴰ���ڴ�ռ���ֽ���һ4���磬��ָ����12λ�����12λ�Ķ�����洢�ռ䣬��Ӧ��Ϊ������32λ����������λ8��</param>
        /// <returns>��������ɹ�������ֵ�������32λֵ���������ʧ�ܣ�����ֵ��0��</returns>
        [DllImport("user32.dll", ExactSpelling = false)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����ı�ָ�����ڵ����ԣ�����Ҳ��ָ����һ��32λֵ�����ڴ��ڵĶ���洢�ռ��ָ��ƫ��λ�á�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�����hWnd����ָ���Ĵ���������̲߳�����ͬһ���̣�������SetWindowLong����ʧ�ܡ�</para>
        /// <para>ָ���Ĵ����������ڻ����б���ģ�����ڵ���SetWindowLong֮���ٵ���SetWindowPos��������ʹSetWindowLong���������ĸı���Ч��</para>
        /// <para>���ʹ�ô�GWL_WNDPROC����ֵ��SetWindowLong�����滻���ڹ��̣���ô��ڹ��̱�����WindowProccallback����˵������ָ����ָ����һ�¡�</para>
        /// <para>���ʹ�ô�DWL_MSGRESULT����ֵ��SetWindowLong������������һ���Ի�����̴������Ϣ�ķ���ֵ��Ӧ�ڴ˺���������TRUE����������ֵ���������������ʹ�Ի�����̽��յ�һ��������Ϣ����Ƕ�׵Ĵ�����Ϣ���ܸ�дʹ��DWL_MSGRESULT�趨�ķ���ֵ��</para>
        /// <para>����ʹ�ô�GWL_WNDPROC����ֵ��SetWindowLong��������һ������������࣬�ô����������ڴ����ô��ڵ��ࡣһ��Ӧ�ó��������һ��ϵͳ��Ϊ���࣬���ǲ�����һ���������̲����Ĵ�����Ϊ���࣬SetwindowLong����ͨ���ı���һ������Ĵ���������ϵ�Ĵ��ڹ����������������࣬�Ӷ�ʹϵͳ�����µĴ��ڹ��̶�������ǰ����Ĵ��ڹ��̡�Ӧ�ó������ͨ������CallWindowProc������ǰ���ڴ���δ���´��ڴ������Ϣ������������Ӧ�ó��򴴽�һ�����ڹ�������</para>
        /// <para>ͨ��ʹ�ú���RegisterClassEx���ṹWNDCLASSEX�е�cbWndExtra��Ԫָ��Ϊһ����0ֵ���������ⴰ���ڴ档</para>
        /// <para>����ͨ�����ô�GWL_HWNDPARENT����ֵ��SetWindowLong�ĺ������ı��Ӵ��ڵĸ����ڣ�Ӧʹ��SetParent������</para>
        /// <para>.</para>
        /// <para>Ҫ���������κ�ֵ��nIndex����ָ������ֵ֮һ��</para>
        /// <para>GWL_EXSTYLE���趨һ���µ���չ���</para>
        /// <para>GWL_STYLE���趨һ���µĴ��ڷ��</para>
        /// <para>GWL_WNDPROC��Ϊ���ڹ����趨һ���µĵ�ַ��</para>
        /// <para>GWL_ID������һ���µĴ��ڱ�ʶ����</para>
        /// <para>GWL_HINSTANCE������һ���µ�Ӧ�ó���ʵ�������</para>
        /// <para>GWL_USERDATA�������봰���йص�32λֵ��ÿ�����ھ���һ���ɴ����ô��ڵ�Ӧ�ó���ʹ�õ�32λֵ��</para>
        /// <para>.</para>
        /// <para>��hWnd������ʶ��һ���Ի���ʱ��nIndexҲ��ʹ������ֵ��</para>
        /// <para>DWL_DLGPROC�����öԻ�����̵��µ�ַ��</para>
        /// <para>DWL_MSGRESULT�������ڶԻ�������д������Ϣ�ķ���ֵ��</para>
        /// <para>DWL_USER�����õ�Ӧ�ó���˽�е��µĶ�����Ϣ������һ�������ָ�롣</para>
        /// </summary>
        /// <param name="hWnd">���ھ������Ӹ����Ĵ����������ࡣ</param>
        /// <param name="nIndex">ָ�����趨�Ĵ��ڵ���0��ƫ��ֵ����Чֵ�ķ�Χ��0��������Ĵ洢�ռ���ֽ�����4��������ָ����12λ�����12λ�Ķ�����洢�ռ䣬��Ӧ��Ϊ������32λ����������λ8��</param>
        /// <param name="dwNewLong">ָ�����滻ֵ��</param>
        /// <returns>��������ɹ�������ֵ��ָ����32λ������ԭ����ֵ���������ʧ�ܣ�����ֵΪ0��</returns>
        [DllImport("user32.dll", ExactSpelling = false)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        #endregion


        #region Message Functions                                   ��Ϣ����

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ������Ϣ���͵�һ���������ڡ��˺���Ϊָ���Ĵ��ڵ��ô��ڳ���ֱ�����ڳ���������Ϣ�ٷ��ء�</para>
        /// <para>������PostMessage��ͬ����һ����Ϣ���͵�һ���̵߳���Ϣ���к��������ء�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ��HWND_BROADCASTͨ�ŵ�Ӧ�ó���Ӧ��ʹ�ú���RegisterWindowMessage��ΪӦ�ó�����ͨ��ȡ��һ��Ψһ����Ϣ��</para>
        /// <para>���ָ���Ĵ����������ڵ��õ��̴߳����ģ��򴰿ڳ���������Ϊ�ӳ�����á����ָ���Ĵ������ɲ�ͬ�̴߳����ģ���ϵͳ�л������̲߳�����ǡ���Ĵ��ڳ���</para>
        /// <para>�̼߳����Ϣֻ�����߳�ִ����Ϣ��������ʱ�ű����������̱߳�����ֱ�������̴߳�������ϢΪֹ��</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��򽫽�����Ϣ�Ĵ��ڵľ��������˲���ΪHWND_BROADCAST������Ϣ�������͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڣ�����Ϣ�������͵��Ӵ��ڡ�</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <returns>����ֵָ����Ϣ����Ľ���������������͵���Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ������Ϣ���͵�һ���������ڡ��˺���Ϊָ���Ĵ��ڵ��ô��ڳ���ֱ�����ڳ���������Ϣ�ٷ��ء�</para>
        /// <para>������PostMessage��ͬ����һ����Ϣ���͵�һ���̵߳���Ϣ���к��������ء�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ��HWND_BROADCASTͨ�ŵ�Ӧ�ó���Ӧ��ʹ�ú���RegisterWindowMessage��ΪӦ�ó�����ͨ��ȡ��һ��Ψһ����Ϣ��</para>
        /// <para>���ָ���Ĵ����������ڵ��õ��̴߳����ģ��򴰿ڳ���������Ϊ�ӳ�����á����ָ���Ĵ������ɲ�ͬ�̴߳����ģ���ϵͳ�л������̲߳�����ǡ���Ĵ��ڳ���</para>
        /// <para>�̼߳����Ϣֻ�����߳�ִ����Ϣ��������ʱ�ű����������̱߳�����ֱ�������̴߳�������ϢΪֹ��</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��򽫽�����Ϣ�Ĵ��ڵľ��������˲���ΪHWND_BROADCAST������Ϣ�������͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڣ�����Ϣ�������͵��Ӵ��ڡ�</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <returns>����ֵָ����Ϣ����Ľ���������������͵���Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ������Ϣ���͵�һ���������ڡ��˺���Ϊָ���Ĵ��ڵ��ô��ڳ���ֱ�����ڳ���������Ϣ�ٷ��ء�</para>
        /// <para>������PostMessage��ͬ����һ����Ϣ���͵�һ���̵߳���Ϣ���к��������ء�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ��HWND_BROADCASTͨ�ŵ�Ӧ�ó���Ӧ��ʹ�ú���RegisterWindowMessage��ΪӦ�ó�����ͨ��ȡ��һ��Ψһ����Ϣ��</para>
        /// <para>���ָ���Ĵ����������ڵ��õ��̴߳����ģ��򴰿ڳ���������Ϊ�ӳ�����á����ָ���Ĵ������ɲ�ͬ�̴߳����ģ���ϵͳ�л������̲߳�����ǡ���Ĵ��ڳ���</para>
        /// <para>�̼߳����Ϣֻ�����߳�ִ����Ϣ��������ʱ�ű����������̱߳�����ֱ�������̴߳�������ϢΪֹ��</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��򽫽�����Ϣ�Ĵ��ڵľ��������˲���ΪHWND_BROADCAST������Ϣ�������͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڣ�����Ϣ�������͵��Ӵ��ڡ�</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <returns>����ֵָ����Ϣ����Ľ���������������͵���Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ������Ϣ���͵�һ���������ڡ��˺���Ϊָ���Ĵ��ڵ��ô��ڳ���ֱ�����ڳ���������Ϣ�ٷ��ء�</para>
        /// <para>������PostMessage��ͬ����һ����Ϣ���͵�һ���̵߳���Ϣ���к��������ء�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ��HWND_BROADCASTͨ�ŵ�Ӧ�ó���Ӧ��ʹ�ú���RegisterWindowMessage��ΪӦ�ó�����ͨ��ȡ��һ��Ψһ����Ϣ��</para>
        /// <para>���ָ���Ĵ����������ڵ��õ��̴߳����ģ��򴰿ڳ���������Ϊ�ӳ�����á����ָ���Ĵ������ɲ�ͬ�̴߳����ģ���ϵͳ�л������̲߳�����ǡ���Ĵ��ڳ���</para>
        /// <para>�̼߳����Ϣֻ�����߳�ִ����Ϣ��������ʱ�ű����������̱߳�����ֱ�������̴߳�������ϢΪֹ��</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��򽫽�����Ϣ�Ĵ��ڵľ��������˲���ΪHWND_BROADCAST������Ϣ�������͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڣ�����Ϣ�������͵��Ӵ��ڡ�</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <returns>����ֵָ����Ϣ����Ľ���������������͵���Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ������Ϣ���͵�һ���������ڡ��˺���Ϊָ���Ĵ��ڵ��ô��ڳ���ֱ�����ڳ���������Ϣ�ٷ��ء�</para>
        /// <para>������PostMessage��ͬ����һ����Ϣ���͵�һ���̵߳���Ϣ���к��������ء�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ��HWND_BROADCASTͨ�ŵ�Ӧ�ó���Ӧ��ʹ�ú���RegisterWindowMessage��ΪӦ�ó�����ͨ��ȡ��һ��Ψһ����Ϣ��</para>
        /// <para>���ָ���Ĵ����������ڵ��õ��̴߳����ģ��򴰿ڳ���������Ϊ�ӳ�����á����ָ���Ĵ������ɲ�ͬ�̴߳����ģ���ϵͳ�л������̲߳�����ǡ���Ĵ��ڳ���</para>
        /// <para>�̼߳����Ϣֻ�����߳�ִ����Ϣ��������ʱ�ű����������̱߳�����ֱ�������̴߳�������ϢΪֹ��</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��򽫽�����Ϣ�Ĵ��ڵľ��������˲���ΪHWND_BROADCAST������Ϣ�������͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڣ�����Ϣ�������͵��Ӵ��ڡ�</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <returns>����ֵָ����Ϣ����Ľ���������������͵���Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref NativeMethods.RECT lParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ������Ϣ���͵�һ���������ڡ��˺���Ϊָ���Ĵ��ڵ��ô��ڳ���ֱ�����ڳ���������Ϣ�ٷ��ء�</para>
        /// <para>������PostMessage��ͬ����һ����Ϣ���͵�һ���̵߳���Ϣ���к��������ء�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ��HWND_BROADCASTͨ�ŵ�Ӧ�ó���Ӧ��ʹ�ú���RegisterWindowMessage��ΪӦ�ó�����ͨ��ȡ��һ��Ψһ����Ϣ��</para>
        /// <para>���ָ���Ĵ����������ڵ��õ��̴߳����ģ��򴰿ڳ���������Ϊ�ӳ�����á����ָ���Ĵ������ɲ�ͬ�̴߳����ģ���ϵͳ�л������̲߳�����ǡ���Ĵ��ڳ���</para>
        /// <para>�̼߳����Ϣֻ�����߳�ִ����Ϣ��������ʱ�ű����������̱߳�����ֱ�������̴߳�������ϢΪֹ��</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��򽫽�����Ϣ�Ĵ��ڵľ��������˲���ΪHWND_BROADCAST������Ϣ�������͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڣ�����Ϣ�������͵��Ӵ��ڡ�</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <returns>����ֵָ����Ϣ����Ľ���������������͵���Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref NativeMethods.COPYDATASTRUCT lParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ������Ϣ���͵�һ���������ڡ��˺���Ϊָ���Ĵ��ڵ��ô��ڳ���ֱ�����ڳ���������Ϣ�ٷ��ء�</para>
        /// <para>������PostMessage��ͬ����һ����Ϣ���͵�һ���̵߳���Ϣ���к��������ء�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ��HWND_BROADCASTͨ�ŵ�Ӧ�ó���Ӧ��ʹ�ú���RegisterWindowMessage��ΪӦ�ó�����ͨ��ȡ��һ��Ψһ����Ϣ��</para>
        /// <para>���ָ���Ĵ����������ڵ��õ��̴߳����ģ��򴰿ڳ���������Ϊ�ӳ�����á����ָ���Ĵ������ɲ�ͬ�̴߳����ģ���ϵͳ�л������̲߳�����ǡ���Ĵ��ڳ���</para>
        /// <para>�̼߳����Ϣֻ�����߳�ִ����Ϣ��������ʱ�ű����������̱߳�����ֱ�������̴߳�������ϢΪֹ��</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��򽫽�����Ϣ�Ĵ��ڵľ��������˲���ΪHWND_BROADCAST������Ϣ�������͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڣ�����Ϣ�������͵��Ӵ��ڡ�</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣָ����Ϣ��</param>
        /// <returns>����ֵָ����Ϣ����Ľ���������������͵���Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref NativeMethods.TOOLINFO lParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����һ����Ϣ���루���ͣ�����ָ�����ڴ������߳�����ϵ��Ϣ��������ȴ��̴߳�����Ϣ�ͷ��أ����첽��Ϣģʽ��</para>
        /// <para>��Ϣ���������Ϣͨ������GetMessage��PeekMessageȡ�á�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ�� HWND_BROADCAST��ʽͨ�ŵ�Ӧ�ó���Ӧ���ú��� RegisterwindwosMessage�����Ӧ�ó����ͨ�ŵĶ��ص���Ϣ��</para>
        /// <para>�������һ������WM_USER��Χ����Ϣ���첽��Ϣ������PostMessage.SendNotifyMessage��SendMesssgeCallback������Ϣ�������ܰ���ָ�롣</para>
        /// <para>���򣬲�������ʧ�ܡ��������ٽ����̴߳�����Ϣ֮ǰ���أ������߽����ڴ汻ʹ��֮ǰ�ͷš�</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��������Ϣ�Ĵ��ڵľ������ȡ���ض����������ֵ��HWND_BROADCAST����Ϣ�����͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڡ���Ϣ�������͵��Ӵ��ڡ�NULL���˺����Ĳ����͵��ò���dwThread����Ϊ��ǰ�̵߳ı�ʶ��PostThreadMessage����һ����</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣ�ض�����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣ�ض�����Ϣ��</param>
        /// <returns>����������óɹ������ط���ֵ�������������ʧ�ܣ�����ֵ���㡣�����ø���Ĵ�����Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����һ����Ϣ���루���ͣ�����ָ�����ڴ������߳�����ϵ��Ϣ��������ȴ��̴߳�����Ϣ�ͷ��أ����첽��Ϣģʽ��</para>
        /// <para>��Ϣ���������Ϣͨ������GetMessage��PeekMessageȡ�á�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ҫ�� HWND_BROADCAST��ʽͨ�ŵ�Ӧ�ó���Ӧ���ú��� RegisterwindwosMessage�����Ӧ�ó����ͨ�ŵĶ��ص���Ϣ��</para>
        /// <para>�������һ������WM_USER��Χ����Ϣ���첽��Ϣ������PostMessage.SendNotifyMessage��SendMesssgeCallback������Ϣ�������ܰ���ָ�롣</para>
        /// <para>���򣬲�������ʧ�ܡ��������ٽ����̴߳�����Ϣ֮ǰ���أ������߽����ڴ汻ʹ��֮ǰ�ͷš�</para>
        /// </summary>
        /// <param name="hWnd">�䴰�ڳ��������Ϣ�Ĵ��ڵľ������ȡ���ض����������ֵ��HWND_BROADCAST����Ϣ�����͵�ϵͳ�����ж��㴰�ڣ�������Ч�򲻿ɼ��ķ�����ӵ�еĴ��ڡ������ǵĴ��ں͵���ʽ���ڡ���Ϣ�������͵��Ӵ��ڡ�NULL���˺����Ĳ����͵��ò���dwThread����Ϊ��ǰ�̵߳ı�ʶ��PostThreadMessage����һ����</param>
        /// <param name="Msg">ָ�������͵���Ϣ��</param>
        /// <param name="wParam">ָ�����ӵ���Ϣ�ض�����Ϣ��</param>
        /// <param name="lParam">ָ�����ӵ���Ϣ�ض�����Ϣ��</param>
        /// <returns>����������óɹ������ط���ֵ�������������ʧ�ܣ�����ֵ���㡣�����ø���Ĵ�����Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        #endregion


        #region Configuration Reference                             ���òο�

        /// <summary>
        /// ����ָ����ϵͳ������ϵͳ�������á�ע�����м���GetSystemMetrics�����سߴ硣
        /// </summary>
        /// <param name="nIndex">The system metric or configuration setting to be retrieved. This parameter can be one of the following values. Note that all SM_CX* values are widths and all SM_CY* values are heights. Also note that all settings designed to return Boolean data represent TRUE as any nonzero value, and FALSE as a zero value.</param>
        /// <returns>��������ɹ�������ֵ����Ҫ���ϵͳ�������������á��������ʧ�ܣ�����ֵ��0�����ṩ��չ�Ĵ�����Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        #endregion


        #region Error Handling Functions                            ��������

        /// <summary>
        /// <para>����:</para>
        /// <para>��˸ָ������һ�Ρ����ı䴰�ڵļ���״̬��Ҫָ����˸��ʱ�䣬ʹ��FlashWindowEx������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>Flashing a window means changing the appearance of its caption bar as if the window were changing from inactive to active status, or vice versa. (An inactive caption bar changes to an active caption bar; an active caption bar changes to an inactive caption bar.)</para>
        /// <para>Typically, a window is flashed to inform the user that the window requires attention but that it does not currently have the keyboard focus.</para>
        /// <para>The FlashWindow function flashes the window only once; for repeated flashing, the application should create a system timer.</para>
        /// </summary>
        /// <param name="hWnd">A handle to the window to be flashed. The window can be either open or minimized.</param>
        /// <param name="bInvert">
        /// <para>If this parameter is TRUE, the window is flashed from one state to the other. If it is FALSE, the window is returned to its original state (either active or inactive).</para>
        /// <para>When an application is minimized and this parameter is TRUE, the taskbar window button flashes active/inactive.</para>
        /// <para>If it is FALSE, the taskbar window button flashes inactive, meaning that it does not change colors. It flashes, as if it were being redrawn, but it does not provide the visual invert clue to the user.</para>
        /// </param>
        /// <returns>The return value specifies the window's state before the call to the FlashWindow function. If the window caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        /// <summary>
        /// <para>����:</para>
        /// <para>��˸ָ�����ڡ����ı䴰�ڵļ���״̬��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>Typically, you flash a window to inform the user that the window requires attention but does not currently have the keyboard focus.</para>
        /// <para>When a window flashes, it appears to change from inactive to active status. An inactive caption bar changes to an active caption bar; an active caption bar changes to an inactive caption bar.</para>
        /// </summary>
        /// <param name="pfwi">A pointer to a FLASHWINFO structure.</param>
        /// <returns>The return value specifies the window's state before the call to the FlashWindowEx function. If the window caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(ref  NativeMethods.FLASHWINFO pfwi);

        #endregion


        #region Coordinate Space and Transformation Functions       ����ռ�任����

        /// <summary>
        /// �ú�����ָ������û�����ת������Ļ���ꡣ
        /// </summary>
        /// <param name="hWnd">�û���������ת���Ĵ��ھ����</param>
        /// <param name="lpPoint">ָ��һ������Ҫת�����û�����Ľṹ��ָ�룬����������óɹ�������Ļ���긴�Ƶ��˽ṹ��</param>
        /// <returns>����������óɹ�������ֵΪ����ֵ������Ϊ�㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref NativeMethods.POINT lpPoint);
        /// <summary>
        /// �ú�������Ļ��ָ�������Ļ����ת�����û����ꡣ
        /// </summary>
        /// <param name="hWnd">ָ�򴰿ڵľ�����˴��ڵ��û��ռ佫������ת����</param>
        /// <param name="lpPoint">ָ��POINT�ṹָ�룬�ýṹ����Ҫת������Ļ���ꡣ</param>
        /// <returns>����������óɹ�������ֵΪ����ֵ������Ϊ�㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref NativeMethods.POINT lpPoint);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����������һ�����ڵ�����ռ��һ���ӳ����������һ���ڵ�����ռ��һ��㡣</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>.</para>
        /// </summary>
        /// <param name="hWndFrom">ת�������ڴ��ڵľ��������˲���ΪNULL��HWND_DESETOP��ٶ���Щ������Ļ�����ϡ�</param>
        /// <param name="hWndTo">ת�����Ĵ��ڵľ��������˲���ΪNULL��HWND_DESKTOP����Щ�㱻ת��Ϊ��Ļ���ꡣ</param>
        /// <param name="rect">ָ��POINT�ṹ�����ָ�룬�˽ṹ�������Ҫת���ĵ㣬�˲���Ҳ��ָ��RECT�ṹ���ڴ�����£�Cpoints����Ӧ����Ϊ2��</param>
        /// <param name="cPoints">ָ��rect����ָ���������POINT�ṹ����Ŀ��</param>
        /// <returns>����������óɹ�������ֵ�ĵ�λ����ÿһ��Դ���ˮƽ�����������Ŀ���Ա����ÿ��Ŀ����ˮƽ���ꣻ��λ����ÿһ��Դ��Ĵ�ֱ��������ص���Ŀ���Ա����ÿ��Ŀ���Ĵ�ֱ���꣬�����������ʧ�ܣ�����ֵΪ�㡣</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] ref NativeMethods.RECT rect, int cPoints);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����������һ�����ڵ�����ռ��һ���ӳ����������һ���ڵ�����ռ��һ��㡣</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>.</para>
        /// </summary>
        /// <param name="hWndFrom">ת�������ڴ��ڵľ��������˲���ΪNULL��HWND_DESETOP��ٶ���Щ������Ļ�����ϡ�</param>
        /// <param name="hWndTo">ת�����Ĵ��ڵľ��������˲���ΪNULL��HWND_DESKTOP����Щ�㱻ת��Ϊ��Ļ���ꡣ</param>
        /// <param name="pt">ָ��POINT�ṹ�����ָ�룬�˽ṹ�������Ҫת���ĵ㣬�˲���Ҳ��ָ��RECT�ṹ���ڴ�����£�Cpoints����Ӧ����Ϊ2��</param>
        /// <param name="cPoints">ָ��pt����ָ���������POINT�ṹ����Ŀ��</param>
        /// <returns>����������óɹ�������ֵ�ĵ�λ����ÿһ��Դ���ˮƽ�����������Ŀ���Ա����ÿ��Ŀ����ˮƽ���ꣻ��λ����ÿһ��Դ��Ĵ�ֱ��������ص���Ŀ���Ա����ÿ��Ŀ���Ĵ�ֱ���꣬�����������ʧ�ܣ�����ֵΪ�㡣</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] ref NativeMethods.POINT pt, int cPoints);

        #endregion


        #region Device Context Functions                            �豸�����ĺ���

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������һָ�����ڵĿͻ������������Ļ����ʾ�豸�����Ļ����ľ�����Ժ������GDI������ʹ�øþ�������豸�����Ļ����л�ͼ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// </summary>
        /// <param name="hWnd">�豸�����Ļ����������Ĵ��ڵľ���������ֵΪNULL��GetDC�����������Ļ���豸�����Ļ�����</param>
        /// <returns>����ɹ�������ָ�����ڿͻ������豸�����Ļ��������ʧ�ܣ�����ֵΪNull��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������ָ�����ڿͻ������������Ļ����ʾ�豸�����Ļ����ľ����������GDI�����п���ʹ�øþ�����豸�����Ļ����л�ͼ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>������ʾ�豸�����Ļ�������һ�������࣬�ڻ�ͼ����֮��һ��Ҫ����ReleaseDC�����ͷ��豸�����Ļ�������Ϊֻ��5�������豸�����Ļ������κθ�����ʱ�䶼��Ч���ͷ��豸�����Ļ���ʧ�ܵ�������Ӧ�ó����ܷ��ʸ��豸�����Ļ�����</para>
        /// <para>�����������ע��ʱ��CS_CLASSDC��CS_OWNDC��CS_PARENTDC��ָ��ΪWNDCLASS�ṹ�ķ����ô�ú�������һ�����ڸô�������豸�����Ļ�����</para>
        /// <para>.</para>
        /// <para>���б�־�ɱ������ڲ���flags��:</para>
        /// <para>DCX_WINDOW�������봰�ھ��ζ�������ͻ��������Ӧ���豸�����Ļ�����</para>
        /// <para>DXC_CACHE���Ӹ��ٻ�������Ǵ�OWNDC��CLASSDC�����з����豸�����Ļ������ӱ����ϸ���CS_OWNDC��CS_CLASSDC��</para>
        /// <para>DCX_PARENTCLIP��ʹ�ø����ڵĿɼ����򣬸����ڵ�WS_CIPCHILDREN��CS_PARENTDC��񱻺��ԣ������豸�����Ļ�����ԭ�㣬������hWnd����ʶ�Ĵ��ڵ����Ͻǡ�</para>
        /// <para>DCX_CLIPSIBLINGS���ų�hWnd��������ʶ�����ϵ������ֵܴ��ڵĿɼ�����</para>
        /// <para>DCX_CLIPCHILDREN���ų�hWnd��������ʶ�����ϵ������Ӵ��ڵĿɼ�����</para>
        /// <para>DCX_NORESETATTRS�����豸�����Ļ������ͷ�ʱ���������ø��豸�����Ļ���������Ϊȱʡ���ԡ�</para>
        /// <para>DCX_LOCKWINDOWUPDATE����ʹ���ų�ָ�����ڵ�LockWindowUpdate����������Ч�������Ҳ�����ƣ��ò��������ڸ����ڼ���л��ơ�</para>
        /// <para>DCX_EXCLUDERGN���ӷ����豸�����Ļ����Ŀɼ��������ų���hrgnClipָ���ļ�������</para>
        /// <para>DCX_INTERSECTRGN����hrgnClipָ���ļ��������뷵���豸�����Ŀɼ������������㡣</para>
        /// <para>DCX_VALIDATE������DCX_INTERSECTUPDATEһ��ָ��ʱ����ʹ�豸�����Ļ�����ȫ��Ч���ú�����DCX_INTERSECTUPDATE��DCX_VALIDATEһ��ʹ��ʱ��ʹ��BeginPaint������ͬ��</para>
        /// </summary>
        /// <param name="hWnd">���ڵľ�����ô��ڵ��豸�����Ļ�����Ҫ�������������ֵΪNULL����GetDCEx������������Ļ���豸�����Ļ�����</param>
        /// <param name="hrgnClip">ָ��һ�����������������豸�����Ļ����Ŀɼ��������ϡ�</param>
        /// <param name="flags">ָ����δ����豸�����Ļ�����</param>
        /// <returns>����ɹ�������ֵ��ָ�������豸�����Ļ����ľ�������ʧ�ܣ�����ֵΪNull��HWnd������һ����Чֵ��ʹ����ʧ�ܡ�</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags);
        /// <summary>
        /// <para>����:</para>
        /// <para>�����ͷ��豸�����Ļ�����DC��������Ӧ�ó���ʹ�á�������Ч�����豸�����Ļ��������йء���ֻ�ͷŹ��õĺ��豸�����Ļ������������˽�е�����Ч��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>ÿ�ε���GetWindowDC��GetDC�������������豸�����Ļ���֮��Ӧ�ó���������ReleaseDC�������ͷ��豸�����Ļ�����</para>
        /// </summary>
        /// <param name="hWnd">ָ��Ҫ�ͷŵ��豸�����Ļ������ڵĴ��ڵľ����</param>
        /// <param name="hDC">ָ��Ҫ�ͷŵ��豸�����Ļ����ľ���� </param>
        /// <returns>����ֵ˵�����豸�����Ļ����Ƿ��ͷţ�����ͷųɹ����򷵻�ֵΪ1�����û���ͷųɹ����򷵻�ֵΪ0��</returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        #endregion


        #region Painting and Drawing Functions                      �滭�ͻ�ͼ����

        /// <summary>
        /// <para>����:</para>
        /// <para>BeginPaint����Ϊָ�����ڽ��л�ͼ������׼�������ý��ͻ�ͼ�йص���Ϣ��䵽һ��PAINTSTRUCT�ṹ�С�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>BeginPaint�����Զ�������ʾ�豸���ݵļ������򣬶��ų��κθ�������������򡣸ø����������ͨ��InvalidateRect��InvalidateRgn�������ã�Ҳ������ϵͳ�ڸı��С���ƶ������������������õģ�</para>
        /// <para>����������Ӱ��ͻ����Ĳ��������õġ�����������򱻱��Ϊ�ɲ����ģ�BeginPaint����һ��WM_ERASEBKGND��Ϣ�����ڡ�</para>
        /// <para>һ��Ӧ�ó��������ӦWM_PAINT��Ϣ�⣬��Ӧ�õ���BeginPaint��ÿ�ε���BeginPaint��Ӧ������Ӧ��EndPaint������</para>
        /// <para>������滭�Ŀͻ�������һ��caret��caret����������Ǵ��ڿͻ����е�һ����˸���ߣ��飬��λͼ�������ͨ����ʾ�ı���ͼ�ν�������ĵط�����һ��һ���Ĺ�꣩��BeginPaint�Զ����ظ÷��ţ�����֤������������</para>
        /// <para>�����������һ������ˢ��BeginPaintʹ�����ˢ����������������ı�����</para>
        /// </summary>
        /// <param name="hWnd">���ػ�Ĵ��ھ��</param>
        /// <param name="lpPaint">ָ��һ���������ջ滭��Ϣ��PAINTSTRUCT�ṹ</param>
        /// <returns>��������ɹ�������ֵ��ָ�����ڵġ���ʾ�豸������������������ʧ�ܣ�����ֵ��NULL������û�еõ���ʾ�豸�����ݡ�Windows NT/2000/XP: ʹ��GetLastError�õ�����Ĵ�����Ϣ��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref NativeMethods.PAINTSTRUCT lpPaint);
        /// <summary>
        /// <para>����:</para>
        /// <para>EndPaint�������ָ�����ڵĻ滭���̽�����</para>
        /// <para>���������ÿ�ε���BeginPaint����֮�����󣬵������ڻ滭����Ժ�</para>
        /// </summary>
        /// <param name="hWnd">�Ѿ����ػ��Ĵ��ڵ�HANDLE</param>
        /// <param name="lpPaint">ָ��һ��PAINTSTRUCT�ṹ���ýṹ�����˻滭��Ϣ����BeginPaint�������صķ���ֵ��</param>
        /// <returns>����ֵʼ���Ƿ�0</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndPaint(IntPtr hWnd, ref NativeMethods.PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>����:</para>
        /// <para>����hWnd������ָ���Ĵ��ڵ������Ļ�����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��</para>
        /// </summary>
        /// <param name="hWnd">��Ҫ��ȡ�����Ļ����Ĵ��ڵľ��</param>
        /// <returns>����ɹ�������ָ�����ڿͻ������豸�����Ļ��������ʧ�ܣ�����ֵΪNull��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>
        /// <para>����:</para>
        /// <para>��ȡ���ڵ�����ֻ�б���������������ڵĵط��Żᱻ�ػ棬���������������ڵ���������ϵͳ��������ʾ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>һ�����ڵĴ����������������ڴ��ڵ����Ͻǣ��������ڴ��ڵĿͻ�����</para>
        /// <para>���ô��ڵĴ������򣬵���SetWindowRgn���ܡ�</para>
        /// </summary>
        /// <param name="hWnd">Ҫ���õĴ��ھ����</param>
        /// <param name="hRgn">�����޸ĵ�region�ľ����</param>
        /// <returns>����ֵָ���ú�����õ��������͡�������������ֵ֮һ��NULLREGION �μ�SCR</returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
        /// <summary>
        /// <para>����:</para>
        /// <para>�����趨ĳһ���ڵ��ض����򣨴������򣩡� ��һ��������˸ô�����ϵͳ���Ի�ͼ�ķ�Χ�� ϵͳ����ʾ�ô�����һ����֮����κβ��֡�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���ú��������õ�ʱ��ϵͳ�Ѹ����ڵ�ѶϢ�͸� WM_WINDOWPOSCHANGING �� WM_WINDOWPOSCHANGED ��</para>
        /// <para>һ�������Ĵ����������������ڴ��ڵ�����-��߽�������Ǵ��ڵĿͻ�����</para>
        /// <para>���óɹ�֮�󣬶� SetWindowRgn ��ϵͳӵ�б������ hRgn ָ�������� ϵͳ��������ĸ����� ��ˣ��㲻Ӧ������һ������������κεĽϽ�һ���ķ������á� ���䣬��Ҫɾ����һ���������� ����������Ҫ��ʱ��ϵͳ������һ��������</para>
        /// <para>Ϊ��Ҫ��ô��ڵĴ������򣬵��� GetWindowRgn ������</para>
        /// </summary>
        /// <param name="hWnd">�����趨���������ĳһ���ڵı���</param>
        /// <param name="hRgn">��������ľ���������������Ĵ��������趨Ϊ��һ��������� hRgn ����Ч���ģ����������������趨Ϊ�㡣</param>
        /// <param name="bRedraw">ָ��ϵͳ�Ƿ����趨��������֮���ػ洰�ڡ���� bRedraw ΪTRUE��ϵͳ�ػ�; ���򣬲��ػ档</param>
        /// <returns>����������óɹ����ط���ֵ�Ƿ��㡣�����������ʧ�ܣ��ط���ֵ���㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ���Ĵ�������������һ�����Σ�Ȼ�󴰿ڿͻ��������һ���ֽ������»��ơ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�����Ϊ��Ч���ε�����ֱ��WM_PAINT��Ϣ��������֮��Ż���ʧ������ʹ��ValidateRect()��ValidateRgn()������ʹ֮��Ч��</para>
        /// <para>��Ӧ�ó������Ϣ������Ϊ��ʱ�����Ҵ���Ҫ���µ�����ǿ�ʱ��ϵͳ�ᷢ��һ��WM_PAINT��Ϣ�����塣</para>
        /// </summary>
        /// <param name="hWnd">Ҫ���µĿͻ������ڵĴ���ľ�������ΪNULL����ϵͳ���ں�������ǰ���»������еĴ���, Ȼ���� WM_ERASEBKGND �� WM_NCPAINT �����ڹ��̴�������</param>
        /// <param name="lpRect">��Ч����ľ��δ�������һ���ṹ��ָ�룬����ž��εĴ�С�����ΪNULL��ȫ���Ĵ��ڿͻ����򽫱����ӵ����������С�</param>
        /// <param name="bErase">ָ����Ч���α����Ϊ��Ч���Ƿ��ػ��������ػ�ʱ��Ԥ�ȶ���õĻ�ˢ����ָ��TRUEʱ��Ҫ�ػ���</param>
        /// <returns>�����ɹ��򷵻ط���ֵ�����򷵻���ֵ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ���Ĵ�������������һ�����Σ�Ȼ�󴰿ڿͻ��������һ���ֽ������»��ơ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�����Ϊ��Ч���ε�����ֱ��WM_PAINT��Ϣ��������֮��Ż���ʧ������ʹ��ValidateRect()��ValidateRgn()������ʹ֮��Ч��</para>
        /// <para>��Ӧ�ó������Ϣ������Ϊ��ʱ�����Ҵ���Ҫ���µ�����ǿ�ʱ��ϵͳ�ᷢ��һ��WM_PAINT��Ϣ�����塣</para>
        /// </summary>
        /// <param name="hWnd">Ҫ���µĿͻ������ڵĴ���ľ�������ΪNULL����ϵͳ���ں�������ǰ���»������еĴ���, Ȼ���� WM_ERASEBKGND �� WM_NCPAINT �����ڹ��̴�������</param>
        /// <param name="lpRect">��Ч����ľ��δ�������һ���ṹ��ָ�룬����ž��εĴ�С�����ΪNULL��ȫ���Ĵ��ڿͻ����򽫱����ӵ����������С�</param>
        /// <param name="bErase">ָ����Ч���α����Ϊ��Ч���Ƿ��ػ��������ػ�ʱ��Ԥ�ȶ���õĻ�ˢ����ָ��TRUEʱ��Ҫ�ػ���</param>
        /// <returns>�����ɹ��򷵻ط���ֵ�����򷵻���ֵ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect(IntPtr hWnd, ref NativeMethods.RECT lpRect, bool bErase);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú���ͨ�����һ������һ�����ڵĸ�����������ʹָ�����εĿͻ�������Ч��</para>
        /// <para>�����Ч����������и��������е��������򽫱������������һ��WM_PAINT��Ϣ������ʱ����档</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��Ч�������ۻ���ֱ���¸�WM_PAINT��Ϣ���������ͨ��ValidateRect��ValidateRgn��ʹ�������Ч��</para>
        /// <para>ϵͳ����һ��WM_PAINT��Ϣ����һ�����ڣ����۴��ڵĸ��������ǲ��ǿյģ���û����������Ϣ�ڴ��ڵ�Ӧ�ó�������С�</para>
        /// <para>ָ������������Ѿ�ͨ��һ�������������ˡ�</para>
        /// <para>��������������κβ��ֵ�bErase������TRUE����������ı�������������������ָ�����ǲ��֡�</para>
        /// </summary>
        /// <param name="hWnd">���������޸ĵĴ��ھ��</param>
        /// <param name="hRgn">����ӵ��������������ľ����������򱻼ٶ���һ���ͻ������ꡣ������������NULL�������ͻ���������ӽ���������</param>
        /// <param name="bErase">˵�����������򱻴����ʱ����������ڵı����Ƿ�Ҫ������������������TRUE����BeginPaint���������õ�ʱ�򱳾��������������������FALSE����������ı䡣</param>
        /// <returns>����ֵ���Ƿ��㡣</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRgn(IntPtr hWnd, IntPtr hRgn, bool bErase);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������ָ�����ڵ���Ч��������ʹ֮��Ч��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>BeginPaint�������Զ�ʹȫ���ͻ�����Ч��</para>
        /// <para>�������һ��WM_PAINT��Ϣ����֮ǰ��һ������ĵĸ������������Ч����ô��Ҫ����ValidateRect��ValidateRgn������</para>
        /// <para>����ϵͳ��������WM_PAINT ��Ϣֱ����ǰ�ĸ���������Ч��</para>
        /// </summary>
        /// <param name="hWnd">��ʶһ����Ҫ�޸�״̬�Ĵ��ڡ����ò���ΪNULL, ϵͳ���������еĴ��ڣ�Ȼ���ں�������ǰ���� WM_ERASEBKGND �� WM_NCPAINT ��Ϣ�����ڹ��̴�������</param>
        /// <param name="lpRect">ָ��һ��������Ҫ��Ч�ľ��εĸ������������RECT �ṹ�塣����ò���ΪNULL�����еĿͻ����򽫻���Ч��</param>
        /// <returns>�ɹ�ִ�з��ط���ֵ�����򷵻���ֵ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ValidateRect(IntPtr hWnd, ref NativeMethods.RECT lpRect);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������ָ�����ڵ���Ч��������ʹ֮��Ч��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>BeginPaint�������Զ�ʹȫ���ͻ�����Ч��</para>
        /// <para>�������һ��WM_PAINT��Ϣ����֮ǰ��һ������ĵĸ������������Ч����ô��Ҫ����ValidateRect��ValidateRgn������</para>
        /// <para>����ϵͳ��������WM_PAINT ��Ϣֱ����ǰ�ĸ���������Ч��</para>
        /// </summary>
        /// <param name="hWnd">��ʶһ����Ҫ�޸�״̬�Ĵ��ڡ����ò���ΪNULL, ϵͳ���������еĴ��ڣ�Ȼ���ں�������ǰ���� WM_ERASEBKGND �� WM_NCPAINT ��Ϣ�����ڹ��̴�������</param>
        /// <param name="lpRect">ָ��һ��������Ҫ��Ч�ľ��εĸ������������RECT �ṹ�塣����ò���ΪNULL�����еĿͻ����򽫻���Ч��</param>
        /// <returns>�ɹ�ִ�з��ط���ֵ�����򷵻���ֵ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ValidateRect(IntPtr hWnd, IntPtr lpRect);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������ָ�����ڵ���Ч����ʹ֮��Ч��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>BeginPaint�������Զ�ʹȫ���ͻ�����Ч��</para>
        /// <para>�������һ��WM_PAINT��Ϣ����֮ǰ��һ������ĵĸ������������Ч����ô��Ҫ����ValidateRect��ValidateRgn������</para>
        /// <para>����ϵͳ��������WM_PAINT ��Ϣֱ����ǰ�ĸ���������Ч��</para>
        /// </summary>
        /// <param name="hWnd">��ʶһ����Ҫ�޸�״̬�Ĵ��ڡ�</param>
        /// <param name="hRgn">Ҫ�Ƴ�������ľ��������ò���ΪNULL�����еĿͻ����򽫻���Ч��</param>
        /// <returns>�ɹ�ִ�з��ط���ֵ�����򷵻���ֵ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ValidateRgn(IntPtr hWnd, IntPtr hRgn);

        /// <summary>
        /// <para>����:</para>
        /// <para>������ڸ��µ�����Ϊ�գ�UpdateWindow����ͨ������һ��WM_PAINT��Ϣ������ָ�����ڵĿͻ�����</para>
        /// <para>�����ƹ�Ӧ�ó������Ϣ���У�ֱ�ӷ���WM_PAINT��Ϣ��ָ�����ڵĴ��ڹ��̣������������Ϊ�գ��򲻷�����Ϣ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// </summary>
        /// <param name="hWnd">Ҫ���µĴ��ڵľ��.</param>
        /// <returns>����������óɹ�������ֵΪ����ֵ������������ò��ɹ�������ֵΪ�㡣��Windows NT/2000/XP�У����ǿ���ʹ��API ���� GetLastError ���õ���չ�Ĵ�����Ϣ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����ػ�ȫ���򲿷ִ�������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��������洰��Ӧ�������������Ӧ�ó��������RDW_ERASE����ػ����档</para>
        /// </summary>
        /// <param name="hWnd">Ҫ�ػ��Ĵ��ڵľ�������ʾ�������洰��</param>
        /// <param name="lprcUpdate">��������Ҫ�ػ���һ�������������hrgnUpdate����ʶ�𣬽����Դ˲�����</param>
        /// <param name="hrgnUpdate">������Ҫ�ػ�ļ�������</param>
        /// <param name="flags">�涨�����ػ������ı�ʶ��</param>
        /// <returns>����������óɹ�������ֵΪ����ֵ������������ò��ɹ�������ֵΪ�㡣��Windows NT/2000/XP�У����ǿ���ʹ��API ���� GetLastError ���õ���չ�Ĵ�����Ϣ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, int flags);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����ػ�ȫ���򲿷ִ�������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��������洰��Ӧ�������������Ӧ�ó��������RDW_ERASE����ػ����档</para>
        /// </summary>
        /// <param name="hWnd">Ҫ�ػ��Ĵ��ڵľ�������ʾ�������洰��</param>
        /// <param name="lprcUpdate">��������Ҫ�ػ���һ�������������hrgnUpdate����ʶ�𣬽����Դ˲�����</param>
        /// <param name="hrgnUpdate">������Ҫ�ػ�ļ�������</param>
        /// <param name="flags">�涨�����ػ������ı�ʶ��</param>
        /// <returns>����������óɹ�������ֵΪ����ֵ������������ò��ɹ�������ֵΪ�㡣��Windows NT/2000/XP�У����ǿ���ʹ��API ���� GetLastError ���õ���չ�Ĵ�����Ϣ��</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RedrawWindow(IntPtr hWnd, ref NativeMethods.RECT lprcUpdate, IntPtr hrgnUpdate, int flags);

        #endregion


        #region Keyboard Input Functions                            �������뺯��

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);


        /// <summary>
        /// <para>����:</para>
        /// <para>�ú��������ж�ָ���Ĵ����Ƿ�������ܼ��̻�������롣</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�Ӵ���ֻ���ڱ������ҿɼ�ʱ�ſɽ������롣</para>
        /// </summary>
        /// <param name="hWnd">�����ԵĴ��ھ����</param>
        /// <returns>������������ܼ��̻�������룬�򷵻ط���ֵ�������ڲ�������ܼ��̻�������룬�򷵻�ֵΪ�㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowEnabled(IntPtr hWnd);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������/��ָֹ���Ĵ��ڻ�ؼ��������ͼ��̵����룬�����뱻��ֹʱ�����ڲ���Ӧ���Ͱ��������룬��������ʱ�����ڽ������е����롣</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�����ڵ�����״̬�������仯��WM_ENABLE��Ϣ����Enblewindow��������ǰ���ͳ�ȥ���������ѱ���ֹ�������е��Ӵ���Ҳ����ֹ�����ܲ�δ���Ӵ��ڷ���WM_ENABLE��Ϣ��</para>
        /// <para>���ڱ�����ǰ���봦������״̬�����磬һ��Ӧ�ó�����ʾһ����ģʽ�Ի�������ʹ�öԻ���������ڴ��ڽ�ֹ״̬�����ڳ����öԻ���֮ǰ��ʹ�������ڴ�������״̬�������������ڽ����ܲ���������Ӵ��ڱ���ֹ����ϵͳ�������ĸ����ڽ��������Ϣʱ�����Ըô���</para>
        /// <para>ȱʡ����£����ڱ�����ʱ����Ϊ����������һ����ʼ��Ϊ��ֹ״̬�Ĵ��ڣ�Ӧ�ó�����Ҫ��CeateWindow��CeateWindowEX�����ж���WS_DISABLED��ʽ�����ڴ�����Ӧ�ó������EnbleWindow�������ֹ���ڡ�</para>
        /// <para>Ӧ�ó�������ô˺�������/��ֹ�Ի����е�ĳ���ؼ�������ֹ�Ŀؼ��Ȳ��ܽ��ܼ������룬Ҳ���ܱ��û����ʡ�</para>
        /// </summary>
        /// <param name="hWnd">������/��ֹ�Ĵ��ھ��</param>
        /// <param name="bEnable">���崰���Ǳ��������Ǳ���ֹ�����ò���ΪTRUE���򴰿ڱ��������ò���ΪFALSE���򴰿ڱ���ֹ��</param>
        /// <returns>�� EnableWindow ��Ա��������֮ǰ��ָʾ״̬��������ڴ�ǰ�ѽ��ã��򷵻�ֵ�Ƿ��㡣������ڴ�ǰδ���ã��򷵻�ֵ���㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        /// <summary>
        /// <para>����:</para>
        /// <para>�������м��̽���Ĵ��ڵľ��,����������ӵ������̵߳���Ϣ���С�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>GetFocus���ؼ��̽���Ĵ���Ϊ��ǰ�̵߳���Ϣ���С����GetFocus����NULL,��һ���̵߳Ķ��п������ӵ����̽����һ�����ڡ�</para>
        /// <para>ʹ��GetForegroundWindow���������������û���ǰ�����Ĵ��ڡ�����Խ�����̵߳���Ϣ�����봰������һ���߳�ʹ��AttachThreadInput���ܡ�</para>
        /// <para>��ü��̽���Ĵ���ǰ̨���л���һ���̵߳Ķ���,ʹ��GetGUIThreadInfo���ܡ�</para>
        /// </summary>
        /// <returns>����ֵ�Ǽ��̽���Ĵ��ڵľ������������̵߳���Ϣ����û������̽�����صĴ���,����ֵ��NULL��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();
        /// <summary>
        /// <para>����:</para>
        /// <para>���̽�������Ϊָ���Ĵ��ڡ��������븽�ӵ������̵߳���Ϣ���С�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>SetFocus��������һ��WM_KILLFOCUS��Ϣ��ʧ���̽���Ĵ��ں�һ��WM_SETFOCUS��Ϣ���ռ��̽���Ĵ��ڡ�ͬʱ�����,���ս���򸸴��ڵĽ��ս��㡣</para>
        /// <para>���һ�������ǻ�Ծ��û�н���,��������¾ͻ����WM_SYSCHAR,WM_SYSKEYDOWN,��WM_SYSKEYUP��Ϣ��������ش�VK_MENU��,��Ϣ��lParam�������е�30��������,û����һ���������Ϣ��</para>
        /// <para>ͨ��ʹ��AttachThreadInput����,һ���߳̿��Խ������봦���ӵ���һ���̡߳�������һ���̵߳���SetFocus���ü��̽��㴰�����ӵ���һ���̵߳���Ϣ���С�</para>
        /// </summary>
        /// <param name="hWnd">���ڵľ��,�����ռ������롣������������NULL,���������ԡ�</param>
        /// <returns>��������ɹ�,����ֵ�Ǵ�����ǰ�Ĵ����м��̽��㡣���hWnd������Ч�򴰿ڲ����ӵ������̵߳���Ϣ����,����ֵ��NULL����չ�Ĵ�����Ϣ,����GetLastError.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ȡָ���������״̬��</para>
        /// <para>��״ָ̬���˼���UP״̬��DOWN״̬�����Ǳ������ģ�����ÿ�ΰ��´˼�ʱ�����л�����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�������̴߳�������Ϣ�����ж�����Ϣʱ���ú������صļ�״̬�����ı䡣��״̬������ӳ��Ӳ����ص��жϼ���״̬��ʹ��GetAsyncKeyState�ɻ�ȡ��һ��Ϣ��</para>
        /// <para>Ӧ�ó������ʹ��GetKeyState����Ӧһ���ɼ��������������Ϣ����ʱ�ó����õ�����������Ϣ����ʱ�ü�λ��״̬��</para>
        /// <para>����ȡ���������״̬��Ϣ������ʹ��GetKeyboardState������</para>
        /// <para>Ӧ�ó������ʹ��������볣��VK_SHIFT��VK_CONTROL��VK_MENU��ΪnVirtKey������ֵ��������shift��ctrl��alt����ֵ�����������Ҽ���Ӧ�ó���Ҳ����ʹ�����µ�������볣����nVirtKey��ֵ������ǰ������������Ҽ������Ρ�</para>
        /// <para>VK_LSHIFT��VK_RSHIFT��VK_LCONTROL��VK_RCONTROL��VK_LMENU��VK_RMENU��</para>
        /// <para>����Ӧ�ó������GetKeyboardSlate��SetKeyboardState��GetAsyncKeystate��GetKeyState��MapVirtualKey����ʱ���ſ�����Щ�������Ҽ��ĳ�����</para>
        /// <para>Windows CE��GetKeyState�����������ڼ�������������DOWN״̬��</para>
        /// <para>VK_LSHIFT��VKRSHIFT��VK_LCONTROL��VK_RCONTROL��VK_LMENU��VK_RMENU��</para>
        /// <para>GetKeyState����ֻ�����ڼ��VK_CAPITAL������Ĵ���״̬��</para>
        /// </summary>
        /// <param name="nVirtKey">����һ���������Ҫ������������ĸ�����֣�A��Z��a��z��0��9����nVirtKey���뱻��Ϊ��Ӧ�ַ���ASCII��ֵ�����������ļ���nVirtKey������һ������롣��ʹ�÷�Ӣ����̲��֣���ȡֵ��ASCIIa��z��0��9������������ڶ������������ַ��������磬���ڵ�����̸�ʽ��ֵΪASCII0��OX4F���������ָ����"0"������VK_OEM_1ָ"��������0��"</param>
        /// <returns>������λΪ1���������DOWN״̬������ΪUP״̬��������λΪ1�����������������CAPS LOCK�������ҿ�ʱ����������������λ��Ϊ0��������رգ��Ҳ����������������ڼ����ϵ�ָʾ�ƣ�����������ʱ����������������ʱ����</returns>
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);
        /// <summary>
        /// �ú����ϳɼ����¼�������¼�������ģ�������߼��̲������¼�������������괦��������档
        /// </summary>
        /// <param name="nInputs">ָ��ninput ������Ԫ�صĸ��������ǲ����¼��ĸ�����</param>
        /// <param name="pInputs">ָ��һ������ΪINPUT������������������е�ÿ��Ԫ�ش���һ����Ҫ���뵽�߳��¼���ȥ�ļ��̻�����¼���</param>
        /// <param name="cbSize">ָ��INPUT�ṹ�Ĵ�С�����cbSize����INPUT�ṹ�Ĵ�С��������ʧ�ܷ��ء�</param>
        /// <returns>�ɹ������˶��ٸ������¼��������������������GetLastError���鿴�������͡�</returns>
        [DllImport("User32.dll")]
        public static extern uint SendInput(uint nInputs, NativeMethods.INPUT[] pInputs, int cbSize);

        /// <summary>
        /// �ú������Ի����ϵͳ�������ĵ�ǰ�����Ӧ�ļ��̲��־�����ú��������������ָ���Ļ������С�
        /// </summary>
        /// <param name="nBuff">ָ���������п��Դ�ŵ��������Ŀ��</param>
        /// <param name="lpList">������ָ�룬�������д���ż��̲��־�����顣</param>
        /// <returns>���������óɹ����򷵻�ֵΪ�������������ļ��̲��־������Ŀ�����ߣ���nBuffΪ0�����˻�ֵΪ�������е�ǰ���̲��ֵĻ������еĴ�С���������ԱΪ��λ��������������ʧ�ܣ�����ֵΪ0�������ø��������Ϣ���ɵ���GetLastError������</returns>
        [DllImport("user32")]
        public static extern int GetKeyboardLayoutList(int nBuff, IntPtr[] lpList);
        /// <summary>
        /// �ú������Ի��ָ���̵߳Ļ���̲��֡���idThread����Ϊ�㣬�����ػ�̵߳ļ��̲��֡�
        /// </summary>
        /// <param name="idThread">��ʶ����ѯ���̱߳�ʶ������ǰ�̱߳�ʶ��Ϊ0��</param>
        /// <returns>����ֵΪָ���̵߳ļ��̲��־��������ֵ�ĵ�λ�ְ������������Ե����Ա�ʶ������λ�ְ����˼��������ֵľ����</returns>
        [DllImport("user32")]
        public static extern IntPtr GetKeyboardLayout(int idThread);
        /// <summary>
        /// ������̲��֡��ú���Windows NT��Windows 95�е�ʵ���кܴ�ͬ�����ο�ҳ�����ȸ�����������Windows NT��ʵ�֣������ָ�����Windows 95�汾��ʵ�֣��Ա��Ҹ��õ��˽���ߵ�������Windows NT��ActivateKeyboadLayout��������һ�ֲ�ͬ�ļ��̲��֣�ͬʱ������ϵͳ�ж��������ǵ��øú����Ľ����н��ü��̲�����Ϊ��ġ�
        /// </summary>
        /// <param name="hkl">��������ļ��̲��ֵľ������Windows NT/2000/XP�£��ò��ֱ����ȵ���LoadKeyboadLayout����װ�룬�ò��������Ǽ��̷־ֵľ�����������µ�ֵ�е�һ�֣�</param>
        /// <param name="Flags">������̲�����α�����ò�����ȡ���µ�һЩֵ��</param>
        /// <returns>����������óɹ�������ֵΪǰһ���̲��ֵľ�������򣬷���ֵΪ�㡣��Ҫ��ø���������Ϣ���ɵ���GetLastError������</returns>
        [DllImport("user32")]
        public static extern uint ActivateKeyboardLayout(IntPtr hkl, uint Flags);

        #endregion


        #region Mouse Input Functions                               ������뺯��

        /// <summary>
        /// �ú���ȡ�����ĵ�ǰ˫��ʱ�䡣һ��˫����ָ��������������������һ�λ�������ָ��ʱ���ڻ��ڶ��Ρ�˫��ʱ����ָ��˫���У���һ�λ����͵ڶ��λ���֮�������������
        /// </summary>
        /// <returns>�����ǵ�ǰ˫��ʱ�䣬��������㡣</returns>
        [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        public static extern int GetDoubleClickTime();

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú���ȡ�ò��������Ĵ��ڣ�������ڣ��ľ������ͬһʱ�̣�ֻ��һ�������ܲ�����ꣻ��ʱ���ô��ڽ����������룬���۹���Ƿ����䷶Χ�ڡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>����NULL������ζ��ϵͳ��û���������̻��̲߳�����ֻ꣬��ʾ��ǰ�߳�û�в�����ꡣ</para>
        /// </summary>
        /// <returns>����ֵ���뵱ǰ�߳�������Ĳ��񴰿ڵľ���������ǰ�߳���û�д��ڲ�����꣬�򷵻�NULL��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetCapture();
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú��������ڵ�ǰ�̵߳�ָ��������������겶��</para>
        /// <para>һ�����ڲ�������꣬����������붼��Ըô��ڣ����۹���Ƿ��ڴ��ڵı߽��ڡ�</para>
        /// <para>ͬһʱ��ֻ����һ�����ڲ�����ꡣ</para>
        /// <para>������������һ���̴߳����Ĵ����ϣ�ֻ�е���������ʱϵͳ�Ž��������ָ��ָ���Ĵ��ڡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>ֻ��ǰ̨���ڲ��ܲ�����ꡣ</para>
        /// <para>���һ����̨�����벶����꣬��ô��ڽ�Ϊ�����ȵ��ڸô��ڿɼ����ݵ�����¼�������Ϣ��</para>
        /// <para>���⣬��ʹǰ̨�����Ѳ�������꣬�û�Ҳ�ɵ����һ�����ڣ��������ǰ̨��</para>
        /// <para>��һ�����ڲ�����Ҫ���е��������ʱ�������ô��ڵ��߳�Ӧ�����ú���ReleaseCapture���ͷ���ꡣ</para>
        /// <para>�˺������ܱ�����������һ���̵�������롣</para>
        /// </summary>
        /// <param name="hWnd">��ǰ�߳���Ҫ�������Ĵ��ھ����</param>
        /// <returns>����ֵ���ϴβ������Ĵ��ھ������������������ľ��������ֵ��NULL��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����ӵ�ǰ�߳��еĴ����ͷ���겶�񣬲��ָ�ͨ����������봦��</para>
        /// <para>�������Ĵ��ڽ������е�������루���۹���λ������������ǵ������ʱ������ȵ�����һ���̵߳Ĵ����С�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>Ӧ�ó����ڵ��ú���SetCaPture֮����ô˺�����</para>
        /// </summary>
        /// <returns>����������óɹ������ط���ֵ�������������ʧ�ܣ�����ֵ���㡣</returns>
        [DllImport("user32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseCapture();

        #endregion


        #region Cursor Functions                                    ��꺯��

        /// <summary>
        /// ��ȡȫ�ֹ����Ϣ
        /// </summary>
        /// <param name="pci">A pointer to a CURSORINFO structure that receives the information. Note that you must set the cbSize member to sizeof(CURSORINFO) before calling this function.</param>
        /// <returns>If the function succeeds, the return value is nonzero.If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorInfo(out NativeMethods.CURSORINFO pci);
        /// <summary>
        /// �ú�����ʾ�����ع�ꡣ�ú���������һ���ڲ���ʾ��������ȷ������Ƿ���ʾ��������ʾ��������ֵ���ڻ����0ʱ��������ʾ�������װ����꣬����ʾ�����ĳ�ʼֵΪ0�����û�а�װ��꣬��ʾ������C1��
        /// </summary>
        /// <param name="bShow">ȷ���ڲ�����ʾ�����������ӻ��Ǽ��٣����bShowΪTRUE������ʾ����������1�����bShowΪFALSE�����������1��</param>
        /// <returns>����ֵ�涨�µ���ʾ��������</returns>
        [DllImport("user32.dll")]
        public static extern int ShowCursor(bool bShow);

        #endregion


        #region Menu Functions                                      �˵�����

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������Ӧ�ó���Ϊ���ƻ��޸Ķ����ʴ��ڲ˵���ϵͳ�˵�����Ʋ˵�����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�κ�û���ú���GetSystemMenu�������Լ��Ĵ��ڲ˵������Ĵ��ڽ����ܱ�׼���ڲ˵���</para>
        /// <para>����ĳ����������Ĳ˵����ж��ֱ�ʶ��ֵ����SC_CLOSE��SC_MOVE��SC_SIZE��</para>
        /// <para>���ڲ˵��ϵĲ˵����WM_SYSCOMMAND��Ϣ��</para>
        /// <para>����Ԥ����Ĵ��ڲ˵���ı�ʶ��������OxFOOO�����һ��Ӧ�ó�������������ڲ˵���Ӧ��ʹ��С��OxFOOO�ı�ʶ������</para>
        /// <para>ϵͳ����״̬�Զ���ұ�׼���ڲ˵��ϵĲ˵��Ӧ�ó���ͨ����Ӧ���κ�ĳ����ʾ֮ǰ���͵�WM_INITMENU��Ϣ��ʵ��ѡȡ�ͱ�ҡ�</para>
        /// <para>Windows CE�����£���֧��ϵͳ�˵�����GetSyemMenu�Ժ�ķ�ʽʵ�֣��Ա��ֺ��Ѵ��ڴ���ļ����ԡ�����ʹ�øú�ķ��ز˵����ʹ�رտ���Ч������Windows����ƽ̨��һ����Windows CE�µķ���ֵû�������ô�������bRevert���á�</para>
        /// <para>������Ĵ���ʹ�رհ�ť��Ч��</para>
        /// <para>EnableMenultem��GetSystemMenu��hwnd��FALSE����SC_CLOSE��MF_BYCOMMAND I MF_GRAYED����</para>
        /// </summary>
        /// <param name="hWnd">ӵ�д��ڲ˵������Ĵ��ڵľ����</param>
        /// <param name="bRevert">ָ����ִ�еĲ���������˲���ΪFALSE��GetSystemMenu���ص�ǰʹ�ô��ڲ˵��Ŀ����ľ�����ÿ�����ʼʱ�봰�ڲ˵���ͬ�������Ա��޸ġ�����˲���ΪTRUE��GetSystemMenu���ô��ڲ˵���ȱʡ״̬�����������ǰ�Ĵ��ڲ˵����������١�</param>
        /// <returns>�������bRevertΪFALSE������ֵ�Ǵ��ڲ˵��Ŀ����ľ�����������bRevertΪTRUE������ֵ��NULL��</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ���Ĳ˵���������ʽ�˵����Ӳ˵����ݲ˵���ĩβ׷��һ���²˵��</para>
        /// <para>�˺�����ָ���˵�������ݡ���ۺ����ܡ�����AppendMenu����lnsertMenultemȡ����</para>
        /// <para>���������ҪlnsertMenultem����չ���ԣ��Կ�ʹ��AppendMenu��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>һ���˵����޸ģ��������Ƿ�����ʾ�����Ӧ�ó��������ú���DrawMenuBar��</para>
        /// <para>Ϊ��ʹ���̼��ټ��ܿ���λ�����Լ����ƵĲ˵���˵���ӵ���߱��봦��WM_MENUCHAR��Ϣ��</para>
        /// <para>�μ��Ի��Ʋ˵���WM_MENUCHAR��Ϣ��</para>
        /// <para>���б�־�ɱ������ڲ���uFlags�</para>
        /// <para>MF_BITMAP����һ��λͼ�����˵������lpNewltem�ﺬ�и�λͼ�ľ����</para>
        /// <para>MF_CHECKED���ڲ˵����Ա߷���һ��ѡȡ��ǡ����Ӧ�ó����ṩһ��ѡȡ��ǣ�λͼ���μ�SetMenultemBitmaps������ѡȡ���λͼ�����ڲ˵����Աߡ�</para>
        /// <para>MF_DISABLED��ʹ�˵�����Ч��ʹ����ܱ�ѡ�񣬵���ʹ�˵����ҡ�</para>
        /// <para>MF_ENABLED��ʹ�˵�����Ч��ʹ�����ܱ�ѡ�񣬲�ʹ��ӱ�ҵ�״̬�ָ���</para>
        /// <para>MF_GRAYED��ʹ�˵�����Ч����ң�ʹ�䲻�ܱ�ѡ��</para>
        /// <para>MF_MENUBARBREAK���Բ˵����Ĺ���ͬMF_MENUBREAK��־��������ʽ�˵����Ӳ˵����ݲ˵������к;��б���ֱ�߷ֿ���</para>
        /// <para>MF_MENUBREAK�����˵�����������У��Բ˵������������У�������ʽ�˵����Ӳ˵����ݲ˵������޷ָ��С�</para>
        /// <para>MF_OWNERDRAW��ָ���ò˵���Ϊ�Ի��Ʋ˵���˵���һ����ʾǰ��ӵ�в˵��Ĵ��ڽ���һ��WM_MEASUREITEM��Ϣ���õ��˵���Ŀ�͸ߡ�Ȼ��ֻҪ�˵���޸ģ���������WM_DRAWITEM��Ϣ���˵�ӵ���ߵĴ��ڳ���</para>
        /// <para>MF_POPUP��ָ���˵���һ������ʽ�˵����Ӳ˵�������uIDNewltem����ʽ�˵����Ӳ˵��ľ�����˱�־�������˵�������һ������ʽ�˵����ڲ˵��Ĳ˵���Ӳ˵����ݲ˵���һ�����֡�</para>
        /// <para>MF_SEPARATOR����һ��ˮƽ�����ߡ��˱�־ֻ������ʽ�˵����Ӳ˵����ݲ˵�ʹ�á��������߲��ܱ���ҡ���Ч�����������IpNewltem��uIDNewltem���á�</para>
        /// <para>MF_STRING��ָ���˵�����һ�������ַ���������lpNewltemָ����ַ�����</para>
        /// <para>MF_UNCHECKED��������ѡȡ����ڲ˵����Աߣ�ȱʡ�������Ӧ�ó����ṩһ��ѡȡ���λͼ���μ�SetMenultemBitmaps������ѡȡ���λͼ�����ڲ˵����Աߡ�</para>
        /// <para>���б�־�鲻�ܱ�һ��ʹ�ã�</para>
        /// <para>MF_DISABLED��MF_ENABLED��MF_GRAYED��MF_BITMAP,MF_STRING��MF_OWNERDRAW</para>
        /// <para>MF_MENUBARBREAK��MF_MENUBREAK��MF_CHECKED��MF_UNCHECKED</para>
        /// <para>Windows CE�����£���֧�ֲ���fuFlagsʹ�����б�־��</para>
        /// <para>MF_BITMAP��MF_DOSABLE��MF_GRAYED</para>
        /// <para>MF_GRAYED����������MF_DISABLED��MFS_GRAYED��</para>
        /// <para>Windows CE 1.0��֧�ֲ��ʽ�˵�����ʹ��Windows CE 1.0ʱ�����ܽ�һ��MF_POPUP�˵����뵽��һ������ʽ�˵��С�Window CE 1.0��֧�����б�־��</para>
        /// <para>MF_POPUP��MF_MENUBREAK��MF_MENUBARBREAK</para>
        /// <para>Windows CE 2.0����߰汾�У�֧��������־��Ҳ֧�ֲ��ʽ�˵���</para>
        /// </summary>
        /// <param name="hMenu">�����޸ĵĲ˵���������ʽ�˵����Ӳ˵������ݲ˵��ľ����</param>
        /// <param name="uFlags">�����²˵������ۺ����ܵı�־���˲��������Ǳ�ע������ֵ����ϡ�</param>
        /// <param name="uIDNewltem">ָ���²˵���ı�ʶ�������ߵ�uFlags����ΪMF_POPUPʱ����ʾ����ʽ�˵����Ӳ˵��ľ����</param>
        /// <param name="lpNewltem">ָ���²˵�������ݡ��˲����ĺ���ȡ���ڲ���uFlags�Ƿ����MF_BITMAP, MF_OWNERDRAW��MF_STRING��־��������ʾ��MF_BITMAP������λͼ�����MF_STRING����`\O���������ַ�����ָ�롣MF_OWNERDRAW�����б�Ӧ�ó���Ӧ�õ�32λֵ�����Ա�����˵����йصĸ������ݡ����˵�������������۱��޸�ʱ����ֵ����ϢWM_MEASURE��WM_DRAWITEM�Ĳ���IParamָ��Ľṹ����ԱitemData�</param>
        /// <returns>����������óɹ������ط���ֵ�������������ʧ�ܣ�����ֵ���㡣�����ø���Ĵ�����Ϣ�������GetLastError������</returns>
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AppendMenu(IntPtr hMenu, uint uFlags, uint uIDNewltem, string lpNewltem);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������һ���²˵���˵����ʹ�˵������������ơ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>һ���˵����޸ģ��������Ƿ�����ʾ�����Ӧ�ó��������ú���DrawMenuBar��</para>
        /// </summary>
        /// <param name="hMenu">�����޸ĵĲ˵��ľ����</param>
        /// <param name="uPosition">ָ���²˵����������ǰ��Ĳ˵���京���ɲ���uFlagS������</param>
        /// <param name="uFlags">ָ�����Ʋ���uPosition�Ľ��͵ı�־���²˵�������ݡ���ۺ����ܡ��˲�������Ϊ����ֵ֮һ�����ڱ�ע���һ��ֵ����ϡ�MF_BYCOMMAND����ʾuPosition�����˵���ı�ʶ�������MF_BYCOMMAND��MF_BYPOSITION��û��ָ������MF_BYCOMMANDΪȱʡ�ı�־��MF_BYPOSITION����ʾuPosition�����²˵������������λ�á����uPositionΪOxFFFFFFFF�²˵���׷���ڲ˵���ĩβ��</param>
        /// <param name="uIDNewItem">ָ���²˵���ı�ʶ�������ߵ�����uFlags����ΪMF_POPUPʱ��ָ������ʽ�˵����Ӳ˵��ľ����</param>
        /// <param name="lpNewItem">ָ���²˵�������ݡ��京�������ڲ���UFlags�Ƿ������־MF_BITMAP,MF_OWNERDRAW��MF_STRING��������ʾ��MF_BITMAP������λͼ�����MF_STRING����`\0���������ַ�����ָ�루ȱʡ����MF_OWNERDRAW�����б�Ӧ�ó���Ӧ�õ�32λֵ�����Ա�����˵����йصĸ������ݡ����˵�������������۱��޸�ʱ����ֵ����ϢWM_MEASURE��WM_DRAWITEM�Ĳ���IParamָ��Ľṹ�С���ԱitemData�</param>
        /// <returns>����������óɹ�������ֵ���㣻�����������ʧ�ܣ�����ֵΪ�㡣�����ø���Ĵ�����Ϣ�������GetLastError������</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InsertMenu(IntPtr hMenu, uint uPosition, uint uFlags, uint uIDNewItem, string lpNewItem);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ָ���˵�ɾ��һ���˵�������һ���Ӳ˵�������˵����һ������ʽ�˵����Ӳ˵���RemoveMenu�����ٸò˵�������������˵������á��ڵ��ô˺���ǰ������GetSubMenuӦ��ȡ������ʽ�˵����Ӳ˵��ľ����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>ֻҪһ���˵����޸ģ��������Ƿ�����ʾ�����Ӧ�ó��򶼱�����ú���DrawMenuBar��</para>
        /// </summary>
        /// <param name="hMenu">�����޸ĵĲ˵��ľ����</param>
        /// <param name="uPosition">ָ������ɾ���Ĳ˵���京���ɲ���uFlages������</param>
        /// <param name="uFlags">ָ������uPosition��ν��͡��˲�������Ϊ����֮һֵ��MF_BYCOMMAND����ʾuPositon�����˵���ı�ʶ�������MF_BYCOMMAND��MF_BYPOSITION��û��ָ������MF_BYCOMMAND��ȱʡ��־������ MF_BYCOMMAND��0x0000��ʮ����Ϊ0����Mu_BYPOSITION����ʾuPositon�����˵�����������λ�ã����� MF_BYPOSITION��0x00004(ʮ����Ϊ1024)��</param>
        /// <returns>����������óɹ������ط���ֵ�������������ʧ�ܣ�����ֵ���㡣�����ø���Ĵ�����Ϣ�������GetLastError������</returns>
        [DllImport("user32")]
        public static extern int RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        #endregion


        #region Scroll Bar Functions                                ����������

        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����ʾ��������ָ���Ĺ�������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�������������Ϣʱ�����ܵ�������������ع�������</para>
        /// </summary>
        /// <param name="hWnd">���ݲ���wBarֵ��������������ƻ���б�׼���������塣</param>
        /// <param name="wBar">ָ���������Ǳ���ʾ�������ء�</param>
        /// <param name="bShow">ָ���������Ǳ���ʾ�������ء��˲���ΪTRUE��������������ʾ���������ء�</param>
        /// <returns>����������гɹ�������ֵΪ���㣻�����������ʧ�ܣ�����ֵΪ�㡣</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowScrollBar(IntPtr hWnd, int wBar, [MarshalAs(UnmanagedType.Bool)] bool bShow);
        /// <summary>
        /// <para>����:</para>
        /// <para>�����й�ָ����������Ϣ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���idObject��OBJID_CLIENT��ָ���Ĵ��ڵ�HWND�ǲ���ϵͳ���������ƣ�ϵͳ����SBM_GETSCROLLBARINFO��Ϣ�Ĵ��ڹ���������ȡ��Ϣ��</para>
        /// <para>��ʹ��GetScrollBarInfo�����Զ���ؼ�ģ��һ����������������ڲ�����SBM_GETSCROLLBARINFO��Ϣ��GetScrollBarInfo����ʧ�ܡ�</para>
        /// </summary>
        /// <param name="hwnd">���ھ������һ���������ؼ��ľ����������һ������WS_VSCROLL��WS_HSCROLL��ʽ�Ĵ��ھ����</param>
        /// <param name="idObject">ָ�����������������������������ֵ֮һ�� ��OBJID_ ��˵��OBJID_CLIENT hWnd������һ���������ؼ��ľ����OBJID_HSCROLL hWnd����ˮƽ��������OBJID_VSCROLL hWnd���ڴ�ֱ��������</param>
        /// <param name="psbi">ָ��һ��SCROLLBARINFO�ṹ���Ի�õ���Ϣ���ڵ���GetScrollBarInfo������cbSize��ԱΪsizeof��SCROLLBARINFO����</param>
        /// <returns>��������ɹ�������ֵΪ���㡣�������ʧ�ܣ�����ֵΪ�㡣Ϊ�˻�ø���Ĵ�����Ϣ������GetLastError��</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetScrollBarInfo(IntPtr hwnd, int idObject, ref NativeMethods.SCROLLBARINFO psbi);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú����ҵ��������Ĳ���������������λ�õ���Сֵ�����ֵ��ҳ���С��������ť��λ�õȡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>Getscrolllnfo��������WM_HSCROLL��WM_VSCROLLָ���˹�����λ����Ϣ��ȴ���ṩ��16λ���ݣ�������SetScrollnfo��GetScrollnfo���ṩ��32λ�Ĺ��������ݡ�</para>
        /// <para>�������Ӧ�ó����ڴ���WM_HSCROLL�� WM_VSCROLLʱ��Ҫ���32λ������λ�õ�����ʱ����Ҫ����Getscrolllnfo������</para>
        /// <para>��WM_HSCROLL��WM_VSCROLL��Ϣ��SB_THUMBTRACKͨ������У�Ϊ�˻��32λ�Ĺ�����λ�ã���Ҫ����GetScrolllnfo�����Եõ��ṹSCROLLINFO��ԱfMask�е�SCROLLINFOֵ��</para>
        /// <para>���������ڽṹSCROLLINFO��ԱnTrackPos��ָ���Ĺ����и���λ�õ�ֵ���⽫�����û��ƶ�������ʱ�ܵõ���λ�á�</para>
        /// </summary>
        /// <param name="hwnd">���������ƻ��б�׼�������Ĵ���������fnBar����ȷ����</param>
        /// <param name="fnBar">ָ�����һع��������������ͣ��˲�������Ϊ����ֵ����ֵ���壺��SB_</param>
        /// <param name="lpsi">ָ��SCROLLINFO�ṹ��</param>
        /// <returns>��������ҵ��κ�һ��ֵ����ô����ֵΪ���㣻�������û���ҵ��κ�ֵ����ô����ֵΪ�㣻</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref NativeMethods.SCROLLINFO lpsi);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú������ù�������������������λ�õ����ֵ����Сֵ��ҳ���С��������ť��λ�á��类���󣬺���Ҳ�����ػ���������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>SetScrolllnfo����ִ�������Ǽ��SCROLLINFO�ṹ���ɳ�ԱnPage��nPosֵ�ķ�Χ��</para>
        /// <para>��ԱnPageֵ�����0��nMax- nMin+1����ԱnPos��������nMin��nMax-nMax-max��nPage C1��0��֮���ָ��ֵ��</para>
        /// <para>����κ�һ��ֵ�����������Χ����������ָ����Χ��Ϊ������һ��ֵ��</para>
        /// </summary>
        /// <param name="hwnd">�������ؼ������׼�������Ĵ���������fnBar����������</param>
        /// <param name="fnBar">ָ�����趨�����Ĺ����������͡������������������ֵ���������£���SB_</param>
        /// <param name="lpsi">ָ��SCROLLINFO�ṹ���ڵ���SetScrollInfo֮ǰ������SCROLLINFO�ṹ��cbSize��Ա�Ա�ʶ�ṹ��С�����ó�ԱfMask��˵�������õĹ������������������ʵ��ĳ�Ա���ƶ��µĲ���ֵ��</param>
        /// <param name="fRedraw">ָ���������Ƿ��ػ��Է�ӳ�������ı仯������������ΪTRUE�������������ػ������򲻱��ػ���</param>
        /// <returns>����ֵ�ǻ���ĵ�ǰλ�á�</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref NativeMethods.SCROLLINFO lpsi, bool fRedraw);
        /// <summary>
        /// <para>����:�ú�����ȡָ���������й�����ť�ĵ�ǰλ�á���ǰλ����һ�����ݵ�ǰ������Χ���������ֵ��</para>
        /// <para>���磬���������Χ��0��100֮�䣬������ť���м�λ�ã����䵱ǰλ��Ϊ50���ú����ṩ���������ԣ��µ�Ӧ�ó���Ӧʹ��GetScrollInfo������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>����GetScrollPos����ʹӦ�ó���ʹ��32λ����λ�á�������ϢWM_HSCROLL��WM_VSCROLLָ���˹�����λ�ã���ȴ������Ϊ16λ��������SetScrollPos��SetScrollRange��GetScrollPos���� GetscrollRange��֧��32λ�Ĺ��������ݡ�</para>
        /// <para>��WM_HSCROLL��WM_VSCROLL��Ϣ��ͨ��SB_JHUMBTRACKʱ��Ϊ�˵õ�������32λ��λ�ã������GetScrolllnfo������</para>
        /// <para>��WM_HSCROLL��WM_VSCROLL��Ϣ��ͨ��SB_THUMBTRACKʱ��Ϊ�˵õ�32λ�Ĺ�����������ú���GetScrolllnfo��</para>
        /// </summary>
        /// <param name="hWnd">���ݲ���nBarֵ��������������ƻ���б�׼���������塣</param>
        /// <param name="nBar">ָ��������������顣�����������������ֵ���������£���SB_</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);
        /// <summary>
        /// <para>����:�ú���������ָ���������еĹ�����ť��λ�ã������Ҫ�����ػ�������Է�ӳ��������ť����λ�á��ú����ṩ���������ԣ��µ�Ӧ�ó���Ӧʹ��SetScrolllnfo������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��������ֵ����˻��ػ�������ĺ�������ô���ò���bRedrawΪFALSE�Ƿǳ��б�Ҫ�ġ�</para>
        /// <para>��Ϊ˵��������λ�õ���ϢWM_HSCROLL�� WM_VSCROLLֻ��Ϊ16λ���ݣ���Щֻ������˵��λ��������Ϣ��Ӧ�ó����ں���SetScrollPos�Ĳ���nMaxPos����һ��ʵ�����ֵ65,535 ��</para>
        /// <para>���ǣ���Ϊ����SetScrolllnfo��SetScrollPos�� SetScrollRange��GetScrolllnfo��GetScrollPos����GetScrollRange��֧��32λ�Ĺ�����λ�����ݣ�������һ�����16λWM_HSCROLL��WM_VSCROLL��Ϣ�谭��;������μ�����GetScrolllnfo���йؼ���˵����</para>
        /// </summary>
        /// <param name="hWnd">�������ؼ�����б�׼����������ľ������nBar����ֵȷ��</param>
        /// <param name="nBar">ָ���������������á���������������±�ֵ�е�һ�����������£���SB_</param>
        /// <param name="nPos">ָ��������ť����λ�á����λ�ñ����ڹ�����Χ֮�ڡ���Ҫ�˽�����йع�����Χ����Ϣ����μ�SetScrollRange������</param>
        /// <param name="bRedraw">ָ���������Ƿ��ػ��Է�ӳ�仯������������ΪTRUE�������������ػ������ΪFALSE�򲻱��ػ���</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        #endregion


        #region ComboBox Control Functions                          ��Ͽ�ؼ�����

        /// <summary>
        /// <para>����:</para>
        /// <para>Retrieves information about the specified combo box.</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>The CB_GETCOMBOBOXINFO message is equivalent to this function.</para>
        /// </summary>
        /// <param name="hwndCombo">A handle to the combo box.</param>
        /// <param name="pcbi">A pointer to a COMBOBOXINFO structure that receives the information. You must set COMBOBOXINFO.cbSize before calling this function.</param>
        /// <returns>f the function succeeds, the return value is nonzero.If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref  NativeMethods.COMBOBOXINFO pcbi);

        #endregion
    }
}
