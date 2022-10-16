using Grpc.Core;
using GrpcServiceExample;

public class AnimalsService : Animals.AnimalsBase
{
    private readonly ILogger<AnimalsService> _logger;
    public AnimalsService(ILogger<AnimalsService> logger)
    {
        _logger = logger;
    }

    public override Task<AnimalsReply> Get(AnimalsRequest req, ServerCallContext context)
    {
        var reply = new AnimalsReply();
        reply.Animals.AddRange(new List<string>()
        {
            "Elefante", "Canguro", "Gallo"
        });
        return Task.FromResult(reply);
    }
}