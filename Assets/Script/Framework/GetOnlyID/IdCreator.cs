
namespace ECSFrameWork{
    public class IdCreator
    {
        private static long _instanceIdGenerator;

        private static long _appId;

        public static long AppId
        {
            set
            {
                _appId = value;
                _instanceIdGenerator = _appId << 48;
            }
        }
        private static ushort _value;

        public static long GenerateId()
        {
            long time = TimeHelper.ClientNowSeconds();

            return (_appId << 48) + (time << 16) + ++_value;
        }

        public static long GenerateInstanceId()
        {
            return ++_instanceIdGenerator;
        }

        public static int GetAppId(long v)
        {
            return (int)(v >> 48);
        }
    }
}
