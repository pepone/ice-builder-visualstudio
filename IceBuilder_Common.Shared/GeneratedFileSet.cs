﻿// Copyright (c) ZeroC, Inc. All rights reserved.

using System.Collections.Generic;

namespace IceBuilder
{
    public struct GeneratedFileSet
    {
        // Slice file name
        public string filename;

        // Each entry in this dictionary represents a generated source file and the list of configurations for which
        // it is build.
        public Dictionary<string, List<string>> sources;

        // Each entry in this dictionary represents a generated C++ header file and the list of configurations for
        // which it is build. It is always empty for non C++ projects.
        public Dictionary<string, List<string>> headers;
    }
}
