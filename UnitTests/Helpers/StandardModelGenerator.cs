﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RaikesSimplexService.DataModel;
using RaikesSimplexService.Implementation;

namespace UnitTests.Helpers
{
    public static class StandardModelGenerator
    {
        public static StandardModel getSimpleStandardModel()
        {
            return StandardModel.FromModel(ModelGenerator.getSimpleModel());
        }

        public static StandardModel getImpossibleStandardModel()
        {
            return StandardModel.FromModel(ModelGenerator.getImpossibleModel());
        }
    }
}
