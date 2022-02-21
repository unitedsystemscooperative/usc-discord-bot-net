using System.Text;
using Discord;
using Discord.Interactions;

namespace UnitedSystemsCooperative.Bot.Modules.Commands;

[Group("edu", "Educational Information")]
public class EducationCommandModule : InteractionModuleBase<SocketInteractionContext>
{
    private const string INFORMATION_SENT = "Information sent to user.";

    [SlashCommand("combat-logging", "What is combat logging?")]
    public async Task EducateOnCombatLogging(IUser? user = null)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Combat Logging is improperly exiting gameplay (via menu, alt+F4, pulling a plug, etc) while in combat.");
        stringBuilder.AppendLine("FDev is very strict on this and it can result in a ban.");
        stringBuilder.AppendLine("While FDev does not consider logging to menu as 'Combat Logging', the Elite: Dangerous community does.");
        stringBuilder.AppendLine("Combat Logging is against the rules of USC and can result in a kick or ban.");

        var embedBuilder = new EmbedBuilder()
            .WithTitle("What is Combat Logging (clogging)?")
            .WithDescription(stringBuilder.ToString());

        if (user != null)
        {
            await user.SendMessageAsync(embed: embedBuilder.Build());
            await RespondAsync(INFORMATION_SENT, ephemeral: true);

        }
        else
        {
            await RespondAsync(embed: embedBuilder.Build());
        }
    }

    [Group("engineering", "Engineering things")]
    public class EngineeringSubcommandModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("fox-guide", "Fox's Guide to unlock engineers")]
        public async Task EducateOnFoxGuide(IUser? user = null)
        {
            string message = "Find Fox's Guide to unlocking engineers: https://www.reddit.com/r/EliteDangerous/comments/merpky/foxs_comprehensive_guide_to_engineer_unlocking/";
            if (user != null)
            {
                await user.SendMessageAsync(message);
                await RespondAsync(INFORMATION_SENT, ephemeral: true);
            }
            else
                await RespondAsync(message);
        }

        [SlashCommand("inara", "Engineer list on Inara")]
        public async Task EducateOnInaraEngineers(IUser? user = null)
        {
            string message = "Find where and what each engineer does at: https://inara.cz/galaxy-engineers/";
            if (user != null)
            {
                await user.SendMessageAsync(message);
                await RespondAsync(INFORMATION_SENT, ephemeral: true);
            }
            else
                await RespondAsync(message);
        }
    }

    [SlashCommand("fsd-booster", "Link to Exegious' video on how to unlock the Guardian FSD Booster")]
    public async Task EducateOnFsdBoosterUnlock(IUser? user = null)
    {
        string message = "Here's how to unlock the guardian fsd booster: https://youtu.be/J9C9a00-rkQ";
        if (user != null)
        {
            await user.SendMessageAsync(message);
            await RespondAsync(INFORMATION_SENT, ephemeral: true);
        }
        else
            await RespondAsync(message);
    }

    [SlashCommand("neutron", "How to use Neutron Highway")]
    public async Task EducateOnSuperCharging(
        [Summary(description: "Choose what you'd like to know about the Neutron Highway")]
        [Choice("Image Tutorial", "img")]
        [Choice("Spansh's Website", "spansh")]
        string option,
        IUser? user = null)
    {
        string message;
        switch (option)
        {
            case "img":
                message = "https://i.imgur.com/gg6n5VM.jpg";
                break;
            case "spansh":
                message = "Plot neutron highway routes online here: https://www.spansh.co.uk/plotter";
                break;
            default:
                await RespondAsync($"The {option} does not exist", ephemeral: true);
                return;
        }

        if (user != null)
        {
            await user.SendMessageAsync(message);
            await RespondAsync(INFORMATION_SENT, ephemeral: true);
        }
        else
            await RespondAsync(message);
    }

    [SlashCommand("promotions", "How do I get promoted in the squad?")]
    public async Task EducateOnSquadPromotions(IUser? user = null)
    {
        var embed = new EmbedBuilder()
            .WithTitle("How do I get promoted?")
            .AddField("Ensign", "You must have spent at least one week in squad and you've joined the squad in-game and in Discord")
            .AddField("Lieutenant", "Ensign requirements + You've joined the Inara squad and have a good understanding of the game/engineers")
            .AddField("Lt. Commander", "Lieutenant + joined the mentorship mission on Inara and have been approved by High Command")
            .AddField("Captain +", "Selected from the Lt. Cmdrs and offered the role of High Command")
            .Build();

        if (user != null)
        {
            await user.SendMessageAsync(embed: embed);
            await RespondAsync(INFORMATION_SENT, ephemeral: true);
        }
        else
            await RespondAsync(embed: embed);

    }

    [SlashCommand("ranks", "What are the Pilot's Federation or Navy Ranks?")]
    public async Task EducateOnRanks(
        [Summary(description:"Rank to see")]
        [Choice("Combat - Ship Only", "combat")]
        [Choice("Combat - Ship Only", "combat")]
        [Choice("Combat - Ship Only", "combat")]
        [Choice("Combat - Ship Only", "combat")]
        [Choice("Combat - Ship Only", "combat")]
        [Choice("Combat - Ship Only", "combat")]
        [Choice("Combat - Ship Only", "combat")]
        [Choice("Combat - Ship Only", "combat")]
        string rankSet,
        IUser? user = null
    )
    {

    }

    [SlashCommand("scoopable", "What stars can I scooop?")]
    public async Task EducateOnKgbFoam(IUser? user = null)
    {

    }

    [SlashCommand("websites", "Gives a list of 3rd party websites")]
    public async Task EducateOn3rdPartySites(IUser? user = null)
    {

    }
}
