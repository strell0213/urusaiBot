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

        public async Task StartSettingBot()
        {
            DiscordSocketConfig config = new DiscordSocketConfig();
            config.GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent;
            client = new DiscordSocketClient(config);
            client.MessageReceived += CommandsHandler;
            client.InteractionCreated += HandleButtonPress;
            //client.Log += window.Log;

            await client.LoginAsync(TokenType.Bot, key);
        }

        public async Task StartBot()
        {
            await client.StartAsync();
            botConnect = true;
        }

        public async Task StopBot()
        {
            await client.StopAsync();
            botConnect = false;
        }

        private async Task CommandsHandler(SocketMessage message)
        {
            if (message.Author.IsBot) return;

            switch (message.Content)
            {
                case "хай":
                    await message.Channel.SendMessageAsync($"Прив, {message.Author}");
                    break;
                case "!start":
                    await GetStartButtons(message);
                    break;
                default:
                    await message.Channel.SendMessageAsync($"Ты ввел что-то не то...");
                    break;
            }
        }

        private async Task HandleButtonPress(SocketInteraction interaction)
        {
            if (interaction is not SocketMessageComponent component) return;

            switch (component.Data.CustomId)
            {
                case "authYa":
                    break;
                default:
                    break;
            }
        }

        private async Task GetStartButtons(SocketMessage message)
        {
            string msg = "Добро пожаловать в urusaiBot!\nДля начала необходимо сгенерировать токен!\n";

            var button = new ButtonBuilder()
            {
                Label = "Сгенерировать токен",
                CustomId = "authYa",
                Style = ButtonStyle.Primary
            };

            var builder = new ComponentBuilder().WithButton(button);

            await message.Channel.SendMessageAsync(msg, components: builder.Build());
            return;
        }
    }
}
