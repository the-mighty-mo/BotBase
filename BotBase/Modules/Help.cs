using Discord;
using Discord.Interactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotBase.Modules
{
    public class Help : InteractionModuleBase<SocketInteractionContext>
    {
        private const string help =
            "ping\n" +
            "  - Returns the bot's Server and API latencies";

        [SlashCommand("help", "List of commands")]
        public Task HelpAsync()
        {
            EmbedBuilder embed = new EmbedBuilder()
                .WithColor(SecurityInfo.botColor)
                .WithTitle(SecurityInfo.botName);

            List<EmbedFieldBuilder> fields = new();

            EmbedFieldBuilder field = new EmbedFieldBuilder()
                .WithIsInline(true)
                .WithName("Commands")
                .WithValue(help);
            fields.Add(field);
            embed.WithFields(fields);

            return Context.Interaction.RespondAsync(embed: embed.Build(), ephemeral: true);
        }
    }
}