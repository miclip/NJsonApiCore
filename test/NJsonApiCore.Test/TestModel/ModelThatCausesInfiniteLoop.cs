﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJsonApi.Test.TestModel
{
    public class ModelThatCausesInfiniteLoop
    {
        public ModelThatCausesInfiniteLoop Child { get; set; }
    }
}
