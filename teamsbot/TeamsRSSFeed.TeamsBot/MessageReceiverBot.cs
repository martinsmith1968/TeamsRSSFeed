using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace RSSFeed.TeamsBot
{
    public class MessageReceiverBot : ActivityHandler
    {
        protected override Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            //turnContext.Activity.
            return base.OnMessageActivityAsync(turnContext, cancellationToken);
        }
    }
}
