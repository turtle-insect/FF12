using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF12
{
	class Par
	{
		public (bool, int) Adaptation(String patch)
		{
			patch = patch.Replace("\t", " ");
			patch = patch.Replace("\r\n", "\n");
			String[] lines = patch.Split('\n');

			SaveData save = SaveData.Instance();
			for (int i = 0; i < lines.Length; i++)
			{
				if (String.IsNullOrEmpty(lines[i])) continue;

				uint size = 0;
				uint address = 0;
				uint value = 0;
				uint loop = 1;
				uint move = 0;
				uint add = 0;

				String[] code = lines[i].Split(' ');
				if (code.Length != 2)
				{
					return (false, i);
				}

				address = Convert.ToUInt32(code[0].Substring(1), 16);
				value = Convert.ToUInt32(code[1], 16);
				switch (code[0][0])
				{
					case '0':
						size = 1;
						break;

					case '1':
						size = 2;
						break;

					case '2':
						size = 4;
						break;

					case '4':
						if (i + 1 >= lines.Length)
						{
							return (false, i);
						}
						address = Convert.ToUInt32(code[0].Substring(2), 16);
						switch (code[0][1])
						{
							case '0':
								size = 1;
								break;

							case '1':
								size = 2;
								break;

							case '2':
								size = 4;
								break;
						}
						i++;
						code = lines[i].Split(' ');
						if(code[0][0] != '4')
						{
							return (false, i);
						}
						loop = Convert.ToUInt32(code[0].Substring(1, 3), 16);
						move = Convert.ToUInt32(code[0].Substring(4), 16);
						add = Convert.ToUInt32(code[1], 16);
						break;

					default:
						return (false, i);
				}

				for (uint j = 0; j < loop; j++)
				{
					save.WriteNumber(address + move * j, size, value + add * j);
				}
			}

			return (true, 0);
		}
	}
}
