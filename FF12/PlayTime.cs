using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF12
{
	class PlayTime
	{
		private uint mHour;
		private uint mMinute;
		private uint mSecond;

		public PlayTime()
		{
			uint value = SaveData.Instance().ReadNumber(0x10, 4);

			mHour = value / 216000;
			mMinute = value / 3600 % 60;
			mSecond = (value - mMinute * 3600) / 60 % 60;
		}

		public uint Hour
		{
			get { return mHour; }
			set
			{
				if (value < 0) value = 0;
				mHour = value;
				Write();
			}
		}

		public uint Minute
		{
			get { return mMinute; }
			set
			{
				if (value < 0) value = 0;
				if (value > 59) value = 59;
				mMinute = value;
				Write();
			}
		}

		public uint Second
		{
			get { return mSecond; }
			set
			{
				if (value < 0) value = 0;
				if (value > 59) value = 59;
				mSecond = value;
				Write();
			}
		}

		private void Write()
		{
			uint value = mHour * 216000;
			value += mMinute * 3600;
			value += mSecond * 60;
			SaveData.Instance().WriteNumber(0x10, 4, value);
		}
	}
}
