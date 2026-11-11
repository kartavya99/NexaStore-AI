using NexaStore.Application.AI;
using System.Runtime.CompilerServices;

namespace NexaStore.Infrastructure.AI
{
    public sealed class DisabledNexaAssistantService : INextAssistantService
    {
        public async IAsyncEnumerable<string> StreamResponseAsync(IReadOnlyList<AssistantMessageDto> messages, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            cancellationToken.ThrowIfCancellationRequested();
            yield return "nexa AI is disabled in this enviornment";
                
        }
    }
}
