﻿using HDF5CSharp.DataTypes;
using HDF5CSharp.Example.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HDF5_CSharp.Example.UnitTest
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemEvent2
    {
        [Hdf5EntryName("timestamp")] public long timestamp;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)][Hdf5EntryName("type")] public string type;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)][Hdf5EntryName("description")] public string description;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200000)][Hdf5EntryName("data")] public string data;
        [Hdf5EntryName("error")] public int isError;

  
        public SystemEvent2(long timestamp, string type, string description, string data, bool isError)
        {
            this.timestamp = timestamp;
            this.type = type;
            this.description = description;
            this.data = data;
            this.isError = isError ? 1 : 0;
        }

        public bool GetErrorAsBoolean() => isError == 1;


        public bool Equals(SystemEvent2 other)
        {
            return timestamp == other.timestamp && type == other.type && description == other.description && data == other.data && isError == other.isError;
        }

        public override bool Equals(object obj)
        {
            return obj is SystemEvent2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = timestamp.GetHashCode();
                hashCode = (hashCode * 397) ^ (type != null ? type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (description != null ? description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (data != null ? data.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ isError;
                return hashCode;
            }
        }
    }
}
