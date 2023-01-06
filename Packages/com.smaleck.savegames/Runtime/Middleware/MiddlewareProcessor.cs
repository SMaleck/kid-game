using System.Collections.Generic;
using System.Linq;

namespace Savegames.Middleware
{
    public class MiddlewareProcessor : IMiddlewareProcessor
    {
        private readonly IReadOnlyDictionary<ObjectMiddlewareStage, ISavegameObjectMiddleware[]> _objectMiddleware;
        private readonly IReadOnlyDictionary<SerializedMiddlewareStage, ISavegameSerializedMiddleware[]> _serializedMiddleware;

        public MiddlewareProcessor(
            IEnumerable<ISavegameObjectMiddleware> objectMiddleware,
            IEnumerable<ISavegameSerializedMiddleware> serializedMiddleware)
        {
            _objectMiddleware = objectMiddleware
                .GroupBy(e => e.Stage)
                .ToDictionary(g => g.Key, g => g.ToArray());

            _serializedMiddleware = serializedMiddleware
                .GroupBy(e => e.Stage)
                .ToDictionary(g => g.Key, g => g.ToArray());
        }

        public void RunMiddleware<T>(T savegame, ObjectMiddlewareStage stage)
        {
            if (!_objectMiddleware.TryGetValue(stage, out var middleware))
            {
                return;
            }

            foreach (var mw in middleware)
            {
                mw.Process(savegame);
            }
        }

        public string RunMiddleware(string serialized, SerializedMiddlewareStage stage)
        {
            if (!_serializedMiddleware.TryGetValue(stage, out var middleware))
            {
                return serialized;
            }

            foreach (var mw in middleware)
            {
                serialized = mw.Process(serialized);
            }

            return serialized;
        }
    }
}
