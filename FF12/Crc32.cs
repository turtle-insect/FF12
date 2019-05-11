using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF12
{
	class Crc32
	{
		private readonly uint[] mTable;

		public Crc32()
		{
			mTable = new uint[256];
			for (uint i = 0; i < 256; i++)
			{
				var x = i;
				for (var j = 0; j < 8; j++)
				{
					x = (uint)((x & 1) == 0 ? x >> 1 : -306674912 ^ x >> 1);
				}
				mTable[i] = x;
			}
		}

		public uint Calc(ref Byte[] buf, int start, int end)
		{
			uint num = uint.MaxValue;
			for (var i = start; i < end; i++)
			{
				num = mTable[(num ^ buf[i]) & 255] ^ num >> 8;
			}

			return (uint)(num ^ -1);
		}
	}
}
