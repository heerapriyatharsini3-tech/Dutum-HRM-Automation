using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Children)]
[assembly: LevelOfParallelism(4)]

namespace TestProject1
{
    internal class ParallelAssembly
    {
    }
}
