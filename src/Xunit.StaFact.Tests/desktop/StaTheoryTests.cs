﻿// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Ms-PL license. See LICENSE.txt file in the project root for full license information.

#if !NET45

using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class StaTheoryTests
{
    [StaTheory]
    [InlineData(0)]
    [InlineData(1)]
    public async Task StaTheory_OnSTAThread(int arg)
    {
        Assert.Null(SynchronizationContext.Current);
        Assert.Equal(ApartmentState.STA, Thread.CurrentThread.GetApartmentState());
        await Task.Yield();

        // Without a single-threaded SynchronizationContext, we won't come back to the STA thread.
        Assert.Null(SynchronizationContext.Current);
        Assert.Equal(ApartmentState.MTA, Thread.CurrentThread.GetApartmentState());

        Assert.True(arg == 0 || arg == 1);
    }

    [Trait("Category", "FailureExpected")]
    [StaTheory]
    [InlineData(0)]
    [InlineData(1)]
    public async Task StaTheoryFails(int arg)
    {
        Assert.Null(SynchronizationContext.Current);
        Assert.Equal(ApartmentState.STA, Thread.CurrentThread.GetApartmentState());
        await Task.Yield();

        // Without a single-threaded SynchronizationContext, we won't come back to the STA thread.
        Assert.Null(SynchronizationContext.Current);
        Assert.Equal(ApartmentState.MTA, Thread.CurrentThread.GetApartmentState());

        Assert.False(arg == 0 || arg == 1);
    }
}

#endif