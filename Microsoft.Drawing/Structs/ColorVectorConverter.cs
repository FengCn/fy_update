using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Microsoft.Drawing
{
    /// <summary>
    /// ��ɫ����ת����
    /// Copyright (c) JajaSoft
    /// </summary>
    public class ColorVectorConverter : TypeConverter
    {
        /// <summary>
        /// ���ظ�ת�����Ƿ����ʹ��ָ���������Ľ��������͵Ķ���ת��Ϊ��ת���������͡�
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext���ṩ��ʽ�����ġ�</param>
        /// <param name="sourceType">һ�� System.Type����ʾҪת�������͡�</param>
        /// <returns>�����ת�����ܹ�ִ��ת������Ϊ true������Ϊ false��</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// ���ش�ת�����Ƿ����ʹ��ָ���������Ľ��ö���ת��Ϊָ�������͡�
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext���ṩ��ʽ�����ġ�</param>
        /// <param name="destinationType">һ�� System.Type����ʾҪת���������͡�</param>
        /// <returns>�����ת�����ܹ�ִ��ת������Ϊ true������Ϊ false��</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }

        /// <summary>
        /// ʹ��ָ���������ĺ���������Ϣ�������Ķ���ת��Ϊ��ת���������͡�
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext���ṩ��ʽ�����ġ�</param>
        /// <param name="culture">������ǰ�����Ե� System.Globalization.CultureInfo��</param>
        /// <param name="value">Ҫת���� System.Object��</param>
        /// <returns>��ʾת���� value �� System.Object��</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            //NULL
            string str = value as string;
            if (str == null)
                return base.ConvertFrom(context, culture, value);

            //���ַ���
            string trimStr = str.Trim();
            if (trimStr.Length <= 0)
                return ColorVector.Empty;

            //����ָ���
            if (culture == null)
                culture = CultureInfo.CurrentCulture;
            char ch = culture.TextInfo.ListSeparator[0];

            //����ת����
            TypeConverter longConverter = TypeDescriptor.GetConverter(typeof(long));
            TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));

            //�����ָ���
            if (trimStr.IndexOf(ch) == -1)
            {
                if (((trimStr[0] == '#') &&
                    (trimStr.Length == 13 || trimStr.Length == 17)) ||
                    ((trimStr.StartsWith("0x") || trimStr.StartsWith("0X") || trimStr.StartsWith("&h") || trimStr.StartsWith("&H")) &&
                    (trimStr.Length == 14 || trimStr.Length == 18)))
                    return ColorVector.FromArgb((long)longConverter.ConvertFromString(trimStr));
            }
            else//�����ָ���
            {
                string[] strArray = trimStr.Split(new char[] { ch });
                int[] numArray = new int[strArray.Length];
                for (int i = 0; i < numArray.Length; i++)
                    numArray[i] = (int)intConverter.ConvertFromString(context, culture, strArray[i]);

                switch (numArray.Length)
                {
                    case 3:
                        return ColorVector.FromArgb(numArray[0], numArray[1], numArray[2]);

                    case 4:
                        return ColorVector.FromArgb(numArray[0], numArray[1], numArray[2], numArray[3]);
                }
            }

            throw new ArgumentException("��Ч����ɫ����");
        }

        /// <summary>
        /// ʹ��ָ���������ĺ���������Ϣ��������ֵ����ת��Ϊָ�������͡�
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext���ṩ��ʽ�����ġ�</param>
        /// <param name="culture">System.Globalization.CultureInfo��������� null������õ�ǰ�����ԡ�</param>
        /// <param name="value">Ҫת���� System.Object��</param>
        /// <param name="destinationType">value ����Ҫת���ɵ� System.Type��</param>
        /// <returns>��ʾת���� value �� System.Object��</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (value is ColorVector)
            {
                if (destinationType == typeof(string))//ת��Ϊstring
                {
                    ColorVector colorVector = (ColorVector)value;

                    if (culture == null)
                        culture = CultureInfo.CurrentCulture;

                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));

                    string[] strArray = new string[4];
                    strArray[0] = intConverter.ConvertToString(context, culture, colorVector.A);
                    strArray[1] = intConverter.ConvertToString(context, culture, colorVector.R);
                    strArray[2] = intConverter.ConvertToString(context, culture, colorVector.G);
                    strArray[3] = intConverter.ConvertToString(context, culture, colorVector.B);
                    return string.Join(separator, strArray);
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    MemberInfo member = null;
                    object[] arguments = null;
                    ColorVector colorVector2 = (ColorVector)value;
                    if (colorVector2 == ColorVector.Empty)
                    {
                        member = typeof(ColorVector).GetField("Empty");
                    }
                    else
                    {
                        member = typeof(ColorVector).GetMethod("FromArgb", new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) });
                        arguments = new object[] { colorVector2.A, colorVector2.R, colorVector2.G, colorVector2.B };
                    }

                    if (member != null)
                        return new InstanceDescriptor(member, arguments);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }


        /// <summary>
        /// ����֪��������� (Property) ֵ��������£�ʹ��ָ���������Ĵ������ System.ComponentModel.TypeConverter ���������͵�ʵ����
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext���ṩ��ʽ�����ġ�</param>
        /// <param name="propertyValues">������ (Property) ֵ�� System.Collections.IDictionary��</param>
        /// <returns>һ�� System.Object����ʾ������ System.Collections.IDictionary����������޷������ö�����Ϊ null���˷���ʼ�շ��� null��</returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }
            object alpha = propertyValues["A"];
            object red = propertyValues["R"];
            object green = propertyValues["G"];
            object blue = propertyValues["B"];
            if (((alpha == null) || (red == null) || (green == null) || (blue == null))
                || (!(alpha is short) || !(red is short) || !(green is short) || !(blue is short)))
            {
                throw new ArgumentException("����ֵΪ��Ч����");
            }
            return ColorVector.FromArgb((int)(short)alpha, (int)(short)red, (int)(short)green, (int)(short)blue);
        }

        /// <summary>
        /// �����йظ��ĸö����ϵ�ĳ��ֵ�Ƿ���Ҫʹ��ָ���������ĵ��� System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary) �Դ�����ֵ�������
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext���ṩ��ʽ�����ġ�</param>
        /// <returns>������Ĵ˶����������Ҫ���� System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary) ��������ֵ����Ϊ true������Ϊ false��</returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// ʹ��ָ���������ķ���ֵ����ָ�����������͵����� (Property) �ļ��ϡ�
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext���ṩ��ʽ�����ġ�</param>
        /// <param name="value">һ�� System.Object��ָ��ҪΪ���ȡ���Ե��������͡�</param>
        /// <param name="attributes">����ɸѡ���� System.Attribute �������顣</param>
        /// <returns>����Ϊ���������͹��������Ե� System.ComponentModel.PropertyDescriptorCollection���������û�����ԣ���Ϊ null��</returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(ColorVector), attributes).Sort(new string[] { "A", "R", "G", "B" });
        }

        /// <summary>
        /// ���ش˶����Ƿ�֧�����ԡ�
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext���ṩ��ʽ�����ġ�</param>
        /// <returns>���Ӧ���� System.ComponentModel.TypeConverter.GetProperties(System.Object) �����Ҵ˶�������ԣ���Ϊ true������Ϊ false��</returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
