﻿using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe struct PtrPtrPtr<T>
    : IEquatable<PtrPtrPtr<T>>
      where T : unmanaged
{
    private T** p;

    private PtrPtrPtr(T** p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals(object? other) => (other is PtrPtrPtr<T> p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PtrPtrPtr<T> other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr3) => ptr1.p == ptr3.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr3) => ptr1.p != ptr3.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return ((IntPtr)this.p).GetHashCode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtrPtr<T>(T** p) => UnsafePtr.As<T, PtrPtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtrPtr(PtrPtrPtr<T> ptr) => (void**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T**(PtrPtrPtr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void**(PtrPtrPtr<T> ptr) => (void**)ptr.p;
}
