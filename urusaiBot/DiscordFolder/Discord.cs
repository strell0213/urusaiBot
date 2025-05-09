using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace urusaiBot.DiscordFolder
{
    public class DiscordClass
    {
        private DiscordSocketClient client;
        public string key = "";
        public bool botConnect = false;

        public DiscordClass() { }

        public async Task StartSettingBot()
        {
            DiscordSocketConfig config = new DiscordSocketConfig();
            config.GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent;
            client = new DiscordSocketClient(config);
            client.MessageReceived += CommandsHandler;
            //client.Log += window.Log;

            await client.LoginAsync(TokenType.Bot, key);
        }

        public async Task StartBot()
        {
            await client.StartAsync();
            botConnect = true;
        }

        private async Task CommandsHandler(SocketMessage message)
        {
            if (!message.Author.IsBot)
            {
                if (message.Content == "хай")
                {
                    await message.Channel.SendMessageAsync($"Прив, {message.Author}");
                }
                //else if (message.Content.Contains("/play"))
                //{
                //    string mes = message.Content;
                //    string urlpath = mes.Replace("/play", "");
                //    urlpath.Trim();
                //    if (urlpath != null && urlpath != "")
                //    {
                //        //string voiceid = message.
                //        await message.Channel.SendMessageAsync($"Ваша ссылка - {urlpath}");
                //        IVoiceChannel channel = null;
                //        channel = channel ?? (message.Author as IGuildUser)?.VoiceChannel;
                //        if (channel == null) { await message.Channel.SendMessageAsync("User must be in a voice channel, or a voice channel must be passed as an argument."); return; }

                //        var audioClient = await channel.ConnectAsync();
                //    }
                //    else
                //    {
                //        await message.Channel.SendMessageAsync("Укажите ссылку");
                //    }
                //}
            }
        }

        public string GetKey(string url)
        {
            if (url.Length > 0)
            {
                StreamReader reader = new StreamReader(url);
                GlobalSettings.key = reader.ReadToEnd();
                reader.Close();
                return GlobalSettings.key;
            }
            else return "";
        }
    }
}
