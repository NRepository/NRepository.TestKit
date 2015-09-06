namespace NRepository.TestKit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Flags]
    public enum EntityGeneratorOptions
    {
        None,
        IgnoreExceptions = 1,
        SetPrivateProperties = 2,
    }
}
