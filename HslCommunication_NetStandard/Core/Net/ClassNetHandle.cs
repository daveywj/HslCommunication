﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



/*************************************************************************************
 * 
 *    文件名：ClassNetHandle.cs
 *    功能：  网络通信头，标识消息的内容
 *    
 *    这个类公开在HslCommunication下面
 * 
 *************************************************************************************/




namespace HslCommunication
{


    /// <summary>
    /// 用于网络传递的信息头，使用上等同于int
    /// </summary>
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct NetHandle
    {
        #region Implicit Support

        /// <summary>
        /// 赋值操作，可以直接赋值int数据
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator NetHandle(int value)
        {
            return new NetHandle(value);
        }

        /// <summary>
        /// 也可以赋值给int数据
        /// </summary>
        /// <param name="netHandle"></param>
        public static implicit operator int(NetHandle netHandle)
        {
            return netHandle.m_CodeValue;
        }

        #endregion

        #region Operator Support

        /// <summary>
        /// 判断是否相等
        /// </summary>
        /// <param name="netHandle1">第一个数</param>
        /// <param name="netHandle2">第二个数</param>
        /// <returns></returns>
        public static bool operator == (NetHandle netHandle1, NetHandle netHandle2)
        {
            return netHandle1.CodeValue == netHandle2.CodeValue;
        }

        /// <summary>
        /// 判断是否不相等
        /// </summary>
        /// <param name="netHandle1"></param>
        /// <param name="netHandle2"></param>
        /// <returns></returns>
        public static bool operator != (NetHandle netHandle1, NetHandle netHandle2)
        {
            return netHandle1.CodeValue != netHandle2.CodeValue;
        }

        /// <summary>
        /// 两个数值相加
        /// </summary>
        /// <param name="netHandle1"></param>
        /// <param name="netHandle2"></param>
        /// <returns></returns>
        public static NetHandle operator + (NetHandle netHandle1, NetHandle netHandle2)
        {
            return new NetHandle(netHandle1.CodeValue + netHandle2.CodeValue);
        }

        /// <summary>
        /// 两个数值相减
        /// </summary>
        /// <param name="netHandle1"></param>
        /// <param name="netHandle2"></param>
        /// <returns></returns>
        public static NetHandle operator - (NetHandle netHandle1, NetHandle netHandle2)
        {
            return new NetHandle(netHandle1.CodeValue - netHandle2.CodeValue);
        }

        /// <summary>
        /// 判断是否小于另一个数值
        /// </summary>
        /// <param name="netHandle1"></param>
        /// <param name="netHandle2"></param>
        /// <returns></returns>
        public static bool operator < (NetHandle netHandle1, NetHandle netHandle2)
        {
            return netHandle1.CodeValue < netHandle2.CodeValue;
        }

        /// <summary>
        /// 判断是否大于另一个数值
        /// </summary>
        /// <param name="netHandle1"></param>
        /// <param name="netHandle2"></param>
        /// <returns></returns>
        public static bool operator > (NetHandle netHandle1, NetHandle netHandle2)
        {
            return netHandle1.CodeValue > netHandle2.CodeValue;
        }

        #endregion

        #region Constructor


        /// <summary>
        /// 初始化一个暗号对象
        /// </summary>
        public NetHandle(int value)
        {
            m_CodeMajor = 0;
            m_CodeMinor = 0;
            m_CodeIdentifier = 0;

            m_CodeValue = value;
        }


        /// <summary>
        /// 根据三个值来初始化暗号对象
        /// </summary>
        /// <param name="major">主暗号</param>
        /// <param name="minor">次暗号</param>
        /// <param name="identifier">暗号编号</param>
        public NetHandle(byte major, byte minor, ushort identifier)
        {
            m_CodeValue = 0;

            m_CodeMajor = major;
            m_CodeMinor = minor;
            m_CodeIdentifier = identifier;
        }


        #endregion

        #region Private Members


        /// <summary>
        /// 完整的暗号值
        /// </summary>
        [System.Runtime.InteropServices.FieldOffset(0)]
        private int m_CodeValue;

        /// <summary>
        /// 主暗号分类0-255
        /// </summary>
        [System.Runtime.InteropServices.FieldOffset(3)]
        private byte m_CodeMajor;

        /// <summary>
        /// 次要的暗号分类0-255
        /// </summary>
        [System.Runtime.InteropServices.FieldOffset(2)]
        private byte m_CodeMinor;

        /// <summary>
        /// 暗号的编号分类0-65535
        /// </summary>
        [System.Runtime.InteropServices.FieldOffset(0)]
        private ushort m_CodeIdentifier;



        #endregion

        #region Public Members

        
        /// <summary>
        /// 完整的暗号值
        /// </summary>
        public int CodeValue { get => m_CodeValue; set => m_CodeValue = value; }

        /// <summary>
        /// 主暗号分类0-255
        /// </summary>
        public byte CodeMajor { get => m_CodeMajor; private set => m_CodeMajor = value; }
        /// <summary>
        /// 次要的暗号分类0-255
        /// </summary>
        public byte CodeMinor { get => m_CodeMinor; private set => m_CodeMinor = value; }

        /// <summary>
        /// 暗号的编号分类0-65535
        /// </summary>
        public ushort CodeIdentifier { get => m_CodeIdentifier; private set => m_CodeIdentifier = value; }

        #endregion

        #region Object Override
        
        /// <summary>
        /// 获取完整的暗号数据
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_CodeValue.ToString();
        }

        /// <summary>
        /// 判断两个实例是否相同
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is NetHandle headCode)
            {
                return CodeValue.Equals(headCode.CodeValue);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
