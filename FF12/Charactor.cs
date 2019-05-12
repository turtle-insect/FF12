using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF12
{
	class Charactor
	{
		private readonly uint mAddress;
		private readonly String mName;

		public Charactor(uint address, String name)
		{
			mAddress = address;
			mName = name;
		}

		public String Name
		{
			get { return mName; }
		}

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 442, 1); }
			set { Unit.WriteNumber(mAddress + 442, 1, value, 1, 99); }
		}

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 388, 4); }
			set { Unit.WriteNumber(mAddress + 388, 4, value, 0, 9999999); }
		}

		public uint LP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 392, 4); }
			set { Unit.WriteNumber(mAddress + 392, 4, value, 0, 9999999); }
		}

		public uint HP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 28, 4); }
			set
			{
				Unit.WriteNumber(mAddress + 28, 4, value, 0, 9999);
				Unit.WriteNumber(mAddress + 64, 4, value, 0, 9999);
			}
		}

		public uint HPBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 0, 4); }
			set { Unit.WriteNumber(mAddress + 0, 4, value, 0, 9999); }
		}

		public uint MP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 32, 2); }
			set
			{
				Unit.WriteNumber(mAddress + 32, 2, value, 0, 999);
				Unit.WriteNumber(mAddress + 68, 4, value, 0, 999);
			}
		}

		public uint MPBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 4, 2); }
			set { Unit.WriteNumber(mAddress + 4, 2, value, 0, 999); }
		}

		public uint Strength
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 34, 1); }
			set { Unit.WriteNumber(mAddress + 34, 1, value, 0, 255); }
		}

		public uint Magic
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 35, 1); }
			set { Unit.WriteNumber(mAddress + 35, 1, value, 0, 255); }
		}

		public uint Vitality
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 36, 1); }
			set { Unit.WriteNumber(mAddress + 36, 1, value, 0, 255); }
		}

		public uint Speed
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 37, 1); }
			set { Unit.WriteNumber(mAddress + 37, 1, value, 0, 255); }
		}

		public uint Attack
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 38, 1); }
			set { Unit.WriteNumber(mAddress + 38, 1, value, 0, 255); }
		}

		public uint Defense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 39, 1); }
			set { Unit.WriteNumber(mAddress + 39, 1, value, 0, 255); }
		}

		public uint MagicDefense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 40, 1); }
			set { Unit.WriteNumber(mAddress + 40, 1, value, 0, 255); }
		}

		public uint MagicResist
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 41, 1); }
			set { Unit.WriteNumber(mAddress + 41, 1, value, 0, 255); }
		}

		public uint Evade
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 42, 1); }
			set { Unit.WriteNumber(mAddress + 42, 1, value, 0, 255); }
		}
	}
}
