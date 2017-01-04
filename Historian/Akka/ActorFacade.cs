using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Historian.Logging;

namespace Historian.Akka
{
    public abstract class ActorFacade
    {
        protected ILogger Logger { get; }
        protected ActorSystem ActorSystem { get; }

        protected ActorFacade(ActorSystem actorSystem, ILogger logger)
        {
            if (actorSystem == null) throw new ArgumentNullException(nameof(actorSystem));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            ActorSystem = actorSystem;
            Logger = logger;
        }

        protected void LogFailure(object answer)
        {
            if (answer is Failure)
            {
                var failure = answer as Failure;
                Logger.Msg(this, l => l.Error(failure.Exception));
            }
        }
    }
}
