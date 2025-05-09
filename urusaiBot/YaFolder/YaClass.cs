using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexMusicApi;
using YandexMusicApi.Auth;
using YandexMusicApi.Network;

namespace urusaiBot.YaFolder
{
    public class YaClass
    {
        public bool isAuth = false;
        private Token _token;
        private string _tokenAPI;

        YaClass() 
        { 
            _token = new Token(new ApiParams());
        }

        public async Task<bool> Auth(string login, string pass)
        {
            await _token.LoginUsername(login);
            await _token.LoginPassword(pass);

            _tokenAPI = _token.GetToken().ToString();
            return true;
        }


        
    }
}
