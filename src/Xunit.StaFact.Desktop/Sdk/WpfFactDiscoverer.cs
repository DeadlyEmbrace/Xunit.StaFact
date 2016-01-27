﻿// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Ms-PL license. See LICENSE.txt file in the project root for full license information.

namespace Xunit.Sdk
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Threading;
    using Abstractions;

    /// <summary>
    /// The discovery class for <see cref="WpfFactAttribute"/>
    /// </summary>
    public class WpfFactDiscoverer : FactDiscoverer
    {
        private readonly IMessageSink diagnosticMessageSink;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfFactDiscoverer"/> class.
        /// </summary>
        /// <param name="diagnosticMessageSink">The diagnostic message sink.</param>
        public WpfFactDiscoverer(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;
        }

        protected override IXunitTestCase CreateTestCase(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            return new UITestCase(UITestCase.SyncContextType.WPF, this.diagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), testMethod);
        }
    }
}