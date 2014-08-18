using System.Collections.Generic;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    class D3ProfileExplorerLightConfig
    {
        public List<D3ProfileContainer> Profiles { get; set; }

        public D3ProfileExplorerLightConfig()
        {
            Profiles = new List<D3ProfileContainer>();
        }
    }
}
