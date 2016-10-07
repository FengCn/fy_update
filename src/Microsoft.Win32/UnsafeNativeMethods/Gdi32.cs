using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Gdi32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú���ѡ��һ����ָ�����豸�����Ļ����У����¶����滻��ǰ����ͬ���͵Ķ���</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�ú���������ǰָ�����͵�ѡ�����һ��Ӧ�ó�������ʹ���¶�����л������֮��Ӧ����ԭʼ��ȱʡ�Ķ����滻�¶���</para>
        /// <para>Ӧ�ó�����ͬʱѡ��һ��λͼ������豸�����Ļ����С�</para>
        /// <para>ICM�������ѡ��Ķ����ǻ��ʻ�ʣ���ô��ִ����ɫ����</para>
        /// <para>.</para>
        /// <para>hgdiobj����Ϊ���·������ɵĶ���</para>
        /// <para>λͼ��CreateBitmap, CreateBitmapIndirect, CreateCompatible Bitmap, CreateDIBitmap, CreateDIBsection��ֻ���ڴ��豸�����Ļ�����ѡ��λͼ��������ͬһʱ��ֻ��һ���豸�����Ļ���ѡ��λͼ����</para>
        /// <para>��ˢ��CreateBrushIndirect, CreateDIBPatternBrush, CreateDIBPatternBrushPt, CreateHatchBrush, CreatePatternBrush, CreateSolidBrush��</para>
        /// <para>���壺CreateFont, CreateFontIndirect��</para>
        /// <para>�ʣ�CreatePen, CreatePenIndirect��</para>
        /// <para>����CombineRgn, CreateEllipticRgn, CreateEllipticRgnIndirect, CreatePolygonRgn, CreateRectRgn, CreateRectRgnIndirect��</para>
        /// </summary>
        /// <param name="hdc">�豸�����Ļ����ľ����</param>
        /// <param name="hgdiobj">��ѡ��Ķ���ľ������ָ��������������µĺ���������</param>
        /// <returns>
        /// <para>���ѡ������������Һ���ִ�гɹ�����ô����ֵ�Ǳ�ȡ���Ķ���ľ����</para>
        /// <para>���ѡ������������Һ���ִ�гɹ�����������һֵ��</para>
        /// <para>SIMPLEREGION�������ɵ���������ɣ�</para>
        /// <para>COMPLEXREGION�������ɶ��������ɡ�</para>
        /// <para>NULLREGION������Ϊ�ա�</para>
        /// <para>�������������ѡ�������һ��������ô����ֵΪNULL�����򷵻�GDI_ERROR��</para>
        /// </returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);


        /// <summary>
        /// <para>����:</para>
        /// <para>�ú���ɾ��ָ�����豸�����Ļ�����DC����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���һ���豸�����Ļ����ľ����ͨ������GetDC�����õ��ģ���ôӦ�ó�����ɾ�����豸�����Ļ�������Ӧ�õ���ReleaseDC�������ͷŸ��豸�����Ļ�����</para>
        /// </summary>
        /// <param name="hdc">�豸�����Ļ����ľ����</param>
        /// <returns>�ɹ������ط���ֵ��ʧ�ܣ������㡣</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteDC(IntPtr hdc);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú���ɾ��һ���߼��ʡ����ʡ����塢λͼ��������ߵ�ɫ�壬�ͷ�������ö����йص�ϵͳ��Դ���ڶ���ɾ��֮��ָ���ľ��Ҳ��ʧЧ�ˡ�</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��һ���滭������ʻ򻭱ʣ���ǰ��ѡ��һ���豸�����Ļ���ʱ��Ҫɾ���ö��󡣵�һ����ɫ�廭�ʱ�ɾ��ʱ����û�����ص�λͼ������ɾ������ͼ���뵥����ɾ����</para>
        /// </summary>
        /// <param name="hObject">�߼��ʡ����ʡ����塢λͼ��������ߵ�ɫ��ľ����</param>
        /// <returns>�ɹ������ط���ֵ�����ָ���ľ����Ч�������ѱ�ѡ���豸�����Ļ������򷵻�ֵΪ�㡣</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteObject(IntPtr hObject);


        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������һ����ָ���豸���ݵ��ڴ��豸�����Ļ�����DC����ͨ��GetDC()��ȡ��HDCֱ��������豸��ͨ����������������DC���������ڴ��е�һ�������������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�ڴ��豸�����Ļ����ǽ����ڴ��д��ڵ��豸�����Ļ��������ڴ��豸�����Ļ���������ʱ��������ʾ�����Ǳ�׼��һ����ɫ���ؿ��һ����ɫ���ظߣ���һ��Ӧ�ó������ʹ���ڴ��豸�����Ļ������л�ͼ����֮ǰ��������ѡ��һ���ߺͿ���ȷ��λͼ���豸�����Ļ����У������ͨ��ʹ��CreateCompatibleBitmap����ָ���ߡ����ɫ����������㺯�����õ���Ҫ��</para>
        /// <para>��һ���ڴ��豸�����Ļ�������ʱ�����е����Զ���Ϊȱʡֵ���ڴ��豸�����Ļ�����Ϊһ����ͨ���豸�����Ļ���ʹ�ã���ȻҲ����������Щ����Ϊ��ȱʡֵ���õ��������Եĵ�ǰ���ã�Ϊ��ѡ�񻭱ʣ�ˢ�Ӻ�����</para>
        /// <para>CreateCompatibleDC����ֻ������֧�ֹ�դ�������豸��Ӧ�ó������ͨ������GetDeviceCaps������ȷ��һ���豸�Ƿ�֧����Щ������</para>
        /// <para>��������Ҫ�ڴ��豸�����Ļ���ʱ���ɵ���DeleteDC����ɾ������</para>
        /// <para>ICM�����ͨ���ú�����hdc�������͸��ú����豸�����Ļ���(DC)���ڶ�����ɫ����ICM�������õģ���ú����������豸�����Ļ���(DC)��ICM���õģ���Դ��Ŀ����ɫ�������DC�ж��塣</para>
        /// </summary>
        /// <param name="hdc">�����豸�����Ļ����ľ��������þ��ΪNULL���ú�������һ����Ӧ�ó���ĵ�ǰ��ʾ�����ݵ��ڴ��豸�����Ļ�����</param>
        /// <returns>����ɹ����򷵻��ڴ��豸�����Ļ����ľ�������ʧ�ܣ��򷵻�ֵΪNULL��</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú���������ָ�����豸������ص��豸���ݵ�λͼ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>��CreateCompatibleBitmap����������λͼ����ɫ��ʽ���ɲ���hdc��ʶ���豸����ɫ��ʽƥ�䡣��λͼ����ѡ������һ����ԭ�豸���ݵ��ڴ��豸�����С������ڴ��豸���������ɫ�͵�ɫ����λͼ����˵�ָ�����豸�������ڴ��豸����ʱ����CreateCompatibleBitmap�������ص�λͼ��ʽ��һ����ͬ��Ȼ��Ϊ���ڴ��豸���������ļ���λͼͨ��ӵ����ͬ����ɫ��ʽ������ʹ����ָ�����豸����һ����ɫ�ʵ�ɫ�塣</para>
        /// </summary>
        /// <param name="hdc">�豸���������</param>
        /// <param name="nWidth">ָ��λͼ�Ŀ�ȣ���λΪ���ء�</param>
        /// <param name="nHeight">ָ��λͼ�ĸ߶ȣ���λΪ���ء�</param>
        /// <returns>�������ִ�гɹ�����ô����ֵ��λͼ�ľ�����������ִ��ʧ�ܣ���ô����ֵΪNULL�������ȡ���������Ϣ�������GetLastError��</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);


        /// <summary>
        /// <para>����:</para>
        /// <para>The SetBkMode function sets the background mix mode of the specified device context.</para>
        /// <para>The background mix mode is used with text, hatched brushes, and pen styles that are not solid lines.</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>The SetBkMode function affects the line styles for lines drawn using a pen created by the CreatePen function.</para>
        /// <para>SetBkMode does not affect lines drawn using a pen created by the ExtCreatePen function.</para>
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="iBkMode">The background mode. This parameter can be one of the following values.</param>
        /// <returns>If the function succeeds, the return value specifies the previous background mode.If the function fails, the return value is zero.</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, int iBkMode);
        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�������һ�����μ�������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>����ʱһ��Ҫ��DeleteObject����ɾ��������</para>
        /// <para>������ε��±ߺ��ұ߲�����������֮��</para>
        /// </summary>
        /// <param name="nLeftRect">��</param>
        /// <param name="nTopRect">��</param>
        /// <param name="nRightRect">��</param>
        /// <param name="nBottomRect">��</param>
        /// <returns>����������</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        /// <summary>
        /// <para>����:</para>
        /// <para>����һ��Բ�Ǿ��Σ��þ�����nLeftRect��nTopRect-nRightRect��nBottomRectȷ��������nWidthEllipse��nHeightEllipseȷ������Բ����Բ�ǻ��� ����ֵ Long��ִ�гɹ���Ϊ��������ʧ����Ϊ0</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>����ʱһ��Ҫ��DeleteObject����ɾ��������</para>
        /// <para>�øú�����������������RoundRect API��������Բ�Ǿ��β���ȫ��ͬ����Ϊ�����ε��ұߺ��±߲�����������֮��</para>
        /// </summary>
        /// <param name="nLeftRect">����</param>
        /// <param name="nTopRect">�ϸ߶�</param>
        /// <param name="nRightRect">�ҿ��</param>
        /// <param name="nBottomRect">�¸߶�</param>
        /// <param name="nWidthEllipse">Բ����Բ�Ŀ��䷶Χ��0��û��Բ�ǣ������ο�ȫԲ��</param>
        /// <param name="nHeightEllipse">Բ����Բ�ĸߡ��䷶Χ��0��û��Բ�ǣ������θߣ�ȫԲ��</param>
        /// <returns>�������ִ�гɹ�����region��������򷵻�NULL��</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        /// <summary>
        /// The SelectClipRgn function selects a region as the current clipping region for the specified device context.
        /// </summary>
        /// <param name="hdc">�豸���������</param>
        /// <param name="hrgn">��ʶ��ѡ�������</param>
        /// <returns>����ֵ����������ĸ��Ӷȣ�����������ֵ֮һ��</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);
        /// <summary>
        /// �ú���ͨ���ض��ķ�ʽ��һ���ض��������뵱ǰ�ļ�������ϲ���һ��
        /// </summary>
        /// <param name="hdc">�豸���������</param>
        /// <param name="hrgn">��ʶ��ѡ������򡣵�ָ��RGN_COPYģʽʱ���þ������ΪNULL��</param>
        /// <param name="fnMode">����ִ�е�����ģʽ��������������ֵ֮һ��</param>
        /// <returns>����ֵ�������µļ�������ĸ��Ӷȣ�����ֵ�����¼��֣�</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int ExtSelectClipRgn(IntPtr hdc, IntPtr hrgn, int fnMode);


        /// <summary>
        /// <para>����:</para>
        /// <para>�ú�����������ָ���豸�����е�λͼ����ģʽ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>����ģʽ��Ӧ�ó������StretchBit����ʱ����ϵͳ��ν�λͼ���л�������ʾ�豸�ϵ��������ص������ϡ�</para>
        /// <para>BLACKONWHITE(STRETCH_ANDSCANS)��WHITEONBLACK(STRETCH_ORSCANS)ģʽ���͵�����������ɫλͼ�е�ǰ�����ء�COLORONCOLOR(STRETCH_DELETESCANS)ģʽ����͵����ڱ�����ɫλͼ�е���ɫ��</para>
        /// <para>HALFTONEģʽ����������ģʽ��Ҫ��Դͼ����и���Ĵ���Ҳ������ģʽ���������ܲ���������ͼ��ҲӦע��������HALFTONEģʽ֮��Ӧ����SetBrushOrgEx�����Ա������ˢ��û��׼����</para>
        /// <para>�����豸��������Ĺ��ܲ�ͬ������һЩ����ģʽҲ������Ч��</para>
        /// </summary>
        /// <param name="hdc">�豸���������</param>
        /// <param name="iStretchMode">ָ������ģʽ��������ȡ����ֵ����Щֵ�ĺ������£�</param>
        /// <returns>�������ִ�гɹ�����ô����ֵ������ǰ������ģʽ���������ִ��ʧ�ܣ���ô����ֵΪ0��</returns>
        [DllImport("gdi32.dll")]
        public static extern int SetStretchBltMode(IntPtr hdc, int iStretchMode);
        /// <summary>
        /// <para>����:</para>
        /// <para>��ָ����Դ�豸���������е����ؽ���λ�飨bit_block��ת�����Դ��͵�Ŀ���豸������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�����Դ�豸�����п���ʵ����ת����б任����ô����BitBlt����һ������������������任������Ŀ���豸������ƥ��任��Ч������ôĿ���豸�����еľ�����������Ҫʱ�������졢ѹ������ת��</para>
        /// <para>���Դ��Ŀ���豸��������ɫ��ʽ��ƥ�䣬��ôBitBlt������Դ��������ɫ��ʽת��������Ŀ���ʽƥ��ĸ�ʽ�������ڼ�¼һ����ǿ��ͼԪ�ļ�ʱ�����Դ�豸������ʶΪһ����ǿ��ͼԪ�ļ��豸��������ô����ִ������Դ��Ŀ���豸��������ͬ���豸����ôBitBlt�������ش���</para>
        /// <para>.</para>
        /// <para>���б�־�ɱ������ڲ���dwRop��:</para>
        /// <para>BLACKNESS����ʾʹ���������ɫ�������0��ص�ɫ�������Ŀ��������򣬣���ȱʡ�������ɫ����ԣ�����ɫΪ��ɫ����</para>
        /// <para>DSTINVERT����ʾʹĿ�����������ɫȡ����</para>
        /// <para>MERGECOPY����ʾʹ�ò����͵�AND���룩��������Դ�����������ɫ���ض�ģʽ���һ��</para>
        /// <para>MERGEPAINT��ͨ��ʹ�ò����͵�OR���򣩲������������Դ�����������ɫ��Ŀ������������ɫ�ϲ���</para>
        /// <para>NOTSRCCOPY����Դ����������ɫȡ�����ڿ�����Ŀ���������</para>
        /// <para>NOTSRCERASE��ʹ�ò������͵�OR���򣩲��������Դ��Ŀ������������ɫֵ��Ȼ�󽫺ϳɵ���ɫȡ����</para>
        /// <para>PATCOPY�����ض���ģʽ������Ŀ��λͼ�ϡ�</para>
        /// <para>PATPAINT��ͨ��ʹ�ò���OR���򣩲�������Դ��������ȡ�������ɫֵ���ض�ģʽ����ɫ�ϲ���Ȼ��ʹ��OR���򣩲��������ò����Ľ����Ŀ����������ڵ���ɫ�ϲ���</para>
        /// <para>PATINVERT��ͨ��ʹ��XOR����򣩲�������Դ��Ŀ����������ڵ���ɫ�ϲ���</para>
        /// <para>SRCAND��ͨ��ʹ��AND���룩����������Դ��Ŀ����������ڵ���ɫ�ϲ���</para>
        /// <para>SRCCOPY����Դ��������ֱ�ӿ�����Ŀ���������</para>
        /// <para>SRCERASE��ͨ��ʹ��AND���룩��������Ŀ�����������ɫȡ������Դ�����������ɫֵ�ϲ���</para>
        /// <para>SRCINVERT��ͨ��ʹ�ò����͵�XOR����򣩲�������Դ��Ŀ������������ɫ�ϲ���</para>
        /// <para>SRCPAINT��ͨ��ʹ�ò����͵�OR���򣩲�������Դ��Ŀ������������ɫ�ϲ���</para>
        /// <para>WHITENESS��ʹ���������ɫ��������1�йص���ɫ���Ŀ��������򡣣�����ȱʡ�����ɫ����˵�������ɫ���ǰ�ɫ����</para>
        /// </summary>
        /// <param name="hdcDest">ָ��Ŀ���豸�����ľ����</param>
        /// <param name="nXDest">ָ��Ŀ������������Ͻǵ�X���߼����ꡣ</param>
        /// <param name="nYDest">ָ��Ŀ������������Ͻǵ�Y���߼����ꡣ</param>
        /// <param name="nWidth">ָ��Դ��Ŀ�����������߼���ȡ�</param>
        /// <param name="nHeight">ָ��Դ��Ŀ�����������߼��߶ȡ�</param>
        /// <param name="hdcSrc">ָ��Դ�豸�����ľ����</param>
        /// <param name="nXSrc">ָ��Դ�����������Ͻǵ�X���߼����ꡣ</param>
        /// <param name="nYSrc">ָ��Դ�����������Ͻǵ�Y���߼����ꡣ</param>
        /// <param name="dwRop">ָ����դ�������롣��Щ���뽫����Դ�����������ɫ���ݣ������Ŀ������������ɫ������������������ɫ��</param>
        /// <returns>��������ɹ�����ô����ֵ���㣻�������ʧ�ܣ��򷵻�ֵΪ�㡣</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        /// <summary>
        /// <para>����:</para>
        /// <para>������Դ�����и���һ��λͼ��Ŀ����Σ���Ҫʱ��ĿǰĿ���豸���õ�ģʽ����ͼ��������ѹ����</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>StretchBlt stretches or compresses the source bitmap in memory and then copies the result to the destination rectangle. This bitmap can be either a compatible bitmap (DDB) or the output from CreateDIBSection. The color data for pattern or destination pixels is merged after the stretching or compression occurs.</para>
        /// <para>When an enhanced metafile is being recorded, an error occurs (and the function returns FALSE) if the source device context identifies an enhanced-metafile device context.</para>
        /// <para>If the specified raster operation requires a brush, the system uses the brush currently selected into the destination device context.</para>
        /// <para>The destination coordinates are transformed by using the transformation currently specified for the destination device context; the source coordinates are transformed by using the transformation currently specified for the source device context.</para>
        /// <para>If the source transformation has a rotation or shear, an error occurs.</para>
        /// <para>If destination, source, and pattern bitmaps do not have the same color format, StretchBlt converts the source and pattern bitmaps to match the destination bitmap.</para>
        /// <para>If StretchBlt must convert a monochrome bitmap to a color bitmap, it sets white bits (1) to the background color and black bits (0) to the foreground color. To convert a color bitmap to a monochrome bitmap, it sets pixels that match the background color to white (1) and sets all other pixels to black (0). The foreground and background colors of the device context with color are used.</para>
        /// <para>StretchBlt creates a mirror image of a bitmap if the signs of the nWidthSrc and nWidthDest parameters or if the nHeightSrc and nHeightDest parameters differ. If nWidthSrc and nWidthDest have different signs, the function creates a mirror image of the bitmap along the x-axis. If nHeightSrc and nHeightDest have different signs, the function creates a mirror image of the bitmap along the y-axis.</para>
        /// <para>Not all devices support the StretchBlt function. For more information, see the GetDeviceCaps.</para>
        /// <para>ICM: No color management is performed when a blit operation occurs.</para>
        /// <para>When used in a multiple monitor system, both hdcSrc and hdcDest must refer to the same device or the function will fail. To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling GetDIBits. To display the DIB to the second device, call SetDIBits or StretchDIBits.</para>
        /// </summary>
        /// <param name="hdcDest">ָ��Ŀ���豸�����ľ����</param>
        /// <param name="nXOriginDest">ָ��Ŀ��������Ͻǵ�X�����꣬���߼���λ��ʾ���ꡣ</param>
        /// <param name="nYOriginDest">ָ��Ŀ��������Ͻǵ�Y�����꣬���߼���λ��ʾ���ꡣ</param>
        /// <param name="nWidthDest">ָ��Ŀ����εĿ�ȣ����߼���λ��ʾ��ȡ�</param>
        /// <param name="nHeightDest">ָ��Ŀ����εĸ߶ȣ����߼���λ��ʾ�߶ȡ�</param>
        /// <param name="hdcSrc">ָ��Դ�豸�����ľ����</param>
        /// <param name="nXOriginSrc">ָ��Դ�����������Ͻǵ�X�����꣬���߼���λ��ʾ���ꡣ</param>
        /// <param name="nYOriginSrc">ָ��Դ�����������Ͻǵ�Y�����꣬���߼���λ��ʾ���ꡣ</param>
        /// <param name="nWidthSrc">ָ��Դ���εĿ�ȣ����߼���λ��ʾ��ȡ�</param>
        /// <param name="nHeightSrc">ָ��Դ���εĸ߶ȣ����߼���λ��ʾ�߶ȡ�</param>
        /// <param name="dwRop">ָ��Ҫ���еĹ�դ��������դ�����붨����ϵͳ�������������������ɫ����Щ��������ˢ�ӡ�Դλͼ��Ŀ��λͼ�ȶ��󡣲ο�BitBlt���˽ⳣ�õĹ�դ�������б�</param>
        /// <returns>�������ִ�гɹ�����ô����ֵΪ���㣬�������ִ��ʧ�ܣ���ô����ֵΪ�㡣</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, int dwRop);
        /// <summary>
        /// <para>����:</para>
        /// <para>��Win2K��Win2K�������GdiAlphaBlend���ú���������ʾ����ָ��͸���ȵ�ͼ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>���Դ����������Ŀ����������С��һ������ô������Դλͼ��Ŀ���������ƥ�䡣</para>
        /// <para>���ʹ��SetStretchBltMode��������ôiStretchMode��ֵ��BLACKONWHITE��WHITEONBLACK���ڱ������У�iStretchMode��ֵ�Զ�ת����COLORONCOLOR��</para>
        /// <para>Ŀ������ʹ��ΪĿ���豸������ǰָ����ת����ʽ����ת����</para>
        /// <para>Դ������ʹ��ΪԴ�豸����ָ���ĵ�ǰת����ʽ����ת����</para>
        /// <para>���Դ�豸������ʶΪ��ǿ��ͼԪ�ļ��豸��������ô��������Ҹú�������FALSE����</para>
        /// <para>���Ŀ���Դλͼ��ɫ�ʸ�ʽ��ͬ����ôAlphaBlend��Դλͼת����ƥ��Ŀ��λͼ��</para>
        /// <para>AlphaBlend��֧�־������Դ��Ŀ������Ŀ�Ȼ�߶�Ϊ��������ô���ý�ʧ�ܡ�</para>
        /// </summary>
        /// <param name="hdcDest">ָ��Ŀ���豸�����ľ����</param>
        /// <param name="xoriginDest">ָ��Ŀ������������Ͻǵ�X�����꣬���߼���λ��</param>
        /// <param name="yoriginDest">ָ��Ŀ������������Ͻǵ�Y�����꣬���߼���λ��</param>
        /// <param name="wDest">ָ��Ŀ���������Ŀ�ȣ����߼���λ��</param>
        /// <param name="hDest">ָ��Ŀ���������ĸ߶ȣ����߼���λ��</param>
        /// <param name="hdcSrc">ָ��Դ�豸�����ľ����</param>
        /// <param name="xoriginSrc">ָ��Դ�����������Ͻǵ�X�����꣬���߼���λ��</param>
        /// <param name="yoriginSrc">ָ��Դ�����������Ͻǵ�Y�����꣬���߼���λ��</param>
        /// <param name="wSrc">ָ��Դ��������Ŀ�ȣ����߼���λ��</param>
        /// <param name="hSrc">ָ��Դ��������ĸ߶ȣ����߼���λ��</param>
        /// <param name="ftn">ָ������Դλͼ��Ŀ��λͼʹ�õ�alpha��Ϲ��ܣ���������Դλͼ��ȫ��alphaֵ�͸�ʽ��Ϣ��Դ��Ŀ���Ϲ��ܵ�ǰֻ��ΪAC_SRC_OVER�����һ������blendFunction��һ��BLENDFUNCTION�ṹ��BLENDFUNCTION�ṹ����Դ��Ŀ��λͼ�Ļ�Ϸ�ʽ������BlendOp�ֶ�ָ����Դ��ϲ�������ֻ֧��AC_SRC_OVER��������Դalphaֵ��Դͼ����ӵ�Ŀ��ͼ���ϡ�OpenGL��alpha��ϻ�֧�������ķ�ʽ���糣����ɫԴ����һ���ֶ�BlendFlags������0��Ҳ��Ϊ�Ժ��Ӧ�ñ����ġ����һ���ֶ�AlphaFormat������ѡ��0��ʾ����alphaֵ��AC_SRC_ALPHA��ʾÿ�������и��Ե�alphaͨ����</param>
        /// <returns>�������ִ�гɹ�����ô����ֵΪTRUE���������ִ��ʧ�ܣ���ô����ֵΪFALSE��If the function succeeds, the return value is TRUE.If the function fails, the return value is FALSE.This function can return the following value.ERROR_INVALID_PARAMETER:One or more of the input parameters is invalid.</returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiAlphaBlend(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, NativeMethods.BLENDFUNCTION ftn);
        /// <summary>
        /// <para>����:</para>
        /// <para>��Win2K��Win2K�������GdiGradientFill���ú��������κ������νṹ��</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>�����ھ��������м���һЩƽ������Ӱ�����ƣ������������ε������������GradientFill������CDI���������Բ�ֵ��������������</para>
        /// <para>�ڻ��ƾ���ʱ����ʹ��������Ӱģʽ��ˮƽģʽ�У����δ������ҿ�ʼ�䰵���ڴ�ֱģʽ�����Ǵ������½��С�</para>
        /// </summary>
        /// <param name="hdc">ָ��Ŀ���豸�����ľ����</param>
        /// <param name="pVertex">ָ��TRIVERTEX�ṹ�����ָ�룬�������е�ÿ����������ζ��㡣</param>
        /// <param name="dwVertex">������Ŀ��</param>
        /// <param name="pMesh">������ģʽ�µ�GRADIENT_TRIANGLE�ṹ���飬�����ģʽ�µ�GRADIENT_RECT�ṹ���顣</param>
        /// <param name="dwMesh">����pMesh�еĳ�Ա��Ŀ����Щ��Ա�������λ���Σ���</param>
        /// <param name="dwMode">ָ����б���ģʽ���ò������԰�������ֵ����Щֵ�ĺ���Ϊ��</param>
        /// <returns>�������ִ�гɹ�����ô����ֵΪTRUE���������ִ��ʧ�ܣ��򷵻�ֵΪFALSE��</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiGradientFill(IntPtr hdc, IntPtr pVertex, uint dwVertex, IntPtr pMesh, uint dwMesh, uint dwMode);
        /// <summary>
        /// <para>����:</para>
        /// <para>��Win2K��Win2K�������GdiTransparentBlt���ú�����ָ����Դ�豸�����еľ����������ص���ɫ���ݽ���λ�飨bit_block��ת���������������Ŀ���豸������</para>
        /// <para>.</para>
        /// <para>��ע:</para>
        /// <para>����TransparentBlt֧��4λ/���غ�8λ/���ظ�ʽ��Դλͼ��ʹ��AlphaBlend����ָ������͸���ȵ�32λ/���ظ�ʽ��λͼ��</para>
        /// <para>���Դ��Ŀ����εĴ�С��һ�£���ô����Դλͼ������������Ŀ�����ƥ�䣬��ʹ��SetStretchBltMode����ʱ��BLACKONWHITE��WHITEONBLACK����iStretchModeģʽ����ת����TransparentBlt������COLORONCOLORģʽ��</para>
        /// <para>Ŀ���豸����ָ��������Ŀ������ı任���ͣ���Դ�豸����ָ����Դ����ʹ�õı任���͡�</para>
        /// <para>���Դλͼ��Ŀ��λͼ�Ŀ�Ȼ�߶��Ǹ�������ôTransparentBlt����Ҳ����λͼ���о���</para>
        /// </summary>
        /// <param name="hdcDest">ָ��Ŀ���豸�����ľ����</param>
        /// <param name="xoriginDest">ָ��Ŀ������������Ͻǵ�X�����꣬���߼���λ��</param>
        /// <param name="yoriginDest">ָ��Ŀ������������Ͻǵ�Y�����꣬���߼���λ��</param>
        /// <param name="wDest">ָ��Ŀ���������Ŀ�ȣ����߼���λ��</param>
        /// <param name="hDest">ָ��Ŀ���������ĸ߶ȣ����߼���λ��</param>
        /// <param name="hdcSrc">ָ��Դ�豸�����ľ����</param>
        /// <param name="xoriginSrc">ָ��Դ�����������Ͻǵ�X�����꣬���߼���λ��</param>
        /// <param name="yoriginSrc">ָ��Դ�����������Ͻǵ�Y�����꣬���߼���λ��</param>
        /// <param name="wSrc">ָ��Դ��������Ŀ�ȣ����߼���λ��</param>
        /// <param name="hSrc">ָ��Դ��������ĸ߶ȣ����߼���λ��</param>
        /// <param name="crTransparent">Դλͼ�е�RGBֵ����͸����ɫ��</param>
        /// <returns>����ֵ���������ִ�гɹ�����ô����ֵΪTRUE���������ִ��ʧ�ܣ���ô����ֵΪFALSE��</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiTransparentBlt(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, uint crTransparent);
    }
}
