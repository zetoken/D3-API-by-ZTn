using System;
using ZTn.BNet.BattleNet;

namespace ZTn.BNet.D3ProfileExplorer
{
    internal class BNetContext<T>
    {
        public String Host;
        public BattleTag BattleTag;
        public T Data;

        public BNetContext(String host, BattleTag battleTag, T data)
        {
            Host = host;
            BattleTag = battleTag;
            Data = data;
        }
    }
}