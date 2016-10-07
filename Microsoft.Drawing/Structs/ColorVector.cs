using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Drawing
{
    /// <summary>
    /// ��ɫ����,ֻ֧�ּӼ�����,��֧�ֳ˳�����
    /// Copyright (c) JajaSoft
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true), TypeConverter(typeof(ColorVectorConverter))]
    public struct ColorVector
    {
        #region ��̬

        /// <summary>
        /// A=0,R=0,G=0,B=0
        /// </summary>
        public static readonly ColorVector Empty;

        /// <summary>
        /// ��̬����
        /// </summary>
        static ColorVector()
        {
            Empty = new ColorVector();
        }

        /// <summary>
        /// ����Long,��ռ16λ��64λ
        /// </summary>
        /// <param name="alpha">A</param>
        /// <param name="red">R</param>
        /// <param name="green">G</param>
        /// <param name="blue">B</param>
        /// <returns>��������ֵ</returns>
        private static long MakeLong(int alpha, int red, int green, int blue)
        {
            ulong ulA = (ulong)(alpha & ushort.MaxValue);
            ulong ulR = (ulong)(red & ushort.MaxValue);
            ulong ulG = (ulong)(green & ushort.MaxValue);
            ulong ulB = (ulong)(blue & ushort.MaxValue);
            return (long)((ulA << 0x30) | (ulR << 0x20) | (ulG << 0x10) | ulB);
        }


        /// <summary>
        /// ��һ��64λ��������ColorVector�ṹ
        /// </summary>
        /// <param name="value">64λ����</param>
        /// <returns>ColorVector�ṹ</returns>
        public static ColorVector FromArgb(long value)
        {
            return new ColorVector(value);
        }

        /// <summary>
        /// ��һ��Color�ṹ����ColorVector�ṹ
        /// </summary>
        /// <param name="color">Color�ṹ</param>
        /// <returns>ColorVector�ṹ</returns>
        public static ColorVector FromArgb(Color color)
        {
            return new ColorVector(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        /// ��һ��Color�ṹ����ColorVector�ṹ,��Alphaʹ��ָ����ֵ
        /// </summary>
        /// <param name="alpha">Alphaָ��ֵ</param>
        /// <param name="color">Color�ṹ</param>
        /// <returns>ColorVector�ṹ</returns>
        public static ColorVector FromArgb(int alpha, Color color)
        {
            return new ColorVector(alpha, color.R, color.G, color.B);
        }

        /// <summary>
        /// ��һ��ColorVector�ṹ����ColorVector�ṹ,��Alphaʹ��ָ��ֵ
        /// </summary>
        /// <param name="alpha">Alphaָ��ֵ</param>
        /// <param name="vector">ColorVector�ṹ</param>
        /// <returns>ColorVector�ṹ</returns>
        public static ColorVector FromArgb(int alpha, ColorVector vector)
        {
            return new ColorVector(alpha, vector.R, vector.G, vector.B);
        }

        /// <summary>
        /// ������16λ��������ColorVector�ṹ,Alphaʹ��0
        /// </summary>
        /// <param name="red">Redֵ</param>
        /// <param name="green">Greenֵ</param>
        /// <param name="blue">Blueֵ</param>
        /// <returns>ColorVector�ṹ</returns>
        public static ColorVector FromArgb(int red, int green, int blue)
        {
            return new ColorVector(0, red, green, blue);
        }

        /// <summary>
        /// ���ĸ�16λ��������ColorVector�ṹ
        /// </summary>
        /// <param name="alpha">Alphaֵ</param>
        /// <param name="red">Redֵ</param>
        /// <param name="green">Greenֵ</param>
        /// <param name="blue">Blueֵ</param>
        /// <returns>ColorVector�ṹ</returns>
        public static ColorVector FromArgb(int alpha, int red, int green, int blue)
        {
            return new ColorVector(alpha, red, green, blue);
        }

        #endregion


        #region �ֶ�����

        //64λֵ
        private long Value;

        /// <summary>
        /// Alpha�����ϵ�ƫ����
        /// </summary>
        public short A
        {
            get
            {
                return (short)((this.Value >> 0x30) & ushort.MaxValue);
            }
        }

        /// <summary>
        /// ��ɫ�����ϵ�ƫ����
        /// </summary>
        public short R
        {
            get
            {
                return (short)((this.Value >> 0x20) & ushort.MaxValue);
            }
        }

        /// <summary>
        /// ��ɫ�����ϵ�ƫ����
        /// </summary>
        public short G
        {
            get
            {
                return (short)((this.Value >> 0x10) & ushort.MaxValue);
            }
        }

        /// <summary>
        /// ��ɫ�����ϵ�ƫ����
        /// </summary>
        public short B
        {
            get
            {
                return (short)(this.Value & ushort.MaxValue);
            }
        }

        #endregion


        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="value">��������ֵ</param>
        private ColorVector(long value)
        {
            this.Value = value;
        }

        /// <summary>
        /// ���캯��,��ռ16λ.short(-32768,32767)
        /// </summary>
        /// <param name="alpha">A</param>
        /// <param name="red">R</param>
        /// <param name="green">G</param>
        /// <param name="blue">B</param>
        private ColorVector(int alpha, int red, int green, int blue)
            : this(MakeLong(alpha, red, green, blue))
        {
        }

        #endregion


        #region ��������

        /// <summary>
        /// ��ȡHashֵ
        /// </summary>
        /// <returns>����</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        /// <summary>
        /// ת��Ϊ�ַ���
        /// </summary>
        /// <returns>�ַ���</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x20);
            builder.Append(base.GetType().Name);
            builder.Append(" [");
            if (this == ColorVector.Empty)
            {
                builder.Append("Empty");
            }
            else
            {
                builder.Append("A=");
                builder.Append(this.A);
                builder.Append(", R=");
                builder.Append(this.R);
                builder.Append(", G=");
                builder.Append(this.G);
                builder.Append(", B=");
                builder.Append(this.B);
            }
            builder.Append("]");
            return builder.ToString();
        }

        /// <summary>
        /// �ж������Ƿ����
        /// </summary>
        /// <param name="obj">Ŀ�����</param>
        /// <returns>��ȷ���true,���򷵻�false</returns>
        public override bool Equals(object obj)
        {
            if (obj is ColorVector)
            {
                ColorVector vector = (ColorVector)obj;
                return this == vector;
            }
            return false;
        }

        /// <summary>
        /// ת��Ϊ��ɫ
        /// </summary>
        /// <returns>��ɫ</returns>
        public Color ToColor()
        {
            return Color.FromArgb(MathEx.Clamp(this.A, (byte)0, (byte)255),
                MathEx.Clamp(this.R, (byte)0, (byte)255),
                MathEx.Clamp(this.G, (byte)0, (byte)255),
                MathEx.Clamp(this.B, (byte)0, (byte)255));
        }

        #endregion


        #region ������

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="left">��ֵ</param>
        /// <param name="right">��ֵ</param>
        /// <returns>��ȷ���true,���򷵻�false</returns>
        public static bool operator ==(ColorVector left, ColorVector right)
        {
            return left.Value == right.Value;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="left">��ֵ</param>
        /// <param name="right">��ֵ</param>
        /// <returns>���ȷ���true,���򷵻�false</returns>
        public static bool operator !=(ColorVector left, ColorVector right)
        {
            return !(left == right);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="left">��ֵ</param>
        /// <param name="right">��ֵ</param>
        /// <returns>A,R,G,Bȫ�����ڷ���true,���򷵻�false</returns>
        public static bool operator >(ColorVector left, ColorVector right)
        {
            return left.A > right.A
                && left.R > right.R
                && left.G > right.G
                && left.B > right.B;
        }

        /// <summary>
        /// ���ڵ���
        /// </summary>
        /// <param name="left">��ֵ</param>
        /// <param name="right">��ֵ</param>
        /// <returns>A,R,G,Bȫ�����ڵ��ڷ���true,���򷵻�false</returns>
        public static bool operator >=(ColorVector left, ColorVector right)
        {
            return left.A >= right.A
                && left.R >= right.R
                && left.G >= right.G
                && left.B >= right.B;
        }

        /// <summary>
        /// С��
        /// </summary>
        /// <param name="left">��ֵ</param>
        /// <param name="right">��ֵ</param>
        /// <returns>A,R,G,Bȫ��С�ڷ���true,���򷵻�false</returns>
        public static bool operator <(ColorVector left, ColorVector right)
        {
            return left.A < right.A
                && left.R < right.R
                && left.G < right.G
                && left.B < right.B;
        }

        /// <summary>
        /// С�ڵ���
        /// </summary>
        /// <param name="left">��ֵ</param>
        /// <param name="right">��ֵ</param>
        /// <returns>A,R,G,Bȫ��С�ڵ��ڷ���true,���򷵻�false</returns>
        public static bool operator <=(ColorVector left, ColorVector right)
        {
            return left.A <= right.A
                && left.R <= right.R
                && left.G <= right.G
                && left.B <= right.B;
        }

        /// <summary>
        /// ������ɫ�������
        /// </summary>
        /// <param name="left">��ֵ</param>
        /// <param name="right">��ֵ</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator +(ColorVector left, ColorVector right)
        {
            return new ColorVector(left.A + right.A, left.R + right.R, left.G + right.G, left.B + right.B);
        }

        /// <summary>
        /// ��ɫ������ɫ����
        /// </summary>
        /// <param name="left">��ɫ</param>
        /// <param name="right">��ɫ����</param>
        /// <returns>��������ɫ</returns>
        public static Color operator +(Color left, ColorVector right)
        {
            return Color.FromArgb(MathEx.Clamp(left.A + right.A, (byte)0, (byte)255),
                MathEx.Clamp(left.R + right.R, (byte)0, (byte)255),
                MathEx.Clamp(left.G + right.G, (byte)0, (byte)255),
                MathEx.Clamp(left.B + right.B, (byte)0, (byte)255));
        }

        /// <summary>
        /// ������ɫ�������
        /// </summary>
        /// <param name="left">��ֵ</param>
        /// <param name="right">��ֵ</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator -(ColorVector left, ColorVector right)
        {
            return new ColorVector(left.A - right.A, left.R - right.R, left.G - right.G, left.B - right.B);
        }

        /// <summary>
        /// ��ɫ��ȥ��ɫ����
        /// </summary>
        /// <param name="left">��ɫ</param>
        /// <param name="right">��ɫ����</param>
        /// <returns>��������ɫ</returns>
        public static Color operator -(Color left, ColorVector right)
        {
            return Color.FromArgb(MathEx.Clamp(left.A - right.A, (byte)0, (byte)255),
                MathEx.Clamp(left.R - right.R, (byte)0, (byte)255),
                MathEx.Clamp(left.G - right.G, (byte)0, (byte)255),
                MathEx.Clamp(left.B - right.B, (byte)0, (byte)255));
        }

        /// <summary>
        /// ��ɫ�������Ը�����
        /// </summary>
        /// <param name="left">��ɫ����</param>
        /// <param name="right">������</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator *(ColorVector left, float right)
        {
            return new ColorVector((int)(left.A * right), (int)(left.R * right), (int)(left.G * right), (int)(left.B * right));
        }

        /// <summary>
        /// ������������ɫ����
        /// </summary>
        /// <param name="left">������</param>
        /// <param name="right">��ɫ����</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator *(float left, ColorVector right)
        {
            return new ColorVector((int)(left * right.A), (int)(left * right.R), (int)(left * right.G), (int)(left * right.B));
        }

        /// <summary>
        /// ��ɫ������������
        /// </summary>
        /// <param name="left">��ɫ����</param>
        /// <param name="right">������</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator *(ColorVector left, int right)
        {
            return new ColorVector(left.A * right, left.R * right, left.G * right, left.B * right);
        }

        /// <summary>
        /// ����������ɫ����
        /// </summary>
        /// <param name="left">����</param>
        /// <param name="right">��ɫ����</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator *(int left, ColorVector right)
        {
            return new ColorVector(left * right.A, left * right.R, left * right.G, left * right.B);
        }

        /// <summary>
        /// ��ɫ�������Ը�����
        /// </summary>
        /// <param name="left">��ɫ����</param>
        /// <param name="right">������</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator /(ColorVector left, float right)
        {
            return new ColorVector((int)(left.A / right), (int)(left.R / right), (int)(left.G / right), (int)(left.B / right));
        }

        /// <summary>
        /// ������������ɫ����
        /// </summary>
        /// <param name="left">������</param>
        /// <param name="right">��ɫ����</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator /(float left, ColorVector right)
        {
            return new ColorVector((int)(left / right.A), (int)(left / right.R), (int)(left / right.G), (int)(left / right.B));
        }

        /// <summary>
        /// ��ɫ������������
        /// </summary>
        /// <param name="left">��ɫ����</param>
        /// <param name="right">����</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator /(ColorVector left, int right)
        {
            return new ColorVector(left.A / right, left.R / right, left.G / right, left.B / right);
        }

        /// <summary>
        /// ����������ɫ����
        /// </summary>
        /// <param name="left">����</param>
        /// <param name="right">��ɫ����</param>
        /// <returns>��������ɫ����</returns>
        public static ColorVector operator /(int left, ColorVector right)
        {
            return new ColorVector(left / right.A, left / right.R, left / right.G, left / right.B);
        }

        #endregion
    }
}
