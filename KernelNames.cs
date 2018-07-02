using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nyxeka.ai
{

    public static class KernelNames
    {
		//names of functions
        public static string WeightValues = "NNAddWeights1024";
        public static string SumWeights = "NNSumWeights256";
        public static string CreateOutput = "NNCreateOutput";

		//names of buffers
		public static string VISION_IO_BUFFER = "Result";
		public static string WEIGHT_INPUT = "weightValues";
		public static string WEIGHTED_VALUE_HOLDER = "weightedValues";

		public static int stepA_X = 1;
		public static int stepA_Y = 4;
		public static int stepA_Z = 64;

		public static int stepB_X = 16;
		public static int stepB_Y = 64;
		public static int stepB_Z = 1;

		public static int stepC_X = 1;
		public static int stepC_Y = 1;
		public static int stepC_Z = 1;
        
    }

    public static class AITexSizes
    {
        public static int 
            INPUT_TEX_WIDTH = 32,
            OUTPUT_TEX_WIDTH = 32,
			WEIGHTED_VALUE_HOLDER_WIDTH = 256,
			WEIGHTED_VALUE_HOLDER_HEIGHT = 1024,
            AXON_TEX_WIDTH = 1024,
            STAT_INPUT_WIDTH = 8,
            STAT_INFLUENCE_WIDTH = 8,
            HORMONE_TEX_WIDTH = 8,
            MEMORY_TEX_WIDTH = 8192,
            NEW_THOUGHT_BUFFER = 2048;
    }
}
