using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardApiOpensourceLibs.Core.Interfaces
{
    /// <summary>
    /// Default url is 'https://eu.battle.net/oauth/token'
    /// </summary>
    public interface IBattleNetApiProxy: IDisposable
    {
        /// <summary>
        /// Method for OAuth2
        /// </summary>
        /// <param name="cliendId">string data from developer portal</param>
        /// <param name="secret">string data from developer portal</param>
        /// <returns>if all is ok you will get token</returns>
        Task<string> GetToken(string cliendId, string secret);
    }
}
