using System;

namespace Rey.Mapping {
    public class MapToFailedException : Exception {
        public MapToFailedException(string message)
            : base(message) {
        }
    }
}
