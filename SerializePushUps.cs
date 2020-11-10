using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Калькуратор_отжиманий
{
    [Serializable]
    class SerializePushUps
    {
        static private readonly BinaryFormatter binFormat = new BinaryFormatter();
        static public int GetPushUps()
        {
            try
            {
                using (FileStream fStream = new FileStream("user.dat", FileMode.OpenOrCreate))
                {
                    return (int)binFormat.Deserialize(fStream);
                }
            }
            catch {
                return 0;
            }
        }
        static public void SetPushUps(int count)
        {
            using (Stream fStream = new FileStream("user.dat",
                        FileMode.Create))
            {
                binFormat.Serialize(fStream, count);
            }
        }
        static public void UpdatePushUps(int count)
        {
            using (Stream fStream = new FileStream("user.dat",
                        FileMode.Create))
            {
                binFormat.Serialize(fStream, count);
            }
        }

    }
}
