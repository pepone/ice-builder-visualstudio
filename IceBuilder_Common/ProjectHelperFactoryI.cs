// **********************************************************************
//
// Copyright (c) ZeroC, Inc. All rights reserved.
//
// **********************************************************************

namespace IceBuilder
{
    public class ProjectHelperFactoryI : IVsProjectHelperFactory
    {
        public IVCUtil VCUtil
        {
            get
            {
                return new VCUtilI();
            }
        }

        public INuGet NuGet
        {
            get
            {
                return new NuGetI();
            }
        }

        public IVsProjectHelper ProjectHelper
        {
            get
            {
                return new ProjectHelper();
            }
        }
    }
}
