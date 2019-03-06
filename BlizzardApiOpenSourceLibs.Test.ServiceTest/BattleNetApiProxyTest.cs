using BlizzardApiOpensourceLibs.Core.Interfaces;
using BlizzardApiOpenSourceLibs.Service.Proxies;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BlizzardApiOpenSourceLibs.Test.ServiceTest
{
    public class BattleNetApiProxyTest: IDisposable
    {
        private IBattleNetApiProxy _proxy = new BattleNetApiProxy("https://eu.battle.net/oauth/token");

        [Fact]
        public async Task GetTokenTest()
        {
            // todo:
            // need to hide!

            var clientId = "put-your-client-id";
            var secret = "put-your-secret-id";

            var token = await _proxy.GetToken(clientId, secret);
            
        }

        public void Dispose()
        {

        }
    }
}
