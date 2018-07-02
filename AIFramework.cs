using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nyxeka.ai
{
	


	public enum AIStep{
		addWeights,sumWeights,createOutput
	}

    public class AIFramework : MonoBehaviour
    {
        /// <summary>
        /// 32x32 visual input.
        /// </summary>
        public RenderTexture visionInput;
        /// <summary>
        /// visual processing results to be used with activation function.
        /// </summary>
        private Texture2D visionOutput;
        /// <summary>
        /// input weights for our processing.
        /// </summary>
        public Texture2D weights;
        /// <summary>
        /// weighted value processor.
        /// </summary>
        protected Texture2D weightedValues;

		//protected Color32[,] texture;

        public ComputeShader NNProcessor;

		Color32[] pixels;

		Color32 activatedStepA;
        
        // Use this for initialization
        void Start()
        {
            visionInput.enableRandomWrite = true;
			visionOutput = new Texture2D (AITexSizes.INPUT_TEX_WIDTH, AITexSizes.INPUT_TEX_WIDTH);
			weightedValues = new Texture2D (AITexSizes.WEIGHTED_VALUE_HOLDER_WIDTH, AITexSizes.WEIGHTED_VALUE_HOLDER_HEIGHT);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void RunProcess()
        {

        }

        void StopProcess() { }

        IEnumerator VisualProcessing()
		{
			// "weight" as a verb.
			int kernelWeightValues = NNProcessor.FindKernel (KernelNames.WeightValues);

			int kernelSumValues = NNProcessor.FindKernel (KernelNames.SumWeights);

			int kernelCreateOutput = NNProcessor.FindKernel (KernelNames.CreateOutput);

			int kernelVisProcess = NNProcessor.FindKernel ("NNProcessVisuals");

			ComputeBuffer buffer = new ComputeBuffer (1024, 16);
			
			pixels = visionOutput.GetPixels32();

			buffer.SetData (pixels);

			Color32[] output = new Color32[1024];
			/*
			while (true) {
			//	*/

				//start by doing a dispatch
				NNProcessor.SetTexture(kernelWeightValues,KernelNames.VISION_IO_BUFFER,visionInput);
				NNProcessor.SetBuffer(kernelVisProcess, "output", buffer);
				NNProcessor.Dispatch (kernelWeightValues, KernelNames.stepA_X, KernelNames.stepA_Y, KernelNames.stepA_Z);

				//------
				yield return null;
				//grab the information:
				
				buffer.GetData (output);

				visionOutput.SetPixels32 (output);

				visionOutput.Apply ();

				activatedStepA = visionOutput.GetPixels32 (5) [0];
				/*
			}
			// */
        }



    }
}
